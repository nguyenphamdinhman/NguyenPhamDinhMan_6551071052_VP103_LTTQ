CREATE DATABASE LTTQ_AnKhangClinic;
GO
USE LTTQ_AnKhangClinic;
GO
CREATE TABLE BacSi (
    MaBS        INT IDENTITY(1,1) PRIMARY KEY,
    HoTen       NVARCHAR(100) NOT NULL,
    ChuyenKhoa  NVARCHAR(100) NULL,
    SDT         VARCHAR(15) NULL
);
CREATE TABLE LichKham (
    MaLich       INT IDENTITY(1,1) PRIMARY KEY,
    TenBenhNhan  NVARCHAR(100) NOT NULL,
    SDT          VARCHAR(15) NULL,
    NgayKham     DATE NULL,
    GioKham      NVARCHAR(10) NULL,      -- dạng HH:mm
    MaBS         INT NULL,
    TrangThai    NVARCHAR(20) NULL,      -- Chờ khám / Đã khám / Đã hủy
    CONSTRAINT FK_LichKham_BacSi FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS)
);
GO
INSERT INTO BacSi (HoTen, ChuyenKhoa, SDT) VALUES
(N'Nguyễn Văn A', N'Nội tổng quát', '0901000001'),
(N'Nguyễn Văn B', N'Nhi khoa',      '0901000002'),
(N'Nguyễn Văn C', N'Tim mạch',      '0901000003'),
(N'Nguyễn Văn D', N'Da liễu',       '0901000004');

-- Ngày lấy theo hôm nay để bạn test tìm kiếm theo khoảng ngày
INSERT INTO LichKham (TenBenhNhan, SDT, NgayKham, GioKham, MaBS, TrangThai) VALUES
(N'Nguyễn Xinh',     '09725667897', DATEADD(DAY,-3, CAST(GETDATE() AS DATE)), '13:00', 1, N'Đã khám'),
(N'Nguyễn Hạm',      '09725667899', DATEADD(DAY, 1, CAST(GETDATE() AS DATE)), '16:00', 1, N'Chờ khám'),
(N'Nguyễn Tình',     '09725667830', DATEADD(DAY, 2, CAST(GETDATE() AS DATE)), '16:00', 2, N'Chờ khám'),
(N'Nguyễn Hoan Anh', '09725667899', DATEADD(DAY, 5, CAST(GETDATE() AS DATE)), '18:00', 3, N'Đã hủy'),
(N'Trần Thị Mai',    '09725667894', DATEADD(DAY,10, CAST(GETDATE() AS DATE)), '09:00', 4, N'Chờ khám');
GO
