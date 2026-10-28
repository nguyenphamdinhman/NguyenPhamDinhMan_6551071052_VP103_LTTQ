using System.ComponentModel.DataAnnotations.Schema;

namespace AnKhangClinic.Models;

public partial class BacSi
{
    [NotMapped]
    public string HienThi => $"BS. {HoTen} - {ChuyenKhoa}";
}