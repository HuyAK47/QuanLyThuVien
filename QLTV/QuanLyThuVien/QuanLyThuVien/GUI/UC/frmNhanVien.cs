﻿using System;
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
    
    public partial class frmNhanVien : Form
    {
        bool kt;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lockControl();
            showLsvNV();
        }

        public void lockControl()
        {
            txtMaNV.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtLuong.Enabled = false;
            txtNgaySinh.Enabled = false;
            txtSDT.Enabled = false;
            txtTenNV.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvNhanVien.Enabled = true;
        }

        public void openControl()
        {
            txtMaNV.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtLuong.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            txtTenNV.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvNhanVien.Enabled = false;
        }

        public void showLsvNV()
        {

            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("NhanVien");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["IDNhanVien"].ToString();
                item.SubItems.Add(dr["HoTen"].ToString());
                item.SubItems.Add(dr["NgaySinh"].ToString());
                item.SubItems.Add(dr["Luong"].ToString());
                item.SubItems.Add(dr["SDT"].ToString());
                item.SubItems.Add(dr["Email"].ToString());
                item.SubItems.Add(dr["GioiTinh"].ToString());
                item.SubItems.Add(dr["DiaChi"].ToString());
                lsvNhanVien.Items.Add(item);
            }
        }


        private void btnThem_Click_1(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNV.Focus();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtMaNV.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtTenNV.Focus();
        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedItems.Count > 0)
            {
                txtMaNV.Text = lsvNhanVien.SelectedItems[0].SubItems[0].Text;
                txtTenNV.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                txtNgaySinh.Text = lsvNhanVien.SelectedItems[0].SubItems[2].Text;
                txtLuong.Text = lsvNhanVien.SelectedItems[0].SubItems[3].Text;
                txtSDT.Text = lsvNhanVien.SelectedItems[0].SubItems[4].Text;
                txtEmail.Text = lsvNhanVien.SelectedItems[0].SubItems[5].Text;
                txtGioiTinh.Text = lsvNhanVien.SelectedItems[0].SubItems[6].Text;
                txtDiaChi.Text = lsvNhanVien.SelectedItems[0].SubItems[7].Text;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
    }
}

