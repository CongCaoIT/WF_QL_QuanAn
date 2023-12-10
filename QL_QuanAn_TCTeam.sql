                -- Đề Tài Quản Lý Quán Ăn Được Xây Dựng Và Triển Khai Bởi TC Team--

CREATE DATABASE QL_QuanAn
 ON PRIMARY
 (
     NAME = N'QL_QuanAn_Data',
     FILENAME = 'E:\HK V (2023 - 2024)\TH_He_Quan_Tri_Co_So_Du_Lieu\DU_AN\QL_QuanAn.mdf',
     SIZE = 100MB,
     MAXSIZE = UNLIMITED,
     FILEGROWTH = 20%
 )
 LOG ON
 (   
     NAME = N'QL_QuanAn_Log',
     FILENAME = 'E:\HK V (2023 - 2024)\TH_He_Quan_Tri_Co_So_Du_Lieu\DU_AN\QL_QuanAn.ldf',
     SIZE = 50MB,
     MAXSIZE = UNLIMITED,
     FILEGROWTH = 10%
 )
GO

USE QL_QuanAn
GO

CREATE TABLE NhomQuyen
(
	MaNhom INT IDENTITY NOT NULL,
	TenNhom NVARCHAR(50) NULL,

	CONSTRAINT PK_NhomQuyen PRIMARY KEY (MaNhom)
)
GO

CREATE TABLE Quyen
(
	MaQuyen INT IDENTITY NOT NULL,
	DienGiai NVARCHAR(MAX) NULL,

	CONSTRAINT PK_Quyen PRIMARY KEY (MaQuyen)
)
GO

CREATE TABLE CapQuyen_Nhom
(
	MaNhom INT NOT NULL,
	MaQuyen INT NOT NULL,

	CONSTRAINT PK_CapQuyenNhom PRIMARY KEY (MaNhom, MaQuyen),
	CONSTRAINT FK_CapQuyenNhom_NhomQuyen FOREIGN KEY (MaNhom) REFERENCES NhomQuyen(MaNhom),
	CONSTRAINT FK_CapQuyenNhom_Quyen FOREIGN KEY (MaQuyen) REFERENCES Quyen(MaQuyen)
)
GO

INSERT INTO NhomQuyen (TenNhom)
VALUES 
		(N'Admin'),
		(N'Nhân viên')
GO

INSERT INTO Quyen
VALUES
	(N'Lấy tất cả thông tin trên bảng khu vực'),

	(N'Lấy tất cả thông tin trên bảng bàn'),
	(N'Cập nhật trạng thái trên bảng bàn'),

	(N'Lấy tất cả thông tin trên bảng hóa đơn'),
	(N'Cập nhật ngày ra, thành tiền trên bảng hóa đơn'),
	(N'Thêm hóa đơn trên bảng hóa đơn'),
	(N'Xóa hóa đơn trên bảng hóa đơn'),

	(N'Lấy tất cả thông tin trên bảng chi tiết hóa đơn'),
	(N'Cập nhật số lượng trên bảng chi tiết hóa đơn'),
	(N'Thêm chi tiết hóa đơn trên bảng chi tiết hóa đơn'),
	(N'Xóa chi tiết hóa đơn trên bảng chi tiết hóa đơn'),

	(N'Lấy tất cả thông tin trên bảng nhân viên của nhân viên hiện thành'),

	(N'Lấy tất cả thông tin trên bản tài khoản của nhân viên hiện thành'),
	(N'Cập nhật mật khẩu trên bảng tài khoản của nhân viên hiện thành'),

	(N'Lấy tất cả thông tin trên bảng món ăn'),

	(N'Lấy tất cả thông tin trên bảng loại món ăn'),

	(N'Tất cả quyền')
GO

INSERT INTO CapQuyen_Nhom
VALUES
	(1, 17),
	(2, 1),
	(2, 2),
	(2, 3),
	(2, 4),
	(2, 5),
	(2, 6),
	(2, 7),
	(2, 8),
	(2, 9),
	(2, 10),
	(2, 11),
	(2, 12),
	(2, 13),
	(2, 14),
	(2, 15),
	(2, 16)
GO

CREATE TABLE NHANVIEN
(
    MANHANVIEN VARCHAR(10) NOT NULL,
    HOTEN NVARCHAR(100) NULL,
    PHAI NVARCHAR(4) NULL CHECK (PHAI = N'Nam' OR PHAI = N'Nữ'),
    NGAYSINH DATE NULL,
    DIACHI NVARCHAR(255) NULL,
    SDT VARCHAR(12) NULL CHECK (SDT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    NGAYVAOLAM DATE NULL,
    LUONGCOBAN DECIMAL(12, 2) NULL DEFAULT 0,
    DAXOA BIT NOT NULL DEFAULT 0

    CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANHANVIEN)
)
GO

CREATE TABLE TAIKHOAN
(
    TENDANGNHAP VARCHAR(50) NOT NULL,
    MANHANVIEN VARCHAR(10) NOT NULL,
    TENHIENTHI NVARCHAR(50) NOT NULL,
    MATKHAU NVARCHAR(100) NOT NULL,
    MaNhom INT NULL,
    TRANGTHAI NVARCHAR(50) NULL,

    CONSTRAINT PK_TAIKHOAN PRIMARY KEY(TENDANGNHAP),
    CONSTRAINT FK_TAIKHOAN_NHANVIEN FOREIGN KEY(MANHANVIEN) REFERENCES NHANVIEN(MANHANVIEN),
	CONSTRAINT FK_TAIKHOAN_NhomQuyen FOREIGN KEY (MaNhom) REFERENCES NhomQuyen(MaNhom)
)
GO

CREATE TABLE KHUVUC
(
    MAKHUVUC INT IDENTITY NOT NULL,
    TENKHUVUC NVARCHAR(50) NULL UNIQUE,

    CONSTRAINT PK_KHUVUC PRIMARY KEY(MAKHUVUC)
)
GO

CREATE TABLE BAN
(
    MABAN INT IDENTITY NOT NULL,
    MAKHUVUC INT NOT NULL,
    TENBAN NVARCHAR(50) NULL UNIQUE,
    SOLUONGNGUOI INT NULL CHECK (SOLUONGNGUOI > 0),    
    TRANGTHAI NVARCHAR(255) NULL,
    DAXOA BIT NOT NULL DEFAULT 0,

    CONSTRAINT PK_BAN PRIMARY KEY(MABAN),
    CONSTRAINT FK_BAN_KHUVUC FOREIGN KEY(MAKHUVUC) REFERENCES KHUVUC(MAKHUVUC)
)
GO

CREATE TABLE CHAMCONG
(
    MANHANVIEN VARCHAR(10) NOT NULL,
    NGAYLAM DATE NOT NULL,
    CALAM NVARCHAR(20) NOT NULL,

    CONSTRAINT PK_CHAMCONG PRIMARY KEY(MANHANVIEN, NGAYLAM, CALAM),
    CONSTRAINT FK_CHAMCONG_NHANVIEN FOREIGN KEY(MANHANVIEN) REFERENCES NHANVIEN(MANHANVIEN)
)
GO

CREATE TABLE HOADON
(
    MAHOADON INT IDENTITY NOT NULL, 
    MABAN INT NOT NULL,
    MANHANVIEN VARCHAR(10) NOT NULL,
    NGAYVAO DATE NULL,
    NGAYRA DATE NULL,
    GIAMGIA INT NULL DEFAULT 0,
    THANHTIEN DECIMAL(12, 2) NULL DEFAULT 0,

    CONSTRAINT PK_HOADON PRIMARY KEY(MAHOADON),
    CONSTRAINT FK_HOADON_BAN FOREIGN KEY(MABAN) REFERENCES BAN(MABAN),
    CONSTRAINT FK_HOADON_NHANVIEN FOREIGN KEY(MANHANVIEN) REFERENCES NHANVIEN(MANHANVIEN)
)
GO

