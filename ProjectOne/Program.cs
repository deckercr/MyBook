using System;
using System.Windows.Forms;

namespace ProjectOne
{
    internal class Program
    {
        // Entry point of the application.
        [STAThread]
        static void Main()
        {
            // Enables visual styles for the application.
            Application.EnableVisualStyles();
            // Sets the default text rendering mode to use the system's settings.
            Application.SetCompatibleTextRenderingDefault(false);

            // Wrap the database initialization and form launch in a try-catch block to handle potential errors.
            try
            {
                // Create an instance of the DatabaseManager class using a using statement to ensure proper disposal.
                using (var dbManager = new DatabaseManager())
                {
                    // Initialize the database.
                    if (dbManager.Initialize())
                    {
                        // Create the main form (Form1) and pass the initialized DatabaseManager instance.
                        // Application.Run starts the message loop and runs the application.
                        Application.Run(new mainForm(dbManager)); 
                    }
                    else
                    {
                        // Display an error message box if the database initialization fails.
                        MessageBox.Show("Failed to initialize database. Application will now exit.",
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message box if any exception occurs during the process.
                MessageBox.Show($"An error occurred: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}