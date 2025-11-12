namespace BankAccountApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.ThongKe = new System.Windows.Forms.Button();
            this.NhanVien = new System.Windows.Forms.Button();
            this.GiaoDich = new System.Windows.Forms.Button();
            this.QuanLiNganSach = new System.Windows.Forms.Button();
            this.KhachHang = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.ThongKe);
            this.panel1.Controls.Add(this.NhanVien);
            this.panel1.Controls.Add(this.GiaoDich);
            this.panel1.Controls.Add(this.QuanLiNganSach);
            this.panel1.Controls.Add(this.KhachHang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 520);
            this.panel1.TabIndex = 31;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(86)))));
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::BankAccountApp.Properties.Resources.signout_106525;
            this.btnThoat.Location = new System.Drawing.Point(84, 444);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(39, 40);
            this.btnThoat.TabIndex = 28;
            this.btnThoat.Text = " ";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.Thoat_Click);
            // 
            // ThongKe
            // 
            this.ThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(86)))));
            this.ThongKe.FlatAppearance.BorderSize = 0;
            this.ThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ThongKe.Location = new System.Drawing.Point(4, 369);
            this.ThongKe.Name = "ThongKe";
            this.ThongKe.Size = new System.Drawing.Size(188, 46);
            this.ThongKe.TabIndex = 27;
            this.ThongKe.Text = "Thống Kê";
            this.ThongKe.UseVisualStyleBackColor = false;
            this.ThongKe.Click += new System.EventHandler(this.ThongKe_Click);
            // 
            // NhanVien
            // 
            this.NhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(86)))));
            this.NhanVien.FlatAppearance.BorderSize = 0;
            this.NhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.NhanVien.Location = new System.Drawing.Point(3, 292);
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Size = new System.Drawing.Size(188, 46);
            this.NhanVien.TabIndex = 27;
            this.NhanVien.Text = "Nhân Viên";
            this.NhanVien.UseVisualStyleBackColor = false;
            this.NhanVien.Click += new System.EventHandler(this.NhanVien_Click);
            // 
            // GiaoDich
            // 
            this.GiaoDich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(86)))));
            this.GiaoDich.FlatAppearance.BorderSize = 0;
            this.GiaoDich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GiaoDich.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GiaoDich.Location = new System.Drawing.Point(3, 226);
            this.GiaoDich.Name = "GiaoDich";
            this.GiaoDich.Size = new System.Drawing.Size(188, 46);
            this.GiaoDich.TabIndex = 27;
            this.GiaoDich.Text = "Giao Dịch";
            this.GiaoDich.UseVisualStyleBackColor = false;
            this.GiaoDich.Click += new System.EventHandler(this.GiaoDich_Click);
            // 
            // QuanLiNganSach
            // 
            this.QuanLiNganSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(86)))));
            this.QuanLiNganSach.FlatAppearance.BorderSize = 0;
            this.QuanLiNganSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuanLiNganSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuanLiNganSach.Location = new System.Drawing.Point(3, 160);
            this.QuanLiNganSach.Name = "QuanLiNganSach";
            this.QuanLiNganSach.Size = new System.Drawing.Size(188, 46);
            this.QuanLiNganSach.TabIndex = 27;
            this.QuanLiNganSach.Text = "Quản Lí Ngân Sách";
            this.QuanLiNganSach.UseVisualStyleBackColor = false;
            this.QuanLiNganSach.Click += new System.EventHandler(this.QuanLiNganSach_Click);
            // 
            // KhachHang
            // 
            this.KhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(86)))));
            this.KhachHang.FlatAppearance.BorderSize = 0;
            this.KhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KhachHang.Location = new System.Drawing.Point(0, 97);
            this.KhachHang.Name = "KhachHang";
            this.KhachHang.Size = new System.Drawing.Size(197, 46);
            this.KhachHang.TabIndex = 27;
            this.KhachHang.Text = "Khách Hàng";
            this.KhachHang.UseVisualStyleBackColor = false;
            this.KhachHang.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Xin chào, Admin!!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::BankAccountApp.Properties.Resources.round_account_button_with_user_inside_icon_icons1;
            this.label1.Location = new System.Drawing.Point(77, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 37);
            this.label1.TabIndex = 26;
            this.label1.Text = "  \\";
            // 
            // contentPanel
            // 
            this.contentPanel.Location = new System.Drawing.Point(198, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1178, 522);
            this.contentPanel.TabIndex = 32;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 520);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "DNTU Bank - Accounts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button KhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button NhanVien;
        private System.Windows.Forms.Button GiaoDich;
        private System.Windows.Forms.Button QuanLiNganSach;
        private System.Windows.Forms.Button ThongKe;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel contentPanel;
    }
}