CREATE TABLE NGUYENLIEU
(
    MANGUYENLIEU INT IDENTITY NOT NULL,
    TENNGUYENLIEU NVARCHAR(100) NULL UNIQUE,

    CONSTRAINT PK_NGUYENLIEU PRIMARY KEY(MANGUYENLIEU)
)
GO

CREATE TABLE LOAIMONAN
(
    MALOAIMONAN INT IDENTITY NOT NULL,
    TENLOAIMONAN NVARCHAR(50) NULL UNIQUE,
    DAXOA BIT NOT NULL DEFAULT 0,

    CONSTRAINT PK_LOAIMONAN PRIMARY KEY(MALOAIMONAN)
)
GO

CREATE TABLE MONAN
(
    MAMONAN INT IDENTITY NOT NULL,
    MALOAIMONAN INT NOT NULL,
    TENMONAN NVARCHAR(100) NULL UNIQUE,
    DVT NVARCHAR(20) NULL,
    DONGIA DECIMAL(10, 2) NULL DEFAULT 0,
    HINHANH NVARCHAR(MAX) NULL,
    DAXOA BIT NOT NULL DEFAULT 0,

    CONSTRAINT PK_MONAN PRIMARY KEY(MAMONAN),
    CONSTRAINT FK_MONAN_LOAIMONAN FOREIGN KEY(MALOAIMONAN) REFERENCES LOAIMONAN(MALOAIMONAN)
)
GO

CREATE TABLE CONGTHUC
(
    MACONGTHUC INT IDENTITY NOT NULL,
    MAMONAN INT NOT NULL,
    MANGUYENLIEU INT NOT NULL,
    HAMLUONG NVARCHAR(50) NULL,

    CONSTRAINT PK_CONGTHUC PRIMARY KEY(MACONGTHUC),
    CONSTRAINT FK_CONTHUC_NGUYENLIEU FOREIGN KEY(MANGUYENLIEU) REFERENCES NGUYENLIEU(MANGUYENLIEU), 
    CONSTRAINT FK_CONGTHUC_MONAN FOREIGN KEY(MAMONAN) REFERENCES MONAN(MAMONAN)
)
GO

CREATE TABLE CHITIETHOADON
(
    MACHITIETHD INT IDENTITY NOT NULL,
    MAMONAN INT NOT NULL,
    MAHOADON INT NOT NULL,
    SOLUONG INT NULL DEFAULT 0,

    CONSTRAINT PK_CHITIETHOADON PRIMARY KEY(MACHITIETHD),
    CONSTRAINT FK_CHITIETHOADON_MONAN FOREIGN KEY(MAMONAN) REFERENCES MONAN(MAMONAN),
    CONSTRAINT FK_CHITIETHOADON_HOADON FOREIGN KEY(MAHOADON) REFERENCES HOADON(MAHOADON)
)
GO

--Tạo View chứa thông tin hóa đơn
CREATE VIEW V_HOADON
AS
SELECT HOADON.MAHOADON, CHITIETHOADON.SOLUONG, NHANVIEN.HOTEN, MONAN.TENMONAN, MONAN.DONGIA, BAN.TENBAN, MONAN.DONGIA * CHITIETHOADON.SOLUONG AS THANHTIEN
FROM BAN
        INNER JOIN HOADON ON BAN.MABAN = HOADON.MABAN
        INNER JOIN CHITIETHOADON ON HOADON.MAHOADON = CHITIETHOADON.MAHOADON
        INNER JOIN NHANVIEN ON HOADON.MANHANVIEN = NHANVIEN.MANHANVIEN
        INNER JOIN MONAN ON CHITIETHOADON.MAMONAN = MONAN.MAMONAN
GROUP BY HOADON.MAHOADON, CHITIETHOADON.SOLUONG, NHANVIEN.HOTEN, MONAN.TENMONAN, MONAN.DONGIA, dbo.BAN.TENBAN
GO

--Tạo View doanh thu
CREATE VIEW DOANHTHU
AS
SELECT dbo.BAN.TENBAN, dbo.NHANVIEN.HOTEN, HOADON.MAHOADON, HOADON.NGAYVAO, HOADON.THANHTIEN, MONTH(HOADON.NGAYVAO) AS THANG, YEAR(HOADON.NGAYVAO) AS NAM
FROM dbo.BAN
        INNER JOIN HOADON ON BAN.MABAN = HOADON.MABAN 
        INNER JOIN NHANVIEN ON HOADON.MANHANVIEN = NHANVIEN.MANHANVIEN
GROUP BY BAN.TENBAN, NHANVIEN.HOTEN, HOADON.MAHOADON, HOADON.NGAYVAO, HOADON.THANHTIEN, MONTH(HOADON.NGAYVAO), YEAR(HOADON.NGAYVAO)
GO

--Tạo View Report chấm công
CREATE VIEW RPCHAMCONG
AS
SELECT NHANVIEN.HOTEN, NHANVIEN.NGAYSINH, NHANVIEN.DIACHI, 
       NHANVIEN.SDT, NHANVIEN.LUONGCOBAN, COUNT(CHAMCONG.MANHANVIEN) AS SOCA, 
       COUNT(CHAMCONG.MANHANVIEN) * NHANVIEN.LUONGCOBAN AS TONGTIEN, 
       MONTH(CHAMCONG.NGAYLAM) AS THANG, YEAR(CHAMCONG.NGAYLAM) AS NAM
FROM CHAMCONG INNER JOIN NHANVIEN ON CHAMCONG.MANHANVIEN = NHANVIEN.MANHANVIEN
GROUP BY NHANVIEN.MANHANVIEN, NHANVIEN.HOTEN, NHANVIEN.NGAYSINH, NHANVIEN.DIACHI, NHANVIEN.SDT,
         NHANVIEN.LUONGCOBAN, MONTH(CHAMCONG.NGAYLAM), YEAR(CHAMCONG.NGAYLAM)
GO

-- Tạo nhóm quyền nhân viên
EXEC sp_addrole 'nhan_vien'
GO

-- Thêm quyền vào nhóm quyền nhân viên
GRANT SELECT
ON KHUVUC
TO nhan_vien
GO

GRANT SELECT, UPDATE(TRANGTHAI)
ON BAN
TO nhan_vien
GO

GRANT SELECT, UPDATE (NGAYRA, THANHTIEN), INSERT, DELETE
ON HOADON
TO nhan_vien
GO

GRANT SELECT, UPDATE(SOLUONG), INSERT, DELETE
ON CHITIETHOADON
TO nhan_vien
GO

GRANT SELECT
ON NHANVIEN
TO nhan_vien
GO

GRANT SELECT , UPDATE (MATKHAU)
ON TAIKHOAN
TO nhan_vien
GO

GRANT SELECT
ON MONAN
TO nhan_vien
GO

GRANT SELECT
ON LOAIMONAN
TO nhan_vien
GO

-- Tạo nhóm quyền admin
EXEC sp_addrole 'admin'
GO

-- Gán db_owner vào nhóm quyền admin
EXEC sp_addrolemember 'db_owner', 'admin'
GO


                                    --Thêm dữ liệu--
--Thêm nhân viên
--MANHANVIEN VARCHAR(10) NOT NULL,
--HOTEN NVARCHAR(100) NULL,
--PHAI NVARCHAR(4) NULL,
--NGAYSINH DATE NULL,
--DIACHI NVARCHAR(255) NULL,
--SDT VARCHAR(12) NULL,
--NGAYVAOLAM DATE NULL,
--LUONGCOBAN DECIMAL(12, 2) NULL
INSERT INTO NHANVIEN(MANHANVIEN, HOTEN, PHAI, NGAYSINH, DIACHI, SDT, NGAYVAOLAM, LUONGCOBAN) VALUES
('NV001', N'Cao Tấn Công', N'Nam', '2003-10-26', N'17B Tân Trụ, TP. HCM', '0362111265', '2023-10-01', 300000),
('NV005', N'Thanh Thảo', N'Nữ', '2003-10-26', N'17B Tân Trụ, TP. HCM', '0362111265', '2023-10-01', 100000)
GO
--Thêm tài khoản
--TENDANGNHAP VARCHAR(10) NOT NULL,
--MANHANVIEN VARCHAR(10) NULL,
--TENHIENTHI NVARCHAR(50) NOT NULL,
--MATKHAU NVARCHAR(100) NOT NULL,
--CAPQUYEN NVARCHAR(50) NULL,
--TRANGTHAI NVARCHAR(50) NULL

