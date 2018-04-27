using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.ENTITY
{
    class NhanVien
    {
        private string id_nhanvien;

        public string ID_NhanVien
        {
            get { return id_nhanvien; }
            set { id_nhanvien = value; }
        }
        private string hoten;

        public string HoTen
        {
            get { return hoten; }
            set { hoten = value; }
        }
        private string ngaysinh;

        public string NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        private string luong;

        public string Luong
        {
            get { return luong; }
            set { luong = value; }
        }
        private string sdt;

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string gioitinh;

        public string GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        private string diachi;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
    }
}
