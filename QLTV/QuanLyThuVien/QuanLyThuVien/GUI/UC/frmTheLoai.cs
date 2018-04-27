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
    public partial class frmTheLoai : Form
    {
        bool kt;
        public frmTheLoai()
        {
            InitializeComponent();
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lockControl();
            showLsvTheLoai();
        }

        public void lockControl()
        {
            txtMaLoaiSach.Enabled = false;
            txtTenTheLoai.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvTheLoai.Enabled = true;
        }

        public void openControl()
        {
            txtMaLoaiSach.Enabled = true;
            txtTenTheLoai.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvTheLoai.Enabled = false;
        }

        public void showLsvTheLoai()
        {

            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("TheLoai");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["IDTheLoai"].ToString();
                item.SubItems.Add(dr["TenTheLoai"].ToString());
                lsvTheLoai.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaLoaiSach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtMaLoaiSach.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtTenTheLoai.Focus();
        }

        private void lsvTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTheLoai.SelectedItems.Count > 0)
            {
                txtMaLoaiSach.Text = lsvTheLoai.SelectedItems[0].SubItems[0].Text;
                txtTenTheLoai.Text = lsvTheLoai.SelectedItems[0].SubItems[1].Text;


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
            ENTITY.TheLoai t = new ENTITY.TheLoai();
            t.ID_TheLoai = txtMaLoaiSach.Text.Trim();
            t.TenTheLoai = txtTenTheLoai.Text.Trim();
            DAL.TheLoai_Controler tl = new DAL.TheLoai_Controler();
            if (kt==true)
            {
                tl.insertTheLoai(t);
            }
            lockControl();
            showLsvTheLoai();
        }
    }
}