INSERT INTO TAIKHOAN(TENDANGNHAP, MANHANVIEN, TENHIENTHI, MATKHAU, MaNhom, TRANGTHAI) VALUES
('admin', 'NV001', N'ADMIN', '1962026656160185351301320480154111117132155', 1, N'Hoạt động')
GO

--Thêm loại món ăn
--MALOAIMONAN INT IDENTITY NOT NULL,
--TENLOAIMONAN NVARCHAR(50) NULL
INSERT INTO LOAIMONAN(TENLOAIMONAN) VALUES
(N'Hấp'),
(N'Xào'),
(N'Nướng'),
(N'Đồ nguội'),
(N'Đồ sống'),
(N'Combo'),
(N'Chiên'),
(N'Luộc'),
(N'Món Ăn kèm'),
(N'Món Tráng miệng'),
(N'Đồ uống cồn'),
(N'Đồ uống không cồn')
GO

----Thêm món ăn
--MAMONAN INT IDENTITY NOT NULL,
--MALOAIMONAN INT NOT NULL,
--TENMONAN NVARCHAR(100) NULL,
--DVT NVARCHAR(20) NULL,
--DONGIA DECIMAL(10, 2) NULL,
--HINHANH NVARCHAR(100) NULL,
INSERT INTO MONAN(MALOAIMONAN, TENMONAN, DVT, DONGIA, HINHANH) VALUES
(1, N'Gà hấp sả', N'Con', 150000, null),
(1, N'Cá thu hấp', N'Con', 100000, null), 
(2, N'Bạch Tuộc Xốt Tôm Chua', N'Đĩa', 269000, null),
(2, N'Cá Hồi Xốt Mù Tạt', N'Đĩa', 279000, null),
(2, N'Tôm Lửa Hồng', N'Đĩa', 289000, null),
(2, N'Cá Mai Xốt Ớt Xanh', N'Đĩa', 149000, null),
(2, N'Cà Tím Xào Lá Quế', N'Đĩa', 79000, null),
(2, N'Rau Rừng Xào X.O', N'Đĩa', 99000, null),
(2, N'Bông Cải Baby Xào Tỏi', N'Đĩa', 99000, null),
(2, N'Đọt Su Xào Ba Rọi Xông Khói', N'Đĩa', 109000, null),
(2, N'Bánh Đa Xào Bò', N'Đĩa', 189000, null),
(3, N'Ếch Nướng Gỗ Sồi', N'Phần', 249000, null),
(3, N'Hàu Hạ Long Nướng Phô Mai (1 con)', N'Con', 39000, null),
(3, N'Sò Điệp Xốt Trứng Muối (1 con)', N'Con', 45000, null),
(3, N'Bào Ngư Xốt Trứng Muối', N'Con', 69000, null),
(3, N'Cà Tím Nướng Mỡ Hành', N'Đĩa', 69000, null),
(3, N'Ba Chỉ Heo Nướng Mật Ong', N'Đĩa', 149000, null),
(3, N'Ba Chỉ Bò Nướng Xốt Cay', N'Đĩa', 179000, null),
(3, N'Dẻ Sườn Bò Mỹ Nướng Xốt Cay', N'Đĩa', 249000, null),
(3, N'Bò Mỹ Nướng Ống Tre', N'Đĩa', 249000, null),
(3, N'Bò Mỹ Xì Xèo', N'Đĩa', 269000, null),
(4, N'Bánh Mè Chả Đùm', N'Phần', 109000, null),
(5, N'Hàu Hạ Long Ăn Sống (1 con)', N'Con', 35000, null),
(6, N'Combo Hải Sản', N'Phần', 599000, null),
(6, N'Combo Thịt Nướng', N'Phần', 699000, null),
(6, N'Combo Đặc Biệt', N'Phần', 899000, null),
(6, N'Đại Tiệc Thịt Nướng Budweiser', N'Phần', 999000, null),
(6, N'Đảo Hải Sản Hoegaarden', N'Phần', 999000, null),
(7, N'Cơm Chiên Thơm Chay', N'Đĩa', 99000, null),
(7, N'Cơm Chiên Cá Mặn', N'Tô', 129000, null),
(7, N'Cơm Chiên Lá Cẩm Hải Sản', N'Tô', 199000, null),
(8, N'Miến Trộn Chua Cay', N'Đĩa', 269000, null),
(9, N'Khoai Tây Phô Mai', N'Đĩa', 79000, null),
(9, N'Khoai Mì Viên Chiên', N'Đĩa', 79000, null),
(9, N'Xôi Chiên Phồng', N'Đĩa', 69000, null),
(9, N'Khoai Lang Tím Nghiền', N'Đĩa', 69000, null),
(9, N'Khoai Mì Nghiền', N'Đĩa', 69000, null),
(10, N'Cam', N'Đĩa', 69000, null),
(10, N'Xoài', N'Đĩa', 49000, null),
(10, N'Nho', N'Đĩa', 59000, null),
(10, N'Bưởi', N'Đĩa', 49000, null),
(10, N'Dưa hấu', N'Đĩa', 59000, null),
(11, N'Budweiser Draught - Ly 330ml', N'Ly', 39000, null),
(11, N'Budweiser Draught - Tháp 3000ml', N'Tháp', 340000, null),
(11, N'Hoegaarden Draught - Ly 250ml', N'Ly', 49000, null),
(11, N'Hoegaarden Draught - Tháp 3000ml', N'Tháp', 450000, null),
(11, N'Budweiser', N'Chai', 29000, null),
(11, N'Corona 250ml', N'Chai', 39000, null),
(11, N'Hoegaarden White', N'Chai', 69000, null),
(11, N'Tiger Lon', N'Lon', 29000, null),
(11, N'Tiger Crytal Lon', N'Lon', 30000, null),
(11, N'Heineken Silver Lon', N'Lon', 35000, null),
(12, N'La Vie Still 450ml', N'Chai', 29000, null),
(12, N'Sting Dâu Lon', N'Lon', 25000, null),
(12, N'7Up Lon', N'Lon', 25000, null),
(12, N'Pepsi Lon', N'Lon', 25000, null),
(12, N'CocaCola Lon', N'Lon', 25000, null)
GO

--Thêm nguyên liệu
--MANGUYENLIEU INT IDENTITY NOT NULL,
--TENNGUYENLIEU NVARCHAR(100) NULL
INSERT INTO NGUYENLIEU(TENNGUYENLIEU) VALUES
(N'Gà'),
(N'Vịt'),
(N'Cá hồi'),
(N'Cá thu'),
(N'Ếch'),
(N'Hào'),
(N'Sò điệp'),
(N'Bào ngư'),
(N'Cà tím'),
(N'Rau rừng'),
(N'Đường'),
(N'Muối'),
(N'Bột ngọt'),
(N'Bột nêm'),
(N'Ớt'),
(N'Tỏi'),
(N'Tiêu'),
(N'Nước mắm'),
(N'Giấm')
GO

----Thêm công thức
--MACONGTHUC INT IDENTITY NOT NULL,
--MAMONAN INT NOT NULL,
--MANGUYENLIEU INT NOT NULL,
--HAMLUONG NVARCHAR(50) NULL
INSERT INTO CONGTHUC(MAMONAN, MANGUYENLIEU, HAMLUONG) VALUES
(1, 2, N'1 Con'),
(1, 6, N'2 Muỗn'),
(1, 7, N'1 Muỗn'),
(1, 9, N'2 Trái'),
(2, 4, N'1 Con'),
(2, 6, N'2 Muỗn'),
(2, 7, N'1 Muỗn'),
(2, 9, N'2 Trái'),
(3, 4, N'1 Con'),
(3, 6, N'2 Muỗn'),
(3, 7, N'1 Muỗn'),
(3, 9, N'2 Trái')
GO

