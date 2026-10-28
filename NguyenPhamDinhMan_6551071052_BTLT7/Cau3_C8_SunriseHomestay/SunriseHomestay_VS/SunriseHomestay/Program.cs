// =====================================================================
// SUNRISE HOMESTAY - TOAN BO MA NGUON TRONG 1 FILE (Program.cs)
// Cach dung: tao WinForms project .NET 8 (UseWindowsForms, ImplicitUsings=enable),
// cai NuGet Microsoft.EntityFrameworkCore.SqlServer, thay noi dung Program.cs bang file nay,
// chay doan SQL ben duoi trong SQL Server truoc.
/*
CREATE DATABASE SunriseHomestay;
GO
USE SunriseHomestay;
GO
CREATE TABLE LoaiPhong (
    MaLoai     INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai    NVARCHAR(100) NOT NULL,
    GiaMoiDem  DECIMAL(18,2) NULL,
    MoTa       NVARCHAR(255) NULL
);
CREATE TABLE Phong (
    MaPhong   INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong   VARCHAR(10) NOT NULL,
    TangSo    INT NULL,
    TinhTrang NVARCHAR(20) NULL,   -- Trống / Đang ở / Đang dọn
    HinhAnh   NVARCHAR(255) NULL,  -- chỉ lưu TÊN FILE
    MaLoai    INT NULL,
    CONSTRAINT FK_Phong_LoaiPhong FOREIGN KEY (MaLoai) REFERENCES LoaiPhong(MaLoai)
);
GO
INSERT INTO LoaiPhong (TenLoai, GiaMoiDem, MoTa) VALUES
(N'Phòng Đơn', 35000, N'1 giường đơn'),
(N'Phòng Đôi', 20000, N'1 giường đôi'),
(N'Phòng VIP', 30000, N'Phòng cao cấp, view đẹp');
INSERT INTO Phong (SoPhong, TangSo, TinhTrang, HinhAnh, MaLoai) VALUES
('1', 1, N'Trống',    NULL, 1),
('2', 1, N'Đang ở',   NULL, 2),
('3', 2, N'Đang dọn', NULL, 1),
('4', 4, N'Đang dọn', NULL, 2),
('5', 5, N'Đang dọn', NULL, 3);
GO
*/
// =====================================================================

using Microsoft.EntityFrameworkCore;
using SunriseHomestay.Models;

// ===================== Models/LoaiPhong.cs =====================
namespace SunriseHomestay.Models
{
public partial class LoaiPhong
{
    public int MaLoai { get; set; }
    public string TenLoai { get; set; } = null!;
    public decimal? GiaMoiDem { get; set; }
    public string MoTa { get; set; }
    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
}

// ===================== Models/Phong.cs =====================
namespace SunriseHomestay.Models
{
public partial class Phong
{
    public int MaPhong { get; set; }
    public string SoPhong { get; set; } = null!;
    public int? TangSo { get; set; }
    public string TinhTrang { get; set; }
    public string HinhAnh { get; set; }
    public int? MaLoai { get; set; }
    public virtual LoaiPhong MaLoaiNavigation { get; set; }
}
}

// ===================== Models/SunriseHomestayContext.cs =====================
namespace SunriseHomestay.Models
{
// Tương đương file scaffold từ EF Core Power Tools (Database First).
// Nếu bạn scaffold bằng Power Tools thì thay 3 file trong thư mục Models bằng file được sinh ra.
public partial class SunriseHomestayContext : DbContext
{
    public SunriseHomestayContext() { }
    public SunriseHomestayContext(DbContextOptions<SunriseHomestayContext> options) : base(options) { }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
    public virtual DbSet<Phong> Phongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            @"Server=.\SQLEXPRESS;Database=SunriseHomestay;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoaiPhong>(e =>
        {
            e.HasKey(x => x.MaLoai);
            e.ToTable("LoaiPhong");
            e.Property(x => x.TenLoai).HasMaxLength(100);
            e.Property(x => x.GiaMoiDem).HasColumnType("decimal(18, 2)");
            e.Property(x => x.MoTa).HasMaxLength(255);
        });

        modelBuilder.Entity<Phong>(e =>
        {
            e.HasKey(x => x.MaPhong);
            e.ToTable("Phong");
            e.Property(x => x.SoPhong).HasMaxLength(10).IsUnicode(false);
            e.Property(x => x.TinhTrang).HasMaxLength(20);
            e.Property(x => x.HinhAnh).HasMaxLength(255);
            e.HasOne(x => x.MaLoaiNavigation).WithMany(x => x.Phongs)
             .HasForeignKey(x => x.MaLoai).HasConstraintName("FK_Phong_LoaiPhong");
        });
    }
}
}

