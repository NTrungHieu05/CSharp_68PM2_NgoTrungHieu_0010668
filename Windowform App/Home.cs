using System;
using System.Windows.Forms;

namespace Windowform_App
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();


            var uc = new UCQLSV();

            uc.Dock = DockStyle.Fill;

            pn_home.Controls.Clear();
            pn_home.Controls.Add(uc);
        }

        public void LoadUserControl(UserControl userControl)
        {
            if (userControl == null) return;

           
            pn_home.Controls.Clear();

          
            userControl.Dock = DockStyle.Fill;

          
            pn_home.Controls.Add(userControl);

            
            userControl.BringToFront();
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCQLSV uCQLSV = new UCQLSV();

            pn_home.Controls.Clear();

            uCQLSV.Dock = DockStyle.Fill;

            pn_home.Controls.Add(uCQLSV);
        }


        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCQLLH uCQLLH = new UCQLLH();

            pn_home.Controls.Clear();

            uCQLLH.Dock = DockStyle.Fill;

            pn_home.Controls.Add(uCQLLH);
        }
    }
}