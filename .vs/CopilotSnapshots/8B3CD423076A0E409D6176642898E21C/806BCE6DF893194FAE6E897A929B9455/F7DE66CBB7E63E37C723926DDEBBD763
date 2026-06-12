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
    public partial class UCQLSV : UserControl
    {
        databaseDataContext db = new databaseDataContext();
        public UCQLSV()
        {
            InitializeComponent();
        }

        private void UCQLSV_Load(object sender, EventArgs e)
        {
            dgv_DSSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<tbl_sinhvien> dSSV = db.tbl_sinhviens.ToList();
            dgv_DSSV.DataSource = dSSV;
            LoadLopHoc(sender, e);

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string mSSV = txtMSSV.Text;
            string hoten = txtHoTen.Text;
            string gioitinh = cboGioiTinh.Text;
            string dateTime = dtpNgaySinh.Value.ToString("yyyy-MM-dd");

            tbl_sinhvien sinhvien = new tbl_sinhvien();
            sinhvien.id = mSSV;
            sinhvien.hoten = hoten;
            sinhvien.gioitinh = gioitinh;
            sinhvien.ngaysinh = DateTime.Parse(dateTime);
            sinhvien.malop = cboMaLop.SelectedValue.ToString();

            try
            {
                db.tbl_sinhviens.InsertOnSubmit(sinhvien);
                db.SubmitChanges();
                MessageBox.Show("Thêm sinh viên thành công!");
                UCQLSV_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadLopHoc(object sender, EventArgs e)
        {
            List<tbl_lophoc> dslh = db.tbl_lophocs.ToList();
            cboMaLop.DataSource = dslh;
            cboMaLop.DisplayMember = "tenlop";
            cboMaLop.ValueMember = "malop";

        }
    }
}