--Thêm khu vực
--MAKHUVUC INT IDENTITY NOT NULL,
--TENKHUVUC NVARCHAR(50) NULL
INSERT INTO KHUVUC(TENKHUVUC) VALUES
(N'Tầng Trệt'),
(N'Tầng 1'),
(N'Tầng 2'),
(N'Tầng 3')
GO
--Thêm bàn ăn
--MABAN INT IDENTITY NOT NULL,
--MAKHUVUC INT NOT NULL,
--TENBAN NVARCHAR(50) NULL,
--SOLUONGNGUOI INT NULL,    
--TRANGTHAI NVARCHAR(50) NULL
INSERT INTO BAN(MAKHUVUC, TENBAN, SOLUONGNGUOI, TRANGTHAI) VALUES
(1, N'T_Bàn 1', 10, N'Trống'),
(1, N'T_Bàn 2', 10, N'Trống'),
(1, N'T_Bàn 3', 10, N'Trống'),
(1, N'T_Bàn 4', 10, N'Trống'),
(1, N'T_Bàn 5', 2, N'Trống'),
(1, N'T_Bàn 6', 10, N'Trống'),
(1, N'T_Bàn 7', 10, N'Trống'),
(1, N'T_Bàn 8', 10, N'Trống'),
(1, N'T_Bàn 9', 10, N'Trống'),
(1, N'T_Bàn 10', 10, N'Trống'),
(1, N'T_Bàn 11', 2, N'Trống'),
(1, N'T_Bàn 12', 10, N'Trống'),
(2, N'M_Bàn 1', 10, N'Trống'),
(2, N'M_Bàn 2', 30, N'Trống'),
(2, N'M_Bàn 3', 10, N'Trống'),
(2, N'M_Bàn 4', 10, N'Trống'),
(2, N'M_Bàn 5', 3, N'Trống'),
(2, N'M_Bàn 6', 10, N'Trống'),
(3, N'H_Bàn 1', 6, N'Trống'),
(3, N'H_Bàn 2', 10, N'Trống'),
(3, N'H_Bàn 3', 10, N'Trống'),
(3, N'H_Bàn 4', 10, N'Trống'),
(3, N'H_Bàn 5', 10, N'Trống'),
(3, N'H_Bàn 6', 10, N'Trống'),
(4, N'B_Bàn 1', 10, N'Trống'),
(4, N'B_Bàn 2', 3, N'Trống'),
(4, N'B_Bàn 3', 10, N'Trống'),
(4, N'B_Bàn 4', 10, N'Trống'),
(4, N'B_Bàn 5', 10, N'Trống'),
(4, N'B_Bàn 6', 6, N'Trống')
GO

                                     -- Xử lý thủ tục--
                                        --CÔNG: TÀI KHOẢN--
--Đăng nhập
CREATE PROC USP_Login 
    @userName nvarchar(100),
    @passWord nvarchar(100)
AS
BEGIN
    SELECT *
    FROM TAIKHOAN
    WHERE BINARY_CHECKSUM(TENDANGNHAP) = BINARY_CHECKSUM(@userName) AND BINARY_CHECKSUM(MATKHAU) = BINARY_CHECKSUM(@passWord);
END
GO

--Lấy tài khoản bởi tên đăng nhập
CREATE PROC USP_GetAccountByUserName
    @userName nvarchar(100)
AS
    BEGIN
        SELECT * FROM TAIKHOAN WHERE @userName = TENDANGNHAP
    END
GO

--Lấy danh sách tài khoản
CREATE PROC USP_GetListAccount
AS
    BEGIN
        SELECT * FROM TAIKHOAN
    END
GO

--Lấy tài khoản bởi mã nhân viên
CREATE PROC USP_GetAccountByStaffID
    @staffid VARCHAR(10)
AS
    BEGIN
        SELECT * FROM TAIKHOAN WHERE MANHANVIEN = @staffid
    END
GO

--Thêm tài khoản
CREATE PROC USP_InsertAccount
    @userName VARCHAR(50),
    @staffid VARCHAR(10),
    @displayName NVARCHAR(50),
    @permissionGroupId INT, 
    @status NVARCHAR(50)
AS
    BEGIN
		IF (@permissionGroupId = (SELECT MaNhom FROM NhomQuyen WHERE TenNhom = N'Admin'))
			BEGIN
				-- Tạo login
				EXEC sp_addlogin @userName, '1', 'QL_QuanAn'
				-- Tạo user
				EXEC sp_adduser @userName, @userName
				-- Thêm user vào nhóm quyền admin
				EXEC sp_addrolemember 'admin', @userName
			END
		ELSE IF (@permissionGroupId = (SELECT MaNhom FROM NhomQuyen WHERE TenNhom = N'Nhân viên'))
			BEGIN
				-- Tạo login
				EXEC sp_addlogin @userName, '1', 'QL_QuanAn'
				-- Tạo user
				EXEC sp_adduser @userName, @userName
				-- Thêm user vào nhóm quyền admin
				EXEC sp_addrolemember 'nhan_vien', @userName
			END	

        INSERT INTO TAIKHOAN(TENDANGNHAP, MANHANVIEN, TENHIENTHI, MATKHAU, MaNhom, TRANGTHAI) VALUES
        (@userName, @staffid, @displayName, '1962026656160185351301320480154111117132155', @permissionGroupId, @status)
    END
GO

--Xóa tài khoản
CREATE PROC USP_DeleteAccount
    @userName VARCHAR(50)
AS
    BEGIN
		EXEC sp_dropuser @userName
		EXEC sp_droplogin @userName

        DELETE TAIKHOAN WHERE TENDANGNHAP = @userName
    END
GO

--Xóa tài khoản bởi mã nhân viên
CREATE PROC USP_DeleteAccountByStaffID
    @staffid VARCHAR(10)
AS
    BEGIN
		WHILE EXISTS (SELECT * FROM TAIKHOAN WHERE MANHANVIEN = @staffid)
		BEGIN
			DECLARE @userName VARCHAR(50)
			SELECT @userName = TENDANGNHAP FROM TAIKHOAN WHERE MANHANVIEN = @staffid
			EXEC sp_dropuser @userName
			EXEC sp_droplogin @userName
		END

        DELETE TAIKHOAN WHERE MANHANVIEN = @staffid
    END
GO

--Sửa tài khoản
CREATE PROC USP_UpdateAccount
    @permissionGroupId INT, 
    @status NVARCHAR(50),
    @userName VARCHAR(10)
AS
    BEGIN
	IF (@permissionGroupId = (SELECT MaNhom FROM NhomQuyen WHERE TenNhom = N'Admin'))
			BEGIN
				-- Thêm user vào nhóm quyền admin
				EXEC sp_addrolemember 'admin', @userName
				-- Xóa người dùng khỏi nhóm quyền nhân viên
				EXEC sp_droprolemember 'nhan_vien', @userName
			END
		ELSE IF (@permissionGroupId = (SELECT MaNhom FROM NhomQuyen WHERE TenNhom = N'Nhân viên'))
			BEGIN
				-- Thêm user vào nhóm quyền nhân viên
				EXEC sp_addrolemember 'nhan_vien', @userName
				-- Xóa người dùng khỏi nhóm quyền admin
				EXEC sp_droprolemember 'admin', @userName
			END

        UPDATE TAIKHOAN
        SET MaNhom = @permissionGroupId, TRANGTHAI = @status
        WHERE TENDANGNHAP = @userName
    END
GO

--Cài lại mật khẩu
CREATE PROC USP_ResetPassWord
    @userName VARCHAR(50)
