using AnKhangClinic.Models;
using Db = AnKhangClinic.Models.LTTQ_AnKhangClinicContext;
using Microsoft.EntityFrameworkCore;

namespace AnKhangClinic;

public partial class FormBacSi : Form
{
    public FormBacSi()
    {
        InitializeComponent();
        if (dgvBS.Columns.Count == 0)
        {
            dgvBS.AutoGenerateColumns = false;
            dgvBS.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã BS", DataPropertyName = "MaBs", Width = 60 });
            dgvBS.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "HoTen", Width = 200 });
            dgvBS.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Chuyên khoa", DataPropertyName = "ChuyenKhoa", Width = 180 });
            dgvBS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "SĐT", DataPropertyName = "Sdt", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }
    }

    private async Task Chay(Func<Task> viec)
    {
        try { await viec(); }
        catch (Exception ex)
        {
            MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void FormBacSi_Load(object sender, EventArgs e) => await Chay(LoadGridAsync);

    private async Task LoadGridAsync()
    {
        using var db = DbFactory.Create();
        dgvBS.DataSource = await db.BacSis.AsNoTracking().OrderBy(x => x.MaBs).ToListAsync();
        dgvBS_SelectionChanged(null, EventArgs.Empty);
    }

    private int? MaDangChon() => dgvBS.CurrentRow?.DataBoundItem is BacSi b ? b.MaBs : null;

    private void dgvBS_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvBS.CurrentRow?.DataBoundItem is not BacSi b) return;
        txtHoTen.Text = b.HoTen;
        txtChuyenKhoa.Text = b.ChuyenKhoa;
        txtSDT.Text = b.Sdt;
    }

    private bool KiemTra()
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        { MessageBox.Show("Vui lòng nhập họ tên bác sĩ."); txtHoTen.Focus(); return false; }
        return true;
    }

    private async void btnThem_Click(object sender, EventArgs e) => await Chay(async () =>
    {
        if (!KiemTra()) return;
        using var db = DbFactory.Create();
        db.BacSis.Add(new BacSi { HoTen = txtHoTen.Text.Trim(), ChuyenKhoa = txtChuyenKhoa.Text.Trim(), Sdt = txtSDT.Text.Trim() });
        await db.SaveChangesAsync();
        await LoadGridAsync();
    });

    private async void btnSua_Click(object sender, EventArgs e) => await Chay(async () =>
    {
        var ma = MaDangChon();
        if (ma == null) { MessageBox.Show("Hãy chọn bác sĩ cần sửa."); return; }
        if (!KiemTra()) return;
        using var db = DbFactory.Create();
        var b = await db.BacSis.FindAsync(ma.Value);
        if (b == null) return;
        b.HoTen = txtHoTen.Text.Trim(); b.ChuyenKhoa = txtChuyenKhoa.Text.Trim(); b.Sdt = txtSDT.Text.Trim();
        await db.SaveChangesAsync();
        await LoadGridAsync();
    });

    private async void btnXoa_Click(object sender, EventArgs e) => await Chay(async () =>
    {
        var ma = MaDangChon();
        if (ma == null) { MessageBox.Show("Hãy chọn bác sĩ cần xóa."); return; }
        using var db = DbFactory.Create();
        if (await db.LichKhams.AnyAsync(l => l.MaBs == ma))
        { MessageBox.Show("Bác sĩ này đang có lịch khám, không thể xóa."); return; }
        if (MessageBox.Show("Xóa bác sĩ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        var b = await db.BacSis.FindAsync(ma.Value);
        if (b != null) { db.BacSis.Remove(b); await db.SaveChangesAsync(); }
        await LoadGridAsync();
    });

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtHoTen.Clear(); txtChuyenKhoa.Clear(); txtSDT.Clear(); txtHoTen.Focus();
    }
}
