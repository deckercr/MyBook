using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOne
{
    public partial class addStudent : Form
    {
        private readonly DatabaseManager _databaseManager; // Declare an instance of DatabaseManager
        public addStudent()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager(); // Initialize the DatabaseManager instance
        }

        private void addstudentButton_Click(object sender, EventArgs e)
        {
            // Get the student name from the text box
            string studentName = addstudenttextBox.Text.Trim();

            if (string.IsNullOrEmpty(studentName))
            {
                MessageBox.Show("Please enter a student name.");
                return;
            }

            // Call the AddStudent method from the repository
            bool isAdded = _databaseManager.AddStudent(studentName);

            // Provide feedback based on whether the operation was successful
            if (isAdded)
            {
                MessageBox.Show("Student added successfully!");
                addstudenttextBox.Clear();
            }
            else
            {
                MessageBox.Show("Failed to add student. Please try again.");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