AS
    BEGIN
        UPDATE TAIKHOAN
        SET MATKHAU = '1962026656160185351301320480154111117132155'
        WHERE TENDANGNHAP = @userName
    END
GO

--Thay đổi mật khẩu
CREATE PROC USP_ChangePassword
    @userName VARCHAR(50),
    @password NVARCHAR(100),
    @newPassword NVARCHAR(100)
AS
BEGIN
    DECLARE @isRightPass INT = 0

    SELECT @isRightPass = COUNT(*) FROM TAIKHOAN WHERE TENDANGNHAP = @userName AND MATKHAU = @password

    IF(@isRightPass = 1)
        BEGIN
            UPDATE TAIKHOAN SET MATKHAU = @newPassword WHERE TENDANGNHAP = @userName
        END
END
GO

-- Lấy mã nhóm quyền theo tên nhóm quyền
CREATE PROC USP_GetPermissionGroupId
	@permission NVARCHAR(50)
AS
BEGIN
	SELECT MaNhom FROM NhomQuyen WHERE TenNhom = @permission
END
GO

-- Lấy tên nhóm quyền theo mã nhóm quyền
CREATE PROC USP_GetPermissionGroupById
	@id INT
AS
BEGIN
	SELECT TenNhom FROM NhomQuyen WHERE MaNhom = @id
END
GO

                                        --CÔNG: NHÂN VIÊN--
--Lấy danh sách nhân viên
CREATE PROC USP_GetListEmployee
AS
    BEGIN
        SELECT * FROM NHANVIEN WHERE DAXOA = 0
    END
GO

--Lấy nhân viên bởi mã nhân viên
CREATE PROC USP_GetEmployeeByStaffID
    @staffid VARCHAR(10)
AS
    BEGIN
        SELECT * FROM NHANVIEN WHERE MANHANVIEN = @staffid
    END
GO

-- Thêm nhân viên
CREATE PROC USP_InsertEmployee
    @staffid VARCHAR(10),
    @name NVARCHAR(100),
    @sex NVARCHAR(4),
    @dateofbirth DATE,
    @address NVARCHAR(255),
    @phone VARCHAR(12),
    @dateofwork DATE,
    @basicsalary DECIMAL(12, 2)
AS
    BEGIN
        INSERT INTO NHANVIEN(MANHANVIEN, HOTEN, PHAI, NGAYSINH, DIACHI, SDT, NGAYVAOLAM, LUONGCOBAN) VALUES
        (@staffid, @name, @sex, @dateofbirth, @address, @phone, @dateofwork, @basicsalary)
    END
GO

--Xóa nhân viên
CREATE PROC USP_DeleteEmployee
    @staffid VARCHAR(10)
AS
    BEGIN
        UPDATE NHANVIEN
        SET DAXOA = 1
        WHERE MANHANVIEN = @staffid
    END
GO

--Sửa nhân viên
CREATE PROC USP_UpdateEmployee
    @staffid VARCHAR(10),
    @name NVARCHAR(100),
    @sex NVARCHAR(4),
    @dateofbirth DATE,
    @address NVARCHAR(255),
    @phone VARCHAR(12),
    @dateofwork DATE,
    @basicsalary DECIMAL(12, 2)
AS
    BEGIN
        UPDATE NHANVIEN
        SET HOTEN = @name, PHAI = @sex, NGAYSINH = @dateofbirth, DIACHI = @address, SDT = @phone, NGAYVAOLAM = @dateofwork, LUONGCOBAN = @basicsalary
        WHERE MANHANVIEN = @staffid
    END
GO

-- Function Loại bỏ dấu tiếng Việt, giữ nguyên chữ in hoa và các ký tự đặc biệt
CREATE FUNCTION [dbo].[fuConvertToUnsign1]
(
 @strInput NVARCHAR(4000)
)
RETURNS NVARCHAR(4000)
AS
BEGIN 
 IF @strInput IS NULL RETURN @strInput
 IF @strInput = '' RETURN @strInput
 DECLARE @RT NVARCHAR(4000)
 DECLARE @SIGN_CHARS NCHAR(136)
 DECLARE @UNSIGN_CHARS NCHAR (136)
 SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế
 ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý
 ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ
 ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'
 +NCHAR(272)+ NCHAR(208)
 SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee
 iiiiiooooooooooooooouuuuuuuuuuyyyyy
 AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII
 OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 DECLARE @COUNTER int
 DECLARE @COUNTER1 int
 SET @COUNTER = 1
 WHILE (@COUNTER <=LEN(@strInput))
 BEGIN 
 SET @COUNTER1 = 1
 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
 BEGIN
 IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1))
 = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
 BEGIN 
 IF @COUNTER=1
 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
 + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
 ELSE
 SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1)
 +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1)
 + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)
 BREAK
 END
 SET @COUNTER1 = @COUNTER1 +1
 END
 SET @COUNTER = @COUNTER +1
 END
 SET @strInput = replace(@strInput,' ','-')
 RETURN @strInput
END
GO

--Tìm nhân viên theo tên
CREATE PROC USP_SearchEmployeeByName
    @name NVARCHAR(100)
AS
    BEGIN
        SELECT *
        FROM NHANVIEN
        WHERE [dbo].[fuConvertToUnsign1](HOTEN) LIKE N'%' + [dbo].[fuConvertToUnsign1](@name) + N'%' AND DAXOA = 0;
    END
GO

--Tìm nhân viên theo lương
CREATE PROC USP_SearchEmployeeBySalary
     @basicsalary DECIMAL(12, 2)
AS
    BEGIN
        SELECT * FROM NHANVIEN WHERE LUONGCOBAN = @basicsalary AND DAXOA = 0
    END
GO

--Tìm nhân viên theo giới tính
CREATE PROC USP_SearchEmployeeBySex
   @sex NVARCHAR(4)
AS
    BEGIN
        SELECT * FROM NHANVIEN WHERE PHAI = @sex AND DAXOA = 0
    END
GO

--Tìm nhân viên theo lương và giới tính
CREATE PROC USP_SearchEmployeeBySalaryAndSex
    @basicsalary DECIMAL(12, 2),
    @sex NVARCHAR(4)
AS
    BEGIN
        SELECT * FROM NHANVIEN WHERE PHAI = @sex AND LUONGCOBAN = @basicsalary AND DAXOA = 0
    END
GO

-- Tạo stored procedure
CREATE PROC USP_GetEmployeeByStaffIDMonthYear
    @staffid VARCHAR(10),
    @month INT,
    @year INT
AS
    BEGIN
        SELECT * FROM NHANVIEN nv
        JOIN CHAMCONG cc ON nv.MANHANVIEN = cc.MANHANVIEN
        WHERE nv.MANHANVIEN = @staffid AND MONTH(cc.NGAYLAM) = @month AND YEAR(cc.NGAYLAM) = @year
    END
GO

--Lấy danh sách hóa đơn theo ngày ra và nhân viên
CREATE PROC USP_GetListBillByDateOutAndStaff
    @dateStart DATE, @dateEnd DATE, @staffId VARCHAR(10)
AS
    BEGIN
        SELECT * FROM HOADON WHERE NGAYRA >= @dateStart AND NGAYRA <= @dateEnd AND MANHANVIEN = @staffId
    END
GO

                                            --CÔNG: CHẤM CÔNG--
--Lấy danh sách chấm công
CREATE PROC USP_GetListTimeKeeping
AS
    BEGIN
        SELECT * FROM CHAMCONG
        ORDER BY NGAYLAM DESC; -- Sắp xếp theo ngày giảm dần
    END
GO

--Thêm chấm công
CREATE PROC USP_InsertTimeKeeping
    @staffid VARCHAR(10),
    @workshift NVARCHAR(20)
AS
    BEGIN
        DECLARE @dayofwork DATE
        SET @dayofwork = GETDATE()

        INSERT INTO CHAMCONG(MANHANVIEN, NGAYLAM, CALAM) VALUES
        (@staffid, @dayofwork, @workshift)
    END
