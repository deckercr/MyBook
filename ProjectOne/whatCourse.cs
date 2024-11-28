using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

/*Mario Tehandon / Course CISS 311 / Advanced Agile Development / 11.19.2024 / Course Project
This section of the project allows the user to enter a Student's Id number
The program will then pull all the courses that that student is in and list them in the list box.
It will also display the name of the student in the text box.*/

namespace ProjectOne

{

    public partial class whatCourse : Form

    {

        private readonly DatabaseManager dbManager;

        public whatCourse(DatabaseManager dbManager)

        {

            InitializeComponent();
            this.dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));

            //sets up event handlers  this is mostly due to the seperation of project parts

            this.Load += new EventHandler(whatCourse_Load);
            button1.Click += new EventHandler(FindButton_Click);
            button2.Click += new EventHandler(CloseButton_Click);
            textBox1.KeyPress += new KeyPressEventHandler(StudentID_KeyPress);

            //ensures form is blank

            ClearForm();

        }

        private void whatCourse_Load(object sender, EventArgs e)

        {

            //Initialize form

            ClearForm();

        }

        //main event handler for this form...uses text information to pull student information from DB and displays name and info in listbox
        private void FindButton_Click(object sender, EventArgs e)

        {

            string studentId = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(studentId))

            {

                MessageBox.Show("Please enter a Student ID", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            try

            {

                using var connection = dbManager.GetConnection();

                //get the student name

                using (var command = connection.CreateCommand())

                {

                    command.CommandText = "SELECT StudentName FROM Students WHERE StudentID = @studentId";
                    command.Parameters.AddWithValue("@studentId", studentId);

                    var studentName = command.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(studentName))

                    {

                        MessageBox.Show("Student ID not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        return;

                    }

                    textBox2.Text = studentName;

                }

                //get all courses the student is enrolled in

                using (var command = connection.CreateCommand())

                {

                    command.CommandText = @"
                        SELECT 
                            c.CourseID,
                            c.CourseTitle,
                            c.SemesterOffered,
                            sc.EnrollmentStatus,
                            sc.EnrollmentDate
                        FROM Courses c
                        JOIN StudentCourses sc ON c.CourseID = sc.CourseID
                        WHERE sc.StudentID = @studentId
                        ORDER BY c.CourseTitle";

                    command.Parameters.AddWithValue("@studentId", studentId);

                    courseListBox.Items.Clear();

                    using var reader = command.ExecuteReader();

                    while (reader.Read())

                    {

                        string courseInfo = $"Course: {reader["CourseTitle"]} | " +
                                          $"Semester: {reader["SemesterOffered"]} | " +
                                          $"Status: {reader["EnrollmentStatus"]} | " +
                                          $"Enrolled: {Convert.ToDateTime(reader["EnrollmentDate"]).ToShortDateString()}";

                        courseListBox.Items.Add(courseInfo);

                    }

                    if (courseListBox.Items.Count == 0)

                    {

                        courseListBox.Items.Add("No courses found for this student");

                    }

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show($"Error retrieving student courses: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //allows user to activate find event without button press
        private void StudentID_KeyPress(object sender, KeyPressEventArgs e)

        {

            //Enter key event

            if (e.KeyChar == (char)Keys.Enter)

            {

                e.Handled = true;
                FindButton_Click(sender, e);

            }

        }

        private void CloseButton_Click(object sender, EventArgs e)

        {

            Close();

        }

        private void ClearForm()

        {

            textBox1.Clear();
            textBox2.Clear();
            courseListBox.Items.Clear();

        }

    }

}