using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class UC_QuanLiNganSach : UserControl
    {
        private readonly DataTable _budgets = new DataTable();
        private readonly DataTable _transactions = new DataTable();
        private readonly BindingSource _bsBudget = new BindingSource();
        private readonly BindingSource _bsTx = new BindingSource();

        private readonly Color _primary = Color.FromArgb(52, 120, 246);
        private readonly Color _success = Color.FromArgb(35, 183, 132);
        private readonly Color _danger = Color.FromArgb(233, 84, 84);

        public UC_QuanLiNganSach()
        {
            InitializeComponent();
            WireEvents();    // gắn sự kiện ở đây (không đặt trong Designer)
            ApplyTheme();    // style nút/thanh công cụ/card ở đây
        }
        private void WireEvents()
        {
            // TAB GIAO DỊCH
            btnAddT.Click += BtnAddTx_Click;
            btnDelT.Click += BtnDelTx_Click;
            btnImpT.Click += BtnImportTx_Click;   // <-- ĐÚNG TÊN
            btnExpT.Click += BtnExportTx_Click;   // <-- ĐÚNG TÊN

            // bộ lọc (nếu có)
            if (dtFrom != null) dtFrom.ValueChanged += ApplyTxFilter;
            if (dtTo != null) dtTo.ValueChanged += ApplyTxFilter;
            if (cboCat != null) cboCat.SelectedIndexChanged += ApplyTxFilter;
            if (txtSearch != null) txtSearch.TextChanged += ApplyTxFilter;

            // TAB NGÂN SÁCH
            btnAddBud.Click += BtnAddBudget_Click;
            btnDelBud.Click += BtnDelBudget_Click;
            btnImpBud.Click += BtnImpBud_Click;
            btnExpBud.Click += BtnExpBud_Click;
        }

        private void ApplyTheme()
        {
            // Giao dịch
            StyleBtn(btnAddT, "Thêm GD");
            StyleBtn(btnDelT, "Xóa GD");
            StyleBtn(btnImpT, "Nhập CSV");   // <-- ĐÚNG TÊN
            StyleBtn(btnExpT, "Xuất CSV");   // <-- ĐÚNG TÊN

            // Ngân sách
            StyleBtn(btnAddBud, "Thêm mục");
            StyleBtn(btnDelBud, "Xóa mục");
            StyleBtn(btnImpBud, "Nhập CSV");
            StyleBtn(btnExpBud, "Xuất CSV");
        }

        private void StyleBtn(Button b, string text)
        {
            b.Text = text;
            b.AutoSize = true;
            b.BackColor = Color.White;
            b.ForeColor = Color.FromArgb(52, 120, 246);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = Color.FromArgb(52, 120, 246);
            b.FlatAppearance.BorderSize = 1;
            b.Margin = new Padding(2, 0, 2, 2);
            b.Font = new Font("Segoe UI", 9f);
        }
        private void StyleCard(Control c)
        {
            c.BackColor = Color.White;
            c.Padding = new Padding(10);
            c.Margin = new Padding(10, 6, 10, 6);
        }
}
        private void BtnAddBudget_Click(object sender, EventArgs e)
        {
            // thêm 1 dòng trống vào bảng/ngân sách
            if (_budgets != null && _budgets.Columns.Count > 0)
            {
                var r = _budgets.NewRow();
                if (_budgets.Columns.Contains("Tên mục")) r["Tên mục"] = "Mục mới";
                if (_budgets.Columns.Contains("Hạn mức tháng")) r["Hạn mức tháng"] = 0m;
                if (_budgets.Columns.Contains("Đã chi")) r["Đã chi"] = 0m;
                _budgets.Rows.Add(r);
            }
            if (dgvBudgets != null) dgvBudgets.Refresh();
        }
        private void BtnDelBudget_Click(object sender, EventArgs e)
        {
            if (dgvBudgets == null || dgvBudgets.SelectedRows.Count == 0) return;
            foreach (DataGridViewRow row in dgvBudgets.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    var drv = row.DataBoundItem as DataRowView;
                    if (drv != null) drv.Row.Delete();
                }
            }
        }

        private void BtnImportBudget_Click(object sender, EventArgs e)
        {
            ImportCsv(_budgets);           // dùng hàm ImportCsv bạn đã có
            if (dgvBudgets != null) dgvBudgets.Refresh();
        }

        private void BtnExportBudget_Click(object sender, EventArgs e)
        {
            ExportCsv(_budgets, "budgets.csv"); // dùng hàm ExportCsv bạn đã có
        }
        private void ImportCsv(DataTable dt)
        {
            using (var ofd = new OpenFileDialog { Filter = "CSV (*.csv)|*.csv" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                if (lines.Length <= 1) return;

                dt.Rows.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] cols = ParseCsvLine(lines[i]);
                    DataRow row = dt.NewRow();
                    int cmax = Math.Min(dt.Columns.Count, cols.Length);

                    for (int c = 0; c < cmax; c++)
                    {
                        Type type = dt.Columns[c].DataType;
                        object val = cols[c];

                        if (type == typeof(DateTime))
                        {
                            DateTime d;
                            val = DateTime.TryParse(cols[c], out d) ? (object)d : DateTime.Today;
                        }
                        else if (type == typeof(decimal))
                        {
                            decimal m;
                            val = decimal.TryParse(cols[c], out m) ? (object)m : 0m;
                        }

                        row[c] = val;
                    }
                    dt.Rows.Add(row);
                }
            }
        }

        private void ExportCsv(DataTable dt, string defaultName)
        {
            using (var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = defaultName })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (var w = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i > 0) w.Write(',');
                        w.Write(Escape(dt.Columns[i].ColumnName));
                    }
                    w.WriteLine();

                    foreach (DataRow r in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (i > 0) w.Write(',');
                            var cell = Convert.ToString(r[i]) ?? "";
                            w.Write(Escape(cell));
                        }
                        w.WriteLine();
                    }
                }
            }
        }
        // ====== FILTER GIAO DỊCH (được Designer gọi) ======
        private void ApplyTxFilter(object sender, EventArgs e)
        {
            if (_transactions == null) return;

            // đảm bảo grid đang bound qua BindingSource
            if (_bsTx.DataSource == null)
            {
                _bsTx.DataSource = _transactions;
          
            }

            DateTime from = dtFrom != null ? dtFrom.Value.Date : DateTime.MinValue;
            DateTime to = dtTo != null ? dtTo.Value.Date : DateTime.MaxValue;

            // RowFilter dùng dạng #yyyy-MM-dd#
            string fDate = string.Format(
                "([Ngày] >= #{0:yyyy-MM-dd}# AND [Ngày] <= #{1:yyyy-MM-dd}#)",
                from, to);

            // Lọc theo Mục (nếu có cột và không phải 'Tất cả')
            string fCat = "";
            if (cboCat != null && cboCat.SelectedItem != null)
            {
                var cat = cboCat.SelectedItem.ToString();
                if (!string.IsNullOrWhiteSpace(cat) && !cat.Equals("Tất cả", StringComparison.OrdinalIgnoreCase))
                {
                    fCat = string.Format(" AND ([Mục] = '{0}')", EscapeSingle(cat));
                }
            }

            // Tìm kiếm theo Mô tả / Tài khoản / Số tiền (convert sang string)
            string fSearch = "";
            if (txtSearch != null)
            {
                var q = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(q))
                {
                    string like = "%" + EscapeLike(q) + "%";
                    // kiểm tra tồn tại cột trước khi dùng
                    var parts = new List<string>();
                    if (_transactions.Columns.Contains("Mô tả"))
                        parts.Add(string.Format("[Mô tả] LIKE '{0}'", like));
                    if (_transactions.Columns.Contains("Tài khoản"))
                        parts.Add(string.Format("[Tài khoản] LIKE '{0}'", like));
                    if (_transactions.Columns.Contains("Số tiền"))
                        parts.Add(string.Format("Convert([Số tiền], 'System.String') LIKE '{0}'", like));

                    if (parts.Count > 0)
                        fSearch = " AND (" + string.Join(" OR ", parts.ToArray()) + ")";
                }
            }

            string filter = fDate + fCat + fSearch;

            // Áp dụng lọc
            var dv = _transactions.DefaultView;
            dv.RowFilter = filter;

            // Nếu đang dùng BindingSource thì set lại DataSource để refresh
       
        }
        // ====== TX: thêm/xóa/nhập/xuất ======

        private void BtnAddTx_Click(object sender, EventArgs e)
        {
            if (_transactions == null) return;

            // Tạo 1 dòng giao dịch mẫu
            var r = _transactions.NewRow();
            if (_transactions.Columns.Contains("Ngày")) r["Ngày"] = DateTime.Today;
            if (_transactions.Columns.Contains("Mục")) r["Mục"] = (cboCat != null && cboCat.SelectedItem != null)
                                                                          ? cboCat.SelectedItem.ToString()
                                                                          : "Khác";
            if (_transactions.Columns.Contains("Mô tả")) r["Mô tả"] = "";
            if (_transactions.Columns.Contains("Tài khoản")) r["Tài khoản"] = "";
            if (_transactions.Columns.Contains("Số tiền")) r["Số tiền"] = 0m;

            _transactions.Rows.Add(r);

            // đảm bảo grid đang bound
            if (dgvTx != null && dgvTx.DataSource == null)
                dgvTx.DataSource = _transactions;

            ApplyTxFilter(null, EventArgs.Empty); // cập nhật lọc nếu đang bật
        }

        private void BtnDelTx_Click(object sender, EventArgs e)
        {
            if (dgvTx == null || dgvTx.SelectedRows.Count == 0) return;

            foreach (DataGridViewRow row in dgvTx.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    var drv = row.DataBoundItem as DataRowView;
                    if (drv != null) drv.Row.Delete();
                }
            }
        }

        private void BtnImportTx_Click(object sender, EventArgs e)
        {
            ImportCsv(_transactions);           // dùng ImportCsv đã có
            ApplyTxFilter(null, EventArgs.Empty);
        }

        private void BtnExportTx_Click(object sender, EventArgs e)
        {
            ExportCsv(_transactions, "transactions.csv");  // dùng ExportCsv đã có
        }

        // Escape cho RowFilter
        private string EscapeSingle(string s) => (s ?? string.Empty).Replace("'", "''");
        private string EscapeLike(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            // escape các ký tự wildcard trong RowFilter: %, *, [, ]
            return s.Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]").Replace("'", "''");
        }


        // C# 7.x an toàn – KHÔNG dùng raw string
        private string Escape(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            // n?u có d?u ph?y / d?u nháy / xu?ng dòng thì wrap b?ng "
            if (s.IndexOf(',') >= 0 || s.IndexOf('"') >= 0 || s.IndexOf('\n') >= 0 || s.IndexOf('\r') >= 0)
            {
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            }
            return s;
        }

        private string[] ParseCsvLine(string line)
        {
            var list = new List<string>();
            var sb = new StringBuilder();
            bool inQuote = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    // g?p "" bên trong -> thêm 1 " và nh?y qua
                    if (inQuote && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        sb.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuote = !inQuote; // m?/?óng quote
                    }
                }
                else if (c == ',' && !inQuote)
                {
                    // k?t thúc 1 c?t
                    list.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }

            // c?t cu?i
            list.Add(sb.ToString());
            return list.ToArray();
        }

    }
}
