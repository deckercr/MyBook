namespace ProjectOne
{
    partial class whatCourse
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            courseListBox = new ListBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(800, 94);
            button1.Name = "button1";
            button1.Size = new Size(141, 63);
            button1.TabIndex = 1;
            button1.Text = "&FIND";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(480, 552);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "Cl&ose";
            button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 265);
            label4.Name = "label4";
            label4.Size = new Size(184, 20);
            label4.TabIndex = 12;
            label4.Text = "All Course by This Student:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 181);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 11;
            label3.Text = "Student Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 94);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 10;
            label2.Text = "Student ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 25);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 9;
            label1.Text = "Student Data";
            // 
            // courseListBox
            // 
            courseListBox.FormattingEnabled = true;
            courseListBox.Location = new Point(91, 319);
            courseListBox.Name = "courseListBox";
            courseListBox.Size = new Size(850, 204);
            courseListBox.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(457, 181);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(484, 27);
            textBox2.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(290, 94);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(396, 27);
            textBox1.TabIndex = 14;
            // 
            // whatCourse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 627);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(courseListBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "whatCourse";
            Text = "What Courses a Student Enrolled";
            Load += whatCourse_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ListBox courseListBox;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}