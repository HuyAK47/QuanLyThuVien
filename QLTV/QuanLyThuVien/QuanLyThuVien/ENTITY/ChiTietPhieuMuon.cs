using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.ENTITY
{
    class ChiTietPhieuMuon
    {
        private string id_chitietphieumuon;

        public string ID_ChiTietPhieuMuon
        {
            get { return id_chitietphieumuon; }
            set { id_chitietphieumuon = value; }
        }
        private string id_phieumuon;

        public string ID_PhieuMuon
        {
            get { return id_phieumuon; }
            set { id_phieumuon = value; }
        }
        private string id_sach;

        public string ID_Sach
        {
            get { return id_sach; }
            set { id_sach = value; }
        }
        private string soluong;

        public string SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private string trangthai;

        public string TrangThai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
