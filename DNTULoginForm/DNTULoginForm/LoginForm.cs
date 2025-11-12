using BankAccountApp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DNTULoginForm
{
    public partial class LoginForm : Form
    {
        private bool _isPasswordVisible = false;
        private readonly Font _fontInput = new Font("Segoe UI", 10.5f);
        private readonly Font _fontPlaceholder = new Font("Segoe UI", 10f, FontStyle.Italic);

        public LoginForm()
        {
            InitializeComponent();
            // --- Gắn sự kiện vẽ viền cho panel ---
            pnlUserBox.Paint += PanelBorder_Paint;
            pnlPassBox.Paint += PanelBorder_Paint;
            btnTogglePassword.Click += btnTogglePassword_Click;
            btnLogin.Click += BtnLogin_Click;
            lblForgot.Click += LblForgot_Click;

            // Placeholder cho username
            SetupPlaceholder(txtUsername, "Username");

            // Che mật khẩu sẵn
            _isPasswordVisible = false;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.PasswordChar = '*';

            // Căn giữa card
            this.Load += (s, e) => CenterCard();
            this.Resize += (s, e) => CenterCard();

            // Căn lại 👁 + width textbox theo kích thước thật
            pnlPassBox.Resize += (s, e) =>
            {
                btnTogglePassword.Left = pnlPassBox.Width - btnTogglePassword.Width - 8;
                btnTogglePassword.Top = (pnlPassBox.Height - btnTogglePassword.Height) / 2;
                txtPassword.Width = pnlPassBox.Width - 12 - btnTogglePassword.Width - 8 - 6;
            };
            this.Load += (s, e) =>
            {
                btnTogglePassword.Left = pnlPassBox.Width - btnTogglePassword.Width - 8;
                btnTogglePassword.Top = (pnlPassBox.Height - btnTogglePassword.Height) / 2;
                txtPassword.Width = pnlPassBox.Width - 12 - btnTogglePassword.Width - 8 - 6;
            };

            // Enter = login
            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogin.PerformClick();
                    e.Handled = true;
                }
            };
        }
       
        // ===== Hàm vẽ viền panel =====
        private void PanelBorder_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel p)
            {
                using (var pen = new Pen(Color.FromArgb(228, 228, 228)))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
                }
            }
        }

        private void SetupPlaceholder(TextBox tb, string text)
        {
            tb.Text = text;
            tb.ForeColor = Color.Gray;
            tb.Font = _fontPlaceholder;
            tb.GotFocus += (s, e) =>
            {
                if (tb.ForeColor == Color.Gray)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                    tb.Font = _fontInput;
                }
            };
            tb.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = text;
                    tb.ForeColor = Color.Gray;
                    tb.Font = _fontPlaceholder;
                }
            };
        }

        private void CenterCard()
        {
            pnlCard.Left = (ClientSize.Width - pnlCard.Width) / 2;
            pnlCard.Top = (ClientSize.Height - pnlCard.Height) / 2;
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;
            if (_isPasswordVisible)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';
                btnTogglePassword.Text = "🙈";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '*';
                btnTogglePassword.Text = "👁";
            }
            txtPassword.Focus();
            txtPassword.SelectionStart = txtPassword.TextLength;
        }

        
        private void LblForgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ quản trị viên để đặt lại mật khẩu.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // (tùy chọn) truyền thông tin người dùng sang app chính
        public class UserContext
        {
            public string Username { get; set; }
            public string Role { get; set; } = "Admin";
        }

        // trong LoginForm
        public UserContext CurrentUser { get; private set; }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var u = (txtUsername.ForeColor == Color.Gray) ? "" : txtUsername.Text.Trim();
            var p = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(u))
            { MessageBox.Show("Vui lòng nhập tài khoản."); txtUsername.Focus(); return; }
            if (string.IsNullOrEmpty(p))
            { MessageBox.Show("Vui lòng nhập mật khẩu."); txtPassword.Focus(); return; }

            bool ok = u.Equals("admin", StringComparison.OrdinalIgnoreCase) && p == "123";
            if (!ok)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu.", "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.SelectAll(); txtPassword.Focus();
                return;
            }

            // ---> Thành công: set context + trả OK cho Program.cs
            CurrentUser = new UserContext { Username = u, Role = "Admin" };
            this.DialogResult = DialogResult.OK;
            // không Show MessageBox nữa, đóng form luôn cho mượt
            // this.Close(); // không cần gọi, ShowDialog sẽ tự đóng khi set DialogResult
        }
    }
}
