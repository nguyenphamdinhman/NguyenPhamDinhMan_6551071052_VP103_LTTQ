DROP DATABASE IF EXISTS DuLieu
GO

USE MASTER 
GO

CREATE DATABASE DuLieu
GO

CREATE TABLE CongViec (
	MaSach NVARCHAR(15) PRIMARY KEY,
	TenSach NText NOT NULL,
	GiaTien NVARCHAR(12) NOT NULL,
);

INSERT INTO CongViec(MaSach,TenSach,GiaTien) VALUES 
(
	N'S001',N'Lập trình cơ bản',N'180.000'
);

INSERT INTO CongViec(MaSach,TenSach,GiaTien) VALUES 
(
	N'S002',N'Cấu trúc dữ liệu',N'210.000'
);

INSERT INTO CongViec(MaSach,TenSach,GiaTien) VALUES 
(
	N'S003',N'Giải thuật nâng cao',N'195.000'
);
INSERT INTO CongViec(MaSach,TenSach,GiaTien) VALUES 
(
	N'S004',N'Nhập môn AI',N'230.000'
);
INSERT INTO CongViec(MaSach,TenSach,GiaTien) VALUES 
(
	N'S005',N'Quản trị mạng',N'175.000'
);


SELECT * FROM CongViec