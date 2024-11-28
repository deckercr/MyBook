namespace ProjectOne
{
    partial class whoCourse
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
            button1 = new Button();
            button2 = new Button();
            studentListBox = new ListBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            courseTitleComboBox = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(708, 43);
            button1.Name = "button1";
            button1.Size = new Size(141, 63);
            button1.TabIndex = 0;
            button1.Text = "&FIND";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(393, 503);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Cl&ose";
            button2.UseVisualStyleBackColor = true;
            // 
            // studentListBox
            // 
            studentListBox.FormattingEnabled = true;
            studentListBox.Location = new Point(48, 291);
            studentListBox.Name = "studentListBox";
            studentListBox.Size = new Size(801, 204);
            studentListBox.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10F);
            textBox2.Location = new Point(365, 166);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(484, 30);
            textBox2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 5;
            label1.Text = "Course Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(48, 79);
            label2.Name = "label2";
            label2.Size = new Size(150, 23);
            label2.TabIndex = 6;
            label2.Text = "Selected a Course:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(48, 166);
            label3.Name = "label3";
            label3.Size = new Size(104, 23);
            label3.TabIndex = 7;
            label3.Text = "Course Title:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 250);
            label4.Name = "label4";
            label4.Size = new Size(245, 20);
            label4.TabIndex = 8;
            label4.Text = "All Students Enrolled in This Course:";
            // 
            // courseTitleComboBox
            // 
            courseTitleComboBox.Font = new Font("Segoe UI", 10F);
            courseTitleComboBox.FormattingEnabled = true;
            courseTitleComboBox.Location = new Point(365, 79);
            courseTitleComboBox.Name = "courseTitleComboBox";
            courseTitleComboBox.Size = new Size(321, 31);
            courseTitleComboBox.TabIndex = 9;
            // 
            // whoCourse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 579);
            Controls.Add(courseTitleComboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(studentListBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "whoCourse";
            Text = "Who Is In a Course";
            Load += whoCourse_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private ListBox studentListBox;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox courseTitleComboBox;
    }
}