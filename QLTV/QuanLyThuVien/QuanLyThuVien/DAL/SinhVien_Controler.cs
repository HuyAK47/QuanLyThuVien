using QuanLyThuVien.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    class SinhVien_Controler : sqlConnect
    {
        public void insertSinhVien(SinhVien sv)
        {
            openConnection();
            string query = "insert into SinhVien(IDSinhVien, TenSV, GioiTinh, NgaySinh, DiaChi, SDT, Email, HanThe) values (@IDSinhVien, @TenSV, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @Email, @HanThe)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDSinhVien", sv.ID_SinhVien);
            cmd.Parameters.AddWithValue("@TenSV", sv.HoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
            cmd.Parameters.AddWithValue("@DiaChi", sv.DiaChi);
            cmd.Parameters.AddWithValue("@SDT", sv.SDT);
            cmd.Parameters.AddWithValue("@Email", sv.Email);
            cmd.Parameters.AddWithValue("@HanThe", sv.HanThe);
            cmd.ExecuteNonQuery();
        }
    }
}
