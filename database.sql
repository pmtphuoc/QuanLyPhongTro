create database QuanLyPhongTro
use QuanLyPhongTro
set dateformat dmy
create table LoaiPhong
(
	IdLoaiPhong int primary key,
	LoaiPhong nvarchar(20),
	SoTien int,
)
create table Phong
(
	SoPhong int primary key,
	IdLoaiPhong int,
	TrangThai nvarchar(20),
	foreign key (IdLoaiPhong) references LoaiPhong(IdLoaiPhong)
)

create table  KhachHang
(
	Id_KhachHang nvarchar(10) primary key,
	HoTen nvarchar(50),
	DiaChi nvarchar(300),
	SoDienThoai varchar(10),
	Email varchar(50),
	NgaySinh date,
	NgheNghiep nvarchar(50),
	SoPhong int,
	NgayThue date,
	CMND varchar(20),
	NoiCap nvarchar(20),
	BienSoXe nvarchar(20),
	DatCoc int,
	PhongTruong varchar(5)
	foreign key (SoPhong) references Phong(SoPhong)
)

create table VeGuiXe
(
	STT int primary key,
	BienSoXe nvarchar(20),
	Id_KhachHang nvarchar(10),
	NgayMua date,
	HanSuDung date,
	foreign key (Id_KhachHang) references KhachHang(Id_KhachHang)
)

create table TraPhong
(
	STT int identity(1,1) primary key,
	Id_KhachHang nvarchar(10),
	NgayTra date,
	foreign key (Id_KhachHang) references KhachHang(Id_KhachHang)
)
create table DichVu
(
	MaDV int identity (1,1) primary key,
	TenDichVu nvarchar(20),
	SoTien int
)
insert into DichVu  values(N'Nước',10000),(N'Điện',3500)
select* from KhachHang
select LoaiPhong.SoTien from LoaiPhong,Phong where Phong.IdLoaiPhong = LoaiPhong.IdLoaiPhong and Phong.SoPhong=1
select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang where Id_KhachHang = 'KH01'
create table Dien
(
	STT int identity(1,1) primary key,
	SoPhong int,
	CsThangTruoc float,
	CsThangNay float,
	Ngayghi date,
	foreign key (SoPhong) references Phong(SoPhong)
)
--select *from Dien where YEAR(Ngayghi)=2021 and MONTH(Ngayghi)=12
--select 'Số Phòng'=Nuoc.SoPhong,'Tình Trạng'=Phong.TrangThai,'Cs Tháng Trước'=CsThangNay,'Cs Tháng Này'='' from Nuoc,Phong where MONTH(Ngayghi)=1 and YEAR(Nuoc.Ngayghi) = 2022 and Nuoc.SoPhong=Phong.SoPhong
--update Dien set CsThangNay where YEAR(Ngayghi)=2022 and MONTH(Ngayghi)=1 and DAY(Ngayghi)<=10 and SoPhong=2
--select 'Số Phòng'=Dien.SoPhong,'Tình Trạng'=Phong.TrangThai,'Cs Tháng Trước'=CsThangNay,'Cs Tháng Này'='' from Dien,Phong where MONTH(Ngayghi)=12 and YEAR(Dien.Ngayghi) = 2021 and Dien.SoPhong=Phong.SoPhong
create table Nuoc
(
	STT int identity(1,1) primary key,
	SoPhong int,
	CsThangTruoc float,
	CsThangNay float,
	Ngayghi date,
	foreign key (SoPhong) references Phong(SoPhong)
)

create table NhanVien
(
	MaNV varchar(10) primary key,
	HoTen nvarchar(50),
	DiaChi nvarchar(300),
	SoDienThoai varchar(10),
	Email varchar(50),
	NgaySinh date,
	CMND varchar(20),
	NoiCap nvarchar(20),
	BienSoXe nvarchar(20),
	image text
)

