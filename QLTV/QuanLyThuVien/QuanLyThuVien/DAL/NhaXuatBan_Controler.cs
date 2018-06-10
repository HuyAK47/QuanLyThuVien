using QuanLyThuVien.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    class NhaXuatBan_Controler : sqlConnect
    {
        public void insertNhanXuatBan(NhaXuatBan nxb)
        {
            openConnection();
            string query = "insert into NhaXuatBan(IDNhaXuatBan, TenNXB, DiaChi, SDT) values (@IDNhaXuatBan, @TenNXB, @DiaChi, @SDT)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDNhaXuatBan", nxb.ID_NhaXuatBan);
            cmd.Parameters.AddWithValue("@TenNXB", nxb.TenNXB);
            cmd.Parameters.AddWithValue("@DiaChi", nxb.DiaChi);
            cmd.Parameters.AddWithValue("@SDT", nxb.SDT);
            cmd.ExecuteNonQuery();
        }

        public void editNhanXuatBan(NhaXuatBan nxb)
        {
            openConnection();
            string query = "update NhaXuatBan set TenNXB = @TenNXB, DiaChi =  @DiaChi, SDT = @SDT where IDNhaXuatBan = @IDNhaXuatBan";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDNhaXuatBan", nxb.ID_NhaXuatBan);
            cmd.Parameters.AddWithValue("@TenNXB", nxb.TenNXB);
            cmd.Parameters.AddWithValue("@DiaChi", nxb.DiaChi);
            cmd.Parameters.AddWithValue("@SDT", nxb.SDT);
            cmd.ExecuteNonQuery();
        }
        public void deleteNhaXuatBan(NhaXuatBan nxb)
        {
            openConnection();
            string query = "delete NhaXuatBan from IDNhaXuatBan = @MaNXB";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@MaNXB", nxb.ID_NhaXuatBan);
            cmd.ExecuteNonQuery();
        }
    }
}
