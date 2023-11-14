namespace FindJuniorVacancy
{
    partial class Form1
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
            btn_FindJobs = new Button();
            btn_ShowJobs = new Button();
            SuspendLayout();
            // 
            // btn_FindJobs
            // 
            btn_FindJobs.Location = new Point(99, 104);
            btn_FindJobs.Name = "btn_FindJobs";
            btn_FindJobs.Size = new Size(427, 131);
            btn_FindJobs.TabIndex = 0;
            btn_FindJobs.Text = "Find Jobs";
            btn_FindJobs.UseVisualStyleBackColor = true;
            btn_FindJobs.Click += btn_FindJobs_Click;
            // 
            // btn_ShowJobs
            // 
            btn_ShowJobs.Location = new Point(99, 291);
            btn_ShowJobs.Name = "btn_ShowJobs";
            btn_ShowJobs.Size = new Size(427, 131);
            btn_ShowJobs.TabIndex = 1;
            btn_ShowJobs.Text = "Show Jobs";
            btn_ShowJobs.UseVisualStyleBackColor = true;
            btn_ShowJobs.Click += btn_ShowJobs_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 543);
            Controls.Add(btn_ShowJobs);
            Controls.Add(btn_FindJobs);
            Name = "Form1";
            Text = "JobFinder";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_FindJobs;
        private Button btn_ShowJobs;
    }
}