create table HoaDon
(
	MaHD varchar(20) primary key,
	NgayThanhToan date,
	MaNV varchar(10),
	Id_KhachHang nvarchar(10)
	foreign key (MaNV) references NhanVIen(MaNV),
	foreign key (Id_KhachHang) references KhachHang(Id_KhachHang)
)

create table DangNhap
(
	MaDN int identity(1,1) primary key,
	TaiKhoan varchar(20),
	MatKhau varchar(20),
	LoaiTk nvarchar(20),
	MaNV varchar(10)
	foreign key (MaNV) references NhanVIen(MaNV),
)

insert into NhanVien values
('NV01',N'Hà Anh Tuấn',N'Việt Nam','096548365','haanhtuan@gmail.com','10/10/2000','06974668753',N'Việt Nam','52B-012345',''),
('NV02',N'Nguyễn Minh Nhật',N'Việt Nam','096548365','nguyenminhnhat@gmail.com','05/04/1997','06974668753',N'Việt Nam','79C1-03800','')
insert into DangNhap values ('user','user',N'user','NV01'),('admin','admin',N'admin','NV02')

insert into LoaiPhong values (1,N'Phòng Vip',3500000), (2,N'Phòng Thương',2500000)
insert into Phong values
(1,1,N'Trống'),
(2,1,N'Trống'),
(3,1,N'Trống'),
(4,1,N'Trống'),
(5,1,N'Trống'),
(6,1,N'Trống'),
(7,1,N'Trống'),
(8,1,N'Trống'),
(9,1,N'Trống'),
(10,2,N'Trống'),
(11,2,N'Trống'),
(12,2,N'Trống'),
(13,2,N'Trống'),
(14,2,N'Trống'),
(15,2,N'Trống'),
(16,2,N'Trống'),
(17,2,N'Trống'),
(18,2,N'Trống'),
(19,2,N'Trống'),
(20,2,N'Trống')

insert into KhachHang values
('KH13',N'máhgdjadwa',N'Cam phúc nam - Cam Ranh - Khánh Hòa','0975661107','nguyenminhnhat97dc@gmail.com','05/04/1997',N'Sinh viên',1,'14/12/2021',056097010078,N'Khánh Hòa','79C1-03800','','no'),
('KH14',N'dvxcvf',N'Cam phúc nam - Cam Ranh - Khánh Hòa','0975661107','nguyenminhnhat97dc@gmail.com','05/04/1997',N'Sinh viên',1,'14/12/2021',056097010078,N'Khánh Hòa','79C1-03800','','no')

insert into KhachHang values
('KH01',N'Nguyễn Minh Nhật',N'Cam phúc nam - Cam Ranh - Khánh Hòa','0975661107','nguyenminhnhat97dc@gmail.com','05/04/1997',N'Sinh viên',1,'14/12/2021',056097010078,N'Khánh Hòa','79C1-03800','','yes'),
('KH02',N'Hà Anh Tuấn',N' Đức Trọng - Lâm Đồng','0973156482','haanhtuan@gmail.com','06/02/2001',N'Sinh viên',2,'14/11/2021',056097010078,N'Lâm Đồng','79C1-03800','','yes'),
('KH03',N'Phạm Minh Tiến Phước',N'Việt Nam','0954216587','phuocprovipmaximum@gmail.com','01/01/2001',N'Sinh viên',3,'14/10/2020',84548783548,N'Việt Nam','79C1-03800','','yes'),
('KH04',N'Trần Bắc Huyền',N'Trung Quốc','0954215687','tranbachuyen@gmail.com','03/02/1990',N'Kỹ sư',4,'12/10/2021',354648654,N'Trung Quốc','79C1-03800','','yes'),
('KH05',N'Cổ Trần',N'Hồ Chí Minh','0975621486','cotran@gmail.com','10/06/1995',N'Sinh viên',8,'03/08/2019',854621458,N'Hồ Chí Minh','79C1-03800','','yes'),
('KH06',N'Ngô Mạnh Đạt',N'Hà Nội','0563698547','ngomanhdat@gmail.com','22/02/1998',N'Sinh viên',10,'15/08/2020',64867127895,N'Hà Nội','79C1-03800','','yes'),
('KH07',N'Cổ Trần Sa',N'Đà Nẵng','0975614587','cotransa@gmail.com','30/03/2001',N'Sinh viên',12,'25/10/2020',3578624687,N'Đà Nẵng','79C1-03800','','yes'),
('KH08',N'Trần Đan Thư',N'Nghệ An','097123658','trandanthu@gmail.com','10/10/2000',N'Sinh viên',15,'14/12/2021',384864864863,N'Nghệ An','79C1-03800','','yes'),
('KH09',N'Phan Thanh Hiền',N'Quãng Ngãi','038456258','phanthanhhien@gmail.com','11/01/2000',N'Sinh viên',19,'14/12/2021',3543831289,N'Quãng Ngãi','79C1-03800','','yes'),
('KH10',N'Minh Niệm',N'Quãng Nam','096521456','minhniem@gmail.com','23/11/2002',N'Sinh viên',17,'14/12/2021',3593265943,N'Quãng Nam','79C1-03800','','yes')


