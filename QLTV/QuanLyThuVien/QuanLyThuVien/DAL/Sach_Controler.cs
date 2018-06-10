using QuanLyThuVien.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    class Sach_Controler : sqlConnect
    {
        public void insertSach(Sach s)
        {
            openConnection();
            string query = "insert into Sach(IDSach, TenSach, IDTheLoai, IDTacGia, IDNhaXuatBan, SoTrang, NamXB, SoLuong, NgonNgu, GiaNiemYet) values (@IDSach, @TenSach, @IDTheLoai, @IDTacGia, @IDNhaXuatBan, @SoTrang, @NamXB, @SoLuong, @NgonNgu, @GiaNiemYet)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDSach", s.ID_Sach);
            cmd.Parameters.AddWithValue("@TenSach", s.TenSach); 
            cmd.Parameters.AddWithValue("@IDTheLoai", s.ID_TheLoai);
            cmd.Parameters.AddWithValue("@IDTacGia", s.ID_TacGia);
            cmd.Parameters.AddWithValue("@IDNhaXuatBan", s.ID_NhaXuatBan);
            cmd.Parameters.AddWithValue("@SoTrang", s.SoTrang);
            cmd.Parameters.AddWithValue("@NamXB", s.NamXB);
            cmd.Parameters.AddWithValue("@SoLuong", s.SoLuong);
            cmd.Parameters.AddWithValue("@NgonNgu", s.NgonNgu);
            cmd.Parameters.AddWithValue("@GiaNiemYet", s.GiaNiemYet);
            cmd.ExecuteNonQuery();
        }

        public void editSach(Sach s)
        {
            openConnection();
            string query = "update Sach set TenSach = @TenSach, IDTheLoai = @IDTheLoai, IDTacGia = @IDTacGia, IDNhaXuatBan = @IDNhaXuatBan, SoTrang = @SoTrang, NamXB = @NamXB, SoLuong = @SoLuong, NgonNgu = @NgonNgu, GiaNiemYet = @GiaNiemYet, where IDSach = @IDSach";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDSach", s.ID_Sach);
            cmd.Parameters.AddWithValue("@TenSach", s.TenSach);
            cmd.Parameters.AddWithValue("@IDTheLoai", s.ID_TheLoai);
            cmd.Parameters.AddWithValue("@IDTacGia", s.ID_TacGia);
            cmd.Parameters.AddWithValue("@IDNhaXuatBan", s.ID_NhaXuatBan);
            cmd.Parameters.AddWithValue("@SoTrang", s.SoTrang);
            cmd.Parameters.AddWithValue("@NamXB", s.NamXB);
            cmd.Parameters.AddWithValue("@SoLuong", s.SoLuong);
            cmd.Parameters.AddWithValue("@NgonNgu", s.NgonNgu);
            cmd.Parameters.AddWithValue("@GiaNiemYet", s.GiaNiemYet);
            cmd.ExecuteNonQuery();
        }
        public void deleteSach(Sach s)
        {
            openConnection();
            string query = "delete Sach from IDSach = @MaSach";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@MaSach", s.ID_Sach);
            cmd.ExecuteNonQuery();
        }
    }
}
