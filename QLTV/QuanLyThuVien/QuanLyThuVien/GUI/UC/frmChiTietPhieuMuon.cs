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
    public partial class frmChiTietPhieuMuon : Form
    {
        bool kt;
        public frmChiTietPhieuMuon()
        {
            InitializeComponent();
        }

        private void frmChiTietPhieuMuon_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lockControl();
            showLsvCTPM();
        }

        public void lockControl()
        {
            txtMaCTPM.Enabled = false;
            txtMaPM.Enabled = false;
            txtMaSach.Enabled = false;
            txtSoLuong.Enabled = false;
            txtTrangThai.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvChiTietPM.Enabled = true;
        }

        public void openControl()
        {
            txtMaCTPM.Enabled = true;
            txtMaPM.Enabled = true;
            txtMaSach.Enabled = true;
            txtSoLuong.Enabled = true;
            txtTrangThai.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvChiTietPM.Enabled = false;
        }

        public void resetControl()
        {
            txtMaCTPM.ResetText();
            txtMaPM.ResetText();
            txtMaSach.ResetText();
            txtSoLuong.ResetText();
            txtTrangThai.ResetText();
        }

        public void showLsvCTPM()
        {
          
            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("ChiTietPhieuMuon");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["IDctPhieuMuon"].ToString();
                item.SubItems.Add(dr["IDPhieuMuon"].ToString());
                item.SubItems.Add(dr["IDSach"].ToString());
                item.SubItems.Add(dr["SoLuong"].ToString());
                item.SubItems.Add(dr["TrangThai"].ToString());
                lsvChiTietPM.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = false;
            resetControl();
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaCTPM.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            txtMaCTPM.Enabled = false;
            txtMaPM.Enabled = false;
            txtMaSach.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtSoLuong.Focus();
            
        }

        private void lsvChiTietPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvChiTietPM.SelectedItems.Count > 0)
            {
                txtMaCTPM.Text = lsvChiTietPM.SelectedItems[0].SubItems[0].Text;
                txtMaPM.Text = lsvChiTietPM.SelectedItems[0].SubItems[1].Text;
                txtMaSach.Text = lsvChiTietPM.SelectedItems[0].SubItems[2].Text;
                txtSoLuong.Text = lsvChiTietPM.SelectedItems[0].SubItems[3].Text;
                txtTrangThai.Text = lsvChiTietPM.SelectedItems[0].SubItems[4].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.ChiTietPhieuMuon c = new ENTITY.ChiTietPhieuMuon();
            c.ID_ChiTietPhieuMuon = txtMaCTPM.Text.Trim();
            c.ID_PhieuMuon = txtMaPM.Text.Trim();
            c.ID_Sach = txtMaSach.Text.Trim();
            c.SoLuong = txtSoLuong.Text.Trim();
            c.TrangThai = txtTrangThai.Text.Trim();
            DAL.ChiTietPhieuMuon_Controler ct = new DAL.ChiTietPhieuMuon_Controler();
            if (kt==false)
            {
                ct.insertCTPhieuMuon(c);
            }
            showLsvCTPM();
            lockControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
            resetControl();
        }

        private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["ID_ChiTietPhieuMuon"].ToString();
            item.SubItems.Add(dr["ID_PhieuMuon"].ToString());
            item.SubItems.Add(dr["ID_Sach"].ToString());
            item.SubItems.Add(dr["SoLuong"].ToString());
            item.SubItems.Add(dr["TrangThai"].ToString());
            lsvChiTietPM.Items.Add(item);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvChiTietPM.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-P8I38NF\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = cmbTimKiem.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã chi tiết phiếu mượn"))
            {
                query = "select * from ChiTietPhieuMuon where ID_ChiTietPhieuMuon like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from ChiTietPhieuMuon where ID_ChiTietPhieuMuon like '" + value + "%'";
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
