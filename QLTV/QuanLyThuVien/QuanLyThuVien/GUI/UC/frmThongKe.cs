using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.GUI.UC
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        // DemoQLTV.sql có thêm phần tạo thủ tục thống kê ở cuối

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            DAL.sqlConnect sql = new DAL.sqlConnect();
            dgv_Thongke.AutoResizeColumns();
            dgv_Thongke.AutoResizeRows();

            if (cb_Thongke.Text.Equals("Sinh Viên dến hạn trả sách"))
            {
                dgv_Thongke.DataSource = sql.TK("select	b.TenSV as 'Tên sinh viên', b.SDT as 'SĐT', b.HanThe as 'Hạn Thẻ', a.NgayTra as 'Ngày trả', a.HanTra as 'Hạn trả', a.TienPhat  as 'Tiền phạt' from(select * from PhieuMuon where Ngaytra >= HanTra) as a, SinhVien as b where b.IDSinhVien = a.IDSinhVien");
            }
            if (cb_Thongke.Text.Equals("Sinh viên mượn sách trong ngày"))
            {
                dgv_Thongke.DataSource = sql.TK("execute Tk_Sv_NgayMuon '"+ txt_box.Text.Trim() +"'") ;
            }
            if (cb_Thongke.Text.Equals("Sinh viên trả sách trong ngày"))
            {
                dgv_Thongke.DataSource = sql.TK("execute Tk_Sv_NgayTra '" + txt_box.Text.Trim() + "'");
            }
            if (cb_Thongke.Text.Equals("Bìa sách theo tên tác giả"))
            {
                dgv_Thongke.DataSource = sql.TK("exec TK_Sach_TenTacGia '" + txt_box.Text.Trim() + "'");
            }
            if (cb_Thongke.Text.Equals("Bìa sách theo tên nhà xuất bản"))
            {
                dgv_Thongke.DataSource = sql.TK("exec TK_Sach_NhaXuatBan '" + txt_box.Text.Trim() + "'");
            }
            if (cb_Thongke.Text.Equals("Bìa sách theo tên thể loại"))
            {
                dgv_Thongke.DataSource = sql.TK("exec TK_Sach_TheLoai '" + txt_box.Text.Trim() + "'");
            }
            if (cb_Thongke.Text.Equals("Số đầu sách theo tên nhà xuất bản"))
            {
                dgv_Thongke.DataSource = sql.TK("exec TK_NhaXuatBan_SlSach '" + txt_box.Text.Trim() + "'");
            }
            if (cb_Thongke.Text.Equals("Số đầu sách theo tên nhà xuất bản"))
            {
                dgv_Thongke.DataSource = sql.TK("exec TK_NhaXuatBan_SlSach '" + txt_box.Text.Trim() + "'");
            }
            if (cb_Thongke.Text.Equals("Số đầu sách theo tên tác giả"))
            {
                dgv_Thongke.DataSource = sql.TK("exec TK_TacGia_SlSach '" + txt_box.Text.Trim() + "'");
            }
            if (cb_Thongke.Text.Equals("Số đầu sách theo tên thể loại"))
            {
                dgv_Thongke.DataSource = sql.TK("exec TK_TheLoai_SlSach '" + txt_box.Text.Trim() + "'");
            }


        }
    }
}