insert into Dien values
(1,10,20,'17/11/2021'),
(2,15.5,30.2,'17/11/2021'),
(3,11.3,25.6,'17/11/2021'),
(4,5,9,'17/11/2021'),
(5,30,30,'17/11/2021'),
(6,8,8,'17/11/2021'),
(7,8,8,'17/11/2021'),
(8,13,26,'17/11/2021'),
(9,4,4,'17/11/2021'),
(10,14,28,'17/11/2021'),
(11,11,11,'17/11/2021'),
(12,12,24,'17/11/2021'),
(13,30,30,'17/11/2021'),
(14,26,26,'17/11/2021'),
(15,27,54,'17/11/2021'),
(16,7,7,'17/11/2021'),
(17,16,32,'17/11/2021'),
(18,9,9,'17/11/2021'),
(19,28,56,'17/11/2021'),
(20,10,20,'17/11/2021'),

(1,20,35,'17/12/2021'),
(2,30.2,50.2,'17/12/2021'),
(3,25.6,35,'17/12/2021'),
(4,5,9,'17/12/2021'),
(5,30,60,'17/12/2021'),
(6,8,36,'17/12/2021'),
(7,8,10,'17/12/2021'),
(8,26,35,'17/12/2021'),
(9,4,20,'17/12/2021'),
(10,28,60,'17/12/2021'),
(11,11,28,'17/12/2021'),
(12,24,35,'17/12/2021'),
(13,30,43,'17/12/2021'),
(14,26,40,'17/12/2021'),
(15,54,60,'17/12/2021'),
(16,7,22,'17/12/2021'),
(17,32,55,'17/12/2021'),
(18,9,39,'17/12/2021'),
(19,56,80,'17/12/2021'),
(20,20,50,'17/12/2021')

insert into Nuoc values
(1,0,10,'17/11/2021'),
(2,0,11,'17/11/2021'),
(3,0,12,'17/11/2021'),
(4,0,13,'17/11/2021'),
(5,0,9,'17/11/2021'),
(6,0,14,'17/11/2021'),
(7,0,15,'17/11/2021'),
(8,0,14,'17/11/2021'),
(9,0,11,'17/11/2021'),
(10,0,13,'17/11/2021'),
(11,0,16,'17/11/2021'),
(12,0,5,'17/11/2021'),
(13,0,8,'17/11/2021'),
(14,0,11,'17/11/2021'),
(15,0,12,'17/11/2021'),
(16,0,12,'17/11/2021'),
(17,0,5,'17/11/2021'),
(18,0,8,'17/11/2021'),
(19,0,10,'17/11/2021'),
(20,0,16,'17/11/2021'),

