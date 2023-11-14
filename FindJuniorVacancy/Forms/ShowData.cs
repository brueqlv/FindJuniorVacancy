using FindJuniorVacancy.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindJuniorVacancy.Forms
{
    public partial class ShowData : Form
    {
        public ShowData()
        {
            InitializeComponent();
        }

        private void ShowData_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            List<Job> jobs = form1.ScrapData();
            dgv_ShowData.DataSource = jobs;
        }
    }
}
