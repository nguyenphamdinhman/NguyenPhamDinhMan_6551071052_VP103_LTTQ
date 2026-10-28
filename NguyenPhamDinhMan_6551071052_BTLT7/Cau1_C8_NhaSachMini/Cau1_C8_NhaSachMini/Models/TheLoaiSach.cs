using System;
using System.Collections.Generic;
using System.Text;

namespace Cau1_C8_NhaSachMini.Models
{
    public partial class TheLoaiSach
    {
        public int MaTl { get; set; }

        public string TenTheLoai { get; set; } = null!;

        public string? MoTa { get; set; }

        public int SoLuongSach { get; set; }

        public DateTime NgayTao { get; set; }
    }
}
