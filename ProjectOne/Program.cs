using System;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ProjectOne
{
    internal class Program
    {
        // Connection string for SQL Server Express LocalDB
        private static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CollegeDB;Integrated Security=true;";

        // Path to the SQL script file
        private static string sqlScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CreateCollegeDB.sql");

        [STAThread]
        static void Main()
        {
            // Enable visual styles for the application
            Application.EnableVisualStyles();
            // Set the default text rendering mode for compatibility
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Create the database and associated tables if they don't exist
                CreateDatabase(); 
                // Display a success message to the user
                MessageBox.Show("Database setup completed successfully.", "Success");

                // Start the main application logic
                RunApplication(); 
            }
            catch (Exception ex)
            {
                // Display an error message to the user if any exception occurs during database setup
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CreateDatabase()
        {
            // Establish a connection to the SQL Server instance
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection to the SQL Server
                connection.Open();

                // Check if the CollegeDB database already exists
                if (!DatabaseExists("CollegeDB", connection))
                {
                    // Create the CollegeDB database if it doesn't exist
                    string createDatabaseQuery = "CREATE DATABASE CollegeDB";
                    using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
                    {
                        // Execute the command to create the database
                        command.ExecuteNonQuery();
                    }
                }

                // Switch the connection context to the CollegeDB database
                string useDatabaseQuery = "USE CollegeDB";
                using (SqlCommand command = new SqlCommand(useDatabaseQuery, connection))
                {
                    // Execute the command to switch to the CollegeDB database
                    command.ExecuteNonQuery();
                }

                // Execute the SQL script to create tables if they don't exist
                ExecuteScriptIfTablesNotExist(connection); 
            }
        }

        private static void ExecuteScriptIfTablesNotExist(SqlConnection connection)
        {
            // Read the SQL script from the file
            string script = File.ReadAllText(sqlScriptPath);

            // Split the script into individual commands based on "GO" delimiter
            string[] commandStrings = script.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate through each command in the script
            foreach (string commandString in commandStrings)
            {
                // Check if the command is not empty and is a CREATE TABLE command
                if (!string.IsNullOrWhiteSpace(commandString) && IsCreateTableCommand(commandString))
                {
                    // Extract the table name from the CREATE TABLE command
                    string tableName = GetTableNameFromCreateCommand(commandString);

                    // Check if the table already exists in the database
                    if (!TableExists(tableName, connection))
                    {
                        // Create the table if it doesn't exist
                        using (SqlCommand command = new SqlCommand(commandString, connection))
                        {
                            try
                            {
                                // Execute the command to create the table
                                command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Display an error message if an exception occurs during table creation
                                MessageBox.Show($"Error executing SQL command: {commandString}\nError: {ex.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                // Re-throw the exception to propagate the error
                                throw;
                            }
                        }
                    }
                }
            }
        }

        private static bool DatabaseExists(string databaseName, SqlConnection connection)
        {
            // Check if the database with the specified name exists
            string checkDatabaseQuery = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{databaseName}'";
            using (SqlCommand command = new SqlCommand(checkDatabaseQuery, connection))
            {
                // Execute the query and get the count of matching databases
                int count = (int)command.ExecuteScalar();
                // Return true if the database exists, false otherwise
                return count > 0;
            }
        }

        private static bool TableExists(string tableName, SqlConnection connection)
        {
            // Check if the table with the specified name exists
            string checkTableQuery = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{tableName}'";
            using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
            {
                // Execute the query and get the count of matching tables
                int count = (int)command.ExecuteScalar();
                // Return true if the table exists, false otherwise
                return count > 0;
            }
        }

        private static bool IsCreateTableCommand(string commandString)
        {
            // Check if the command string starts with "CREATE TABLE" (case-insensitive)
            return commandString.TrimStart().StartsWith("CREATE TABLE", StringComparison.OrdinalIgnoreCase);
        }

        private static string GetTableNameFromCreateCommand(string createTableCommand)
        {
            // Extract the table name from the CREATE TABLE command
            string[] tokens = createTableCommand.Split(new[] { ' ', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            int tableIndex = Array.FindIndex(tokens, t => t.Equals("TABLE", StringComparison.OrdinalIgnoreCase));
            // Return the table name if found, otherwise return null
            return (tableIndex >= 0 && tableIndex < tokens.Length - 1) ? tokens[tableIndex + 1] : null;
        }

        private static void RunApplication()
        {
            try
            {
                // Establish a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();
                    // Display a message indicating successful connection
                    MessageBox.Show("Connected to database successfully!", "Database Connection");

                    // Count the number of students in the database
                    string countQuery = "SELECT COUNT(*) AS StudentCount From Students";
                    using (SqlCommand command = new SqlCommand(countQuery, connection))
                    {
                        // Execute the query and get the student count
                        int studentCount = (int)command.ExecuteScalar();
                        // Display the student count to the user
                        MessageBox.Show($"Current number of students in database: {studentCount}", "Student Count");
                    }

                    // Run the main application form
                    Application.Run(new Form1());  // This will load your main form
                }
            }
            catch (SqlException ex)
            {
                // Display an error message if a SQL exception occurs during database connection or operation
                MessageBox.Show($"Error connecting to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
