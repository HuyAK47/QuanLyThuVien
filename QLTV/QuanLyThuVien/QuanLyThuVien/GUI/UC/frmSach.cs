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
    public partial class frmSach : Form
    {
        bool kt;
        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lockControl();
            showLsvNXB();
        }

        public void lockControl()
        {
            txtMaNXB.Enabled = false;
            txtMaSach.Enabled = false;
            txtMaTacGia.Enabled = false;
            txtMaTheLoai.Enabled = false;
            txtNamXB.Enabled = false;
            txtNgonNgu.Enabled = false;
            txtSoLuong.Enabled = false;
            txtSoTrang.Enabled = false;
            txtTenSach.Enabled = false;
            txtGiaNY.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvSach.Enabled = true;
        }

        public void openControl()
        {
            txtMaNXB.Enabled = true;
            txtMaSach.Enabled = true;
            txtMaTacGia.Enabled = true;
            txtMaTheLoai.Enabled = true;
            txtNamXB.Enabled = true;
            txtNgonNgu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtSoTrang.Enabled = true;
            txtTenSach.Enabled = true;
            txtGiaNY.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvSach.Enabled = false;
        }

        public void resetControl()
        {
            txtMaNXB.ResetText();
            txtMaSach.ResetText();
            txtMaTacGia.ResetText();
            txtMaTheLoai.ResetText();
            txtNamXB.ResetText();
            txtNgonNgu.ResetText();
            txtSoLuong.ResetText();
            txtSoTrang.ResetText();
            txtTenSach.ResetText();
            txtGiaNY.ResetText();
        }

        public string formatDate(string dt)
        {
            DateTime dateTime = DateTime.Parse(dt);
            string date = dateTime.ToString("yyyy/MM/dd");
            return date;
        }

        public void showLsvNXB()
        {

            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("Sach");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["IDSach"].ToString();
                item.SubItems.Add(dr["TenSach"].ToString());
                item.SubItems.Add(dr["IDTheLoai"].ToString());
                item.SubItems.Add(dr["IDTacGia"].ToString());
                item.SubItems.Add(dr["IDNhaXuatBan"].ToString());
                item.SubItems.Add(dr["SoTrang"].ToString());
                item.SubItems.Add(formatDate(dr["NamXB"].ToString()));
                item.SubItems.Add(dr["SoLuong"].ToString());
                item.SubItems.Add(dr["NgonNgu"].ToString());
                item.SubItems.Add(dr["GiaNiemYet"].ToString());
                lsvSach.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            resetControl();
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaSach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtMaNXB.Enabled = false;
            txtMaSach.Enabled = false;
            txtMaTacGia.Enabled = false;
            txtTenSach.Focus();
        }

        private void lsvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSach.SelectedItems.Count > 0)
            {
                txtMaSach.Text = lsvSach.SelectedItems[0].SubItems[0].Text;
                txtTenSach.Text = lsvSach.SelectedItems[0].SubItems[1].Text;
                txtMaTheLoai.Text = lsvSach.SelectedItems[0].SubItems[2].Text;
                txtMaTacGia.Text = lsvSach.SelectedItems[0].SubItems[3].Text;
                txtMaNXB.Text = lsvSach.SelectedItems[0].SubItems[4].Text;
                txtSoTrang.Text = lsvSach.SelectedItems[0].SubItems[5].Text;
                txtNamXB.Text = lsvSach.SelectedItems[0].SubItems[6].Text;
                txtSoLuong.Text = lsvSach.SelectedItems[0].SubItems[7].Text;
                txtNgonNgu.Text = lsvSach.SelectedItems[0].SubItems[8].Text; 
                txtGiaNY.Text = lsvSach.SelectedItems[0].SubItems[9].Text;


                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.Sach s = new ENTITY.Sach();
            s.ID_Sach = txtMaSach.Text.Trim();
            s.TenSach = txtTenSach.Text.Trim();
            s.ID_TheLoai = txtMaTheLoai.Text.Trim();
            s.ID_TacGia = txtMaTacGia.Text.Trim();
            s.ID_NhaXuatBan = txtMaNXB.Text.Trim();
            s.SoTrang = txtSoTrang.Text.Trim();
            s.NamXB = txtNamXB.Text.Trim();
            s.SoLuong = txtSoLuong.Text.Trim();
            s.NgonNgu = txtNgonNgu.Text.Trim();
            s.GiaNiemYet = txtGiaNY.Text.Trim();
            DAL.Sach_Controler sa = new DAL.Sach_Controler();
            if (kt==true)
            {
                sa.insertSach(s);
            }
            lockControl();
            showLsvNXB();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["IDSach"].ToString();
            item.SubItems.Add(dr["TenSach"].ToString());
            item.SubItems.Add(dr["IDTheLoai"].ToString());
            item.SubItems.Add(dr["IDTacGia"].ToString());
            item.SubItems.Add(dr["IDNhaXuatBan"].ToString());
            item.SubItems.Add(dr["SoTrang"].ToString());
            item.SubItems.Add(dr["NamXB"].ToString());
            item.SubItems.Add(dr["SoLuong"].ToString());
            item.SubItems.Add(dr["NgonNgu"].ToString());
            item.SubItems.Add(dr["GiaNiemYet"].ToString());
            lsvSach.Items.Add(item);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvSach.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-P8I38NF\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = cmbTimKiem.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã Sách"))
            {
                query = "select * from Sach where IDSach like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from Sach where IDSach like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
        }
    }
}