// ===================== FormPhong.Designer.cs =====================
namespace SunriseHomestay
{
    partial class FormPhong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSoPhong = new Label(); lblTang = new Label(); lblLoai = new Label(); lblTinhTrang = new Label();
            txtSoPhong = new TextBox(); nudTang = new NumericUpDown();
            cboLoaiPhong = new ComboBox(); cboTinhTrang = new ComboBox();
            picAnh = new PictureBox(); btnChonAnh = new Button();
            btnThem = new Button(); btnSua = new Button(); btnXoa = new Button(); btnLamMoi = new Button();
            cboLocLoai = new ComboBox(); cboLocTinhTrang = new ComboBox();
            btnTimKiem = new Button(); 
            dgvPhong = new DataGridView();
            colMaPhong = new DataGridViewTextBoxColumn();
            colAnh = new DataGridViewImageColumn();
            colSoPhong = new DataGridViewTextBoxColumn();
            colTang = new DataGridViewTextBoxColumn();
            colLoai = new DataGridViewTextBoxColumn();
            colGia = new DataGridViewTextBoxColumn();
            colTinhTrang = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)nudTang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            SuspendLayout();

            // labels
            lblSoPhong.AutoSize = true; lblSoPhong.Location = new Point(12, 18); lblSoPhong.Text = "Số phòng";
            lblTang.AutoSize = true; lblTang.Location = new Point(132, 18); lblTang.Text = "Tầng số";
            lblLoai.AutoSize = true; lblLoai.Location = new Point(232, 18); lblLoai.Text = "Loại phòng";
            lblTinhTrang.AutoSize = true; lblTinhTrang.Location = new Point(348, 18); lblTinhTrang.Text = "Tình trạng";

            // inputs
            txtSoPhong.Location = new Point(12, 40); txtSoPhong.Size = new Size(110, 23);
            nudTang.Location = new Point(132, 40); nudTang.Size = new Size(90, 23);
            nudTang.Minimum = 0; nudTang.Maximum = 100;
            cboLoaiPhong.Location = new Point(232, 40); cboLoaiPhong.Size = new Size(100, 23);
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinhTrang.Location = new Point(348, 40); cboTinhTrang.Size = new Size(100, 23);
            cboTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;

            // picture
            picAnh.Location = new Point(462, 10); picAnh.Size = new Size(70, 62);
            picAnh.SizeMode = PictureBoxSizeMode.StretchImage; picAnh.BorderStyle = BorderStyle.FixedSingle;
            btnChonAnh.Location = new Point(462, 80); btnChonAnh.Size = new Size(70, 25);
            btnChonAnh.Text = "Chọn ảnh..."; btnChonAnh.Click += btnChonAnh_Click;

            // CRUD buttons
            btnThem.Location = new Point(580, 18); btnThem.Size = new Size(55, 28); btnThem.Text = "Thêm"; btnThem.Click += btnThem_Click;
            btnSua.Location = new Point(642, 18); btnSua.Size = new Size(55, 28); btnSua.Text = "Sửa"; btnSua.Click += btnSua_Click;
            btnXoa.Location = new Point(704, 18); btnXoa.Size = new Size(55, 28); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;
            btnLamMoi.Location = new Point(766, 18); btnLamMoi.Size = new Size(60, 28); btnLamMoi.Text = "Làm mới"; btnLamMoi.Click += btnLamMoi_Click;

            // filter row
            cboLocLoai.Location = new Point(12, 125); cboLocLoai.Size = new Size(165, 23);
            cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTinhTrang.Location = new Point(183, 125); cboLocTinhTrang.Size = new Size(165, 23);
            cboLocTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            btnTimKiem.Location = new Point(357, 124); btnTimKiem.Size = new Size(75, 25);
            btnTimKiem.Text = "Tìm kiếm"; btnTimKiem.Click += btnTimKiem_Click;

            // grid
            dgvPhong.Location = new Point(12, 160); dgvPhong.Size = new Size(814, 290);
            dgvPhong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhong.AutoGenerateColumns = false; dgvPhong.AllowUserToAddRows = false;
            dgvPhong.AllowUserToDeleteRows = false; dgvPhong.ReadOnly = true;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvPhong.MultiSelect = false;
            dgvPhong.RowTemplate.Height = 36; dgvPhong.BackgroundColor = Color.Gray;
            dgvPhong.Columns.AddRange(new DataGridViewColumn[] { colMaPhong, colAnh, colSoPhong, colTang, colLoai, colGia, colTinhTrang });
            dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;

            colMaPhong.HeaderText = "Mã phòng"; colMaPhong.DataPropertyName = "MaPhong"; colMaPhong.Width = 100;
            colAnh.HeaderText = "Ảnh"; colAnh.DataPropertyName = "Anh"; colAnh.ImageLayout = DataGridViewImageCellLayout.Zoom; colAnh.Width = 100;
            colSoPhong.HeaderText = "Số phòng"; colSoPhong.DataPropertyName = "SoPhong"; colSoPhong.Width = 120;
            colTang.HeaderText = "Tầng"; colTang.DataPropertyName = "TangSo"; colTang.Width = 110;
            colLoai.HeaderText = "Loại phòng"; colLoai.DataPropertyName = "TenLoai"; colLoai.Width = 120;
            colGia.HeaderText = "Giá/đêm"; colGia.DataPropertyName = "Gia"; colGia.DefaultCellStyle.Format = "N0"; colGia.Width = 110;
            colTinhTrang.HeaderText = "Tình trạng"; colTinhTrang.DataPropertyName = "TinhTrang";
            colTinhTrang.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // form
            AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 462); StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Phòng - Sunrise Homestay";
            Controls.AddRange(new Control[] { lblSoPhong, lblTang, lblLoai, lblTinhTrang, txtSoPhong, nudTang,
                cboLoaiPhong, cboTinhTrang, picAnh, btnChonAnh, btnThem, btnSua, btnXoa, btnLamMoi,
                cboLocLoai, cboLocTinhTrang, btnTimKiem, dgvPhong });
            Load += FormPhong_Load;
            ((System.ComponentModel.ISupportInitialize)nudTang).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            ResumeLayout(false); PerformLayout();
        }

        private Label lblSoPhong, lblTang, lblLoai, lblTinhTrang;
        private TextBox txtSoPhong;
        private NumericUpDown nudTang;
        private ComboBox cboLoaiPhong, cboTinhTrang, cboLocLoai, cboLocTinhTrang;
        private PictureBox picAnh;
        private Button btnChonAnh, btnThem, btnSua, btnXoa, btnLamMoi, btnTimKiem;
        private DataGridView dgvPhong;
        private DataGridViewTextBoxColumn colMaPhong, colSoPhong, colTang, colLoai, colGia, colTinhTrang;
        private DataGridViewImageColumn colAnh;
    }
}

