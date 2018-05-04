using QuanLyThuVien.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    class TacGia_Controler : sqlConnect
    {
        public void insertTacGia(TacGia tg)
        {
            openConnection();
            string query = "insert into TacGia(IDTacGia, TenTG, HocVi) values (@IDTacGia, @TenTG, @HocVi)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDTacGia", tg.ID_TacGia);
            cmd.Parameters.AddWithValue("@TenTG", tg.TenTacGia);
            cmd.Parameters.AddWithValue("@HocVi", tg.HocVi);
            cmd.ExecuteNonQuery();
        }

        public void editTacGia(TacGia tg)
        {
            openConnection();
            string query = "update TacGia set TenTG = @TenTG, HocVi = @HocVi where IDTacGia = @IDTacGia";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDTacGia", tg.ID_TacGia);
            cmd.Parameters.AddWithValue("@TenTG", tg.TenTacGia);
            cmd.Parameters.AddWithValue("@HocVi", tg.HocVi);
            cmd.ExecuteNonQuery();
        }
    }
}
