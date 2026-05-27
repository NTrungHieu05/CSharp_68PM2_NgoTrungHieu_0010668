using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windowform_App
{
    public partial class UCQLLH : UserControl
    {
        databaseDataContext db = new databaseDataContext();
        public UCQLLH()
        {
            InitializeComponent();
        }

        private void UCQLLH_Load(object sender, EventArgs e)
        {
            dgv_DSLH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<tbl_lophoc> dSSV = db.tbl_lophocs.ToList();
            dgv_DSLH.DataSource = dSSV;
        }
    }
}