// ===================== FormPhong.cs =====================
namespace SunriseHomestay
{
public partial class FormPhong : Form
{
    private readonly SunriseHomestayContext db = new();
    private readonly string imageFolder = Path.Combine(Application.StartupPath, "Images");
    private string tenAnh = null;          // chỉ lưu TÊN FILE ảnh đang chọn
    private bool dangNap = false;          // chặn SelectionChanged khi đang nạp lại lưới

    // Dòng hiển thị trên DataGridView (có cột Image)
    private class PhongRow
    {
        public int MaPhong { get; set; }
        public Image Anh { get; set; }
        public string SoPhong { get; set; }
        public int? TangSo { get; set; }
        public string TenLoai { get; set; }
        public decimal? Gia { get; set; }
        public string TinhTrang { get; set; }
    }

    public FormPhong()
    {
        InitializeComponent();
        Directory.CreateDirectory(imageFolder);
    }

    private void FormPhong_Load(object sender, EventArgs e)
    {
        cboTinhTrang.Items.AddRange(new object[] { "Trống", "Đang ở", "Đang dọn" });
        cboLocTinhTrang.Items.AddRange(new object[] { "Tất cả tình trạng", "Trống", "Đang ở", "Đang dọn" });
        cboLocTinhTrang.SelectedIndex = 0;
        NapLoaiPhong();
        LoadGrid();
    }