GO

--Xóa chấm công
CREATE PROC USP_DeleteTimeKeeping
    @staffid VARCHAR(10),
    @workday DATE,
    @workshift NVARCHAR(20)
AS
    BEGIN
        DELETE CHAMCONG WHERE MANHANVIEN = @staffid AND NGAYLAM = @workday AND CALAM = @workshift
    END
GO

--Tìm ca làm của nhân viên theo theo tên nhân viên
CREATE PROC USP_SearchTimeKeepingByStaffID
    @staffid VARCHAR(10)
AS
    BEGIN
        SELECT *
        FROM CHAMCONG
        WHERE [dbo].[fuConvertToUnsign1](MANHANVIEN) LIKE N'%' + [dbo].[fuConvertToUnsign1](@staffid) + N'%';
    END
GO

--Tìm kiếm
--Tìm chấm công theo ca làm
CREATE PROC USP_SearchTimeKeepingByWorkShifts
    @workshift NVARCHAR(20)
AS
    BEGIN
        SELECT * FROM CHAMCONG WHERE CALAM = @workshift
    END
GO

--Tìm chấm công theo tháng làm
CREATE PROC USP_SearchTimeKeepingByMonth
    @month INT
AS
    BEGIN
        SELECT * FROM CHAMCONG WHERE DATEPART(MONTH, NGAYLAM) = @month
    END
GO

--Tìm chấm công theo năm làm
CREATE PROC USP_SearchTimeKeepingByYear
    @year INT
AS
    BEGIN
        SELECT * FROM CHAMCONG WHERE DATEPART(YEAR, NGAYLAM) = @year
    END
GO

-- Tìm chấm công theo tháng và năm làm
CREATE PROC USP_SearchTimeKeepingByMonthAndYear
    @month INT,
    @year INT
AS
    BEGIN
        SELECT * FROM CHAMCONG
        WHERE DATEPART(YEAR, NGAYLAM) = @year AND DATEPART(MONTH, NGAYLAM) = @month
    END
GO

--Tìm chấm công theo tháng và ca làm
CREATE PROCEDURE USP_SearchTimeKeepingByMonthAndShift
    @month INT,
    @shift NVARCHAR(20)
AS
    BEGIN
        SELECT * FROM CHAMCONG
        WHERE DATEPART(MONTH, NGAYLAM) = @month
        AND CALAM = @shift
    END
GO

--Tìm chấm công theo năm và cam làm
CREATE PROCEDURE USP_SearchTimeKeepingByYearAndShift
    @year INT,
    @shift NVARCHAR(20)
AS
    BEGIN
        SELECT * FROM CHAMCONG
        WHERE DATEPART(YEAR, NGAYLAM) = @year
        AND CALAM = @shift
    END
GO

--Tìm chấm công
CREATE PROCEDURE USP_SearchTimeKeepingByMonthYearAndShift
    @month INT,
    @year INT,
    @shift NVARCHAR(20)
AS
    BEGIN
        SELECT * FROM CHAMCONG
        WHERE DATEPART(MONTH, NGAYLAM) = @month
        AND DATEPART(YEAR, NGAYLAM) = @year
        AND CALAM = @shift
    END
GO

                                        --TIẾN: LOẠI MÓN ĂN--
--Lấy danh sách món ăn
CREATE PROC USP_GetListFoodCategory
AS
   BEGIN
    SELECT * FROM LOAIMONAN WHERE DAXOA = 0
   END
GO

--Thêm loại món ăn
CREATE PROC USP_InsertFoodCategory
    @foodcategoryName NVARCHAR(50)
AS
    BEGIN
        INSERT INTO LOAIMONAN(TENLOAIMONAN) VALUES
        (@foodcategoryName)
    END
GO

--Xóa loại món ăn
CREATE PROC USP_DeleteFoodCategory
    @foodcategoryid INT
AS
    BEGIN
        UPDATE LOAIMONAN
        SET DAXOA = 1
        WHERE MALOAIMONAN = @foodcategoryid
    END
GO

--Sửa loại món ăn
CREATE PROC USP_UpdateFoodCategory
    @foodcategoryid INT,
    @foodcategoryName NVARCHAR(50)
AS
    BEGIN
        UPDATE LOAIMONAN 
        SET TENLOAIMONAN = @foodcategoryName WHERE MALOAIMONAN = @foodcategoryid
    END
GO

                                        --TIẾN: MÓN ĂN--
--Tìm món ăn đưa vào mã loại món ăn
CREATE PROC USP_SearchFoodByFoodCategoryName
    @foodcategoryid INT
AS
    BEGIN
        SELECT * FROM MONAN WHERE MALOAIMONAN = @foodcategoryid AND DAXOA = 0
    END
GO

--Lấy danh sách món ăn
CREATE PROC USP_GetListFood
AS
    BEGIN
        SELECT * FROM MONAN WHERE MALOAIMONAN IN (SELECT MALOAIMONAN FROM LOAIMONAN WHERE DAXOA = 0) AND DAXOA = 0
    END
GO

--Lấy tên món ăn theo mã món ăn
CREATE PROC USP_GetFoodNameByFoodId
    @foodId INT
AS
    BEGIN
        SELECT TENMONAN FROM MONAN WHERE MAMONAN = @foodId
    END
GO

--TÀI: Tìm kiếm món ăn
CREATE FUNCTION UF_SearchFood (@foodName NVARCHAR(100))
RETURNS TABLE
    RETURN SELECT * FROM MONAN WHERE TENMONAN LIKE '%' + @foodName + '%' AND DAXOA = 0
GO

--TÀI: Tìm kiếm món ăn theo danh mục
CREATE FUNCTION UF_SearchFoodByCategoty (@foodName NVARCHAR(100), @category NVARCHAR(50))
RETURNS @FOOD TABLE 
                    (
                        MAMONAN INT,
                        MALOAIMONAN INT,
                        TENMONAN NVARCHAR(100),
                        DVT NVARCHAR(20),
                        DONGIA DECIMAL(10, 2),
                        HINHANH NVARCHAR(100), 
                        DAXOA BIT
                    )
    BEGIN
        DECLARE @categoryId INT
        SELECT @categoryId = MALOAIMONAN FROM LOAIMONAN WHERE TENLOAIMONAN = @category
        INSERT INTO @FOOD
        SELECT * FROM MONAN WHERE MALOAIMONAN = @categoryId AND TENMONAN LIKE '%' + @foodName + '%' AND DAXOA = 0
        RETURN
    END
GO

--TÀI: Lấy đơn giá theo mã món ăn
CREATE PROC USP_GetUnitPriceByFoodId
    @foodId INT
AS
    BEGIN
        SELECT DONGIA FROM MONAN WHERE MAMONAN = @foodId
    END
GO

--Thêm món ăn
CREATE PROC USP_InsertFood
    @foodcategoryid INT,
    @foodName NVARCHAR(100), 
    @unit NVARCHAR(20),
    @price DECIMAL(10, 2),
    @images NVARCHAR(MAX)
AS
    BEGIN
        INSERT INTO MONAN(MALOAIMONAN, TENMONAN, DVT, DONGIA, HINHANH) VALUES
        (@foodcategoryid, @foodName, @unit, @price, @images)
    END
GO

--Sửa món ăn
CREATE PROC USP_UpdateFood
    @foodid INT,
    @foodcategoryid INT,
    @foodName NVARCHAR(100), 
    @unit NVARCHAR(20),
    @price DECIMAL(10, 2),
    @images NVARCHAR(MAX)
AS
    BEGIN
        UPDATE MONAN
        SET MALOAIMONAN = @foodcategoryid, TENMONAN = @foodName, DVT = @unit, DONGIA = @price, HINHANH = @images
        WHERE MAMONAN = @foodid
    END
GO

--Xóa món ăn
CREATE PROC USP_DeleteFood
    @foodid INT
