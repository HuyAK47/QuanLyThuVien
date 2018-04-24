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
    }
}
