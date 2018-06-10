using QuanLyThuVien.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    class NhanVien_Controler : sqlConnect
    {
        public void insertNhanVien(NhanVien nv)
        {
            openConnection();
            string query = "insert into NhanVien(IDNhanVien, HoTen, NgaySinh, Luong, SDT, Email, GioiTinh, DiaChi) values (@IDNhanVien, @HoTen, @NgaySinh, @Luong, @SDT, @Email, @GioiTinh, @DiaChi)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDNhanVien", nv.ID_NhanVien);
            cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
            cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
            cmd.Parameters.AddWithValue("@Luong", nv.Luong);
            cmd.Parameters.AddWithValue("@SDT", nv.SDT);
            cmd.Parameters.AddWithValue("@Email", nv.Email);
            cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
            cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            cmd.ExecuteNonQuery();
        }

        public void editNhanVien(NhanVien nv)
        {
            openConnection();
            string query = "update NhanVien set HoTen = @HoTen, NgaySinh = @NgaySinh, Luong = @Luong, SDT = @SDT, Email = @Email, GioiTinh = @GioiTinh, DiaChi = @DiaChi where IDNhanVien = @IDNhanVien";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDNhanVien", nv.ID_NhanVien);
            cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
            cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
            cmd.Parameters.AddWithValue("@Luong", nv.Luong);
            cmd.Parameters.AddWithValue("@SDT", nv.SDT);
            cmd.Parameters.AddWithValue("@Email", nv.Email);
            cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
            cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            cmd.ExecuteNonQuery();
        }
        public void deleteNhanVien(NhanVien nv)
        {
            openConnection();
            string query = "delete NhanVien from IDNhanVien = @MaNV";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@MaNV", nv.ID_NhanVien);
            cmd.ExecuteNonQuery();
        }
    }
}
