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
    public partial class EnrollStudentForm : Form
{
    private readonly DatabaseManager _databaseManager;

    public EnrollStudentForm()
    {
        InitializeComponent();
        _databaseManager = new DatabaseManager();

        // Load students and courses when the form loads
        LoadStudents();
        LoadCourses();
    }

    private void LoadStudents()
    {
        try
        {
            var students = _databaseManager.GetAllStudents();
            
            // Clear existing items
            SelectStudentDropdown.Items.Clear();
            
            // Populate dropdown with student names
            foreach (var student in students)
            {
                SelectStudentDropdown.Items.Add(new { 
                    Text = student.StudentName, 
                    Value = student.StudentID 
                });
            }

            // Set the display and value members
            SelectStudentDropdown.DisplayMember = "Text";
            SelectStudentDropdown.ValueMember = "Value";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadCourses()
    {
        try
        {
            var courses = _databaseManager.GetAllCourses();
            
            // Clear existing items
            SelectCourseDropdown.Items.Clear();
            
            // Populate dropdown with course titles
            foreach (var course in courses)
            {
                SelectCourseDropdown.Items.Add(new { 
                    Text = $"{course.CourseTitle} ({course.SemesterOffered})", 
                    Value = course.CourseID 
                });
            }

            // Set the display and value members
            SelectCourseDropdown.DisplayMember = "Text";
            SelectCourseDropdown.ValueMember = "Value";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SelectStudentDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Optional: Additional actions when a student is selected
        if (SelectStudentDropdown.SelectedItem != null)
        {
            var selectedStudent = SelectStudentDropdown.SelectedItem;
            // You can access the student ID and name if needed
        }
    }

    private void SelectCourseDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Optional: Additional actions when a course is selected
        if (SelectCourseDropdown.SelectedItem != null)
        {
            var selectedCourse = SelectCourseDropdown.SelectedItem;
            // You can access the course ID and details if needed
        }
    }

        private void EnrollButton_Click(object sender, EventArgs e)
        {
            // Check if both student and course are selected
            if (SelectStudentDropdown.SelectedItem == null || SelectCourseDropdown.SelectedItem == null)
            {
                MessageBox.Show("Please select both a student and a course.", "Enrollment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected student and course IDs
            string studentId = ((dynamic)SelectStudentDropdown.SelectedItem).Value;
            string courseId = ((dynamic)SelectCourseDropdown.SelectedItem).Value;

            // Attempt to enroll the student
            bool enrollmentSuccessful = _databaseManager.EnrollStudent(studentId, courseId);

            if (enrollmentSuccessful)
            {
                MessageBox.Show("Student enrolled successfully!", "Enrollment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to enroll student. The student may already be enrolled in this course.", "Enrollment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
    {
        Close();
    }
}
}
