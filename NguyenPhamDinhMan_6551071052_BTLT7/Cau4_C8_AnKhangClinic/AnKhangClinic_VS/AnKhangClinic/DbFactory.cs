using AnKhangClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace AnKhangClinic;

public static class DbFactory
{
  
    public const string ConnectionString =
         @"Server=LAPTOP-GKRJNL12\SQLEXPRESS;Database=LTTQ_AnKhangClinic;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=30";

    public static LTTQ_AnKhangClinicContext Create()
    {
        var options = new DbContextOptionsBuilder<LTTQ_AnKhangClinicContext>()
            .UseSqlServer(ConnectionString)
            .Options;
        return new LTTQ_AnKhangClinicContext(options);
    }
}
