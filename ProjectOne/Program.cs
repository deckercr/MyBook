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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                CreateDatabase();
                MessageBox.Show("Database setup completed successfully.", "Success");

                // Your main application logic starts here
                RunApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CreateDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the database already exists
                if (!DatabaseExists("CollegeDB", connection))
                {
                    // Create the database if it does not exist
                    string createDatabaseQuery = "CREATE DATABASE CollegeDB";
                    using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                // Switch to the CollegeDB database context
                string useDatabaseQuery = "USE CollegeDB";
                using (SqlCommand command = new SqlCommand(useDatabaseQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Read and execute SQL script for table creation only if tables do not already exist
                ExecuteScriptIfTablesNotExist(connection);
            }
        }

        private static void ExecuteScriptIfTablesNotExist(SqlConnection connection)
        {
            // Read the SQL script
            string script = File.ReadAllText(sqlScriptPath);

            // Check each table creation command in the script to see if the table exists
            string[] commandStrings = script.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string commandString in commandStrings)
            {
                if (!string.IsNullOrWhiteSpace(commandString) && IsCreateTableCommand(commandString))
                {
                    string tableName = GetTableNameFromCreateCommand(commandString);

                    if (!TableExists(tableName, connection))
                    {
                        using (SqlCommand command = new SqlCommand(commandString, connection))
                        {
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error executing SQL command: {commandString}\nError: {ex.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                throw;
                            }
                        }
                    }
                }
            }
        }

        private static bool DatabaseExists(string databaseName, SqlConnection connection)
        {
            string checkDatabaseQuery = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{databaseName}'";
            using (SqlCommand command = new SqlCommand(checkDatabaseQuery, connection))
            {
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private static bool TableExists(string tableName, SqlConnection connection)
        {
            string checkTableQuery = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{tableName}'";
            using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
            {
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private static bool IsCreateTableCommand(string commandString)
        {
            // Check if the command string contains "CREATE TABLE"
            return commandString.TrimStart().StartsWith("CREATE TABLE", StringComparison.OrdinalIgnoreCase);
        }

        private static string GetTableNameFromCreateCommand(string createTableCommand)
        {
            // Extracts the table name from a CREATE TABLE command
            string[] tokens = createTableCommand.Split(new[] { ' ', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            int tableIndex = Array.FindIndex(tokens, t => t.Equals("TABLE", StringComparison.OrdinalIgnoreCase));
            return (tableIndex >= 0 && tableIndex < tokens.Length - 1) ? tokens[tableIndex + 1] : null;
        }

        private static void RunApplication()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Connected to database successfully!", "Database Connection");

                    // Count number of students
                    string countQuery = "SELECT COUNT(*) AS StudentCount From Students";
                    using (SqlCommand command = new SqlCommand(countQuery, connection))
                    {
                        int studentCount = (int)command.ExecuteScalar();
                        MessageBox.Show($"Current number of students in database: {studentCount}", "Student Count");
                    }

                    // Show Form1 after the database operations are done
                    Application.Run(new Form1());  // This will load your main form
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
