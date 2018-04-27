using QuanLyThuVien.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    class ChiTietPhieuMuon_Controler : sqlConnect
    {
        public void insertCTPhieuMuon(ChiTietPhieuMuon ct)
        {
            openConnection();
            string query = "insert into ChiTietPhieuMuon(IDctPhieuMuon, IDPhieuMuon, IDSach, SoLuong, TrangThai) values (@IDctPhieuMuon, @IDPhieuMuon, @IDSach, @SoLuong, @TrangThai)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDctPhieuMuon", ct.ID_ChiTietPhieuMuon);
            cmd.Parameters.AddWithValue("@IDPhieuMuon", ct.ID_PhieuMuon);
            cmd.Parameters.AddWithValue("@IDSach", ct.ID_Sach);
            cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
            cmd.Parameters.AddWithValue("@TrangThai", ct.TrangThai);
            cmd.ExecuteNonQuery();
        }
    }
}