    // ---------- Nạp ComboBox Loại phòng bằng LINQ ----------
    private void NapLoaiPhong()
    {
        var ds = db.LoaiPhongs.AsNoTracking().OrderBy(x => x.TenLoai).ToList();

        cboLoaiPhong.DataSource = ds.ToList();
        cboLoaiPhong.DisplayMember = "TenLoai";
        cboLoaiPhong.ValueMember = "MaLoai";

        var dsLoc = ds.ToList();
        dsLoc.Insert(0, new LoaiPhong { MaLoai = 0, TenLoai = "Tất cả loại phòng" });
        cboLocLoai.DataSource = dsLoc;
        cboLocLoai.DisplayMember = "TenLoai";
        cboLocLoai.ValueMember = "MaLoai";
        cboLocLoai.SelectedIndex = 0;
    }

    // ---------- Đọc ảnh không khóa file ----------
    private static Image DocAnh(string path)
    {
        if (!File.Exists(path)) return null;
        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        using var img = Image.FromStream(fs);
        return new Bitmap(img);
    }

    private Image AnhTheoTen(string ten)
        => string.IsNullOrEmpty(ten) ? null : DocAnh(Path.Combine(imageFolder, ten));

    // ---------- Nạp lưới: Where + Include (Eager Loading) ----------
    private void LoadGrid()
    {
        int maLoai = cboLocLoai.SelectedValue is int v ? v : 0;
        string tinhTrang = cboLocTinhTrang.SelectedIndex > 0 ? cboLocTinhTrang.Text : null;

        var query = db.Phongs.AsNoTracking().Include(x => x.MaLoaiNavigation).AsQueryable();
        if (maLoai > 0) query = query.Where(x => x.MaLoai == maLoai);
        if (tinhTrang != null) query = query.Where(x => x.TinhTrang == tinhTrang);

        var list = query.OrderBy(x => x.MaPhong).ToList()
            .Select(x => new PhongRow
            {
                MaPhong = x.MaPhong,
                Anh = AnhTheoTen(x.HinhAnh),
                SoPhong = x.SoPhong,
                TangSo = x.TangSo,
                TenLoai = x.MaLoaiNavigation?.TenLoai,
                Gia = x.MaLoaiNavigation?.GiaMoiDem,
                TinhTrang = x.TinhTrang
            }).ToList();

        dangNap = true;
        dgvPhong.DataSource = list;
        dangNap = false;
        dgvPhong_SelectionChanged(null, EventArgs.Empty);
    }

    // ---------- Chọn dòng -> đổ dữ liệu + ảnh ----------
    private void dgvPhong_SelectionChanged(object sender, EventArgs e)
    {
        if (dangNap || dgvPhong.CurrentRow == null || dgvPhong.CurrentRow.DataBoundItem is not PhongRow row)
            return;

        var p = db.Phongs.AsNoTracking().FirstOrDefault(x => x.MaPhong == row.MaPhong);
        if (p == null) return;

        txtSoPhong.Text = p.SoPhong;
        nudTang.Value = p.TangSo ?? 0;
        if (p.MaLoai != null) cboLoaiPhong.SelectedValue = p.MaLoai;
        cboTinhTrang.Text = p.TinhTrang;
        tenAnh = p.HinhAnh;
        picAnh.Image?.Dispose();
        picAnh.Image = AnhTheoTen(p.HinhAnh);
    }

    // ---------- Chọn ảnh: copy vào Images, chỉ lưu tên file ----------
    private void btnChonAnh_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog { Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif" };
        if (ofd.ShowDialog() != DialogResult.OK) return;

        string ten = Path.GetFileName(ofd.FileName);
        string dich = Path.Combine(imageFolder, ten);
        if (File.Exists(dich) && !string.Equals(Path.GetFullPath(ofd.FileName), Path.GetFullPath(dich), StringComparison.OrdinalIgnoreCase))
        {
            ten = $"{Guid.NewGuid():N}_{ten}";   // tránh trùng tên
            dich = Path.Combine(imageFolder, ten);
        }
        if (!File.Exists(dich)) File.Copy(ofd.FileName, dich);

        tenAnh = ten;
        picAnh.Image?.Dispose();
        picAnh.Image = DocAnh(dich);
    }

    private bool KiemTra()
    {
        if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
        { MessageBox.Show("Vui lòng nhập số phòng."); txtSoPhong.Focus(); return false; }
        if (cboLoaiPhong.SelectedValue == null)
        { MessageBox.Show("Vui lòng chọn loại phòng."); return false; }
        if (cboTinhTrang.SelectedIndex < 0)
        { MessageBox.Show("Vui lòng chọn tình trạng."); return false; }
        return true;
    }

    private int? MaDangChon()
        => dgvPhong.CurrentRow?.DataBoundItem is PhongRow r ? r.MaPhong : null;

