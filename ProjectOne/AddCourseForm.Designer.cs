// Katelyn Holt
// CISS 311, Advanced Agile, C# Champions Final Project, Project 1

namespace ProjectOne
{
    public partial class AddCourseForm : Form
    {
        List<Course> courses = new List<Course>();

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            newCourseDataLabel = new Label();
            courseTitleLabel = new Label();
            semesterOfferedLabel = new Label();
            courseTitleTextBox = new TextBox();
            semesterOfferedTextBox = new TextBox();
            saveButton = new Button();
            clearButton = new Button();
            closeButton = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // newCourseDataLabel
            // 
            newCourseDataLabel.AutoSize = true;
            newCourseDataLabel.Location = new Point(39, 9);
            newCourseDataLabel.Name = "newCourseDataLabel";
            newCourseDataLabel.Size = new Size(124, 20);
            newCourseDataLabel.TabIndex = 0;
            newCourseDataLabel.Text = "New Course Data";
            // 
            // courseTitleLabel
            // 
            courseTitleLabel.AutoSize = true;
            courseTitleLabel.Location = new Point(65, 34);
            courseTitleLabel.Name = "courseTitleLabel";
            courseTitleLabel.Size = new Size(94, 20);
            courseTitleLabel.TabIndex = 0;
            courseTitleLabel.Text = "Course Title: ";
            // 
            // semesterOfferedLabel
            // 
            semesterOfferedLabel.AutoSize = true;
            semesterOfferedLabel.Location = new Point(27, 92);
            semesterOfferedLabel.Name = "semesterOfferedLabel";
            semesterOfferedLabel.Size = new Size(132, 20);
            semesterOfferedLabel.TabIndex = 0;
            semesterOfferedLabel.Text = "Semester Offered: ";
            // 
            // courseTitleTextBox
            // 
            courseTitleTextBox.Location = new Point(207, 34);
            courseTitleTextBox.Name = "courseTitleTextBox";
            courseTitleTextBox.Size = new Size(361, 27);
            courseTitleTextBox.TabIndex = 2;
            courseTitleTextBox.Text = "Course Title";
            // 
            // semesterOfferedTextBox
            // 
            semesterOfferedTextBox.Location = new Point(207, 89);
            semesterOfferedTextBox.Name = "semesterOfferedTextBox";
            semesterOfferedTextBox.Size = new Size(361, 27);
            semesterOfferedTextBox.TabIndex = 3;
            semesterOfferedTextBox.Text = "Semester Offered";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(69, 239);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 4;
            saveButton.Text = "&Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(274, 239);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(94, 29);
            clearButton.TabIndex = 5;
            clearButton.Text = "&Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(500, 239);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(94, 29);
            closeButton.TabIndex = 6;
            closeButton.Text = "C&lose";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(courseTitleLabel);
            panel1.Controls.Add(semesterOfferedLabel);
            panel1.Controls.Add(semesterOfferedTextBox);
            panel1.Controls.Add(courseTitleTextBox);
            panel1.Location = new Point(26, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(620, 159);
            panel1.TabIndex = 0;
            // 
            // AddCourseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 307);
            Controls.Add(closeButton);
            Controls.Add(newCourseDataLabel);
            Controls.Add(clearButton);
            Controls.Add(saveButton);
            Controls.Add(panel1);
            Name = "AddCourseForm";
            Text = "Add a New Course";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label newCourseDataLabel;
        private Label courseTitleLabel;
        private Label semesterOfferedLabel;
        private TextBox courseTitleTextBox;
        private TextBox semesterOfferedTextBox;
        private Button saveButton;
        private Button clearButton;
        private Button closeButton;
        private Panel panel1;
    }
}