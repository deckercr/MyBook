namespace ProjectOne
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            addStudentButton = new Button();
            allStudentsButton = new Button();
            button2 = new Button();
            whatCoursesButton = new Button();
            addCourseButton = new Button();
            displayAllCoursesButton = new Button();
            whoInCourseButton = new Button();
            exitButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(148, 37);
            label1.Name = "label1";
            label1.Size = new Size(140, 32);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(299, 83);
            label2.Name = "label2";
            label2.Size = new Size(497, 45);
            label2.TabIndex = 3;
            label2.Text = "College Course Tracking System";
            // 
            // addStudentButton
            // 
            addStudentButton.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addStudentButton.Location = new Point(254, 161);
            addStudentButton.Name = "addStudentButton";
            addStudentButton.Size = new Size(217, 52);
            addStudentButton.TabIndex = 4;
            addStudentButton.Text = "Add a Student";
            addStudentButton.UseVisualStyleBackColor = true;
            addStudentButton.Click += addStudentButton_Click;
            // 
            // allStudentsButton
            // 
            allStudentsButton.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            allStudentsButton.Location = new Point(254, 219);
            allStudentsButton.Name = "allStudentsButton";
            allStudentsButton.Size = new Size(217, 86);
            allStudentsButton.TabIndex = 5;
            allStudentsButton.Text = "Display All Students";
            allStudentsButton.UseVisualStyleBackColor = true;
            allStudentsButton.Click += allStudentsButton_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(254, 311);
            button2.Name = "button2";
            button2.Size = new Size(217, 92);
            button2.TabIndex = 6;
            button2.Text = "Enroll a Student In a Course";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // whatCoursesButton
            // 
            whatCoursesButton.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            whatCoursesButton.Location = new Point(254, 409);
            whatCoursesButton.Name = "whatCoursesButton";
            whatCoursesButton.Size = new Size(217, 84);
            whatCoursesButton.TabIndex = 7;
            whatCoursesButton.Text = "What Courses a Student Enrolled In";
            whatCoursesButton.UseVisualStyleBackColor = true;
            whatCoursesButton.Click += whatCoursesButton_Click;
            // 
            // addCourseButton
            // 
            addCourseButton.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addCourseButton.Location = new Point(633, 161);
            addCourseButton.Name = "addCourseButton";
            addCourseButton.Size = new Size(196, 52);
            addCourseButton.TabIndex = 8;
            addCourseButton.Text = "Add a Course";
            addCourseButton.UseVisualStyleBackColor = true;
            addCourseButton.Click += addCourseButton_Click;
            // 
            // displayAllCoursesButton
            // 
            displayAllCoursesButton.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            displayAllCoursesButton.Location = new Point(633, 219);
            displayAllCoursesButton.Name = "displayAllCoursesButton";
            displayAllCoursesButton.Size = new Size(196, 86);
            displayAllCoursesButton.TabIndex = 9;
            displayAllCoursesButton.Text = "Display All Courses";
            displayAllCoursesButton.UseVisualStyleBackColor = true;
            displayAllCoursesButton.Click += displayAllCoursesButton_Click;
            // 
            // whoInCourseButton
            // 
            whoInCourseButton.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            whoInCourseButton.Location = new Point(633, 311);
            whoInCourseButton.Name = "whoInCourseButton";
            whoInCourseButton.Size = new Size(196, 92);
            whoInCourseButton.TabIndex = 10;
            whoInCourseButton.Text = "Who Is In a Course";
            whoInCourseButton.UseVisualStyleBackColor = true;
            whoInCourseButton.Click += whoInCourseButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.Location = new Point(633, 409);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(196, 84);
            exitButton.TabIndex = 11;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 528);
            Controls.Add(exitButton);
            Controls.Add(whoInCourseButton);
            Controls.Add(displayAllCoursesButton);
            Controls.Add(addCourseButton);
            Controls.Add(whatCoursesButton);
            Controls.Add(button2);
            Controls.Add(allStudentsButton);
            Controls.Add(addStudentButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "mainForm";
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Button addStudentButton;
        private Button allStudentsButton;
        private Button button2;
        private Button whatCoursesButton;
        private Button addCourseButton;
        private Button displayAllCoursesButton;
        private Button whoInCourseButton;
        private Button exitButton;
    }
}
