create table NhanVien(
IDNhanVien nvarchar(10) primary key,
HoTen nvarchar(30),
NgaySinh date,
Luong money,
SDT nvarchar(11),
Email nvarchar(30),
GioiTinh nvarchar(3),
DiaChi nvarchar(30),
)
go

create table NhaXuatBan(
IDNhaXuatBan nvarchar(10) primary key,
TenNXB nvarchar(30),
DiaChi nvarchar(30),
SDT nvarchar(11),
)
go

create table SinhVien(
IDSinhVien nvarchar(10) primary key,
TenSV nvarchar(30),
GioiTinh nvarchar(3),
NgaySinh date,
DiaChi nvarchar(50),
SDT nvarchar(11),
Email nvarchar(30),
HanThe date
)
go

create table TacGia(
IDTacGia nvarchar(10) primary key,
TenTG nvarchar(30),
HocVi nvarchar(20)
)
go

create table TheLoai(
IDTheLoai nvarchar(10) primary key,
TenTheLoai nvarchar(20)
)
go

create table PhieuMuon(
IDPhieuMuon nvarchar(10) primary key,
IDNhanVien nvarchar(10) references NhanVien(IDNhanVien),
IDSinhVien nvarchar(10) references SinhVien(IDSinhVien),
NgayMuon date,
NgayTra date,
HanTra date,
TienPhat money,
)
go

create table Sach(
IDSach nvarchar(10) primary key,
TenSach nvarchar(30),
IDTheLoai nvarchar(10) references TheLoai(IDTheLoai),
IDTacGia nvarchar(10) references TacGia(IDTacGia),
IDNhaXuatBan nvarchar(10) references NhaXuatBan(IDNhaXuatBan),
SoTrang int,
NamXB date,
SoLuong int,
NgonNgu nvarchar(15),
GiaNiemYet money
)
go

create table ChiTietPhieuMuon(
IDctPhieuMuon nvarchar(10) primary key,
IDPhieuMuon nvarchar(10) references PhieuMuon(IDPhieuMuon),
IDSach nvarchar(10) references Sach(IDSach),
SoLuong int,
TrangThai bit
)
go


