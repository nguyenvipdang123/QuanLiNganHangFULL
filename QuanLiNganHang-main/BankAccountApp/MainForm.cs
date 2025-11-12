using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BankAccountApp
{
    public partial class MainForm : Form
    {
        private Bank bank = new Bank("DNTU Bank");
        private string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "accounts.csv");
        private UC_GiaoDich ucGiaoDich;
        private UC_ThongKe_NoChart ucThongKe;
        private UC_NhanVien ucNhanVien;
        public MainForm()
        {
            InitializeComponent();

            // Panel chứa nội dung ở bên phải
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(contentPanel);
            this.Controls.SetChildIndex(contentPanel, 0); // đảm bảo contentPanel không đè panel menu
        }

    

        // Tiện ích: hiển thị 1 UserControl vào contentPanel
        private void ShowContent(UserControl uc)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);
            contentPanel.ResumeLayout();
        }
        // ====== HÀM CHUẨN HÓA TÊN ======
        private string ToTitleCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            // dùng char[] + options để tương thích .NET Framework cũ
            var words = input.Trim()
                             .ToLowerInvariant()
                             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                var w = words[i];
                words[i] = char.ToUpperInvariant(w[0]) + (w.Length > 1 ? w.Substring(1) : "");
            }

            return string.Join(" ", words);
        }
        // ==================================


       

  

        /// <summary>
        /// Tạo n tài khoản mẫu và add vào bank.Accounts.
        /// Số TK được đảm bảo unique so với các TK hiện có.
        /// </summary>
        /// 
        private void DrawTopBorder(Button btn, Color color)
        {
            btn.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(color, 2)) // 2px
                {
                    e.Graphics.DrawLine(pen, 0, 0, btn.Width, 0);
                }
            };
        }
       

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { bank.SaveToCsv(csvPath); } catch { }
        }

       
        Button currentButton = null;
        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowContent(new UC_KhachHang(bank, csvPath));
            Button clickedButton = (Button)sender;

            // Nếu đã có nút được chọn trước đó, reset màu lại
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Cyan; // Màu nền mặc định
                currentButton.ForeColor = Color.Black;
            }

            // Cập nhật nút hiện tại
            currentButton = clickedButton;

            // Đổi màu cho nút được chọn
            currentButton.BackColor = Color.DeepSkyBlue; // Màu khi được chọn
            currentButton.ForeColor = Color.Green;
            
        }

        private void QuanLiNganSach_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_QuanLiNganSach());
            Button clickedButton = (Button)sender;

            // Nếu đã có nút được chọn trước đó, reset màu lại
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Cyan; // Màu nền mặc định
                currentButton.ForeColor = Color.Black;
            }

            // Cập nhật nút hiện tại
            currentButton = clickedButton;

            // Đổi màu cho nút được chọn
            currentButton.BackColor = Color.DeepSkyBlue; // Màu khi được chọn
            currentButton.ForeColor = Color.Green;
        }

        private void ShowUserControl(UserControl uc)
        {
            // Xóa UC cũ
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);
            contentPanel.ResumeLayout();
        }


        private void GiaoDich_Click(object sender, EventArgs e)
        {
            
            Button clickedButton = (Button)sender;

            // Nếu đã có nút được chọn trước đó, reset màu lại
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Cyan; // Màu nền mặc định
                currentButton.ForeColor = Color.Black;
            }

            // Cập nhật nút hiện tại
            currentButton = clickedButton;

            // Đổi màu cho nút được chọn
            currentButton.BackColor = Color.DeepSkyBlue; // Màu khi được chọn
            currentButton.ForeColor = Color.Green;
            if (ucGiaoDich == null)
                ucGiaoDich = new UC_GiaoDich();

            ShowPanelControl(ucGiaoDich);
        }
        private void ShowPanelControl(UserControl uc)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);
            contentPanel.ResumeLayout();
        }

        private void MoThe_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Nếu đã có nút được chọn trước đó, reset màu lại
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Cyan; // Màu nền mặc định
                currentButton.ForeColor = Color.Black;
            }

            // Cập nhật nút hiện tại
            currentButton = clickedButton;

            // Đổi màu cho nút được chọn
            currentButton.BackColor = Color.DeepSkyBlue; // Màu khi được chọn
            currentButton.ForeColor = Color.Green;
        }

        private void NhanVien_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Nếu đã có nút được chọn trước đó, reset màu lại
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Cyan; // Màu nền mặc định
                currentButton.ForeColor = Color.Black;
            }

            // Cập nhật nút hiện tại
            currentButton = clickedButton;

            // Đổi màu cho nút được chọn
            currentButton.BackColor = Color.DeepSkyBlue; // Màu khi được chọn
            currentButton.ForeColor = Color.Green;
            if (ucNhanVien == null)
                ucNhanVien = new UC_NhanVien();

            ShowUserControl(ucNhanVien);
        }

        private void ThongKe_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Nếu đã có nút được chọn trước đó, reset màu lại
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Cyan; // Màu nền mặc định
                currentButton.ForeColor = Color.Black;
            }

            // Cập nhật nút hiện tại
            currentButton = clickedButton;

            // Đổi màu cho nút được chọn
            currentButton.BackColor = Color.DeepSkyBlue; // Màu khi được chọn
            currentButton.ForeColor = Color.Green;
            if (ucThongKe == null)
                ucThongKe = new UC_ThongKe_NoChart();

            ShowUserControl(ucThongKe);
        }
      
        private void Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc chắn muốn thoát không?",
        "Xác nhận thoát",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