AS
    BEGIN
        UPDATE MONAN
        SET DAXOA = 1
        WHERE MAMONAN = @foodid
    END
GO

--Lấy danh sách món ăn theo tên món ăn
CREATE PROC USP_GetFoodByID
    @foodid INT
AS
    BEGIN
        SELECT * FROM MONAN WHERE MAMONAN = @foodid
    END
GO

--Lấy món ăn theo mã món ăn
CREATE PROC USP_GetFoodByFoodId
    @foodId INT
AS
    BEGIN
        SELECT * FROM MONAN WHERE MAMONAN = @foodId
    END
GO

                                        --TIẾN: CÔNG THỨC-
--Lấy dánh sách công thức
CREATE PROC USP_GetListFoodRecipes
AS
    BEGIN
        SELECT * FROM CONGTHUC
        ORDER BY MAMONAN
    END
GO

--Thêm công thức
CREATE PROC USP_InsertFoodRecipes
    @foodid INT,
    @ingredientid INT, 
    @content NVARCHAR(50)
AS 
    BEGIN
        INSERT INTO CONGTHUC(MAMONAN, MANGUYENLIEU, HAMLUONG) VALUES
        (@foodid, @ingredientid, @content)
    END
GO

--Kiểm tra trùng dữ liệu CÔNG THỨC
CREATE PROC USP_CheckIngredientExists    
    @foodid INT,
    @IngredientID INT
AS
    BEGIN
        SELECT COUNT(*) FROM CONGTHUC WHERE MAMONAN = @foodid AND MANGUYENLIEU = @IngredientID
    END
GO

-- Xóa công thức
CREATE PROC USP_DeleteFoodRecipes
    @foodid INT,
    @IngredientID INT
AS
    BEGIN
        DELETE CONGTHUC WHERE MAMONAN = @foodid AND MANGUYENLIEU = @IngredientID
    END
GO

-- Xóa công thức món ăn theo mã món ăn
CREATE PROC USP_DeleteFoodRecipesByFoodid
    @foodid INT
AS
    BEGIN
        DELETE CONGTHUC WHERE MAMONAN = @foodid
    END
GO

--Sửa công thức
CREATE PROC USP_UpdateFoodRecipes
    @foodrecipesid INT,
    @foodid INT,
    @IngredientID INT,
    @content NVARCHAR(50)
AS
    BEGIN
        UPDATE CONGTHUC
        SET MAMONAN = @foodid, MANGUYENLIEU = @IngredientID, HAMLUONG = @content
        WHERE MACONGTHUC = @foodrecipesid
    END
GO

--Lấy công thức dựa vào mã món ăn tương ứng
CREATE PROC USP_GetFoodRecipesByFoodID
    @foodid INT
AS
    BEGIN
        SELECT * FROM CONGTHUC WHERE MAMONAN = @foodid
    END
GO

--Xóa món ăn theo loại món ăn
CREATE PROC USP_DeleteFoodByCategoryID
    @categoryid INT
AS
    BEGIN
        DELETE MONAN WHERE MALOAIMONAN = @categoryid
    END
GO

                                        --TIẾN: NGUYÊN LIỆU--
--Lấy danh sách nguyên liệu
CREATE PROC USP_GetListIngredient
AS
    BEGIN
        SELECT * FROM NGUYENLIEU
    END
GO

--Thêm nguyên liệu
CREATE PROC USP_InsertIngredient
    @ingerdientName NVARCHAR(100)
AS
    BEGIN
        INSERT INTO NGUYENLIEU(TENNGUYENLIEU) VALUES
        (@ingerdientName)
    END
GO

--Xóa nguyên liệu
CREATE PROC USP_DeleteIngredient
    @ingredientID INT
AS
    BEGIN
        DELETE NGUYENLIEU WHERE MANGUYENLIEU = @ingredientID
    END
GO

--Sửa nguyên liệu
CREATE PROC USP_UpdateIngredient
    @ingredientID INT,
    @ingerdientName NVARCHAR(100)
AS
    BEGIN
        UPDATE NGUYENLIEU
        SET TENNGUYENLIEU = @ingerdientName
        WHERE MANGUYENLIEU = @ingredientID
    END
GO

--Lấy danh sách nguyên liệu
CREATE PROC USP_GetListIngredientByID
    @ingredientID INT
AS
    BEGIN
        SELECT * FROM NGUYENLIEU WHERE MANGUYENLIEU = @ingredientID
    END
GO

                                        --HUY: BÀN ĂN--
--Lấy danh sách bàn
CREATE PROC USP_GetListTable
AS
    BEGIN 
        SELECT * FROM BAN
    END
GO

--Lấy danh sách bàn theo khu vực
CREATE PROC USP_GetListTableByArea
    @areaId INT
AS
    BEGIN
        SELECT * FROM BAN, KHUVUC WHERE BAN.MAKHUVUC = KHUVUC.MAKHUVUC AND KHUVUC.MAKHUVUC = @areaId AND DAXOA = 0
    END
GO

--Lấy bàn theo mã bàn
CREATE PROC USP_GetTableByTableId
    @tableId INT
AS
    BEGIN
        SELECT * FROM BAN WHERE MABAN = @tableId
    END
GO
--Lấy trạng thái bàn theo mã bàn
CREATE PROC USP_GetStatusByTable
    @tableId INT
AS
    BEGIN
        SELECT TRANGTHAI FROM BAN WHERE MABAN = @tableId
    END
GO
--TÀI: Cập nhật trạng trái của bàn
CREATE PROC USP_UpdateStatusTable
    @tableId INT, @status NVARCHAR(255)
AS
    BEGIN
        UPDATE BAN SET TRANGTHAI = @status WHERE MABAN = @tableId
    END
GO

-- Lấy tên bàn bằng mã bàn
CREATE PROC USP_GetTableIdByTableName
    @tableName NVARCHAR(50)
AS
    BEGIN
        SELECT MABAN FROM BAN WHERE TENBAN = @tableName
    END
GO

--Thêm bàn ăn
CREATE PROC USP_InsertTable
    @areaid INT,
    @tablename NVARCHAR(50),
    @quanlity INT,
    @status NVARCHAR(50)
AS
    BEGIN
        INSERT INTO BAN(MAKHUVUC, TENBAN, SOLUONGNGUOI, TRANGTHAI) VALUES
        (@areaid, @tablename, @quanlity, @status)
    END
GO

--Sửa thông tin bàn ăn
CREATE PROC USP_UpdateTable
    @tableid INT,
    @areaid INT,
    @tablename NVARCHAR(50),
    @quanlity INT,
    @status NVARCHAR(50)
AS
    BEGIN
        UPDATE BAN 
        SET MAKHUVUC = @areaid, TENBAN = @tablename, SOLUONGNGUOI = @quanlity, TRANGTHAI = @status
        WHERE MABAN = @tableid
    END
GO

--Xóa thông tin bàn
CREATE PROC USP_DeleteTable
    @tableID INT
AS
    BEGIN
        UPDATE BAN
        SET DAXOA = 1
        WHERE MABAN = @tableID 
    END
GO

                                        --HUY: KHU VỰC BÀN ĂN--
--Lấy danh sách vùng
CREATE PROC USP_GetListArea
AS
    BEGIN
        SELECT * FROM KHUVUC
    END
GO

--Lấy tên khu vực theo mã khu vực
CREATE PROC USP_GetAreaNameByAreaID
    @areaid INT
AS
    BEGIN 
        SELECT * FROM KHUVUC WHERE MAKHUVUC = @areaid
    END
GO

--Lấy số lượng vùng
CREATE PROC USP_GetNumberOfArea
AS
    BEGIN
        SELECT COUNT(*) FROM KHUVUC
    END
GO

                                        --TÀI: CHI TIẾT HÓA ĐƠN--
--Xóa chi tiết hóa đơn theo mã hóa đơn
CREATE PROC USP_DeleteBillInfoByBill
    @billId INT
