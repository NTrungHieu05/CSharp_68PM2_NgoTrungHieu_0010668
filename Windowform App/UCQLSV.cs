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
        string mssvDangChon = "";
        public UCQLSV()
        {
            InitializeComponent();
            dgv_DSSV.CellClick += dgv_DSSV_CellContentClick;
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
            string mSSV = txtMSSV.Text.Trim();
            string hoten = txtHoTen.Text.Trim();
            string gioitinh = cboGioiTinh.Text.Trim();
            var malop = cboMaLop.SelectedValue;
            DateTime ngaysinh = dtpNgaySinh.Value.Date;

            if (string.IsNullOrEmpty(mSSV))
            {
                MessageBox.Show("Mã sinh viên không được để trống.");
                txtMSSV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(hoten))
            {
                MessageBox.Show("Họ tên không được để trống.");
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrEmpty(gioitinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                cboGioiTinh.Focus();
                return;
            }
            if (malop == null)
            {
                MessageBox.Show("Vui lòng chọn lớp.");
                cboMaLop.Focus();
                return;
            }
            if (ngaysinh > DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại.");
                dtpNgaySinh.Focus();
                return;
            }

            // Check duplicate MSSV
            var exists = db.tbl_sinhviens.Any(s => s.id == mSSV);
            if (exists)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại.");
                txtMSSV.Focus();
                return;
            }

            tbl_sinhvien sinhvien = new tbl_sinhvien();
            sinhvien.id = mSSV;
            sinhvien.hoten = hoten;
            sinhvien.gioitinh = gioitinh;
            sinhvien.ngaysinh = ngaysinh;
            sinhvien.malop = malop.ToString();

            try
            {
                db.tbl_sinhviens.InsertOnSubmit(sinhvien);
                db.SubmitChanges();
                MessageBox.Show("Thêm sinh viên thành công!");
                dgv_DSSV.DataSource = db.tbl_sinhviens.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void LoadLopHoc(object sender, EventArgs e)
        {
            List<tbl_lophoc> dslh = db.tbl_lophocs.ToList();
            cboMaLop.DataSource = dslh;
            cboMaLop.DisplayMember = "tenlop";
            cboMaLop.ValueMember = "malop";

        }

        private void dgv_DSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgv_DSSV.Rows[e.RowIndex];

            mssvDangChon = row.Cells["id"].Value.ToString();

            txtMSSV.Text = row.Cells["id"].Value.ToString();
            txtHoTen.Text = row.Cells["hoten"].Value.ToString();

            cboGioiTinh.Text = row.Cells["gioitinh"].Value.ToString();

            dtpNgaySinh.Value =
                Convert.ToDateTime(row.Cells["ngaysinh"].Value);

            cboMaLop.SelectedValue =
                row.Cells["malop"].Value.ToString();
        }

        

        
    }
}
