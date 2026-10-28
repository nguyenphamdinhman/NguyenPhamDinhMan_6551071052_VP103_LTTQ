using Cau1_C8_NhaSachMini.Models;
using Microsoft.EntityFrameworkCore;

namespace Cau1_C8_NhaSachMini
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            dgvTheLoaiSach.SelectionChanged += dgvTheLoaiSach_SelectionChanged;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
        private NhaSachMiniContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<NhaSachMiniContext>();

            options.UseSqlServer(
                @"Server=LAPTOP-GKRJNL12\SQLEXPRESS;Database=NhaSachMini;Trusted_Connection=True;TrustServerCertificate=True;"
            );

            return new NhaSachMiniContext(options.Options);
        }

        private async Task LoadData()
        {
            using (var context = CreateContext())
            {
                var danhSach = await context.TheLoaiSaches
                    .AsNoTracking()
                    .OrderBy(x => x.MaTl)
                    .ToListAsync();

                dgvTheLoaiSach.DataSource = danhSach;
            }

            if (dgvTheLoaiSach.Columns.Count > 0)
            {
                dgvTheLoaiSach.Columns["MaTl"].HeaderText = "Mã TL";
                dgvTheLoaiSach.Columns["TenTheLoai"].HeaderText = "Tên thể loại";
                dgvTheLoaiSach.Columns["MoTa"].HeaderText = "Mô tả";
                dgvTheLoaiSach.Columns["SoLuongSach"].HeaderText = "Số lượng sách";
                dgvTheLoaiSach.Columns["NgayTao"].HeaderText = "Ngày tạo";
            }
        }

        private void dgvTheLoaiSach_SelectionChanged(
           object? sender,
           EventArgs e)
        {
            if (dgvTheLoaiSach.CurrentRow == null)
                return;

            if (dgvTheLoaiSach.CurrentRow.DataBoundItem is TheLoaiSach theLoai)
            {
                txtMaTL.Text = theLoai.MaTl.ToString();

                txtTenTheLoai.Text = theLoai.TenTheLoai;

                txtMoTa.Text = theLoai.MoTa ?? "";

                lblNgayTaoValue.Text =
                    theLoai.NgayTao.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }


        private bool ValidateInput()
        {
            // Kiểm tra tên thể loại
            if (string.IsNullOrWhiteSpace(txtTenTheLoai.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên thể loại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenTheLoai.Focus();

                return false;
            }

            return true;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string tenTheLoai =
                txtTenTheLoai.Text.Trim();

            string moTa =
                txtMoTa.Text.Trim();

            using (var context = CreateContext())
            {
                // Kiểm tra trùng tên
                bool daTonTai = await context.TheLoaiSaches
                    .AnyAsync(x => x.TenTheLoai == tenTheLoai);

                if (daTonTai)
                {
                    MessageBox.Show(
                        "Tên thể loại đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Tạo object mới
                TheLoaiSach theLoai = new TheLoaiSach
                {
                    TenTheLoai = tenTheLoai,
                    MoTa = string.IsNullOrWhiteSpace(moTa)
                        ? null
                        : moTa,

                    // SQL Server có DEFAULT 0
                    // nên có thể bỏ dòng này
                    SoLuongSach = 0
                };

                context.TheLoaiSaches.Add(theLoai);

                await context.SaveChangesAsync();
            }

            MessageBox.Show(
                "Thêm thể loại thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadData();

            ClearInput();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show(
                    "Vui lòng chọn thể loại cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string tenTheLoai =
                txtTenTheLoai.Text.Trim();

            string moTa =
                txtMoTa.Text.Trim();

            using (var context = CreateContext())
            {
                // Tìm record cần sửa
                var theLoai = await context.TheLoaiSaches
                    .FirstOrDefaultAsync(x => x.MaTl == maTL);

                if (theLoai == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy thể loại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Kiểm tra trùng tên
                bool trungTen = await context.TheLoaiSaches
                    .AnyAsync(x =>
                        x.TenTheLoai == tenTheLoai &&
                        x.MaTl != maTL);

                if (trungTen)
                {
                    MessageBox.Show(
                        "Tên thể loại đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Cập nhật
                theLoai.TenTheLoai = tenTheLoai;

                theLoai.MoTa =
                    string.IsNullOrWhiteSpace(moTa)
                    ? null
                    : moTa;

                await context.SaveChangesAsync();
            }

            MessageBox.Show(
                "Cập nhật thể loại thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadData();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int maTL))
            {
                MessageBox.Show(
                    "Vui lòng chọn thể loại cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa thể loại này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            using (var context = CreateContext())
            {
                var theLoai = await context.TheLoaiSaches
                    .FirstOrDefaultAsync(x => x.MaTl == maTL);

                if (theLoai == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy thể loại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                try
                {
                    context.TheLoaiSaches.Remove(theLoai);

                    await context.SaveChangesAsync();

                    MessageBox.Show(
                        "Xóa thể loại thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show(
                        "Không thể xóa thể loại này vì đang có sách tham chiếu!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }

            await LoadData();

            ClearInput();
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword =
               txtTimKiem.Text.Trim();

            using (var context = CreateContext())
            {
                var danhSach = await context.TheLoaiSaches
                    .AsNoTracking()
                    .Where(x =>
                        x.TenTheLoai.Contains(keyword))
                    .OrderBy(x => x.MaTl)
                    .ToListAsync();

                dgvTheLoaiSach.DataSource = danhSach;
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();

            txtTimKiem.Clear();

            await LoadData();
        }

        private void ClearInput()
        {
            txtMaTL.Clear();

            txtTenTheLoai.Clear();

            txtMoTa.Clear();

            lblNgayTaoValue.Text = "";

            txtTenTheLoai.Focus();
        }
    }
}