AS
    BEGIN
        DELETE CHITIETHOADON WHERE MAHOADON = @billId
    END
GO

--Lấy chi tiết hóa đơn theo hóa đơn
CREATE PROC USP_GetBillInfoByBill
    @billId INT
AS
    BEGIN
        SELECT * FROM CHITIETHOADON WHERE MAHOADON = @billId
    END
GO

--Ghi chi tiết hóa đơn
CREATE PROC USP_InsertBillInfo
    @foodId INT, @billId INT, @count INT
AS
    BEGIN
        INSERT INTO CHITIETHOADON (MAMONAN, MAHOADON, SOLUONG)
        VALUES (@foodId, @billId, @count)
    END
GO

--Xóa chi tiết hóa đơn theo mã hóa đơn và mã món ăn
CREATE PROC USP_DeleteBillInfoByBillIdAndFoodId
    @billId INT, @foodId INT
AS
    BEGIN
        DELETE CHITIETHOADON WHERE MAHOADON = @billId AND MAMONAN = @foodId
    END
GO

--Cập nhật chi tiết hóa đơn
CREATE PROC USP_UpdateCountInBillInfo
    @billId INT, @foodId INT, @count INT
AS
    BEGIN
        UPDATE CHITIETHOADON SET SOLUONG = @count WHERE MAHOADON = @billId AND MAMONAN = @foodId
    END
GO

--Xóa hóa đơn theo mã món ăn
CREATE PROC USP_DeleteBillInfoByFoodId
    @foodid INT
AS
    BEGIN
        DELETE CHITIETHOADON WHERE MAMONAN = @foodid
    END
GO

                                        --TÀI: HÓA ĐƠN--
--Lấy hóa đơn theo bàn
CREATE PROC USP_GetBillByTable
    @tableId INT
AS
    BEGIN
        SELECT * FROM HOADON WHERE MABAN = @tableId AND THANHTIEN = 0
    END
GO

--Ghi hóa đơn
CREATE PROC USP_InsertBill
    @tableId INT, @employeeId VARCHAR(10), @dateIn DATE
AS
    BEGIN
        INSERT INTO HOADON (MABAN, MANHANVIEN, NGAYVAO, NGAYRA, GIAMGIA, THANHTIEN)
        VALUES (@tableId, @employeeId, @dateIn, NULL, 0, 0)
    END
GO

--Xóa hóa đơn
CREATE PROC USP_DeleteBill
    @billId INT
AS
    BEGIN
        EXEC USP_DeleteBillInfoByBill @billId
        DELETE HOADON WHERE MAHOADON = @billId
    END
GO

--Cập nhật lại mã bàn cho hóa đơn
CREATE PROC USP_UpdateTableIdForBill
    @tableId INT, @billId INT
AS
    BEGIN
        UPDATE HOADON SET MABAN = @tableId WHERE MAHOADON = @billId
    END
GO

--Cập nhật thành tiền cho hóa đơn
CREATE PROC USP_UpdateTotalForBill
    @billId INT, @total DECIMAL(12, 2)
AS
    BEGIN
        UPDATE HOADON SET THANHTIEN = @total WHERE MAHOADON = @billId
    END
GO

--Lấy danh sách hóa đơn theo ngày ra
CREATE PROC USP_GetListBillByDateOut
    @dateStart DATE, @dateEnd DATE
AS
    BEGIN
        SELECT * FROM HOADON WHERE NGAYRA >= @dateStart AND NGAYRA <= @dateEnd 
    END
GO
                                     -- Xử lý Trigger--
                                        --Chấm công--

--TIẾN: Kiểm tra (NGAYVAOLAM) của nhân viên phải lớn hơn ngày sinh (NGAYSINH)
CREATE TRIGGER CheckEmploymentStartDate
ON NHANVIEN
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @CountInvalidDates INT

    -- Tạo một bảng tạm thời để lưu trữ các dòng không hợp lệ
    CREATE TABLE #InvalidDates (MANHANVIEN VARCHAR(10))

    -- Kiểm tra ngày vào làm phải lớn hơn ngày sinh cho các dòng được thêm hoặc cập nhật
    INSERT INTO #InvalidDates (MANHANVIEN)
    SELECT I.MANHANVIEN
    FROM inserted AS I
    INNER JOIN NHANVIEN AS N ON I.MANHANVIEN = N.MANHANVIEN
    WHERE I.NGAYVAOLAM <= I.NGAYSINH

    -- Đếm số lượng dòng không hợp lệ
    SELECT @CountInvalidDates = COUNT(*) FROM #InvalidDates

    -- Nếu có dòng không hợp lệ, hủy bỏ thêm/cập nhật
    IF @CountInvalidDates > 0
    BEGIN
        ROLLBACK;
    END

    -- Xóa bảng tạm thời
    DROP TABLE #InvalidDates
END
GO

--CÔNG: Cập nhật lương cơ bản của nhân viên khi thay đổi chức vụ
CREATE TRIGGER Tr_UpdateSalaryOnPositionChange
ON TAIKHOAN
AFTER UPDATE
AS
BEGIN
    IF UPDATE(MaNhom)
    BEGIN
        UPDATE NV
        SET LUONGCOBAN = CASE
                            WHEN TK.MaNhom = (SELECT MaNhom FROM NhomQuyen WHERE TenNhom = N'Admin') THEN NV.LUONGCOBAN * 1.2
                            WHEN TK.MaNhom = (SELECT MaNhom FROM NhomQuyen WHERE TenNhom = N'Nhân viên') THEN NV.LUONGCOBAN / 1.2
                            ELSE NV.LUONGCOBAN
                         END
        FROM NHANVIEN NV
        INNER JOIN TAIKHOAN TK ON NV.MANHANVIEN = TK.MANHANVIEN
        INNER JOIN inserted ON TK.TENDANGNHAP = inserted.TENDANGNHAP;
    END;
END;
GO

--TÀI: Kiểm tra ngày vào phải nhỏ hơn ngày ra của hóa đơn
CREATE TRIGGER Tr_EnforceValidDateRange
ON HOADON
AFTER UPDATE
AS
BEGIN
    IF UPDATE (NGAYRA)
    BEGIN
        DECLARE @CountInvalidDates INT

        CREATE TABLE #InvalidDates (MAHOADON INT)

        INSERT INTO #InvalidDates (MAHOADON)
        SELECT I.MAHOADON
        FROM inserted AS I
        INNER JOIN HOADON AS H ON I.MAHOADON = H.MAHOADON
        WHERE H.NGAYVAO > I.NGAYRA

        -- Đếm số lượng dòng không hợp lệ
        SELECT @CountInvalidDates = COUNT(*) FROM #InvalidDates

        -- Nếu có dòng không hợp lệ, hủy bỏ thêm/cập nhật
        IF @CountInvalidDates > 0
        BEGIN
            ROLLBACK;        
        END

        -- Xóa bảng tạm thời
        DROP TABLE #InvalidDates
    END
END
GO

--TÀI: Cập nhật ngày ra cho hóa đơn khi cập nhật tổng tiền
CREATE TRIGGER UpdateDateOut
ON HOADON
FOR UPDATE
AS
BEGIN
    IF UPDATE(THANHTIEN)
    BEGIN
        UPDATE HOADON SET NGAYRA = GETDATE() WHERE MAHOADON = (SELECT MAHOADON FROM INSERTED)
    END
END
GO

--HUY: Số lượng chỗ ngồi khi thêm bàn ăn phải lớn hơn 0
CREATE TRIGGER TR_CheckQuanlityPeople
ON BAN
AFTER INSERT
AS
BEGIN
    DECLARE @SoLuongNguoi INT;

    SELECT @SoLuongNguoi = SOLUONGNGUOI FROM INSERTED;

    IF @SoLuongNguoi <= 0
    BEGIN
        ROLLBACK;
    END;
END;
GO
 
                                    --TO BE CONTINUED--