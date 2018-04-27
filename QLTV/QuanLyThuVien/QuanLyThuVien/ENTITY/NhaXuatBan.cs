using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.ENTITY
{
    class NhaXuatBan
    {
        private string id_nhaxuatban;

        public string ID_NhaXuatBan
        {
            get { return id_nhaxuatban; }
            set { id_nhaxuatban = value; }
        }
        private string tennxb;

        public string TenNXB
        {
            get { return tennxb; }
            set { tennxb = value; }
        }

        private string diachi;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string sdt;

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
    }
}
