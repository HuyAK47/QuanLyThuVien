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
    public partial class frmNhaXuatBan : Form
    {
        bool kt;
        public frmNhaXuatBan()
        {
            InitializeComponent();
        }

        private void frmNhaXuatBan_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lockControl();
            showLsvNXB();
        }

        public void lockControl()
        {
            txtMaNXB.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtTenNXB.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            lsvNXB.Enabled = true;
        }

        public void openControl()
        {
            txtMaNXB.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtTenNXB.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            lsvNXB.Enabled = false;
        }

        public void resetControl()
        {
            txtMaNXB.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtTenNXB.ResetText();
        }

        public void showLsvNXB()
        {
            lsvNXB.Items.Clear();
            DAL.sqlConnect conn = new DAL.sqlConnect();
            SqlDataReader dr = conn.getDataTable("NhaXuatBan");
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["IDNhaXuatBan"].ToString();
                item.SubItems.Add(dr["TenNXB"].ToString());
                item.SubItems.Add(dr["DiaChi"].ToString());
                item.SubItems.Add(dr["SDT"].ToString());
                lsvNXB.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            resetControl();
            openControl();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNXB.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            txtMaNXB.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtTenNXB.Focus();

        }

        private void lsvNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNXB.SelectedItems.Count > 0)
            {
                txtMaNXB.Text = lsvNXB.SelectedItems[0].SubItems[0].Text;
                txtTenNXB.Text = lsvNXB.SelectedItems[0].SubItems[1].Text;
                txtDiaChi.Text = lsvNXB.SelectedItems[0].SubItems[2].Text;
                txtSDT.Text = lsvNXB.SelectedItems[0].SubItems[3].Text;

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
            ENTITY.NhaXuatBan n = new ENTITY.NhaXuatBan();
            n.ID_NhaXuatBan = txtMaNXB.Text.Trim();
            n.TenNXB = txtTenNXB.Text.Trim();
            n.DiaChi = txtDiaChi.Text.Trim();
            n.SDT = txtSDT.Text.Trim();
            DAL.NhaXuatBan_Controler nxb = new DAL.NhaXuatBan_Controler();
            if (kt==true)
            {
                nxb.insertNhanXuatBan(n);
            }
            else
            {
                nxb.editNhanXuatBan(n);
            }
            lockControl();
            showLsvNXB();
        }
        private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["IDNhaXuatBan"].ToString();
            item.SubItems.Add(dr["TenNXB"].ToString());
            item.SubItems.Add(dr["DiaChi"].ToString());
            item.SubItems.Add(dr["SDT"].ToString());
            lsvNXB.Items.Add(item);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvNXB.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-P8I38NF\\SQLEXPRESS;Initial Catalog=QLTV;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = cmbTimKiem.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã nhà xuất bản"))
            {
                query = "select * from NhaXuatBan where IDNhaXuatBan like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from NhaXuatBan where IDNhaXuatBan like '" + value + "%'";
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
                ENTITY.NhaXuatBan nxb = new ENTITY.NhaXuatBan();
                nxb.ID_NhaXuatBan = txtMaNXB.Text.Trim();
                DAL.NhaXuatBan_Controler nx = new DAL.NhaXuatBan_Controler();
                nx.deleteNhaXuatBan(nxb);
            }
            showLsvNXB();
            lockControl();
        }
    }
    }

