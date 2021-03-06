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
    public partial class frmTacGia : Form
    {
        bool kt;
        public frmTacGia()
        {
            InitializeComponent();
        }

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lockControl();
            showLsvTacGia();
        }

        public void lockControl()
        {
            txtMaTacGia.Enabled = false;
            txtTenTacGia.Enabled = false;
            txtHocVi.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvTacGia.Enabled = true;
        }

        public void openControl()
        {
            txtMaTacGia.Enabled = true;
            txtTenTacGia.Enabled = true;
            txtHocVi.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvTacGia.Enabled = false;
        }

        public void resetControl()
        {
            txtMaTacGia.ResetText();
            txtTenTacGia.ResetText();
            txtHocVi.ResetText();
        }

        public void showLsvTacGia()
        {
            lsvTacGia.Items.Clear();
            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("TacGia");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["IDTacGia"].ToString();
                item.SubItems.Add(dr["TenTG"].ToString());
                item.SubItems.Add(dr["HocVi"].ToString());
                lsvTacGia.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            resetControl();
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaTacGia.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtMaTacGia.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtTenTacGia.Focus();
        }

        private void lsvTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTacGia.SelectedItems.Count > 0)
            {
                txtMaTacGia.Text = lsvTacGia.SelectedItems[0].SubItems[0].Text;
                txtTenTacGia.Text = lsvTacGia.SelectedItems[0].SubItems[1].Text;
                txtHocVi.Text = lsvTacGia.SelectedItems[0].SubItems[2].Text;


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
            ENTITY.TacGia t = new ENTITY.TacGia();
            t.ID_TacGia = txtMaTacGia.Text.Trim();
            t.TenTacGia = txtTenTacGia.Text.Trim();
            t.HocVi = txtHocVi.Text.Trim();
            DAL.TacGia_Controler tg = new DAL.TacGia_Controler();
            if (kt==true)
            {
                tg.insertTacGia(t);
            }
            else
            {
                tg.editTacGia(t);
            }
            lockControl();
            showLsvTacGia();
        }
        private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["IDTacGia"].ToString();
            item.SubItems.Add(dr["TenTG"].ToString());
            item.SubItems.Add(dr["HocVi"].ToString());

            lsvTacGia.Items.Add(item);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvTacGia.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-P8I38NF\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = cmbTimKiem.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã tác giả"))
            {
                query = "select * from TacGia where IDTacGia like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            if (key.Equals("Tên tác giả"))
            {
                query = "select * from TacGia where TenTG like '" + value + "%'";
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
                ENTITY.TacGia tg = new ENTITY.TacGia();
                tg.ID_TacGia = txtMaTacGia.Text.Trim();
                DAL.TacGia_Controler t = new DAL.TacGia_Controler();
                t.deleteTacGia(tg);
            }
            showLsvTacGia();
            lockControl();
        }
    }
}
