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

        public void resetControl()
        {
            txtMaLoaiSach.ResetText();
            txtTenTheLoai.ResetText();
        }

        public void showLsvTheLoai()
        {
            lsvTheLoai.Items.Clear();
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
            resetControl();
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
            else
            {
                tl.editTheLoai(t);
            }
            lockControl();
            showLsvTheLoai();
        }
        private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["IDTheLoai"].ToString();
            item.SubItems.Add(dr["TenTheLoai"].ToString());

            lsvTheLoai.Items.Add(item);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvTheLoai.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-P8I38NF\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = cmbTimKiem.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã Thể Loại"))
            {
                query = "select * from Theloai where IDTheloai like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from TheLoai where IDTheloai like '" + value + "%'";
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
