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

        public void resetControl()
        {
            txtMaNV.ResetText();
            txtDiaChi.ResetText();
            txtEmail.ResetText();
            txtGioiTinh.ResetText();
            txtLuong.ResetText();
            txtNgaySinh.ResetText();
            txtSDT.ResetText();
            txtTenNV.ResetText();
        }

        public string formatDate(string dt)
        {
            DateTime dateTime = DateTime.Parse(dt);
            string date = dateTime.ToString("yyyy/MM/dd");
            return date;
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
                item.SubItems.Add(formatDate(dr["NgaySinh"].ToString()));
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
            resetControl();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ENTITY.NhanVien n = new ENTITY.NhanVien();
            n.ID_NhanVien = txtMaNV.Text.Trim();
            n.HoTen = txtTenNV.Text.Trim();
            n.NgaySinh = txtNgaySinh.Text.Trim();
            n.Luong = txtLuong.Text.Trim();
            n.SDT = txtSDT.Text.Trim();
            n.Email = txtEmail.Text.Trim();
            n.GioiTinh = txtGioiTinh.Text.Trim();
            n.DiaChi = txtDiaChi.Text.Trim();
            DAL.NhanVien_Controler nv = new DAL.NhanVien_Controler();
            if (kt==true)
            {
                nv.insertNhanVien(n);
            }
            lockControl();
            showLsvNV();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }
        private void addList(SqlDataReader dr)
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvNhanVien.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-P8I38NF\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = cmbTimKiem.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã nhân viên"))
            {
                query = "select * from NhanVien where IDNhanVien like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from NhanVien where IDNhanVien like '" + value + "%'";
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