(1,10,20,'17/12/2021'),
(2,11,22,'17/12/2021'),
(3,12,24,'17/12/2021'),
(4,13,26,'17/12/2021'),
(5,9,18,'17/12/2021'),
(6,14,28,'17/12/2021'),
(7,15,30,'17/12/2021'),
(8,14,28,'17/12/2021'),
(9,11,22,'17/12/2021'),
(10,13,26,'17/12/2021'),
(11,16,30,'17/12/2021'),
(12,5,10,'17/12/2021'),
(13,8,16,'17/12/2021'),
(14,11,22,'17/12/2021'),
(15,12,24,'17/12/2021'),
(16,12,24,'17/12/2021'),
(17,5,10,'17/12/2021'),
(18,8,16,'17/12/2021'),
(19,10,20,'17/12/2021'),
(20,16,32,'17/12/2021')
select * from Phong
update  Phong Set TrangThai = N'Trống' where SoPhong=6
insert into HoaDon values ('HD27122101','2021/12/27','NV01','KH01')
update  Phong Set TrangThai = 'Full' where SoPhong=1
update  Phong Set TrangThai = 'Full' where SoPhong=2
update  Phong Set TrangThai = 'Full' where SoPhong=3
update  Phong Set TrangThai = 'Full' where SoPhong=4
update  Phong Set TrangThai = 'Full' where SoPhong=8
update  Phong Set TrangThai = 'Full' where SoPhong=10
update  Phong Set TrangThai = 'Full' where SoPhong=12
update  Phong Set TrangThai = 'Full' where SoPhong=15
update  Phong Set TrangThai = 'Full' where SoPhong=19
update  Phong Set TrangThai = 'Full' where SoPhong=17

update KhachHang Set DatCoc=50000 where Id_KhachHang='KH01'
update KhachHang Set DatCoc=50000 where Id_KhachHang='KH02'
update KhachHang Set DatCoc=50000 where Id_KhachHang='KH03'
update KhachHang Set DatCoc=50000 where Id_KhachHang='KH04'
update KhachHang Set DatCoc=50000 where Id_KhachHang='KH05'
update KhachHang Set DatCoc=50000 where Id_KhachHang='KH06'
update KhachHang Set DatCoc=50000 where Id_KhachHang='KH07'
update KhachHang Set DatCoc=50000 where Id_KhachHang='KH08'
update KhachHang Set DatCoc=50000 where Id_KhachHang='KH09'
update KhachHang Set DatCoc=50000 where Id_KhachHang='KH10'

create function AutoMANV()
RETURNS varchar(10)
as
begin
	Declare @CountNV int
	Declare @KetQua varchar(20)
	set @CountNV =  (select count(MaNV) from NhanVien)
	if @CountNV >=10
		set @KetQua = CONCAT('NV',@CountNV+1)
	else
		set @KetQua = CONCAT('NV0',@CountNV+1)
	return @KetQua
end
select dbo.AutoMaNV()
create function AutoMAKH()
RETURNS varchar(10)
as
begin
	Declare @CountKh int
	Declare @KetQua varchar(20)
	set @CountKh =  (select count(Id_KhachHang) from KhachHang)
	if @CountKh >=10
		set @KetQua = CONCAT('KH',@CountKh+1)
	else
		set @KetQua = CONCAT('KH0',@CountKh+1)
	return @KetQua
end

create function AutoMAHD()
RETURNS varchar(10)
as
begin
	Declare @CountKh int
	Declare @KetQua varchar(20)
	set @CountKh =  (select count(MaHD) from HoaDon)
	if @CountKh >=10
		set @KetQua = CONCAT('HD',DAY(GETDATE()),MONTH(GETDATE()),RIGHT(YEAR(GETDATE()), 2),@CountKh+1)
	else
		set @KetQua = CONCAT('HD',DAY(GETDATE()),MONTH(GETDATE()),RIGHT(YEAR(GETDATE()), 2),'0',@CountKh+1)
	return @KetQua
