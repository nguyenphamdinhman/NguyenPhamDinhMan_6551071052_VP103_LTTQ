USE MASTER
GO

DROP DATABASE IF EXISTS NhaSachMini
GO

CREATE DATABASE NhaSachMini;
GO

USE NhaSachMini;
GO

CREATE TABLE TheLoaiSach
(
    MaTL INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255) NULL,
    SoLuongSach INT NOT NULL DEFAULT 0,
    NgayTao DATETIME NOT NULL DEFAULT GETDATE()
);

INSERT INTO TheLoaiSach (TenTheLoai, MoTa) VALUES
(N'Tiểu thuyết', N'Thể loại tiểu thuyết'),
(N'Kỹ năng sống', N'Sách về kỹ năng sống'),
(N'Thiếu nhi', N'Sách dành cho thiếu nhi'),
(N'Sách giáo khoa', N'Sách giáo khoa các cấp'),
(N'Truyện tranh', N'Truyện tranh');

