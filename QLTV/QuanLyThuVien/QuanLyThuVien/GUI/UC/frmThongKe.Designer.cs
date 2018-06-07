namespace QuanLyThuVien.GUI.UC
{
    partial class frmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_Thongke = new System.Windows.Forms.DataGridView();
            this.cb_Thongke = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txt_box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Thongke)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Thongke
            // 
            this.dgv_Thongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Thongke.Location = new System.Drawing.Point(35, 90);
            this.dgv_Thongke.Name = "dgv_Thongke";
            this.dgv_Thongke.RowTemplate.Height = 24;
            this.dgv_Thongke.Size = new System.Drawing.Size(1052, 552);
            this.dgv_Thongke.TabIndex = 0;
            // 
            // cb_Thongke
            // 
            this.cb_Thongke.FormattingEnabled = true;
            this.cb_Thongke.Location = new System.Drawing.Point(450, 35);
            this.cb_Thongke.Name = "cb_Thongke";
            this.cb_Thongke.Size = new System.Drawing.Size(237, 24);
            this.cb_Thongke.TabIndex = 1;
            this.cb_Thongke.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thống kê theo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Search.BackgroundImage = global::QuanLyThuVien.Properties.Resources._1428438841_Search;
            this.btn_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Search.Location = new System.Drawing.Point(693, 33);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(31, 26);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.UseVisualStyleBackColor = false;
            // 
            // txt_box
            // 
            this.txt_box.Location = new System.Drawing.Point(174, 35);
            this.txt_box.Name = "txt_box";
            this.txt_box.Size = new System.Drawing.Size(270, 22);
            this.txt_box.TabIndex = 4;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 683);
            this.Controls.Add(this.txt_box);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Thongke);
            this.Controls.Add(this.dgv_Thongke);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Thongke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Thongke;
        private System.Windows.Forms.ComboBox cb_Thongke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_box;
    }
}