    // ---------- Thêm ----------
    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!KiemTra()) return;
        string so = txtSoPhong.Text.Trim();
        if (db.Phongs.Any(x => x.SoPhong == so))
        { MessageBox.Show("Số phòng đã tồn tại."); return; }

        db.Phongs.Add(new Phong
        {
            SoPhong = so,
            TangSo = (int)nudTang.Value,
            TinhTrang = cboTinhTrang.Text,
            HinhAnh = tenAnh,
            MaLoai = (int)cboLoaiPhong.SelectedValue
        });
        db.SaveChanges();
        LoadGrid();
        MessageBox.Show("Thêm phòng thành công.");
    }

    // ---------- Sửa ----------
    private void btnSua_Click(object sender, EventArgs e)
    {
        var ma = MaDangChon();
        if (ma == null) { MessageBox.Show("Hãy chọn phòng cần sửa."); return; }
        if (!KiemTra()) return;

        string so = txtSoPhong.Text.Trim();
        if (db.Phongs.Any(x => x.SoPhong == so && x.MaPhong != ma))
        { MessageBox.Show("Số phòng đã tồn tại."); return; }

        var p = db.Phongs.Find(ma);
        p.SoPhong = so;
        p.TangSo = (int)nudTang.Value;
        p.TinhTrang = cboTinhTrang.Text;
        p.HinhAnh = tenAnh;
        p.MaLoai = (int)cboLoaiPhong.SelectedValue;
        db.SaveChanges();
        db.Entry(p).State = EntityState.Detached;
        LoadGrid();
        MessageBox.Show("Cập nhật thành công.");
    }

    // ---------- Xóa ----------
    private void btnXoa_Click(object sender, EventArgs e)
    {
        var ma = MaDangChon();
        if (ma == null) { MessageBox.Show("Hãy chọn phòng cần xóa."); return; }
        if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        var p = db.Phongs.Find(ma);
        db.Phongs.Remove(p);
        db.SaveChanges();
        LoadGrid();
        LamMoiForm();
    }

    // ---------- Làm mới ----------
    private void LamMoiForm()
    {
        txtSoPhong.Clear();
        nudTang.Value = 0;
        if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0;
        cboTinhTrang.SelectedIndex = -1;
        tenAnh = null;
        picAnh.Image?.Dispose();
        picAnh.Image = null;
        txtSoPhong.Focus();
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        cboLocLoai.SelectedIndex = 0;
        cboLocTinhTrang.SelectedIndex = 0;
        LoadGrid();
        LamMoiForm();
    }

    // ---------- Tìm kiếm kết hợp 2 điều kiện ----------
    private void btnTimKiem_Click(object sender, EventArgs e) => LoadGrid();

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        db.Dispose();
        base.OnFormClosed(e);
    }
}
}

// ===================== FormLoaiPhong.Designer.cs =====================
namespace SunriseHomestay
{
    partial class FormLoaiPhong
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTen = new Label(); lblGia = new Label(); lblMoTa = new Label();
            txtTen = new TextBox(); nudGia = new NumericUpDown(); txtMoTa = new TextBox();
            btnThem = new Button(); btnSua = new Button(); btnXoa = new Button(); btnLamMoi = new Button();
            dgv = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();

            lblTen.AutoSize = true; lblTen.Location = new Point(12, 15); lblTen.Text = "Tên loại";
            txtTen.Location = new Point(12, 36); txtTen.Size = new Size(180, 23);
            lblGia.AutoSize = true; lblGia.Location = new Point(205, 15); lblGia.Text = "Giá mỗi đêm";
            nudGia.Location = new Point(205, 36); nudGia.Size = new Size(120, 23);
            nudGia.Maximum = 1000000000; nudGia.Increment = 1000; nudGia.ThousandsSeparator = true;
            lblMoTa.AutoSize = true; lblMoTa.Location = new Point(340, 15); lblMoTa.Text = "Mô tả";
            txtMoTa.Location = new Point(340, 36); txtMoTa.Size = new Size(230, 23);

            btnThem.Location = new Point(590, 14); btnThem.Size = new Size(70, 28); btnThem.Text = "Thêm"; btnThem.Click += btnThem_Click;
            btnSua.Location = new Point(590, 48); btnSua.Size = new Size(70, 28); btnSua.Text = "Sửa"; btnSua.Click += btnSua_Click;
            btnXoa.Location = new Point(670, 14); btnXoa.Size = new Size(70, 28); btnXoa.Text = "Xóa"; btnXoa.Click += btnXoa_Click;
            btnLamMoi.Location = new Point(670, 48); btnLamMoi.Size = new Size(70, 28); btnLamMoi.Text = "Làm mới"; btnLamMoi.Click += btnLamMoi_Click;

