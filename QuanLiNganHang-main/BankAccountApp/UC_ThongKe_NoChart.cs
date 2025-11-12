
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class UC_ThongKe_NoChart : UserControl
    {
        private DataTable _table = new DataTable();   // nguồn gốc
        private DataTable _view = new DataTable();    // sau khi lọc
        private BindingSource _bs = new BindingSource();

        // Dữ liệu đã tổng hợp phục vụ vẽ (không dùng DataVisualization)
        private List<Tuple<string, decimal>> _monthThu = new List<Tuple<string, decimal>>();
        private List<Tuple<string, decimal>> _monthChi = new List<Tuple<string, decimal>>();
        private List<Tuple<string, decimal>> _catChi = new List<Tuple<string, decimal>>();
        private List<Tuple<string, decimal>> _balance = new List<Tuple<string, decimal>>(); // (label ngày, số dư tích luỹ)

        public UC_ThongKe_NoChart()
        {
            InitializeComponent();
            this.Load += UC_ThongKe_NoChart_Load;
            pbMonth.Paint += (s, e) => DrawMonthBars(e.Graphics, pbMonth.ClientRectangle);
            pbCategory.Paint += (s, e) => DrawCategoryBars(e.Graphics, pbCategory.ClientRectangle);
            pbBalance.Paint += (s, e) => DrawBalanceLine(e.Graphics, pbBalance.ClientRectangle);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void UC_ThongKe_NoChart_Load(object sender, EventArgs e)
        {
            BuildSchema();
            _bs.DataSource = _view;
            dgvPreview.DataSource = _bs;

            var now = DateTime.Today;
            dtpFrom.Value = new DateTime(now.Year, now.Month, 1).AddMonths(-2);
            dtpTo.Value = new DateTime(now.Year, now.Month, 1).AddMonths(1).AddDays(-1);

            BtnDemo_Click(this, EventArgs.Empty); // dữ liệu mẫu + tính toán ban đầu
        }

        private void BuildSchema()
        {
            if (_table.Columns.Count > 0) return;
            string[] cols = { "Date", "Account", "Category", "Type", "Amount" };
            Type[] types = { typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(decimal) };
            for (int i = 0; i < cols.Length; i++)
            {
                _table.Columns.Add(cols[i], types[i]);
                _view.Columns.Add(cols[i], types[i]);
            }
        }

        public void SetData(DataTable table)
        {
            if (table == null) return;
            _table = table;
            if (_view.Columns.Count == 0) BuildSchema();
            ApplyFilter();
        }

        // ================== Bộ lọc & tổng hợp ==================
        private void ApplyFilter()
        {
            _view.Rows.Clear();

            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            string typeFilter = cboType.SelectedItem != null ? cboType.SelectedItem.ToString() : "Tất cả";
            string search = txtSearch.Text.Trim().ToLowerInvariant();

            for (int i = 0; i < _table.Rows.Count; i++)
            {
                DataRow r = _table.Rows[i];
                DateTime d = (DateTime)r["Date"];
                if (d < from || d > to) continue;

                string type = Convert.ToString(r["Type"]) ?? "";
                if (typeFilter == "Thu" && !string.Equals(type, "Thu", StringComparison.OrdinalIgnoreCase)) continue;
                if (typeFilter == "Chi" && !string.Equals(type, "Chi", StringComparison.OrdinalIgnoreCase)) continue;

                if (search.Length > 0)
                {
                    string acc = (Convert.ToString(r["Account"]) ?? "").ToLowerInvariant();
                    string cat = (Convert.ToString(r["Category"]) ?? "").ToLowerInvariant();
                    if (!acc.Contains(search) && !cat.Contains(search)) continue;
                }

                _view.ImportRow(r);
            }

            UpdateSummaryAndAggregates();
            pbMonth.Invalidate();
            pbCategory.Invalidate();
            pbBalance.Invalidate();
        }

        private void UpdateSummaryAndAggregates()
        {
            // Reset
            _monthThu.Clear();
            _monthChi.Clear();
            _catChi.Clear();
            _balance.Clear();

            // Tổng quan
            decimal thu = 0m, chi = 0m;
            lblSoGD.Text = _view.Rows.Count.ToString();

            // gom theo MM/yyyy cho Thu & Chi
            var mapThu = new Dictionary<string, decimal>();
            var mapChi = new Dictionary<string, decimal>();

            // gom theo Category cho Chi
            var mapCat = new Dictionary<string, decimal>();

            // gom theo ngày để vẽ số dư tích luỹ
            var mapDayDelta = new SortedDictionary<DateTime, decimal>();

            for (int i = 0; i < _view.Rows.Count; i++)
            {
                DataRow r = _view.Rows[i];
                DateTime d = ((DateTime)r["Date"]).Date;
                string keyMonth = new DateTime(d.Year, d.Month, 1).ToString("MM/yyyy");
                string type = Convert.ToString(r["Type"]) ?? "";
                decimal amount = 0m;
                decimal.TryParse(Convert.ToString(r["Amount"]), out amount);

                if (string.Equals(type, "Thu", StringComparison.OrdinalIgnoreCase))
                {
                    thu += amount;
                    mapThu[keyMonth] = mapThu.ContainsKey(keyMonth) ? mapThu[keyMonth] + amount : amount;
                    mapDayDelta[d] = mapDayDelta.ContainsKey(d) ? mapDayDelta[d] + amount : amount;
                }
                else // Chi
                {
                    chi += amount;
                    mapChi[keyMonth] = mapChi.ContainsKey(keyMonth) ? mapChi[keyMonth] + amount : amount;
                    mapDayDelta[d] = mapDayDelta.ContainsKey(d) ? mapDayDelta[d] - amount : -amount;

                    string cat = Convert.ToString(r["Category"]) ?? "Khác";
                    mapCat[cat] = mapCat.ContainsKey(cat) ? mapCat[cat] + amount : amount;
                }
            }

            lblThu.Text = thu.ToString("N0");
            lblChi.Text = chi.ToString("N0");
            lblChenhLech.Text = (thu - chi).ToString("N0");

            // convert ra list có thứ tự tháng tăng dần theo thời gian xuất hiện
            foreach (var kv in mapThu) _monthThu.Add(Tuple.Create(kv.Key, kv.Value));
            foreach (var kv in mapChi) _monthChi.Add(Tuple.Create(kv.Key, kv.Value));
            _monthThu.Sort((a, b) => StringComparer.Ordinal.Compare(a.Item1, b.Item1));
            _monthChi.Sort((a, b) => StringComparer.Ordinal.Compare(a.Item1, b.Item1));

            // category: sắp xếp giảm dần
            foreach (var kv in mapCat) _catChi.Add(Tuple.Create(kv.Key, kv.Value));
            _catChi.Sort((a, b) => -a.Item2.CompareTo(b.Item2));

            // balance: tích luỹ theo ngày
            decimal bal = 0m;
            foreach (var kv in mapDayDelta)
            {
                bal += kv.Value;
                _balance.Add(Tuple.Create(kv.Key.ToString("dd/MM"), bal));
            }
        }

        // ================== Vẽ biểu đồ thủ công (PictureBox) ==================
        private void DrawMonthBars(Graphics g, Rectangle rect)
        {
            g.Clear(Color.White);
            if (_monthThu.Count == 0 && _monthChi.Count == 0)
            {
                DrawCenterText(g, rect, "Chưa có dữ liệu");
                return;
            }

            // gom danh sách nhãn trục X (hợp nhất Thu & Chi)
            var months = new List<string>();
            foreach (var t in _monthThu) if (!months.Contains(t.Item1)) months.Add(t.Item1);
            foreach (var c in _monthChi) if (!months.Contains(c.Item1)) months.Add(c.Item1);
            months.Sort(StringComparer.Ordinal);

            // map để lấy giá trị theo tháng
            var thuMap = new Dictionary<string, decimal>();
            var chiMap = new Dictionary<string, decimal>();
            foreach (var t in _monthThu) thuMap[t.Item1] = t.Item2;
            foreach (var c in _monthChi) chiMap[c.Item1] = c.Item2;

            // padding
            int left = rect.Left + 40;
            int right = rect.Right - 10;
            int top = rect.Top + 10;
            int bottom = rect.Bottom - 30;

            // find max
            decimal max = 1;
            foreach (var m in months)
            {
                if (thuMap.ContainsKey(m) && thuMap[m] > max) max = thuMap[m];
                if (chiMap.ContainsKey(m) && chiMap[m] > max) max = chiMap[m];
            }

            int colWidth = Math.Max(20, (right - left) / Math.Max(1, months.Count) - 10);
            int x = left;

            using (var penAxis = new Pen(Color.Gray))
            using (var bThu = new SolidBrush(Color.SteelBlue))
            using (var bChi = new SolidBrush(Color.IndianRed))
            using (var f = new Font("Segoe UI", 8))
            {
                g.DrawLine(penAxis, left, bottom, right, bottom); // trục X
                foreach (var m in months)
                {
                    // 2 cột nhóm: Thu, Chi
                    int hThu = (int)((thuMap.ContainsKey(m) ? thuMap[m] : 0) / max * (bottom - top));
                    int hChi = (int)((chiMap.ContainsKey(m) ? chiMap[m] : 0) / max * (bottom - top));

                    Rectangle rThu = new Rectangle(x, bottom - hThu, colWidth / 2, hThu);
                    Rectangle rChi = new Rectangle(x + colWidth / 2 + 2, bottom - hChi, colWidth / 2, hChi);
                    g.FillRectangle(bThu, rThu);
                    g.FillRectangle(bChi, rChi);

                    // nhãn tháng
                    var sz = g.MeasureString(m, f);
                    g.DrawString(m, f, Brushes.Black, x + (colWidth - sz.Width) / 2, bottom + 3);
                    x += colWidth + 10;
                }

                // chú thích
                g.FillRectangle(bThu, right - 120, top, 12, 12); g.DrawString("Thu", f, Brushes.Black, right - 100, top - 2);
                g.FillRectangle(bChi, right - 120, top + 16, 12, 12); g.DrawString("Chi", f, Brushes.Black, right - 100, top + 14);
            }
        }

        private void DrawCategoryBars(Graphics g, Rectangle rect)
        {
            g.Clear(Color.White);
            if (_catChi.Count == 0) { DrawCenterText(g, rect, "Không có chi tiêu"); return; }

            int left = rect.Left + 100;
            int right = rect.Right - 10;
            int top = rect.Top + 10;
            int bottom = rect.Bottom - 10;

            decimal max = 1;
            for (int i = 0; i < _catChi.Count; i++)
                if (_catChi[i].Item2 > max) max = _catChi[i].Item2;

            int rowHeight = Math.Max(18, (bottom - top) / Math.Max(1, _catChi.Count));
            using (var b = new SolidBrush(Color.MediumSeaGreen))
            using (var f = new Font("Segoe UI", 9))
            {
                for (int i = 0; i < _catChi.Count; i++)
                {
                    var item = _catChi[i];
                    int y = top + i * rowHeight + 4;
                    int w = (int)( (item.Item2 / max) * (right - left) );
                    g.FillRectangle(b, new Rectangle(left, y, w, rowHeight - 8));
                    g.DrawString(item.Item1, f, Brushes.Black, 10, y);
                    g.DrawString(item.Item2.ToString("N0"), f, Brushes.Black, left + w + 5, y);
                }
            }
        }

        private void DrawBalanceLine(Graphics g, Rectangle rect)
        {
            g.Clear(Color.White);
            if (_balance.Count == 0) { DrawCenterText(g, rect, "Chưa có dữ liệu"); return; }

            int left = rect.Left + 30;
            int right = rect.Right - 10;
            int top = rect.Top + 10;
            int bottom = rect.Bottom - 20;

            decimal min = 0, max = 0;
            foreach (var p in _balance)
            {
                if (p.Item2 < min) min = p.Item2;
                if (p.Item2 > max) max = p.Item2;
            }
            if (max == min) max = min + 1;

            using (var pen = new Pen(Color.DodgerBlue, 2))
            using (var f = new Font("Segoe UI", 8))
            {
                int n = _balance.Count;
                float step = (float)(right - left) / Math.Max(1, n - 1);
                PointF? prev = null;
                for (int i = 0; i < n; i++)
                {
                    var p = _balance[i];
                    float x = left + i * step;
                    float y = (float)(bottom - ( (p.Item2 - min) / (max - min) ) * (bottom - top));
                    if (prev != null) g.DrawLine(pen, prev.Value, new PointF(x, y));
                    prev = new PointF(x, y);
                }
                // trục X đơn giản
                g.DrawLine(Pens.Gray, left, bottom, right, bottom);
            }
        }

        private void DrawCenterText(Graphics g, Rectangle rect, string text)
        {
            using (var f = new Font("Segoe UI", 10, FontStyle.Italic))
            {
                var sz = g.MeasureString(text, f);
                g.DrawString(text, f, Brushes.Gray, rect.Left + (rect.Width - sz.Width) / 2, rect.Top + (rect.Height - sz.Height) / 2);
            }
        }

        // ================== Sự kiện UI ==================
        private void BtnFilter_Click(object sender, EventArgs e) => ApplyFilter();
        private void TxtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void Dtp_ValueChanged(object sender, EventArgs e) => ApplyFilter();
        private void CboType_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void BtnDemo_Click(object sender, EventArgs e)
        {
            _table.Rows.Clear();
            var rnd = new Random();
            string[] accounts = { "Ví", "ATM", "Tiết kiệm" };
            string[] cats = { "Ăn uống", "Đi lại", "Hóa đơn", "Mua sắm", "Giải trí", "Khác" };
            DateTime start = DateTime.Today.AddMonths(-4);

            for (int i = 0; i < 120; i++)
            {
                bool income = rnd.NextDouble() < 0.25;
                decimal amount = rnd.Next(50, 900) * 1000m;
                var r = _table.NewRow();
                r["Date"] = start.AddDays(rnd.Next(0, 120));
                r["Account"] = accounts[rnd.Next(accounts.Length)];
                r["Category"] = income ? "Lương" : cats[rnd.Next(cats.Length)];
                r["Type"] = income ? "Thu" : "Chi";
                r["Amount"] = amount;
                _table.Rows.Add(r);
            }
            ApplyFilter();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", FileName = "ThongKe.csv" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                using (var w = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                {
                    w.WriteLine("Date,Account,Category,Type,Amount");
                    for (int i = 0; i < _view.Rows.Count; i++)
                    {
                        var r = _view.Rows[i];
                        string date = ((DateTime)r["Date"]).ToString("yyyy-MM-dd");
                        w.WriteLine(string.Join(",", date, EscapeCsv(Convert.ToString(r["Account"]) ?? ""), 
                                                     EscapeCsv(Convert.ToString(r["Category"]) ?? ""),
                                                     EscapeCsv(Convert.ToString(r["Type"]) ?? ""), 
                                                     Convert.ToString(r["Amount"]) ?? "0"));
                    }
                }
                MessageBox.Show("Đã xuất CSV!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string EscapeCsv(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Contains(",") || s.Contains("\""))
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }
    }
}
