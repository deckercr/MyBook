namespace ProjectOne
{
    partial class AllStudentsForm
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
            AllStudentslistBox = new ListBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // AllStudentslistBox
            // 
            AllStudentslistBox.FormattingEnabled = true;
            AllStudentslistBox.ItemHeight = 25;
            AllStudentslistBox.Location = new Point(66, 99);
            AllStudentslistBox.Name = "AllStudentslistBox";
            AllStudentslistBox.Size = new Size(641, 304);
            AllStudentslistBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(324, 445);
            button1.Name = "button1";
            button1.Size = new Size(171, 55);
            button1.TabIndex = 1;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(66, 57);
            label1.Name = "label1";
            label1.Size = new Size(117, 28);
            label1.TabIndex = 2;
            label1.Text = "Student ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(238, 57);
            label2.Name = "label2";
            label2.Size = new Size(152, 28);
            label2.TabIndex = 3;
            label2.Text = "Student Name";
            // 
            // AllStudentsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 537);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(AllStudentslistBox);
            Name = "AllStudentsForm";
            Text = "All Students";
            Load += AllStudentsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox AllStudentslistBox;
        private Button button1;
        private Label label1;
        private Label label2;
    }
}