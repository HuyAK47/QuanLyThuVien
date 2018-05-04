using QuanLyThuVien.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    class TheLoai_Controler : sqlConnect
    {
        public void insertTheLoai(TheLoai tl)
        {
            openConnection();
            string query = "insert into TheLoai(IDTheLoai, TenTheLoai) values (@IDTheLoai, @TenTheLoai)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDTheLoai", tl.ID_TheLoai);
            cmd.Parameters.AddWithValue("@TenTheLoai", tl.TenTheLoai);
            cmd.ExecuteNonQuery();
        }

        public void editTheLoai(TheLoai tl)
        {
            openConnection();
            string query = "update TheLoai set TenTheLoai = @TenTheLoai where IDTheLoai = @IDTheLoai";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDTheLoai", tl.ID_TheLoai);
            cmd.Parameters.AddWithValue("@TenTheLoai", tl.TenTheLoai);
            cmd.ExecuteNonQuery();
        }
    }
}
