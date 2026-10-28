using Microsoft.EntityFrameworkCore;
using NguyenPhamDinhMan_6551071052_VP103_LTTQ.Models;
using System.Text.RegularExpressions;

namespace NguyenPhamDinhMan_6551071052_VP103_LTTQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LamMoi()
        {
            txtMaSach.Clear();
            txtTenTheLoai.Clear();
            txtGiaSach.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
        }
        // 1
        private DuLieuContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DuLieuContext>().UseSqlServer(
                @"Server=LAPTOP-GKRJNL12\SQLEXPRESS;Database=DuLieu;Trusted_Connection=True;TrustServerCertificate=True");
            return new DuLieuContext(optionsBuilder.Options);
        }

        private void LoadData()
        {
            using (var db = CreateContext())
            {
                dgvThongTinSach.DataSource = db.CongViecs.ToList();
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadData();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        // 3
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn thoát không ?", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        // 4
        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Mã sách không được để trống.");
                txtMaSach.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenTheLoai.Text))
            {
                MessageBox.Show("Tên sách không được để trống.");
                txtTenTheLoai.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGiaSach.Text))
            {
                MessageBox.Show("Giá sách không được để trống.");
                txtGiaSach.Focus();
                return false;
            }


            string giaSachText = txtGiaSach.Text.Trim().Replace(',', '.');
            if (!decimal.TryParse(giaSachText,
                System.Globalization.NumberStyles.AllowDecimalPoint,
                System.Globalization.CultureInfo.InvariantCulture, out decimal giaSach) ||
                giaSach < 0)
            {
                MessageBox.Show("Giá sách chỉ được nhập số thực hoặc số nguyên.");
                txtGiaSach.Focus();
                return false;
            }

            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTra()) return;
            {
                MessageBox.Show("Số tiền sách phải là số nguyên!");
                return;
            }

            string maSach = txtMaSach.Text.Trim();
            using (var db = CreateContext())
            {
                bool trungMa = db.CongViecs.Any(x => x.MaSach == maSach);

                if (trungMa)
                {
                    MessageBox.Show("Sách đã có!");
                    return;
                }

                CongViec cv = new CongViec();
                cv.MaSach = txtMaSach.Text.Trim();
                cv.TenSach = txtTenTheLoai.Text.Trim();
                cv.GiaTien = txtGiaSach.Text.Trim();
                db.CongViecs.Add(cv);
                db.SaveChanges();
                LoadData();
                LamMoi();
                btnThem.Enabled = false;
            }
        }

        // 5
        private void dgvThongTinSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtMaSach.Text = dgvThongTinSach.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
            txtTenTheLoai.Text = dgvThongTinSach.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();
            txtGiaSach.Text = dgvThongTinSach.Rows[e.RowIndex].Cells["GiaTien"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }



        // 6
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongTinSach.CurrentRow == null)
            {
                MessageBox.Show("Vui long chon sach!");
                return;
            }
            DialogResult dl = MessageBox.Show("Ban co chac xoa sach nay khong?", "Xac nhan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dl == DialogResult.No) return;

            string ma = txtMaSach.Text.Trim();
            using (var db = CreateContext())
            {
                CongViec cv = db.CongViecs.FirstOrDefault(x => x.MaSach == ma);
                if (cv != null)
                {
                    db.CongViecs.Remove(cv);
                    db.SaveChanges();
                }
            }
            LoadData();
            LamMoi();
        }

        // 7
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThongTinSach.CurrentRow == null) return;
            if (!KiemTra()) return;

            string ma = txtMaSach.Text.Trim();
            using (var db = CreateContext())
            {
                CongViec cv = db.CongViecs.FirstOrDefault(x => x.MaSach == ma);
                if (cv == null) return;
                cv.MaSach = txtMaSach.Text.Trim();
                cv.TenSach = txtTenTheLoai.Text.Trim();
                cv.GiaTien = txtGiaSach.Text.Trim();
                db.SaveChanges();
            }
            LoadData();
            LamMoi();
        }

    }
}
