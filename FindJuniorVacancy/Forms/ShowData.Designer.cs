namespace FindJuniorVacancy.Forms
{
    partial class ShowData
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
            dgv_ShowData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_ShowData).BeginInit();
            SuspendLayout();
            // 
            // dgv_ShowData
            // 
            dgv_ShowData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ShowData.Location = new Point(7, 7);
            dgv_ShowData.Name = "dgv_ShowData";
            dgv_ShowData.RowHeadersWidth = 82;
            dgv_ShowData.RowTemplate.Height = 41;
            dgv_ShowData.Size = new Size(1428, 622);
            dgv_ShowData.TabIndex = 0;
            dgv_ShowData.CellContentClick += dgv_ShowData_CellContentClick;
            // 
            // ShowData
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1447, 735);
            Controls.Add(dgv_ShowData);
            Name = "ShowData";
            Text = "ShowData";
            Load += ShowData_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_ShowData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_ShowData;
    }
}