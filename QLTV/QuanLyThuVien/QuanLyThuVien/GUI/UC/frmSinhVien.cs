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
    public partial class frmSinhVien : Form
    {
        bool kt;
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lockControl();
            showLsvSV();
        }

        public void lockControl()
        {
            txtMaSV.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtHanThe.Enabled = false;
            txtNgaySinh.Enabled = false;
            txtSDT.Enabled = false;
            txtTenSV.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvSinhVien.Enabled = true;
        }

        public void openControl()
        {
            txtMaSV.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtHanThe.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            txtTenSV.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvSinhVien.Enabled = false;
        }

        public void resetControl()
        {
            txtMaSV.ResetText();
            txtDiaChi.ResetText();
            txtEmail.ResetText();
            txtGioiTinh.ResetText();
            txtHanThe.ResetText();
            txtNgaySinh.ResetText();
            txtSDT.ResetText();
            txtTenSV.ResetText();
        }

        public string formatDate(string dt)
        {
            DateTime dateTime = DateTime.Parse(dt);
            string date = dateTime.ToString("yyyy/MM/dd");
            return date;
        }

        public void showLsvSV()
        {

            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("SinhVien");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["IDSinhVien"].ToString();
                item.SubItems.Add(dr["TenSV"].ToString());
                item.SubItems.Add(dr["GioiTinh"].ToString());
                item.SubItems.Add(formatDate(dr["NgaySinh"].ToString()));
                item.SubItems.Add(dr["DiaChi"].ToString());
                item.SubItems.Add(dr["SDT"].ToString());
                item.SubItems.Add(dr["Email"].ToString());
                item.SubItems.Add(formatDate(dr["HanThe"].ToString()));
                lsvSinhVien.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            resetControl();
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaSV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtMaSV.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtTenSV.Focus();
        }

        private void lsvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count > 0)
            {
                txtMaSV.Text = lsvSinhVien.SelectedItems[0].SubItems[0].Text;
                txtTenSV.Text = lsvSinhVien.SelectedItems[0].SubItems[1].Text;
                txtGioiTinh.Text = lsvSinhVien.SelectedItems[0].SubItems[2].Text;
                txtNgaySinh.Text = lsvSinhVien.SelectedItems[0].SubItems[3].Text;
                txtDiaChi.Text = lsvSinhVien.SelectedItems[0].SubItems[4].Text;
                txtSDT.Text = lsvSinhVien.SelectedItems[0].SubItems[5].Text;
                txtEmail.Text = lsvSinhVien.SelectedItems[0].SubItems[6].Text;
                txtHanThe.Text = lsvSinhVien.SelectedItems[0].SubItems[7].Text;


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
            ENTITY.SinhVien s = new ENTITY.SinhVien();
            s.ID_SinhVien = txtMaSV.Text.Trim();
            s.HoTen = txtTenSV.Text.Trim();
            s.GioiTinh = txtGioiTinh.Text.Trim();
            s.NgaySinh = txtNgaySinh.Text.Trim();
            s.DiaChi = txtDiaChi.Text.Trim();
            s.SDT = txtSDT.Text.Trim();
            s.Email = txtEmail.Text.Trim();
            s.HanThe = txtHanThe.Text.Trim();
            DAL.SinhVien_Controler sv = new DAL.SinhVien_Controler();
            if (kt==true)
            {
                sv.insertSinhVien(s);
            }
            lockControl();
            showLsvSV();
        }
    }
}
