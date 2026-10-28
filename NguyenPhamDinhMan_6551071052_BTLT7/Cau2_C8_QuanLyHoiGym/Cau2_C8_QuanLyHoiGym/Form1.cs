using Cau2_C8_QuanLyHoiGym.Models;
using Microsoft.EntityFrameworkCore;

namespace Cau2_C8_QuanLyHoiGym

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            dgvHoiVien.SelectionChanged += dgvHoiVien_SelectionChanged;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            cmbHangThanhVien.Items.Clear();
            cmbHangThanhVien.Items.Add("Basic");
            cmbHangThanhVien.Items.Add("VIP");
            cmbHangThanhVien.Items.Add("Premium");
            cmbHangThanhVien.SelectedIndex = 0;

            cmbTimHang.Items.Clear();
            cmbTimHang.Items.Add("Tất cả");
            cmbTimHang.Items.Add("Basic");
            cmbTimHang.Items.Add("VIP");
            cmbTimHang.Items.Add("Premium");
            cmbTimHang.SelectedIndex = 0;

            chkTrangThai.Checked = true;
            dtpNgaySinh.Format = DateTimePickerFormat.Short;

            await LoadData();

            SetupDataGridView();
        }

        private FitZoneContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<FitZoneContext>();

            options.UseSqlServer(
                @"Server=LAPTOP-GKRJNL12\SQLEXPRESS;Database=FitZone;Trusted_Connection=True;TrustServerCertificate=True;"
            );

            return new FitZoneContext(options.Options);
        }

        private async Task LoadData()
        {
            using (var context = CreateContext())
            {
                var danhSach = await context.HoiViens
                    .AsNoTracking()
                    .OrderBy(x => x.MaHv)
                    .ToListAsync();

                dgvHoiVien.DataSource = danhSach;
            }
        }
        private bool ValidateInput()
        {
            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return false;
            }

            // Kiểm tra giới tính
            if (!rbNam.Checked && !rbNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return false;
            }

            // Kiểm tra tuổi
            DateOnly ngaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
            DateOnly homNay = DateOnly.FromDateTime(DateTime.Now);

            int tuoi = homNay.Year - ngaySinh.Year;

            if (ngaySinh > homNay.AddYears(-tuoi))
            {
                tuoi--;
            }

            if (tuoi < 15)
            {
                MessageBox.Show("Hội viên phải từ 15 tuổi trở lên!");
                dtpNgaySinh.Focus();
                return false;
            }

            // Kiểm tra SĐT
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                txtSDT.Focus();
                return false;
            }

            if (!sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số!");
                txtSDT.Focus();
                return false;
            }

            if (sdt.Length < 9 || sdt.Length > 11)
            {
                MessageBox.Show("Số điện thoại phải có từ 9 đến 11 chữ số!");
                txtSDT.Focus();
                return false;
            }

            // Kiểm tra Email
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập Email!");
                txtEmail.Focus();
                return false;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Email phải chứa ký tự @!");
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra hạng thành viên
            if (cmbHangThanhVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hạng thành viên!");
                cmbHangThanhVien.Focus();
                return false;
            }

            return true;
        }
        private void SetupDataGridView()
        {
            if (dgvHoiVien.Columns.Count == 0)
                return;

            dgvHoiVien.Columns["MaHv"].HeaderText = "Mã HV";
            dgvHoiVien.Columns["HoTen"].HeaderText = "Họ tên";
            dgvHoiVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvHoiVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvHoiVien.Columns["Sdt"].HeaderText = "SĐT";
            dgvHoiVien.Columns["Email"].HeaderText = "Email";
            dgvHoiVien.Columns["HangThanhVien"].HeaderText = "Hạng thành viên";
            dgvHoiVien.Columns["NgayDangKy"].HeaderText = "Ngày đăng ký";
            dgvHoiVien.Columns["TrangThai"].HeaderText = "Trạng thái";

            dgvHoiVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHoiVien.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgvHoiVien.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvHoiVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoiVien.CurrentRow == null)
                return;

            if (dgvHoiVien.CurrentRow.DataBoundItem is HoiVien hv)
            {
                // Mã hội viên
                txtMaHV.Text = hv.MaHv.ToString();

                // Họ tên
                txtHoTen.Text = hv.HoTen;

                // Giới tính
                rbNam.Checked = hv.GioiTinh;
                rbNu.Checked = !hv.GioiTinh;

                // Ngày sinh
                dtpNgaySinh.Value = hv.NgaySinh.ToDateTime(TimeOnly.MinValue);

                // SĐT
                txtSDT.Text = hv.Sdt;

                // Email
                txtEmail.Text = hv.Email;

                // Hạng thành viên
                cmbHangThanhVien.SelectedItem = hv.HangThanhVien;

                // Trạng thái
                chkTrangThai.Checked = hv.TrangThai;

                // Ngày đăng ký
                lblNgayDangKyValue.Text =
                    hv.NgayDangKy.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (var context = CreateContext())
                {
                    HoiVien hv = new HoiVien
                    {
                        HoTen = txtHoTen.Text.Trim(),

                        GioiTinh = rbNam.Checked,

                        NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),

                        Sdt = txtSDT.Text.Trim(),

                        Email = txtEmail.Text.Trim(),

                        HangThanhVien = cmbHangThanhVien.SelectedItem.ToString(),

                        TrangThai = chkTrangThai.Checked
                    };

                    context.HoiViens.Add(hv);

                    await context.SaveChangesAsync();

                    MessageBox.Show(
                        "Thêm hội viên thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                await LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (string.IsNullOrWhiteSpace(txtMaHV.Text))
            {
                MessageBox.Show("Vui lòng chọn hội viên cần sửa!");
                return;
            }

            try
            {
                int maHV = int.Parse(txtMaHV.Text);

                using (var context = CreateContext())
                {
                    var hv = await context.HoiViens
                        .FirstOrDefaultAsync(x => x.MaHv == maHV);

                    if (hv == null)
                    {
                        MessageBox.Show("Không tìm thấy hội viên!");
                        return;
                    }

                    // Cập nhật thông tin
                    hv.HoTen = txtHoTen.Text.Trim();

                    hv.GioiTinh = rbNam.Checked;

                    hv.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);

                    hv.Sdt = txtSDT.Text.Trim();

                    hv.Email = txtEmail.Text.Trim();

                    hv.HangThanhVien =
                        cmbHangThanhVien.SelectedItem.ToString();

                    hv.TrangThai = chkTrangThai.Checked;

                    // Không sửa NgayDangKy
                    await context.SaveChangesAsync();

                    MessageBox.Show(
                        "Cập nhật hội viên thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                await LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHV.Text))
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa hội viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                int maHV = int.Parse(txtMaHV.Text);

                using (var context = CreateContext())
                {
                    var hv = await context.HoiViens
                        .FirstOrDefaultAsync(x => x.MaHv == maHV);

                    if (hv == null)
                    {
                        MessageBox.Show("Không tìm thấy hội viên!");
                        return;
                    }

                    context.HoiViens.Remove(hv);

                    await context.SaveChangesAsync();

                    MessageBox.Show(
                        "Xóa hội viên thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                await LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void ClearForm()
        {
            txtMaHV.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();

            rbNam.Checked = false;
            rbNu.Checked = false;

            cmbHangThanhVien.SelectedIndex = 0;

            chkTrangThai.Checked = true;

            // Đặt ngày mặc định cách hiện tại 18 năm
            dtpNgaySinh.Value = DateTime.Today.AddYears(-18);

            lblNgayDangKyValue.Text = "";
        }
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();

            txtTimKiem.Clear();

            cmbTimHang.SelectedIndex = 0;

            await LoadData();
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();

                string hang = cmbTimHang.SelectedItem?.ToString() ?? "Tất cả";

                using (var context = CreateContext())
                {
                    var danhSach = await context.HoiViens
                        .AsNoTracking()
                        .Where(x =>
                            x.HoTen.Contains(keyword) &&
                            (hang == "Tất cả" || x.HangThanhVien == hang)
                        )
                        .OrderBy(x => x.MaHv)
                        .ToListAsync();

                    dgvHoiVien.DataSource = danhSach;
                }

                SetupDataGridView();

                if (dgvHoiVien.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hội viên phù hợp!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
