using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.GUI;

namespace QuanLyThuVien.GUI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            GUI.UC.frmSinhVien frmSinhVien = new UC.frmSinhVien();
            frmSinhVien.ShowDialog();
        }

        private void btnTheLoai_Click(object sender, EventArgs e)
        {
            UC.frmTheLoai frmTheLoai = new UC.frmTheLoai();
            frmTheLoai.ShowDialog();
        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
            UC.frmTacGia frmTacGia = new UC.frmTacGia();
            frmTacGia.ShowDialog();
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            UC.frmNhaXuatBan frmNhaXuatBan = new UC.frmNhaXuatBan();
            frmNhaXuatBan.ShowDialog();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UC.frmNhanVien frmNhanVien = new UC.frmNhanVien();
            frmNhanVien.ShowDialog();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            UC.frmSach frmSach = new UC.frmSach();
            frmSach.ShowDialog();
        }

        private void btnPhieuMuon_Click(object sender, EventArgs e)
        {
            UC.frmPhieuMuon frmPhieuMuon = new UC.frmPhieuMuon();
            frmPhieuMuon.ShowDialog();
        }

        private void btnCTPM_Click(object sender, EventArgs e)
        {
            UC.frmChiTietPhieuMuon frmChiTietPhieu = new UC.frmChiTietPhieuMuon();
            frmChiTietPhieu.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            UC.frmThongKe frmThongKe = new UC.frmThongKe();
            frmThongKe.ShowDialog();
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            UC.frmTroGiup frmTroGiup = new UC.frmTroGiup();
            frmTroGiup.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.KeyPreview = true ;
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                btnTroGiup.PerformClick();
            }
        }


    }
}
