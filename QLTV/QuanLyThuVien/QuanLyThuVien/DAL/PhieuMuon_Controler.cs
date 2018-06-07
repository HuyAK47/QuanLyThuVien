using QuanLyThuVien.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    class PhieuMuon_Controler : sqlConnect
    {
        public void insertPhieuMuon(PhieuMuon pm)
        {
            openConnection();
            string query = "insert into PhieuMuon(IDPhieuMuon, IDNhanVien, IDSinhVien, NgayMuon, NgayTra, HanTra, TienPhat) values (@IDPhieuMuon, @IDNhanVien, @IDSinhVien, @NgayMuon, @NgayTra, @HanTra, @TienPhat)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDPhieuMuon", pm.ID_PhieuMuon);
            cmd.Parameters.AddWithValue("@IDNhanVien", pm.ID_NhanVien);
            cmd.Parameters.AddWithValue("@IDSinhVien", pm.ID_SinhVien);
            cmd.Parameters.AddWithValue("@NgayMuon", pm.NgayMuon);
            cmd.Parameters.AddWithValue("@NgayTra", pm.NgayTra);
            cmd.Parameters.AddWithValue("@HanTra", pm.HanTra);
            cmd.Parameters.AddWithValue("@TienPhat", pm.TienPhat);
            cmd.ExecuteNonQuery();
        }

        public void editPhieuMuon(PhieuMuon pm)
        {
            openConnection();
            string query = "update PhieuMuon set IDNhanVien = @IDNhanVien, IDSinhVien =@IDSinhVien, NgayMuon = @NgayMuon, NgayTra =@NgayTra, HanTra = @HanTra, TienPhat = @TienPhat where IDPhieuMuon = @IDPhieuMuon";
            SqlCommand cmd = new SqlCommand(query, Conn);
 //           SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.AddWithValue("@IDPhieuMuon", pm.ID_PhieuMuon);
            cmd.Parameters.AddWithValue("@IDNhanVien", pm.ID_NhanVien);
            cmd.Parameters.AddWithValue("@IDSinhVien", pm.ID_SinhVien);
            cmd.Parameters.AddWithValue("@NgayMuon", pm.NgayMuon);
            cmd.Parameters.AddWithValue("@NgayTra", pm.NgayTra);
            cmd.Parameters.AddWithValue("@HanTra", pm.HanTra);
            cmd.Parameters.AddWithValue("@TienPhat", pm.TienPhat);
            cmd.ExecuteNonQuery();
        }
    }
}