end
select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang where SoPhong=1
select Phong.SoPhong,Phong.TrangThai,LoaiPhong.SoTien from Phong,LoaiPhong where Phong.IdLoaiPhong=LoaiPhong.IdLoaiPhong
update Phong set TrangThai=N'Trống' where SoPhong=16
select HoTen,Id_KhachHang  from KhachHang where KhachHang.PhongTruong = 'yes' and KhachHang.SoPhong = 16
select Phong.SoPhong,Phong.TrangThai,KhachHang.HoTen,KhachHang.Id_KhachHang,LoaiPhong.SoTien,KhachHang.PhongTruong from(( Phong Full join KhachHang on Phong.SoPhong = KhachHang.SoPhong) full join LoaiPhong on Phong.IdLoaiPhong = LoaiPhong.IdLoaiPhong) 
 create function gomphong1(@sophong int)
 returns varchar(10)
 begin
 DECLARE @id VARCHAR(10);
 set @id=(select top(1) Id_KhachHang from KhachHang where SoPhong=@sophong)
 return @id
 end;

  create function gomphong2(@sophong int)
 returns varchar(10)
 begin
 DECLARE @id VARCHAR(10);
 set @id=(select SoPhong from Phong where SoPhong=@sophong)
 return @id
 end;

select * from KhachHang
select * from HoaDon
select * from HoaDon where Id_KhachHang='KH01' and MONTH(NgayThanhToan) = GETDATE()
select * from Phong Full outer join KhachHang on Phong.SoPhong=KhachHang.SoPhong
update KhachHang set SoPhong=1 where Id_KhachHang = 'KH01'
select Phong.SoPhong,Phong.TrangThai,KhachHang.HoTen,KhachHang.Id_KhachHang,LoaiPhong.SoTien from(( Phong Full join KhachHang on Phong.SoPhong = KhachHang.SoPhong) full join LoaiPhong on Phong.IdLoaiPhong = LoaiPhong.IdLoaiPhong)
select * from DichVu
select Dien.SoPhong,'Tiền Phòng'=LoaiPhong.SoTien,'CS Điện'=Dien.CsThangNay-Dien.CsThangTruoc,'Tiền Điện'=Round((Dien.CsThangNay-Dien.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Điện'),0),'Cs Nước'=Nuoc.CsThangNay-Nuoc.CsThangTruoc,'Tiền Nước'=Round((Nuoc.CsThangNay-Nuoc.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Nước'),0),Dien.Ngayghi from Dien,Nuoc,Phong,LoaiPhong,KhachHang where MONTH(Nuoc.Ngayghi)='11' and MONTH(Dien.Ngayghi)='11' and Dien.SoPhong=Nuoc.SoPhong and Phong.IdLoaiPhong=LoaiPhong.IdLoaiPhong and Dien.SoPhong=Phong.SoPhong and KhachHang.SoPhong=Phong.SoPhong and KhachHang.Id_KhachHang='KH01'
select * from Phong
select dbo.AutoMAHD()
select dbo.AutoMaKH()
select * from KhachHang
select KhachHang.Id_KhachHang,HoTen,DiaChi,SoDienThoai,Email,NgaySinh,NgheNghiep,KhachHang.SoPhong,LoaiPhong.SoTien,NgayThue,CMND,NoiCap,BienSoXe,DatCoc from KhachHang,Phong,LoaiPhong where KhachHang.SoPhong=Phong.SoPhong and Phong.IdLoaiPhong=LoaiPhong.IdLoaiPhong
select 'Phòng Số' =Nuoc.SoPhong,'Cs Nước Tháng Trước'= Nuoc.CsThangTruoc, 'Cs Nước Tháng này'=Nuoc.CsThangNay,'Số Kg Nước Tháng này'=Round(Nuoc.CsThangNay-Nuoc.CsThangTruoc,1),'Tiền Nước tháng này' =Round( (Nuoc.CsThangNay - Nuoc.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Nước'),0), 'Đơn Vị'='VNĐ','Ngày Nhập'=Ngayghi from Nuoc where MONTH(Nuoc.Ngayghi)='11' and YEAR(Nuoc.Ngayghi) = '2021'
select Dien.SoPhong,CsThangTruoc,'Cs tháng này'='','Tình Trạng'=Phong.TrangThai from Dien,Phong where MONTH(Ngayghi)='11' and Dien.SoPhong=Phong.SoPhong
select 'Phòng Số' =Dien.SoPhong,'Cs Điện Tháng Trước'= Dien.CsThangTruoc, 'Cs Điên Tháng này'=Dien.CsThangNay,'Số Kg Điện Tháng này'=Round(Dien.CsThangNay-Dien.CsThangTruoc,1),'Tiền điện tháng này' =Round( (Dien.CsThangNay - Dien.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Điện'),0), 'Đơn Vị'='VNĐ' from Dien where MONTH(Dien.Ngayghi)='11' and YEAR(Dien.Ngayghi) = '2021'
select Phong.SoPhong,Phong.TrangThai,KhachHang.HoTen,KhachHang.Id_KhachHang,LoaiPhong.SoTien from(( Phong Full join KhachHang on Phong.SoPhong = KhachHang.SoPhong) full join LoaiPhong on Phong.IdLoaiPhong = LoaiPhong.IdLoaiPhong)
select 'Id' = Id_KhachHang,'Họ Tên' = HoTen,'Nghề Nghiệp'=NgheNghiep,'Số Điện Thoại'=SoDienThoai,CMND,Email,'Ngày Thuê'=NgayThue,'Biển Số Xe'=BienSoXe from KhachHang
select Phong.SoPhong, Phong.TrangThai,KhachHang.HoTen, LoaiPhong.SoTien from Phong,KhachHang,LoaiPhong where Phong.IdLoaiPhong=LoaiPhong.IdLoaiPhong and Phong.SoPhong=KhachHang.SoPhong
select * from Dien where MONTH(Ngayghi)='11'
select * from Nuoc where MONTH(Ngayghi)='11'
select Dien.SoPhong,'Tiền Phòng'=LoaiPhong.SoTien,'CS Điện'=Dien.CsThangNay-Dien.CsThangTruoc,'Tiền Điện'=Round((Dien.CsThangNay-Dien.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Điện'),0),'Cs Nước'=Nuoc.CsThangNay-Nuoc.CsThangTruoc,'Tiền Nước'=Round((Nuoc.CsThangNay-Nuoc.CsThangTruoc)*(select SoTien from DichVu where TenDichVu=N'Nước'),0),Dien.Ngayghi from Dien,Nuoc,Phong,LoaiPhong,KhachHang where MONTH(Nuoc.Ngayghi)='11' and MONTH(Dien.Ngayghi)='11' and Dien.SoPhong=Nuoc.SoPhong and Phong.IdLoaiPhong=LoaiPhong.IdLoaiPhong and Dien.SoPhong=Phong.SoPhong and KhachHang.SoPhong=Phong.SoPhong and KhachHang.Id_KhachHang='KH02'

select Dien.SoPhong,'CS Điện'=Dien.CsThangNay,'Cs Nước'=Nuoc.CsThangNay,Dien.Ngayghi from Dien Full OUTER JOIN Nuoc on Dien.SoPhong=Nuoc.SoPhong where MONTH(Nuoc.Ngayghi)='11' and MONTH(Dien.Ngayghi)='11'
select * from Phong,KhachHang where Phong.SoPhong=KhachHang.SoPhong
select HoTen from NhanVien where MaNV='NV01'
select Id_KhachHang,HoTen,CMND,SoDienThoai from KhachHang where Id_KhachHang='KH01';

select * from Phong Full outer join KhachHang on Phong.SoPhong=KhachHang.SoPhong

--update KhachHang set SoPhong=Null where Sophong=1
--delete from Phong where SoPhong=1
