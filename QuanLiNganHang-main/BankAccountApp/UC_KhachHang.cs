using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BankAccountApp
{
    public partial class UC_KhachHang : UserControl
    {

        private Bank bank = new Bank("DNTU Bank");
        private string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "accounts.csv");

        public UC_KhachHang(Bank bank, string csvPath)
        {
            InitializeComponent();

            this.bank = bank ?? new Bank("DNTU Bank");  // ✅ gán vào field
            this.csvPath = string.IsNullOrWhiteSpace(csvPath)
                           ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "accounts.csv")
                           : csvPath;

            SetupGrid();
            LoadData();
            WireEvents();
        }
        private void SetupGrid()
        {
            listViewAccounts.View = View.Details;
            listViewAccounts.FullRowSelect = true;
            listViewAccounts.GridLines = true;
            listViewAccounts.OwnerDraw = true;
            listViewAccounts.Columns.Clear();
            listViewAccounts.Columns.Add("Số TK", 120);
            listViewAccounts.Columns.Add("Chủ TK", 180);
            listViewAccounts.Columns.Add("Số dư", 120, HorizontalAlignment.Right);
            listViewAccounts.Columns.Add("Ngày mở", 110);
            listViewAccounts.Columns.Add("Ghi chú", 310);

        }
        private void LoadData()
        {
            RefreshList();
        }
        private void WireEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
            btnEdit.Click += Edit_Click;       // begin edit
            btnSave.Click += btnEdit_Click;    // lưu cập nhật
            listViewAccounts.SelectedIndexChanged += listViewAccounts_SelectedIndexChanged;
        }
        public void RefreshList(IEnumerable<Account> source = null)
        {
            var list = (source ?? bank.Accounts).ToList();
            listViewAccounts.Items.Clear();

            foreach (var acc in list)
            {
                var item = new ListViewItem(acc.Number);
                item.SubItems.Add(acc.Owner);
                item.SubItems.Add(acc.Balance.ToString("N0")); // thay cho MoneyFmt nếu bạn chưa có
                item.SubItems.Add(acc.OpenedAt.ToShortDateString());
                item.SubItems.Add(acc.Note ?? "");
                item.Tag = acc;
                listViewAccounts.Items.Add(item);
            }
        }
      
      
        private void SeedSampleAccounts(int n)
        {
          // XÓA TOÀN BỘ DỮ LIỆU CŨ
    bank.Accounts.Clear(); // xóa danh sách hiện có
            if (File.Exists(csvPath))
                File.Delete(csvPath);
       

            var rng = new Random();

    var givenNames = new[]
    {
        "Nguyen","Tran","Le","Pham","Hoang","Vu","Do","Bui","Phan","Dang",
        "Trinh","Duong","Ly","Vo","Ngo","Dinh","Mai","Hoang","Lau","Ngo"
    };

    var middleAndFirst = new[]
    {
        "Van A","Thi B","Huy Nguyen","Hoang Nam","Minh Tuan","Ngoc Anh",
        "Quoc Anh","Thi Huong","Duc Anh","Thi Mai","Thanh Tung","Thi Nga",
        "Van Dung","Minh Khang","Thi Lan","Bao Long","Tuan Kiet","Lam Phuong",
        "Huu Khoa","Xuan Loc","Thi Thuy","Ho Xuan","Gia Hung","Thu Trang",
        "Van Hung","Hoang Linh","Ngoc Son","Bao An","Anh Khoa","Thi Kim"
    };

    // Bắt đầu sinh mới 50 khách hàng
    for (int i = 0; i < n; i++)
    {
        string number = rng.Next(10_000_000, 99_999_999).ToString();
        string owner = $"{givenNames[rng.Next(givenNames.Length)]} {middleAndFirst[rng.Next(middleAndFirst.Length)]}";
        double balance = Math.Round(rng.NextDouble() * 10_000_000, 2);

        var acc = new Account(number, owner, balance);

        // Gán ngày mở ngẫu nhiên trong 2 năm gần đây
        DateTime start = DateTime.Now.AddYears(-2);
        int daysRange = (DateTime.Now - start).Days;
        DateTime opened = start.AddDays(rng.Next(daysRange))
                               .AddHours(rng.Next(0, 24))
                               .AddMinutes(rng.Next(0, 60));

        acc.GetType().GetProperty("OpenedAt").SetValue(acc, opened);

        bank.Add(acc);
    }

    // Lưu lại vào file CSV
    bank.SaveToCsv(csvPath);
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
        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            SeedSampleAccounts(50);
            RefreshList();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtOwner_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Lấy & chuẩn hoá input
                string number = txtNumber.Text.Trim();
                string owner = ToTitleCase(txtOwner.Text.Trim());
                string sBal = txtBalance.Text.Trim();

                // 2) Validate cơ bản
                if (string.IsNullOrEmpty(number))
                {
                    MessageBox.Show("Vui lòng nhập Số tài khoản.");
                    txtNumber.Focus();
                    return;
                }

                // Số TK chỉ gồm số, 6–12 ký tự (đổi regex nếu bạn quy định khác)
                if (!System.Text.RegularExpressions.Regex.IsMatch(number, @"^\d{6,12}$"))
                {
                    MessageBox.Show("Số tài khoản phải là số, từ 6 đến 12 ký tự.");
                    txtNumber.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(owner))
                {
                    MessageBox.Show("Vui lòng nhập Chủ tài khoản.");
                    txtOwner.Focus();
                    return;
                }

                if (!double.TryParse(sBal, out double bal))
                {
                    MessageBox.Show("Số dư không hợp lệ.");
                    txtBalance.Focus();
                    return;
                }

                if (bal < 0)
                {
                    MessageBox.Show("Số dư phải ≥ 0.");
                    txtBalance.Focus();
                    return;
                }

                // 3) Kiểm tra trùng số tài khoản
                if (bank[number] != null) // giả sử Bank có indexer: bank["123"] -> Account
                {
                    MessageBox.Show("Số tài khoản đã tồn tại. Vui lòng nhập số khác.");
                    txtNumber.Focus();
                    txtNumber.SelectAll();
                    return;
                }

                // 4) Tạo & thêm
                var acc = new Account(number, owner, bal);
                bank.Add(acc);

                // 5) Lưu & cập nhật giao diện
                bank.SaveToCsv(csvPath);
                RefreshList();

                // 6) Dọn form & đặt focus lại
                txtNumber.Clear();
                txtOwner.Clear();
                txtBalance.Clear();
                txtNumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm tài khoản: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            if (listViewAccounts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa");
                return;
            }

            // Lấy số TK từ dòng được chọn
            string number = listViewAccounts.SelectedItems[0].Text;

            if (bank.Remove(number))
            {
                bank.SaveToCsv(csvPath);
                RefreshList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            bank.SortByBalanceDesc();
            RefreshList();
        }

        private void btnInterest_Click(object sender, EventArgs e)
        {
            bank.ApplyMonthlyInterest();
            RefreshList();
        }

        private void txtFindOwner_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnFindBalance_Click(object sender, EventArgs e)
        {
            double min = 0, max = double.MaxValue;

            // trim để bỏ dấu cách
            string sMin = txtMin.Text.Trim();
            string sMax = txtMax.Text.Trim();

            // nếu nhập Min thì parse, nếu để trống coi như 0
            if (sMin != "" && !double.TryParse(sMin, out min))
            {
                MessageBox.Show("Giá trị Min không hợp lệ");
                return;
            }

            // nếu nhập Max thì parse, nếu để trống coi như vô hạn
            if (sMax != "" && !double.TryParse(sMax, out max))
            {
                MessageBox.Show("Giá trị Max không hợp lệ");
                return;
            }

            if (min > max)
            {
                MessageBox.Show("Min không được lớn hơn Max");
                return;
            }
            RefreshList(bank.FindByBalanceRange(min, max));
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            string fromNum = txtFrom.Text.Trim();
            string toNum = txtTo.Text.Trim();

            var from = bank[fromNum];
            if (from == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản nguồn");
                return;
            }

            if (bank[toNum] == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản đích");
                return;
            }

            if (!double.TryParse(txtAmount.Text, out double amount))
            {
                MessageBox.Show("Số tiền không hợp lệ");
                return;
            }

            try
            {
                from.Transfer(bank, toNum, amount);
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewAccounts_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {

            if (e.Item.Selected)
            {
                using (var b = new SolidBrush(Color.FromArgb(255, 200, 230))) // soft pink
                    e.Graphics.FillRectangle(b, e.Bounds);
            }
            else
            {
                using (var b = new SolidBrush(Color.White))
                    e.Graphics.FillRectangle(b, e.Bounds);
            }

            // Vẽ text của từng ô
            TextRenderer.DrawText(
                e.Graphics,
                e.SubItem.Text,
                listViewAccounts.Font,
                e.Bounds,
                Color.Black,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );
           
        }

        private void listViewAccounts_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }
        Account editingAccount = null;
        private void Edit_Click(object sender, EventArgs e)
        {
            if (listViewAccounts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa");
                return;
            }

            string number = listViewAccounts.SelectedItems[0].Text;
            editingAccount = bank[number]; // lấy object thật

            txtNumber.Text = editingAccount.Number;
            txtOwner.Text = editingAccount.Owner;
            txtBalance.Text = editingAccount.Balance.ToString();

            // khoá số TK lại để không cho sửa số tài khoản (tuỳ bạn)
            txtNumber.Enabled = false;

            btnAdd.Enabled = false;   // khoá nút thêm khi đang sửa
        
        }



        private void btnFindOwner_Click(object sender, EventArgs e)
        {
            RefreshList(bank.FindByOwner(txtFindOwner.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Nếu chưa bấm Sửa để chọn bản ghi
            if (editingAccount == null)
            {
                // Thử lấy từ dòng đang chọn (nếu có)
                if (listViewAccounts.SelectedItems.Count > 0)
                {
                    string number = listViewAccounts.SelectedItems[0].Text;
                    editingAccount = bank[number];
                }

                if (editingAccount == null)
                {
                    MessageBox.Show("Chưa có tài khoản nào đang chỉnh sửa. Vui lòng chọn tài khoản và bấm 'Sửa' trước.");
                    return;
                }
            }

            // --- Validate input ---
            string owner = ToTitleCase(txtOwner.Text.Trim());
            if (string.IsNullOrWhiteSpace(owner))
            {
                MessageBox.Show("Vui lòng nhập Chủ tài khoản.");
                txtOwner.Focus();
                return;
            }

            if (!double.TryParse(txtBalance.Text.Trim(), out double newBal) || newBal < 0)
            {
                MessageBox.Show("Số dư không hợp lệ (phải là số >= 0).");
                txtBalance.Focus();
                return;
            }

            // Nếu bạn có TextBox ghi chú (vd. txtNote) thì lấy, không có thì để rỗng
            string note = null;
            if (this.Controls.Find("txtNote", true).FirstOrDefault() is TextBox txtNote)
                note = txtNote.Text.Trim();

            // --- Cập nhật object ---
            editingAccount.Owner = owner;

            // Cách cập nhật số dư:
            // 1) Nếu class Account cho phép gán trực tiếp:
            // editingAccount.Balance = newBal;
            // 2) Nếu không, dùng chênh lệch với Deposit/Withdraw:
            double diff = newBal - editingAccount.Balance;
            if (Math.Abs(diff) > 0.000001)
            {
                try
                {
                    if (diff >= 0)
                        editingAccount.Deposit(diff);
                    else
                        editingAccount.Deposit(diff); // nếu Deposit chấp nhận số âm; 
                                                      // nếu có Withdraw(amount) thì thay bằng: editingAccount.Withdraw(-diff);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể cập nhật số dư: " + ex.Message);
                    return;
                }
            }

            // Ghi chú (nếu Account có thuộc tính Note)
            var noteProp = editingAccount.GetType().GetProperty("Note");
            if (noteProp != null) noteProp.SetValue(editingAccount, note ?? "");

            // --- Lưu & refresh ---
            try
            {
                bank.SaveToCsv(csvPath);
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu CSV thất bại: " + ex.Message);
                return;
            }

            // --- Reset UI về trạng thái thêm mới ---
            txtNumber.Enabled = true;   // cho phép nhập số TK mới
            btnAdd.Enabled = true;
            editingAccount = null;

            txtNumber.Clear();
            txtOwner.Clear();
            txtBalance.Clear();
            if (this.Controls.Find("txtNote", true).FirstOrDefault() is TextBox txtNote2)
                txtNote2.Clear();

            txtNumber.Focus();
        }


        private void txtBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (editingAccount == null) return;

            if (!double.TryParse(txtBalance.Text, out double bal))
            {
                MessageBox.Show("Số dư không hợp lệ");
                return;
            }

            editingAccount.Owner = ToTitleCase(txtOwner.Text);
            editingAccount.Deposit(bal - editingAccount.Balance); // cập nhật chênh lệch
                                                                  // hoặc editingAccount.Balance = bal nếu bạn cho phép set trực tiếp

            bank.SaveToCsv(csvPath);
            RefreshList();

            // reset trạng thái
            txtNumber.Enabled = false;
            btnAdd.Enabled = true;
            editingAccount = null;
            txtNumber.Clear();
            txtOwner.Clear();
            txtBalance.Clear();
        }
    }
}
