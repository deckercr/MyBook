using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace ProjectOne
{
    // Represents a student with an ID and name.
    public class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }

        // Constructor for the Student class.
        public Student(string id, string name)
        {
            StudentID = id;
            StudentName = name;
        }
    }

    // Represents a course with an ID, title, and semester offered.
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string SemesterOffered { get; set; }

        // Constructor for the Course class.
        public Course(int id, string title, string semester)
        {
            CourseID = id;
            CourseTitle = title;
            SemesterOffered = semester;
        }
    }

    // Manages the connection and operations related to the SQLite database.
    public class DatabaseManager : IDisposable
    {
        // Connection string for the SQLite database.
        private readonly string sqliteConnectionString;
        // Path to the SQL script used to create the database.
        private readonly string sqlScriptPath;
        // Path to the SQLite database file.
        private readonly string dbPath;
        // Stores the current SQLite connection.
        private SqliteConnection? currentConnection;

        // Constructor for the DatabaseManager class. Initializes connection details and paths.
        public DatabaseManager()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CollegeDB.db");
            sqliteConnectionString = $"Data Source={dbPath}";
            sqlScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CreateCollegeDB.sql");
            System.Diagnostics.Debug.WriteLine($"Database Path: {dbPath}");
            System.Diagnostics.Debug.WriteLine($"SQL Script Path: {sqlScriptPath}");
        }

        // Initializes the database, creating it if it doesn't exist and validating its schema.
        public bool Initialize()
        {
            // Initializes the database, ensuring it exists and has the correct schema.
            // Returns true if initialization is successful, false otherwise.
            try
            {
                // First, verify SQL script file exists
                if (!File.Exists(sqlScriptPath))
                {
                    System.Diagnostics.Debug.WriteLine($"SQL script not found at: {sqlScriptPath}");
                    MessageBox.Show($"SQL script file not found at:\n{sqlScriptPath}",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Check if database file exists
                bool dbExists = File.Exists(dbPath);
                System.Diagnostics.Debug.WriteLine($"Database file exists: {dbExists} at path: {dbPath}");

                using (var connection = new SqliteConnection(sqliteConnectionString))
                {
                    connection.Open();
                    System.Diagnostics.Debug.WriteLine("Database connection opened successfully");

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "PRAGMA foreign_keys = ON;";
                        command.ExecuteNonQuery();
                    }

                    // If database doesn't exist, create it using the SQL script
                    if (!dbExists)
                    {
                        System.Diagnostics.Debug.WriteLine("Creating new database...");
                        CreateDatabase();
                    }

                    // Verify that the expected tables and columns exist in the database
                    if (!ValidateDatabaseSchema(connection))
                    {
                        System.Diagnostics.Debug.WriteLine("Database schema validation failed");
                        // If validation fails and db file exists, consider backing up and recreating
                        if (dbExists)
                        {
                            string backupPath = dbPath + ".backup";
                            File.Copy(dbPath, backupPath, true);
                            File.Delete(dbPath);
                            System.Diagnostics.Debug.WriteLine($"Backed up corrupt database to {backupPath} and recreating...");
                            CreateDatabase();

                            // Verify again after recreation
                            if (!ValidateDatabaseSchema(connection))
                            {
                                MessageBox.Show("Failed to create database schema even after recreation. Check SQL script for errors.",
                                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // Perform an additional verification: check if there are any students in the database
                    // This helps confirm that the database was created correctly and potentially has sample data.
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT COUNT(*) FROM Students";
                        try
                        {
                            int studentCount = Convert.ToInt32(command.ExecuteScalar());
                            System.Diagnostics.Debug.WriteLine($"Found {studentCount} students in database");
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error checking student count: {ex.Message}");
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (SqliteException ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQLite Error: {ex.Message}\nErrorCode: {ex.ErrorCode}");
                MessageBox.Show($"Database initialization failed:\n\nError: {ex.Message}\n\nCheck debug output for details.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unexpected Error: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Unexpected error during database initialization:\n\n{ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidateDatabaseSchema(SqliteConnection connection)
        {
            // Validates the database schema against expected tables and columns.
            // Returns true if the schema is valid, false otherwise.
            try
            {
                var expectedTables = new HashSet<string> { "Students", "Courses", "StudentCourses" };
                var expectedColumns = new Dictionary<string, HashSet<string>>
                {
                    { "Students", new HashSet<string> { "StudentID", "StudentName" } },
                    { "Courses", new HashSet<string> { "CourseID", "CourseTitle", "SemesterOffered" } },
                    { "StudentCourses", new HashSet<string> { "StudentID", "CourseID", "EnrollmentStatus", "EnrollmentDate" } }
                };

                // Check if all expected tables exist in the database
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table';";
                    using var reader = command.ExecuteReader();
                    var existingTables = new HashSet<string>();
                    while (reader.Read())
                    {
                        existingTables.Add(reader.GetString(0));
                    }

                    if (!expectedTables.IsSubsetOf(existingTables))
                    {
                        System.Diagnostics.Debug.WriteLine("Missing tables detected");
                        return false;
                    }
                }

                // Check if all expected columns exist in each table
                foreach (var table in expectedTables)
                {
                    using var command = connection.CreateCommand();
                    command.CommandText = $"PRAGMA table_info({table});";
                    using var reader = command.ExecuteReader();
                    var existingColumns = new HashSet<string>();
                    while (reader.Read())
                    {
                        existingColumns.Add(reader.GetString(1)); // Column name is at index 1
                    }

                    if (!expectedColumns[table].IsSubsetOf(existingColumns))
                    {
                        System.Diagnostics.Debug.WriteLine($"Missing columns in table {table}");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error validating schema: {ex.Message}");
                return false;
            }
        }

        private void CreateDatabase()
        {
            // Creates the database using the SQL script specified in sqlScriptPath.
            try
            {
                // Load the SQL script from the file.
                string script = File.ReadAllText(sqlScriptPath);
                System.Diagnostics.Debug.WriteLine("SQL Script loaded successfully");

                // Clean up the script by removing comments and empty lines.
                script = Regex.Replace(script, @"--[^\n]*", ""); // Remove comments
                script = Regex.Replace(script, @"^\s*$\n|\r", "", RegexOptions.Multiline); // Remove empty lines

                // Split the script into individual SQL statements.
                var statements = script.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(s => s.Trim())
                                    .Where(s => !string.IsNullOrWhiteSpace(s))
                                    .ToList();

                System.Diagnostics.Debug.WriteLine($"Found {statements.Count} SQL statements to execute");

                // Open a connection to the SQLite database.
                using (var connection = new SqliteConnection(sqliteConnectionString))
                {
                    connection.Open();
                    // Begin a transaction to ensure atomicity of database creation.
                    using var transaction = connection.BeginTransaction();
                    try
                    {
                        // Execute each SQL statement within the transaction.
                        foreach (var statement in statements)
                        {
                            using var command = connection.CreateCommand();
                            command.Transaction = transaction;
                            command.CommandText = statement;
                            command.ExecuteNonQuery();
                            System.Diagnostics.Debug.WriteLine($"Executed SQL statement successfully: {statement.Substring(0, Math.Min(50, statement.Length))}...");
                        }

                        // Commit the transaction if all statements executed successfully.
                        transaction.Commit();
                        System.Diagnostics.Debug.WriteLine("Database creation completed successfully");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error executing SQL script: {ex.Message}");
                        // Rollback the transaction if any error occurred during execution.
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating database: {ex.Message}");
                throw;
            }
        }

        // Gets a connection to the SQLite database.
        public SqliteConnection GetConnection()
        {
            // If a connection already exists and is open, return it.
            if (currentConnection != null && currentConnection.State == ConnectionState.Open)
            {
                return currentConnection;
            }

            // Dispose of the existing connection if it exists.
            currentConnection?.Dispose();
            // Create a new connection and open it.
            currentConnection = new SqliteConnection(sqliteConnectionString);
            currentConnection.Open();

            // Enable foreign key constraints for the connection.
            using (var command = currentConnection.CreateCommand())
            {
                command.CommandText = "PRAGMA foreign_keys = ON;";
                command.ExecuteNonQuery();
            }

            // Return the open connection.
            return currentConnection;
        }

        // Adds a new student to the Students table.
        public bool AddStudent(string studentName)
        {
            try
            {
                // Get a connection to the database.
                using var connection = GetConnection();
                // Begin a transaction to ensure atomicity of the insert operation.
                using var transaction = connection.BeginTransaction();
                // Get the current date in YYYYMMDD format for use in the student ID.
                var currentDate = DateTime.Now.ToString("yyyyMMdd");

                int lastNumber;
                string newStudentId;

                // Get the last student ID number for the current date.
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = @"
                        SELECT COALESCE(
                            MAX(CAST(SUBSTR(StudentID, -5) AS INTEGER)), 0
                        )
                        FROM Students 
                        WHERE StudentID LIKE @studentIdPrefix";

                    command.Parameters.AddWithValue("@studentIdPrefix", $"STU{currentDate}%");
                    lastNumber = Convert.ToInt32(command.ExecuteScalar());
                }

                // Generate the next student ID.
                var nextNumber = (lastNumber + 1).ToString("D5");
                newStudentId = $"STU{currentDate}{nextNumber}";

                // Insert the new student into the Students table.
                using (var insertCommand = connection.CreateCommand())
                {
                    insertCommand.Transaction = transaction;
                    insertCommand.CommandText = @"
                        INSERT INTO Students (StudentID, StudentName) 
                        VALUES (@studentId, @name)";

                    insertCommand.Parameters.AddWithValue("@studentId", newStudentId);
                    insertCommand.Parameters.AddWithValue("@name", studentName);

                    // Check if the insert operation was successful.
                    var result = insertCommand.ExecuteNonQuery() > 0;
                    transaction.Commit();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding student: {ex.Message}");
                return false;
            }
        }

        // Retrieves all students from the Students table.
        public List<Student> GetAllStudents()
        {
            // Create a list to store the retrieved students.
            var students = new List<Student>();
            try
            {
                // Get a connection to the database.
                using var connection = GetConnection();
                // Create a command to retrieve all students.
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT StudentID, StudentName FROM Students ORDER BY StudentName";

                // Execute the command and retrieve the results.
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student(
                        reader.GetString(0),
                        reader.GetString(1)
                    ));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error retrieving students: {ex.Message}");
            }
            return students;
        }

        // Retrieves all courses from the Courses table.
        public List<Course> GetAllCourses()
        {
            // Create a list to store the retrieved courses.
            var courses = new List<Course>();
            try
            {
                // Get a connection to the database.
                using var connection = GetConnection();
                // Create a command to retrieve all courses.
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT CourseID, CourseTitle, SemesterOffered FROM Courses ORDER BY CourseTitle";

                // Execute the command and retrieve the results.
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add(new Course(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2)
                    ));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error retrieving courses: {ex.Message}");
            }
            return courses;
        }

        // Enrolls a student in a course.
        public bool EnrollStudent(string studentId, int courseId)
        {
            try
            {
                // Get a connection to the database.
                using var connection = GetConnection();
                // Begin a transaction to ensure atomicity of the enrollment operation.
                using var transaction = connection.BeginTransaction();

                // First check if enrollment already exists.
                using (var checkCommand = connection.CreateCommand())
                {
                    checkCommand.Transaction = transaction;
                    checkCommand.CommandText = @"
                        SELECT COUNT(*) 
                        FROM StudentCourses 
                        WHERE StudentID = @studentId 
                        AND CourseID = @courseId";

                    checkCommand.Parameters.AddWithValue("@studentId", studentId);
                    checkCommand.Parameters.AddWithValue("@courseId", courseId);

                    // If the student is already enrolled, return false.
                    if (Convert.ToInt32(checkCommand.ExecuteScalar()) > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("Student already enrolled in this course");
                        return false;
                    }
                }

                // Insert the new enrollment into the StudentCourses table.
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = @"
                        INSERT INTO StudentCourses (StudentID, CourseID, EnrollmentStatus) 
                        VALUES (@studentId, @courseId, 'InProgress')";

                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@courseId", courseId);

                    // Check if the insert operation was successful.
                    var result = command.ExecuteNonQuery() > 0;
                    transaction.Commit();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error enrolling student: {ex.Message}");
                return false;
            }
        }

        // Disposes of the current database connection.
        public void Dispose()
        {
            // Close and dispose of the connection if it's open.
            if (currentConnection != null)
            {
                if (currentConnection.State == ConnectionState.Open)
                {
                    currentConnection.Close();
                }
                currentConnection.Dispose();
                currentConnection = null;
            }
        }
    }
}
