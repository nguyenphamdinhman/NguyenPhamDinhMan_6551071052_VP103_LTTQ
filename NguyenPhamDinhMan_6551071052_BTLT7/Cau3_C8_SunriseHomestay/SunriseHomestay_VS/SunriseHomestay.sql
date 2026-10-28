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
    TinhTrang NVARCHAR(20) NULL, 
    HinhAnh   NVARCHAR(255) NULL,  
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
