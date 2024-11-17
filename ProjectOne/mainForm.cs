using System;
using System.Windows.Forms;
using System.Data.Common;

namespace ProjectOne
{
    // Represents the main form of the application (Form1).
    public partial class mainForm : Form
    {
        // Stores an instance of the DatabaseManager for database operations.
        private readonly DatabaseManager dbManager;

        // Constructor for Form1, initializes components and receives the DatabaseManager instance.
        public mainForm(DatabaseManager dbManager)
        {
            InitializeComponent();
            // Throws an exception if the provided dbManager is null.
            this.dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        // Overrides the OnLoad event to execute code when the form loads.
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Wraps database operations in a try-catch block to handle potential exceptions.
            try
            {
                // Gets a database connection using the DatabaseManager.
                using (var connection = dbManager.GetConnection())
                {
                    // Example: Executes a SQL query to count the number of students.
                    using (var command = connection.CreateCommand())
                    {
                        // Sets the SQL command text to count students from the 'Students' table.
                        command.CommandText = "SELECT COUNT(*) FROM Students";
                        // Executes the command and retrieves the result (student count).
                        int studentCount = Convert.ToInt32(command.ExecuteScalar());
                        // Displays a message box showing the current student count.
                        MessageBox.Show($"Current number of students in database: {studentCount}",
                            "Student Count");
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays an error message box if an exception occurs during database access.
                MessageBox.Show($"Error accessing database: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the button3_Click event.
        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of the StudentForm
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the addStudent form
            addStudent studentForm = new addStudent();

            // Show the form as a modal dialog
            studentForm.ShowDialog(); // Use Show() if you want a non-modal window
        }

        private void allStudentsButton_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Create an instance of AllStudentsForm
                    AllStudentsForm allStudentsForm = new AllStudentsForm();

                    // Show the form (non-modal)
                    allStudentsForm.Show();

                    // Alternatively, if you want the form to be modal (blocking interaction with the parent form)
                    // allStudentsForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., issues opening the form)
                    MessageBox.Show($"Error opening All Students form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}