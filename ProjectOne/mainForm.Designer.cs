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
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
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
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(254, 409);
            button3.Name = "button3";
            button3.Size = new Size(217, 84);
            button3.TabIndex = 7;
            button3.Text = "What Courses a Student Enrolled In";
            button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(633, 161);
            button5.Name = "button5";
            button5.Size = new Size(196, 52);
            button5.TabIndex = 8;
            button5.Text = "Add a Course";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(633, 219);
            button6.Name = "button6";
            button6.Size = new Size(196, 86);
            button6.TabIndex = 9;
            button6.Text = "Display All Courses";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(633, 311);
            button7.Name = "button7";
            button7.Size = new Size(196, 92);
            button7.TabIndex = 10;
            button7.Text = "Who Is In a Course";
            button7.UseVisualStyleBackColor = true;
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
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
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
        private Button button3;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button exitButton;
    }
}
