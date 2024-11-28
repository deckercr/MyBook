using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

/*Mario Tehandon / Course CISS 311 / Advanced Agile Development / 11.19.2024 / Course Project
This section of the project allows the user to selected a course from the dropdown menu
The program will then pull all the students that are in that course and list them in the list box.
It will also display the name of the course in the text box.*/

namespace ProjectOne

{

    public partial class whoCourse : Form

    {

        private readonly DatabaseManager dbManager;

        //initialize database information and if not present throws exception
        public whoCourse(DatabaseManager dbManager)

        {

            InitializeComponent();
            this.dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));

            //handle all events in form

            this.Load += new EventHandler(whoCourse_Load);
            button1.Click += new EventHandler(FindButton_Click);
            button2.Click += new EventHandler(CloseButton_Click);

            //clears information

            ClearForm();

        }

        private void whoCourse_Load(object sender, EventArgs e)

        {

            //puts all courses into the combobox

            ClearForm();
            PopulateCoursesComboBox();

        }

        private void PopulateCoursesComboBox()

        {

            try

            {

                using var connection = dbManager.GetConnection();
                using var command = connection.CreateCommand();

                //ordered titles

                command.CommandText = @"
                    SELECT CourseID, CourseTitle, SemesterOffered 
                    FROM Courses 
                    ORDER BY CourseTitle";

                using var reader = command.ExecuteReader();
                courseTitleComboBox.Items.Clear();

                //creates class to store course information

                while (reader.Read())

                {

                    var courseItem = new CourseItem

                    {

                        CourseID = reader["CourseID"].ToString(),
                        CourseTitle = reader["CourseTitle"].ToString(),
                        SemesterOffered = reader["SemesterOffered"].ToString()

                    };

                    //format "Course Title - Semester"

                    courseTitleComboBox.Items.Add(courseItem);

                }

                //sets default combobox text

                if (courseTitleComboBox.Items.Count > 0)

                {

                    courseTitleComboBox.SelectedIndex = -1;
                    courseTitleComboBox.Text = "Select a Course";

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show($"Error loading courses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //find button functions when a course is selected and button is clicked
        private void FindButton_Click(object sender, EventArgs e)

        {

            if (courseTitleComboBox.SelectedItem == null)

            {

                MessageBox.Show("Please select a course", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            var selectedCourse = (CourseItem)courseTitleComboBox.SelectedItem;

            try

            {

                using var connection = dbManager.GetConnection();

                //shows current selected course title in textbox

                textBox2.Text = $"{selectedCourse.CourseTitle} - {selectedCourse.SemesterOffered}";

                //pulls all students information who are in selected course

                using var command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT 
                        s.StudentID,
                        s.StudentName,
                        sc.EnrollmentStatus,
                        sc.EnrollmentDate
                    FROM Students s
                    JOIN StudentCourses sc ON s.StudentID = sc.StudentID
                    WHERE sc.CourseID = @courseId
                    ORDER BY s.StudentName";

                command.Parameters.AddWithValue("@courseId", selectedCourse.CourseID);
                studentListBox.Items.Clear();

                using var reader = command.ExecuteReader();

                while (reader.Read())

                {

                    string studentInfo = $"ID: {reader["StudentID"]} | " +
                                       $"Name: {reader["StudentName"]} | " +
                                       $"Status: {reader["EnrollmentStatus"]} | " +
                                       $"Enrolled: {Convert.ToDateTime(reader["EnrollmentDate"]).ToShortDateString()}";
                    studentListBox.Items.Add(studentInfo);

                }

                //display text if no students are in selected course

                if (studentListBox.Items.Count == 0)

                {

                    studentListBox.Items.Add("No students enrolled in this course");

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show($"Error retrieving course students: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void CloseButton_Click(object sender, EventArgs e)

        {

            Close();

        }

        private void ClearForm()

        {

            courseTitleComboBox.SelectedIndex = -1;
            textBox2.Clear();
            studentListBox.Items.Clear();

        }

    }

    //stores course information for ease of access from database
    public class CourseItem

    {
        public string CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string SemesterOffered { get; set; }

        public override string ToString()

        {

            return $"{CourseTitle} - {SemesterOffered}";

        }

    }

}