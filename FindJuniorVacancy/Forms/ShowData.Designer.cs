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
            txt_FilterName = new TextBox();
            btn_Filter = new Button();
            btn_submit = new Button();
            btn_LoadAll = new Button();
            btn_LoadFavorites = new Button();
            btn_DeleteFromFavorites = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_ShowData).BeginInit();
            SuspendLayout();
            // 
            // dgv_ShowData
            // 
            dgv_ShowData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_ShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_ShowData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ShowData.Location = new Point(-2, 118);
            dgv_ShowData.Name = "dgv_ShowData";
            dgv_ShowData.RowHeadersWidth = 82;
            dgv_ShowData.RowTemplate.Height = 41;
            dgv_ShowData.Size = new Size(1428, 605);
            dgv_ShowData.TabIndex = 0;
            // 
            // txt_FilterName
            // 
            txt_FilterName.Location = new Point(300, 12);
            txt_FilterName.Name = "txt_FilterName";
            txt_FilterName.Size = new Size(361, 39);
            txt_FilterName.TabIndex = 1;
            // 
            // btn_Filter
            // 
            btn_Filter.Location = new Point(300, 57);
            btn_Filter.Name = "btn_Filter";
            btn_Filter.Size = new Size(361, 55);
            btn_Filter.TabIndex = 2;
            btn_Filter.Text = "Filter";
            btn_Filter.UseVisualStyleBackColor = true;
            btn_Filter.Click += btn_Filter_Click;
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(935, 12);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(269, 46);
            btn_submit.TabIndex = 3;
            btn_submit.Text = "Save To Favorites";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_submit_Click;
            // 
            // btn_LoadAll
            // 
            btn_LoadAll.Location = new Point(12, 12);
            btn_LoadAll.Name = "btn_LoadAll";
            btn_LoadAll.Size = new Size(264, 100);
            btn_LoadAll.TabIndex = 4;
            btn_LoadAll.Text = "Load All Jobs";
            btn_LoadAll.UseVisualStyleBackColor = true;
            btn_LoadAll.Click += btn_LoadAll_Click;
            // 
            // btn_LoadFavorites
            // 
            btn_LoadFavorites.Location = new Point(679, 12);
            btn_LoadFavorites.Name = "btn_LoadFavorites";
            btn_LoadFavorites.Size = new Size(250, 100);
            btn_LoadFavorites.TabIndex = 5;
            btn_LoadFavorites.Text = "Load Favorites";
            btn_LoadFavorites.UseVisualStyleBackColor = true;
            btn_LoadFavorites.Click += btn_LoadFavorites_Click;
            // 
            // btn_DeleteFromFavorites
            // 
            btn_DeleteFromFavorites.Location = new Point(935, 60);
            btn_DeleteFromFavorites.Name = "btn_DeleteFromFavorites";
            btn_DeleteFromFavorites.Size = new Size(265, 48);
            btn_DeleteFromFavorites.TabIndex = 6;
            btn_DeleteFromFavorites.Text = "Delete From Favorites";
            btn_DeleteFromFavorites.UseVisualStyleBackColor = true;
            btn_DeleteFromFavorites.Click += btn_DeleteFromFavorites_Click;
            // 
            // ShowData
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1447, 735);
            Controls.Add(btn_DeleteFromFavorites);
            Controls.Add(btn_LoadFavorites);
            Controls.Add(btn_LoadAll);
            Controls.Add(btn_submit);
            Controls.Add(btn_Filter);
            Controls.Add(txt_FilterName);
            Controls.Add(dgv_ShowData);
            Name = "ShowData";
            Text = "ShowData";
            Load += ShowData_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_ShowData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_ShowData;
        private TextBox txt_FilterName;
        private Button btn_Filter;
        private Button btn_submit;
        private Button btn_LoadAll;
        private Button btn_LoadFavorites;
        private Button btn_DeleteFromFavorites;
    }
}