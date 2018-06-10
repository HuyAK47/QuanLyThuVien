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
    public partial class frmPhieuMuon : Form
    {
        bool kt;
        public frmPhieuMuon()
        {
            InitializeComponent();
        }


        private void frmPhieuMuon_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lockControl();
            showLsvPhieuMuon();
        }

        public void lockControl()
        {
            txtMaPhieuMuon.Enabled = false;
            txtMaNhanVien.Enabled = false;
            txtMaSinhVien.Enabled = false;
            txtNgayMuon.Enabled = false;
            txtNgayTra.Enabled = false;
            txtHanTra.Enabled = false;
            txtTienPhat.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvPhieuMuon.Enabled = true;
        }

        public void openControl()
        {
            txtMaPhieuMuon.Enabled = true;
            txtMaNhanVien.Enabled = true;
            txtMaSinhVien.Enabled = true;
            txtNgayMuon.Enabled = true;
            txtNgayTra.Enabled = true;
            txtHanTra.Enabled = true;
            txtTienPhat.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvPhieuMuon.Enabled = false;
        }

        public void resetControl()
        {
            txtMaPhieuMuon.ResetText();
            txtMaNhanVien.ResetText();
            txtMaSinhVien.ResetText();
            txtNgayMuon.ResetText();
            txtNgayTra.ResetText();
            txtHanTra.ResetText();
            txtTienPhat.ResetText();
        }

        public string formatDate(string dt)
        {
            DateTime dateTime = DateTime.Parse(dt);
            string date = dateTime.ToString("yyyy/MM/dd");
            return date;
        }

        public void showLsvPhieuMuon()
        {
            lsvPhieuMuon.Items.Clear();
            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("PhieuMuon");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["IDPhieuMuon"].ToString();
                item.SubItems.Add(dr["IDNhanVien"].ToString());
                item.SubItems.Add(dr["IDSinhVien"].ToString());
                item.SubItems.Add(formatDate(dr["NgayMuon"].ToString()));
                item.SubItems.Add(formatDate(dr["NgayTra"].ToString()));
                item.SubItems.Add(formatDate(dr["HanTra"].ToString()));
                item.SubItems.Add(dr["TienPhat"].ToString());
                lsvPhieuMuon.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            resetControl();
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaPhieuMuon.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtMaPhieuMuon.Enabled = false;
            txtMaSinhVien.Enabled = false;
            txtMaNhanVien.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtNgayMuon.Focus();
        }

        private void lsvPhieuMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedItems.Count > 0)
            {
                txtMaPhieuMuon.Text = lsvPhieuMuon.SelectedItems[0].SubItems[0].Text;
                txtMaNhanVien.Text = lsvPhieuMuon.SelectedItems[0].SubItems[1].Text;
                txtMaSinhVien.Text = lsvPhieuMuon.SelectedItems[0].SubItems[2].Text;
                txtNgayMuon.Text = lsvPhieuMuon.SelectedItems[0].SubItems[3].Text;
                txtNgayTra.Text = lsvPhieuMuon.SelectedItems[0].SubItems[4].Text;
                txtHanTra.Text = lsvPhieuMuon.SelectedItems[0].SubItems[5].Text;
                txtTienPhat.Text = lsvPhieuMuon.SelectedItems[0].SubItems[6].Text;


                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.PhieuMuon p = new ENTITY.PhieuMuon();
            p.ID_PhieuMuon = txtMaPhieuMuon.Text.Trim();
            p.ID_NhanVien = txtMaNhanVien.Text.Trim();
            p.ID_SinhVien = txtMaSinhVien.Text.Trim();
            p.NgayMuon = txtNgayMuon.Text.Trim();
            p.NgayTra = txtNgayTra.Text.Trim();
            p.HanTra = txtHanTra.Text.Trim();
            p.TienPhat = txtTienPhat.Text.Trim();
            DAL.PhieuMuon_Controler pm = new DAL.PhieuMuon_Controler();
            if (kt==true)
            {
                pm.insertPhieuMuon(p);
            }
            else
            {
                pm.editPhieuMuon(p);
            }
            lockControl();
            showLsvPhieuMuon();
        }
        private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["IDPhieuMuon"].ToString();
            item.SubItems.Add(dr["IDNhanVien"].ToString());
            item.SubItems.Add(dr["IDSinhVien"].ToString());
            item.SubItems.Add(dr["NgayMuon"].ToString());
            item.SubItems.Add(dr["NgayTra"].ToString());
            item.SubItems.Add(dr["HanTra"].ToString());
            item.SubItems.Add(dr["TienPhat"].ToString());
            lsvPhieuMuon.Items.Add(item);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvPhieuMuon.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-P8I38NF\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = cmbTimKiem.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã Phiếu Mượn"))
            {
                query = "select * from PhieuMuon where IDPhieuMuon like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from PhieuMuon where IDPhieuMuon like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                ENTITY.PhieuMuon pm = new ENTITY.PhieuMuon();
                pm.ID_PhieuMuon = txtMaPhieuMuon.Text.Trim();
                DAL.PhieuMuon_Controler p = new DAL.PhieuMuon_Controler();
                p.deletePhieuMuon(pm);
            }
            showLsvPhieuMuon();
            lockControl();
        }
    }
    }

