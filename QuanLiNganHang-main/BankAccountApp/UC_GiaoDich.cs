
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace BankAccountApp
{
    public partial class UC_GiaoDich : UserControl
    {

        private BindingSource _bs = new BindingSource();
        private DataTable _table = new DataTable();
        private const string SearchPlaceholder = "Tìm mô tả / danh mục / tài khoản...";
        public UC_GiaoDich()
        {
            InitializeComponent();
            this.Load += UC_GiaoDich_Load;
            txtSearch.ForeColor = SystemColors.GrayText;
            txtSearch.Text = SearchPlaceholder;
            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == SearchPlaceholder)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = SystemColors.WindowText;
                }
            };
            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = SearchPlaceholder;
                    txtSearch.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private void UC_GiaoDich_Load(object sender, EventArgs e)
        {
            BuildSchema();
            _bs.DataSource = _table;
            dgvTransactions.DataSource = _bs;

            var now = DateTime.Today;
            dtpFrom.Value = new DateTime(now.Year, now.Month, 1);
            dtpTo.Value = dtpFrom.Value.AddMonths(1).AddDays(-1);

            UpdateSummary();
        }

        private void BuildSchema()
        {
            if (_table.Columns.Count > 0) return;
            _table.Columns.Add("Date", typeof(DateTime));
            _table.Columns.Add("Account", typeof(string));
            _table.Columns.Add("Category", typeof(string));
            _table.Columns.Add("Description", typeof(string));
            _table.Columns.Add("Type", typeof(string)); // Thu/Chi
            _table.Columns.Add("Amount", typeof(decimal));
            _table.Columns.Add("Balance", typeof(decimal));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var row = _table.NewRow();
            row["Date"] = DateTime.Today;
            row["Account"] = "Ví chính";
            row["Category"] = "Khác";
            row["Description"] = "Giao dịch mới";
            row["Type"] = "Chi";
            row["Amount"] = 0m;
            row["Balance"] = 0m;
            _table.Rows.Add(row);
            UpdateSummary();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvTransactions.SelectedRows)
            {
                if (!r.IsNewRow) dgvTransactions.Rows.Remove(r);
            }
            UpdateSummary();
        }

        private void btnImport_Click(object sender, EventArgs e) { }
        private void btnExport_Click(object sender, EventArgs e) { }
        private void btnPrint_Click(object sender, EventArgs e)  { }

        private void btnRefresh_Click(object sender, EventArgs e) => ApplyFilter();
        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cboType_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();
        private void dtp_ValueChanged(object sender, EventArgs e) => ApplyFilter();

        private void ApplyFilter()
        {
            string search = txtSearch.Text.Trim().Replace("'", "''");
            string type = cboType.SelectedItem?.ToString() ?? "Tất cả";
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            string filter = $"Date >= '#{from:yyyy-MM-dd}#' AND Date <= '#{to:yyyy-MM-dd}#'";

            if (!string.IsNullOrEmpty(search))
            {
                filter += $" AND (Account LIKE '%{search}%' OR Category LIKE '%{search}%' OR Description LIKE '%{search}%')";
            }
            if (type == "Thu" || type == "Chi")
            {
                filter += $" AND Type = '{type}'";
            }

            _bs.Filter = filter;
            UpdateSummary();
        }

        private void dgvTransactions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) UpdateSummary();
        }

        private void dgvTransactions_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateSummary();
        }

        private void btnDemoData_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            string[] accounts = new[] { "Ví chính", "Thẻ ATM", "Tiết kiệm" };
            string[] cats = new[] { "Ăn uống", "Đi lại", "Hóa đơn", "Giải trí", "Lương", "Chuyển khoản", "Khác" };
            _table.Rows.Clear();

            DateTime today = DateTime.Today;
            decimal bal = 2000000m;

            for (int i = 0; i < 30; i++)
            {
                bool income = rnd.NextDouble() < 0.3;
                decimal amount = rnd.Next(50, 700) * 1000m;
                if (!income) amount = -amount;

                bal += amount;
                var row = _table.NewRow();
                row["Date"] = today.AddDays(-rnd.Next(0, 45));
                row["Account"] = accounts[rnd.Next(accounts.Length)];
                row["Category"] = income ? (rnd.NextDouble() < 0.8 ? "Lương" : "Chuyển khoản") : cats[rnd.Next(cats.Length)];
                row["Description"] = income ? "Thu nhập" : "Chi tiêu";
                row["Type"] = income ? "Thu" : "Chi";
                row["Amount"] = Math.Abs(amount);
                row["Balance"] = bal;
                _table.Rows.Add(row);
            }
            ApplyFilter();
        }

        private void UpdateSummary()
        {
            int count = 0;
            decimal thu = 0m, chi = 0m;
            foreach (System.Data.DataRowView r in _bs)
            {
                count++;
                var type = r["Type"]?.ToString();
                if (decimal.TryParse(r["Amount"].ToString(), out var amt))
                {
                    if (type == "Thu") thu += amt;
                    else chi += amt;
                }
            }
            lblSoGD.Text = count.ToString();
            lblThu.Text = thu.ToString("N0");
            lblChi.Text = chi.ToString("N0");
            lblChenhLech.Text = (thu - chi).ToString("N0");

            // Update progress bar: phần trăm Thu trong (Thu+Chi)
            decimal total = thu + chi;
            int percent = total <= 0 ? 0 : (int)Math.Round(thu * 100m / total);
            progressThuChi.Value = Math.Max(0, Math.Min(100, percent));
        }
    }
}
