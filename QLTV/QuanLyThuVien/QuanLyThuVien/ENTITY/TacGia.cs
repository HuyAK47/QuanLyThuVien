using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.ENTITY
{
    class TacGia
    {
        private string id_tacgia;

        public string ID_TacGia
        {
            get { return id_tacgia; }
            set { id_tacgia = value; }
        }
        private string tentacgia;

        public string TenTacGia
        {
            get { return tentacgia; }
            set { tentacgia = value; }
        }
        private string hocvi;

        public string HocVi
        {
            get { return hocvi; }
            set { hocvi = value; }
        }
    }
}
