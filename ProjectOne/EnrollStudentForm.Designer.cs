namespace ProjectOne
{
    partial class EnrollStudentForm
    {
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
            EnrollButton = new Button();
            CloseButton = new Button();
            SelectStudentDropdown = new ComboBox();
            SelectCourseDropdown = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // EnrollButton
            // 
            EnrollButton.Location = new Point(266, 414);
            EnrollButton.Margin = new Padding(4);
            EnrollButton.Name = "EnrollButton";
            EnrollButton.Size = new Size(109, 50);
            EnrollButton.TabIndex = 0;
            EnrollButton.Text = "&Enroll";
            EnrollButton.UseVisualStyleBackColor = true;
            EnrollButton.Click += EnrollButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(634, 414);
            CloseButton.Margin = new Padding(4);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(106, 50);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "Cl&ose";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // SelectStudentDropdown
            // 
            SelectStudentDropdown.FormattingEnabled = true;
            SelectStudentDropdown.Location = new Point(467, 104);
            SelectStudentDropdown.Margin = new Padding(4);
            SelectStudentDropdown.Name = "SelectStudentDropdown";
            SelectStudentDropdown.Size = new Size(317, 33);
            SelectStudentDropdown.TabIndex = 4;
            SelectStudentDropdown.SelectedIndexChanged += SelectStudentDropdown_SelectedIndexChanged;
            // 
            // SelectCourseDropdown
            // 
            SelectCourseDropdown.FormattingEnabled = true;
            SelectCourseDropdown.Location = new Point(467, 254);
            SelectCourseDropdown.Margin = new Padding(4);
            SelectCourseDropdown.Name = "SelectCourseDropdown";
            SelectCourseDropdown.Size = new Size(317, 33);
            SelectCourseDropdown.TabIndex = 5;
            SelectCourseDropdown.SelectedIndexChanged += SelectCourseDropdown_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(183, 101);
            label1.Name = "label1";
            label1.Size = new Size(202, 32);
            label1.TabIndex = 6;
            label1.Text = "Select a Student";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(195, 251);
            label2.Name = "label2";
            label2.Size = new Size(190, 32);
            label2.TabIndex = 7;
            label2.Text = "Select a Course";
            // 
            // EnrollStudentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 592);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SelectCourseDropdown);
            Controls.Add(SelectStudentDropdown);
            Controls.Add(CloseButton);
            Controls.Add(EnrollButton);
            Margin = new Padding(4);
            Name = "EnrollStudentForm";
            Text = "EnrollStudentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EnrollButton;
        private Button CloseButton;
        private ComboBox SelectStudentDropdown;
        private ComboBox SelectCourseDropdown;
        private Label label1;
        private Label label2;
    }
}