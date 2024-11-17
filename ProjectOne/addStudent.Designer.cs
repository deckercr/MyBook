namespace ProjectOne
{
    partial class addStudent
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
            label1 = new Label();
            label2 = new Label();
            addstudenttextBox = new TextBox();
            addstudentButton = new Button();
            closeButton = new Button();
            statusStrip1 = new StatusStrip();
            feedbackToolStripStatusLabel = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(160, 25);
            label1.TabIndex = 0;
            label1.Text = "Enter Student Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 129);
            label2.Name = "label2";
            label2.Size = new Size(202, 28);
            label2.TabIndex = 1;
            label2.Text = "New Student Name";
            // 
            // addstudenttextBox
            // 
            addstudenttextBox.Location = new Point(254, 129);
            addstudenttextBox.Name = "addstudenttextBox";
            addstudenttextBox.Size = new Size(479, 31);
            addstudenttextBox.TabIndex = 2;
            // 
            // addstudentButton
            // 
            addstudentButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addstudentButton.Location = new Point(30, 276);
            addstudentButton.Name = "addstudentButton";
            addstudentButton.Size = new Size(169, 56);
            addstudentButton.TabIndex = 3;
            addstudentButton.Text = "Add Student";
            addstudentButton.UseVisualStyleBackColor = true;
            addstudentButton.Click += addstudentButton_Click;
            // 
            // closeButton
            // 
            closeButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            closeButton.Location = new Point(601, 276);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(169, 56);
            closeButton.TabIndex = 4;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { feedbackToolStripStatusLabel });
            statusStrip1.Location = new Point(0, 356);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 32);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // feedbackToolStripStatusLabel
            // 
            feedbackToolStripStatusLabel.Name = "feedbackToolStripStatusLabel";
            feedbackToolStripStatusLabel.Size = new Size(179, 25);
            feedbackToolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // addStudent
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 388);
            Controls.Add(statusStrip1);
            Controls.Add(closeButton);
            Controls.Add(addstudentButton);
            Controls.Add(addstudenttextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "addStudent";
            Text = "Add a Student";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox addstudenttextBox;
        private Button addstudentButton;
        private Button closeButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel feedbackToolStripStatusLabel;
    }
}