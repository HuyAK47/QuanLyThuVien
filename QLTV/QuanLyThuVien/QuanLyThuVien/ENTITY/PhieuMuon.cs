using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.ENTITY
{
    class PhieuMuon
    {
        private string id_phieumuon;

        public string ID_PhieuMuon
        {
            get { return id_phieumuon; }
            set { id_phieumuon = value; }
        }
        private string id_nhanvien;

        public string ID_NhanVien
        {
            get { return id_nhanvien; }
            set { id_nhanvien = value; }
        }
        private string id_sinhvien;

        public string ID_SinhVien
        {
            get { return id_sinhvien; }
            set { id_sinhvien = value; }
        }
        private string ngaymuon;

        public string NgayMuon
        {
            get { return ngaymuon; }
            set { ngaymuon = value; }
        }
        private string ngaytra;

        public string NgayTra
        {
            get { return ngaytra; }
            set { ngaytra = value; }
        }
        private string hantra;

        public string HanTra
        {
            get { return hantra; }
            set { hantra = value; }
        }
        private string tienphat;

        public string TienPhat
        {
            get { return tienphat; }
            set { tienphat = value; }
        }
    }
}
