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
    public partial class AllStudentsForm : Form
    {
        public AllStudentsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AllStudentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Clear existing items in case this event fires multiple times
                AllStudentslistBox.Items.Clear();

                // Call the GetAllStudents method from your DatabaseManager
                var students = new DatabaseManager().GetAllStudents();

                // Add students to the ListBox
                foreach (var student in students)
                {
                    AllStudentslistBox.Items.Add($"{student.StudentID}   -   {student.StudentName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
