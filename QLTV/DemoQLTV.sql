create database qlThuVien
go

use qlThuVien
go
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

create proc TK_Sach_TenTacGia( @TenTG nvarchar(30))
as
begin 
		select * from Sach , (select IDTacGia from TacGia where TenTG = @TenTG) as A
		where Sach.IDTacGia = A.IDTacGia 
end
-------------

create proc TK_Sach_NhaXuatBan( @TenNXB nvarchar(30))
as
begin 
		select * from Sach , (select IDNhaXuatBan from NhaXuatBan where TenNXB = @TenNXB) as A
		where Sach.IDNhaXuatBan = A.IDNhaXuatBan
end
-----------
create proc TK_Sach_TheLoai( @TenTheLoai nvarchar(30))
as
begin 
		select * from Sach , (select IDTheLoai from TheLoai where TenTheLoai = @TenTheLoai) as A
		where Sach.IDTheLoai = A.IDTheLoai
end
-----------

create proc TK_NhaXuatBan_SlSach( @TenNXB nvarchar(30))
as
begin 
		select B.IDNhaXuatBan, B.TenNXB , count (A.IDSach) as SoDauSach
		from  (select IDSach, IDNhaXuatBan from Sach) as A, (select IDNhaXuatBan, TenNXB from NhaXuatBan where TenNXB = @TenNXB)  as B
		where A.IDNhaXuatBan = B.IDNhaXuatBan
		group by B.IDNhaXuatBan, B.TenNXB
end
----------
create proc TK_TacGia_SlSach( @TenTG nvarchar(30))
as
begin 
		select B.IDTacGia, B.TenTG , count (A.IDSach) as SoDauSach
		from  (select IDSach, IDTacGia from Sach) as A, (select IDTacGia, TenTG from TacGia where TenTG = @TenTG)  as B
		where A.IDTacGia = B.IDTacGia
		group by B.IDTacGia, B.TenTG
end
----------

create proc TK_TheLoai_SlSach( @TenTheLoai nvarchar(30))
as
begin 
		select B.IDTheLoai, B.TenTheLoai , count (A.IDSach) as SoDauSach
		from  (select IDSach, IDTheLoai from Sach) as A, (select IDTheLoai, TenTheLoai from TheLoai where TenTheLoai = @TenTheLoai)  as B
		where A.IDTheLoai = B.IDTheLoai
		group by B.IDTheLoai, B.TenTheLoai
end

-------
create proc [dbo].[Tk_Sv_NgayMuon] ( @NgayMuon date )
 as
 begin
		select SinhVien.*,  PhieuMuon.NgayTra from SinhVien,PhieuMuon
		where PhieuMuon.NgayMuon  = @NgayMuon
end

------------
create proc [dbo].[Tk_Sv_NgayTra] ( @NgayTra date )
 as
 begin
		select SinhVien.*,  PhieuMuon.NgayTra from SinhVien,PhieuMuon
		where PhieuMuon.NgayTra  = @NgayTra
end 
