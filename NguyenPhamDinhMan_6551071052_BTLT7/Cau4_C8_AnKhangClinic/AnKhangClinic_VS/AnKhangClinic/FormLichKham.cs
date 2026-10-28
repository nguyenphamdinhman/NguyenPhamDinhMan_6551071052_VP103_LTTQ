using AnKhangClinic.Models;
using Db = AnKhangClinic.Models.LTTQ_AnKhangClinicContext;
using Microsoft.EntityFrameworkCore;

namespace AnKhangClinic;

public partial class FormLichKham : Form
{
    private bool dangLoc = false;   // true khi lưới đang hiển thị kết quả tìm kiếm

    // Dòng hiển thị trên DataGridView
    private class LichRow
    {
        public int MaLich { get; set; }
        public string TenBenhNhan { get; set; }
        public string SDT { get; set; }
        public DateTime? NgayKham { get; set; }
        public string GioKham { get; set; }
        public int? MaBS { get; set; }
        public string BacSi { get; set; }
        public string ChuyenKhoa { get; set; }
        public string TrangThai { get; set; }
    }

    private class ComboItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    public FormLichKham()
    {
        InitializeComponent();
        TaoCot();
    }

    // Tạo cột cho lưới bằng code, tránh bị mất cột khi Visual Studio sinh lại file Designer
    private void TaoCot()
    {
        if (dgvLich.Columns.Count > 0) return;
        dgvLich.AutoGenerateColumns = false;
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã lịch", DataPropertyName = "MaLich", Width = 65 });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên bệnh nhân", DataPropertyName = "TenBenhNhan", Width = 140 });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SĐT", DataPropertyName = "SDT", Width = 105 });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "Ngày khám", DataPropertyName = "NgayKham", Width = 100,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
        });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giờ khám", DataPropertyName = "GioKham", Width = 75 });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Bác sĩ", DataPropertyName = "BacSi", Width = 260 });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Chuyên khoa", DataPropertyName = "ChuyenKhoa", Width = 120 });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "Trạng thái", DataPropertyName = "TrangThai",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });
    }

    // Bọc try/catch để báo lỗi kết nối thay vì văng exception
    private async Task Chay(Func<Task> viec)
    {
        try { await viec(); }
        catch (Exception ex)
        {
            MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ---------------- Load ----------------
    private async void FormLichKham_Load(object sender, EventArgs e)
    {
        cboTrangThai.Items.AddRange(new object[] { "Chờ khám", "Đã khám", "Đã hủy" });
        cboTrangThai.SelectedIndex = 0;
        dtpNgay.Value = DateTime.Today;
        dtpGio.Value = DateTime.Today.AddHours(8);
        dtpTu.Value = DateTime.Today;
        dtpDen.Value = DateTime.Today.AddDays(30);

        await Chay(async () =>
        {
            await NapBacSiAsync();
            await LoadGridAsync();
        });
    }

    // ---------------- Nạp ComboBox bác sĩ (LINQ) ----------------
    private async Task NapBacSiAsync()
    {
        using var db = DbFactory.Create();
        var ds = await db.BacSis.AsNoTracking().OrderBy(x => x.HoTen).ToListAsync();

        int? chon = cboBacSi.SelectedValue as int?;
        cboBacSi.DataSource = ds.Select(x => new ComboItem { Value = x.MaBs, Text = x.HienThi }).ToList();
        cboBacSi.DisplayMember = "Text";
        cboBacSi.ValueMember = "Value";
        cboBacSi.SelectedIndex = -1;
        if (chon != null) cboBacSi.SelectedValue = chon.Value;

        int? chonLoc = cboLocBS.SelectedValue as int?;
        var loc = ds.Select(x => new ComboItem { Value = x.MaBs, Text = x.HienThi }).ToList();
        loc.Insert(0, new ComboItem { Value = 0, Text = "Tất cả bác sĩ" });
        cboLocBS.DataSource = loc;
        cboLocBS.DisplayMember = "Text";
        cboLocBS.ValueMember = "Value";
        cboLocBS.SelectedValue = chonLoc ?? 0;
    }

    // ---------------- Nạp lưới: Include + Where ----------------
    private async Task LoadGridAsync()
    {
        using var db = DbFactory.Create();

        var q = db.LichKhams.AsNoTracking()
                  .Include(x => x.MaBsNavigation)      // JOIN bảng BacSi
                  .AsQueryable();

        if (dangLoc)
        {
            var tu = DateOnly.FromDateTime(dtpTu.Value);
            var den = DateOnly.FromDateTime(dtpDen.Value);
            q = q.Where(x => x.NgayKham >= tu && x.NgayKham <= den);   // khoảng ngày

            if (cboLocBS.SelectedValue is int maBS && maBS > 0)
                q = q.Where(x => x.MaBs == maBS);                      // bác sĩ
        }

        var data = await q.OrderBy(x => x.NgayKham).ThenBy(x => x.GioKham).ToListAsync();

        // dùng ?. để không bị NullReferenceException khi lịch chưa có bác sĩ
        dgvLich.DataSource = data.Select(x => new LichRow
        {
            MaLich = x.MaLich,
            TenBenhNhan = x.TenBenhNhan,
            SDT = x.Sdt,
            NgayKham = x.NgayKham?.ToDateTime(TimeOnly.MinValue),
            GioKham = x.GioKham,
            MaBS = x.MaBs,
            BacSi = x.MaBsNavigation?.HienThi,
            ChuyenKhoa = x.MaBsNavigation?.ChuyenKhoa,
            TrangThai = x.TrangThai
        }).ToList();

        dgvLich_SelectionChanged(null, EventArgs.Empty);
    }

    // ---------------- Chọn dòng -> đổ lên form ----------------
    private void dgvLich_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvLich.CurrentRow?.DataBoundItem is not LichRow r) return;

        txtTenBN.Text = r.TenBenhNhan;
        txtSDT.Text = r.SDT;
        dtpNgay.Value = r.NgayKham ?? DateTime.Today;

        if (DateTime.TryParseExact(r.GioKham, "HH:mm", null, System.Globalization.DateTimeStyles.None, out var gio))
            dtpGio.Value = DateTime.Today.Add(gio.TimeOfDay);

        if (r.MaBS != null) cboBacSi.SelectedValue = r.MaBS.Value;
        else cboBacSi.SelectedIndex = -1;

        cboTrangThai.Text = r.TrangThai;
    }

    private int? MaDangChon() => dgvLich.CurrentRow?.DataBoundItem is LichRow r ? r.MaLich : null;
    private DateTime? NgayDangChon() => dgvLich.CurrentRow?.DataBoundItem is LichRow r ? r.NgayKham : null;

    // ---------------- Validate ----------------
    private bool KiemTra(DateTime? ngayCu)
    {
        if (string.IsNullOrWhiteSpace(txtTenBN.Text))
        { MessageBox.Show("Vui lòng nhập tên bệnh nhân."); txtTenBN.Focus(); return false; }

        if (cboBacSi.SelectedValue == null)
        { MessageBox.Show("Vui lòng chọn bác sĩ."); cboBacSi.Focus(); return false; }

        if (cboTrangThai.SelectedIndex < 0)
        { MessageBox.Show("Vui lòng chọn trạng thái."); return false; }

        // Không cho đặt lịch vào ngày quá khứ (khi sửa mà không đổi ngày thì bỏ qua)
        bool doiNgay = ngayCu == null || ngayCu.Value.Date != dtpNgay.Value.Date;
        if (dtpNgay.Value.Date < DateTime.Today && doiNgay)
        { MessageBox.Show("Không được đặt lịch khám vào ngày trong quá khứ."); dtpNgay.Focus(); return false; }

        return true;
    }

    // Trùng lịch: cùng bác sĩ, cùng ngày, cùng giờ (bỏ qua lịch đã hủy)
    private async Task<bool> TrungLichAsync(Db db, int maBS, DateOnly ngay, string gio, int maLichBoQua)
    {
        if (cboTrangThai.Text == "Đã hủy") return false;
        return await db.LichKhams.AnyAsync(x => x.MaBs == maBS && x.NgayKham == ngay
            && x.GioKham == gio && x.TrangThai != "Đã hủy" && x.MaLich != maLichBoQua);
    }

    // ---------------- Thêm ----------------
    private async void btnThem_Click(object sender, EventArgs e) => await Chay(async () =>
    {
        if (!KiemTra(null)) return;
        using var db = DbFactory.Create();
        int maBS = (int)cboBacSi.SelectedValue;
        string gio = dtpGio.Value.ToString("HH:mm");

        if (await TrungLichAsync(db, maBS, DateOnly.FromDateTime(dtpNgay.Value), gio, 0))
        { MessageBox.Show("Bác sĩ này đã có lịch vào ngày và giờ đó."); return; }

        db.LichKhams.Add(new LichKham
        {
            TenBenhNhan = txtTenBN.Text.Trim(),
            Sdt = txtSDT.Text.Trim(),
            NgayKham = DateOnly.FromDateTime(dtpNgay.Value),
            GioKham = gio,
            MaBs = maBS,
            TrangThai = cboTrangThai.Text
        });
        await db.SaveChangesAsync();
        await LoadGridAsync();
        MessageBox.Show("Thêm lịch khám thành công.");
    });

    // ---------------- Sửa ----------------
    private async void btnSua_Click(object sender, EventArgs e) => await Chay(async () =>
    {
        var ma = MaDangChon();
        if (ma == null) { MessageBox.Show("Hãy chọn lịch khám cần sửa."); return; }
        if (!KiemTra(NgayDangChon())) return;

        using var db = DbFactory.Create();
        var l = await db.LichKhams.FindAsync(ma.Value);
        if (l == null) { MessageBox.Show("Lịch khám không còn tồn tại."); await LoadGridAsync(); return; }

        int maBS = (int)cboBacSi.SelectedValue;
        string gio = dtpGio.Value.ToString("HH:mm");
        if (await TrungLichAsync(db, maBS, DateOnly.FromDateTime(dtpNgay.Value), gio, ma.Value))
        { MessageBox.Show("Bác sĩ này đã có lịch vào ngày và giờ đó."); return; }

        l.TenBenhNhan = txtTenBN.Text.Trim();
        l.Sdt = txtSDT.Text.Trim();
        l.NgayKham = DateOnly.FromDateTime(dtpNgay.Value);
        l.GioKham = gio;
        l.MaBs = maBS;
        l.TrangThai = cboTrangThai.Text;
        await db.SaveChangesAsync();
        await LoadGridAsync();
        MessageBox.Show("Cập nhật thành công.");
    });

    // ---------------- Xóa (có xác nhận YesNo) ----------------
    private async void btnXoa_Click(object sender, EventArgs e) => await Chay(async () =>
    {
        var ma = MaDangChon();
        if (ma == null) { MessageBox.Show("Hãy chọn lịch khám cần xóa."); return; }

        if (MessageBox.Show("Bạn có chắc muốn xóa lịch khám này?", "Xác nhận xóa",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        using var db = DbFactory.Create();
        var l = await db.LichKhams.FindAsync(ma.Value);
        if (l != null)
        {
            db.LichKhams.Remove(l);
            await db.SaveChangesAsync();
        }
        await LoadGridAsync();
        LamMoiForm();
    });

    // ---------------- Làm mới ----------------
    private void LamMoiForm()
    {
        txtTenBN.Clear();
        txtSDT.Clear();
        dtpNgay.Value = DateTime.Today;
        dtpGio.Value = DateTime.Today.AddHours(8);
        cboBacSi.SelectedIndex = -1;
        cboTrangThai.SelectedIndex = 0;
        txtTenBN.Focus();
    }

    private async void btnLamMoi_Click(object sender, EventArgs e) => await Chay(async () =>
    {
        dangLoc = false;
        cboLocBS.SelectedValue = 0;
        dtpTu.Value = DateTime.Today;
        dtpDen.Value = DateTime.Today.AddDays(30);
        await LoadGridAsync();
        LamMoiForm();
    });

    // ---------------- Tìm kiếm: khoảng ngày + bác sĩ ----------------
    private async void btnTimKiem_Click(object sender, EventArgs e) => await Chay(async () =>
    {
        if (dtpTu.Value.Date > dtpDen.Value.Date)
        { MessageBox.Show("'Từ ngày' không được lớn hơn 'Đến ngày'."); return; }
        dangLoc = true;
        await LoadGridAsync();
    });

    // ---------------- Mở form Quản lý Bác sĩ ----------------
    private async void btnBacSi_Click(object sender, EventArgs e)
    {
        using (var f = new FormBacSi()) f.ShowDialog();
        await Chay(async () =>
        {
            await NapBacSiAsync();
            await LoadGridAsync();
        });
    }
}