            dgv.Location = new Point(12, 90); dgv.Size = new Size(728, 260);
            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv.AutoGenerateColumns = false; dgv.AllowUserToAddRows = false; dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã loại", DataPropertyName = "MaLoai", FillWeight = 20 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên loại", DataPropertyName = "TenLoai", FillWeight = 35 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá/đêm", DataPropertyName = "GiaMoiDem", FillWeight = 25, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mô tả", DataPropertyName = "MoTa", FillWeight = 50 });
            dgv.SelectionChanged += dgv_SelectionChanged;

            AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 362); StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Loại phòng";
            Controls.AddRange(new Control[] { lblTen, txtTen, lblGia, nudGia, lblMoTa, txtMoTa, btnThem, btnSua, btnXoa, btnLamMoi, dgv });
            Load += FormLoaiPhong_Load;
            ((System.ComponentModel.ISupportInitialize)nudGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false); PerformLayout();
        }

        private Label lblTen, lblGia, lblMoTa;
        private TextBox txtTen, txtMoTa;
        private NumericUpDown nudGia;
        private Button btnThem, btnSua, btnXoa, btnLamMoi;
        private DataGridView dgv;
    }
}

// ===================== FormLoaiPhong.cs =====================
namespace SunriseHomestay
{
public partial class FormLoaiPhong : Form
{
    private readonly SunriseHomestayContext db = new();
    private bool dangNap = false;

    public FormLoaiPhong() => InitializeComponent();

    private void FormLoaiPhong_Load(object sender, EventArgs e) => LoadGrid();

    private void LoadGrid()
    {
        dangNap = true;
        dgv.DataSource = db.LoaiPhongs.AsNoTracking().OrderBy(x => x.MaLoai).ToList();
        dangNap = false;
        dgv_SelectionChanged(null, EventArgs.Empty);
    }

    private int? MaDangChon() => dgv.CurrentRow?.DataBoundItem is LoaiPhong l ? l.MaLoai : null;

    private void dgv_SelectionChanged(object sender, EventArgs e)
    {
        if (dangNap || dgv.CurrentRow?.DataBoundItem is not LoaiPhong l) return;
        txtTen.Text = l.TenLoai;
        nudGia.Value = l.GiaMoiDem ?? 0;
        txtMoTa.Text = l.MoTa;
    }

    private bool KiemTra()
    {
        if (string.IsNullOrWhiteSpace(txtTen.Text))
        { MessageBox.Show("Vui lòng nhập tên loại phòng."); txtTen.Focus(); return false; }
        return true;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!KiemTra()) return;
        db.LoaiPhongs.Add(new LoaiPhong { TenLoai = txtTen.Text.Trim(), GiaMoiDem = nudGia.Value, MoTa = txtMoTa.Text.Trim() });
        db.SaveChanges();
        LoadGrid();
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        var ma = MaDangChon();
        if (ma == null) { MessageBox.Show("Hãy chọn loại phòng cần sửa."); return; }
        if (!KiemTra()) return;
        var l = db.LoaiPhongs.Find(ma);
        l.TenLoai = txtTen.Text.Trim(); l.GiaMoiDem = nudGia.Value; l.MoTa = txtMoTa.Text.Trim();
        db.SaveChanges();
        db.Entry(l).State = EntityState.Detached;
        LoadGrid();
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        var ma = MaDangChon();
        if (ma == null) { MessageBox.Show("Hãy chọn loại phòng cần xóa."); return; }
        if (db.Phongs.Any(p => p.MaLoai == ma))
        { MessageBox.Show("Loại phòng này đang có phòng sử dụng, không thể xóa."); return; }
        if (MessageBox.Show("Xóa loại phòng này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        db.LoaiPhongs.Remove(db.LoaiPhongs.Find(ma));
        db.SaveChanges();
        LoadGrid();
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtTen.Clear(); nudGia.Value = 0; txtMoTa.Clear(); txtTen.Focus();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        db.Dispose();
        base.OnFormClosed(e);
    }
}
}

// ===================== Program.cs =====================
namespace SunriseHomestay
{
static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormPhong());
    }
}
}
