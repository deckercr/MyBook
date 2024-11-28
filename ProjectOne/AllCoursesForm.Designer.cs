// Uploaded by Katelyn Holt for assistance

namespace ProjectOne
{
    partial class AllCoursesForm
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
            AllCourseslistBox = new ListBox();
            CloseButton = new Button();
            SuspendLayout();
            // 
            // AllCourseslistBox
            // 
            AllCourseslistBox.FormattingEnabled = true;
            AllCourseslistBox.ItemHeight = 25;
            AllCourseslistBox.Location = new Point(66, 99);
            AllCourseslistBox.Name = "AllStudentslistBox";
            AllCourseslistBox.Size = new Size(641, 304);
            AllCourseslistBox.TabIndex = 0;
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseButton.Location = new Point(324, 445);
            CloseButton.Name = "button1";
            CloseButton.Size = new Size(171, 55);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // AllCoursesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 537);
            Controls.Add(CloseButton);
            Controls.Add(AllCourseslistBox);
            Name = "AllCoursesForm";
            Text = "All Courses";
            Load += AllCoursesForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox AllCourseslistBox;
        private Button CloseButton;
    }
}