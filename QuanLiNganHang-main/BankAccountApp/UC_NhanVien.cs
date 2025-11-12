using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class UC_NhanVien : UserControl
    {
        private BindingList<Employee> _employees = new BindingList<Employee>();
        private BindingSource _bs = new BindingSource();
        private Employee _editingSnapshot = null;
        private bool _isNew = false;

        public UC_NhanVien()
        {
            InitializeComponent();
            InitializeData();
            WireBindings();
            SetEditMode(false);
        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            // optional load logic
        }

        private void InitializeData()
        {
            _employees.Add(new Employee{
                MaNV="NV001", HoTen="Nguyễn Văn A", ChucVu="Giao dịch viên",
                PhongBan="Chi nhánh Quận 1", NgaySinh=new DateTime(1995, 3, 12),
                GioiTinh="Nam", Email="a.nguyen@bank.com", SDT="0901234567", TrangThai="Đang làm"
            });
            _employees.Add(new Employee{
                MaNV="NV002", HoTen="Trần Thị B", ChucVu="Chuyên viên tín dụng",
                PhongBan="Khối SME", NgaySinh=new DateTime(1994, 8, 2),
                GioiTinh="Nữ", Email="b.tran@bank.com", SDT="0912345678", TrangThai="Đang làm"
            });
            _employees.Add(new Employee{
                MaNV="NV003", HoTen="Phạm Minh C", ChucVu="Kiểm soát viên",
                PhongBan="Khối Vận hành", NgaySinh=new DateTime(1990, 1, 24),
                GioiTinh="Nam", Email="c.pham@bank.com", SDT="0987654321", TrangThai="Nghỉ phép"
            });

            _bs.DataSource = _employees;
            dgvEmployees.DataSource = _bs;
        }

        private void WireBindings()
        {
            txtMaNV.DataBindings.Add("Text", _bs, "MaNV", true, DataSourceUpdateMode.Never);
            txtHoTen.DataBindings.Add("Text", _bs, "HoTen", true, DataSourceUpdateMode.Never);
            cboChucVu.DataBindings.Add("Text", _bs, "ChucVu", true, DataSourceUpdateMode.Never);
            txtPhongBan.DataBindings.Add("Text", _bs, "PhongBan", true, DataSourceUpdateMode.Never);
            dtNgaySinh.DataBindings.Add("Value", _bs, "NgaySinh", true, DataSourceUpdateMode.Never);
            cboGioiTinh.DataBindings.Add("Text", _bs, "GioiTinh", true, DataSourceUpdateMode.Never);
            txtEmail.DataBindings.Add("Text", _bs, "Email", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Add("Text", _bs, "SDT", true, DataSourceUpdateMode.Never);
            cboTrangThai.DataBindings.Add("Text", _bs, "TrangThai", true, DataSourceUpdateMode.Never);
        }

        private void SetEditMode(bool enabled)
        {
            foreach (Control c in grpThongTin.Controls)
            {
                Label lbl = c as Label;
                if (lbl == null) c.Enabled = enabled;
            }
            btnSave.Enabled = enabled;
            btnCancel.Enabled = enabled;

            btnAdd.Enabled = !enabled;
            btnEdit.Enabled = !enabled && _bs.Current != null;
            btnDelete.Enabled = !enabled && _bs.Current != null;
            btnUpload.Enabled = enabled;
        }

        private void ClearInputs()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            cboChucVu.SelectedIndex = -1;
            txtPhongBan.Text = "";
            dtNgaySinh.Value = DateTime.Now.AddYears(-20);
            cboGioiTinh.SelectedIndex = -1;
            txtEmail.Text = "";
            txtSDT.Text = "";
            cboTrangThai.SelectedIndex = -1;
            picAvatar.Image = null;
        }

        private Employee SnapshotFromInputs()
        {
            Employee e = new Employee();
            e.MaNV = txtMaNV.Text.Trim();
            e.HoTen = txtHoTen.Text.Trim();
            e.ChucVu = cboChucVu.Text.Trim();
            e.PhongBan = txtPhongBan.Text.Trim();
            e.NgaySinh = dtNgaySinh.Value.Date;
            e.GioiTinh = cboGioiTinh.Text.Trim();
            e.Email = txtEmail.Text.Trim();
            e.SDT = txtSDT.Text.Trim();
            e.TrangThai = cboTrangThai.Text.Trim();
            e.AvatarBytes = ImageToBytes(picAvatar.Image);
            return e;
        }

        private void ApplyToCurrent(Employee e)
        {
            Employee cur = _bs.Current as Employee;
            if (cur != null)
            {
                cur.MaNV = e.MaNV;
                cur.HoTen = e.HoTen;
                cur.ChucVu = e.ChucVu;
                cur.PhongBan = e.PhongBan;
                cur.NgaySinh = e.NgaySinh;
                cur.GioiTinh = e.GioiTinh;
                cur.Email = e.Email;
                cur.SDT = e.SDT;
                cur.TrangThai = e.TrangThai;
                cur.AvatarBytes = e.AvatarBytes;
                _bs.ResetCurrentItem();
            }
        }

        private string ValidateInputs(out string firstErrorControlName)
        {
            firstErrorControlName = null;
            if (string.IsNullOrWhiteSpace(txtMaNV.Text)) { firstErrorControlName = txtMaNV.Name; return "Mã nhân viên không được để trống."; }
            if (_isNew && _employees.Any(x => string.Equals(x.MaNV, txtMaNV.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            { firstErrorControlName = txtMaNV.Name; return "Mã nhân viên đã tồn tại."; }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)) { firstErrorControlName = txtHoTen.Name; return "Họ tên không được để trống."; }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.Contains("@")) { firstErrorControlName = txtEmail.Name; return "Email không hợp lệ."; }
            if (!string.IsNullOrWhiteSpace(txtSDT.Text) && txtSDT.Text.Any(ch => !char.IsDigit(ch))) { firstErrorControlName = txtSDT.Name; return "Số điện thoại chỉ gồm chữ số."; }
            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isNew = true;
            _editingSnapshot = null;
            ClearInputs();
            SetEditMode(true);
            txtMaNV.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bs.Current == null) return;
            _isNew = false;
            _editingSnapshot = (Employee)((Employee)_bs.Current).Clone();
            SetEditMode(true);
            txtHoTen.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current == null) return;
            Employee cur = (Employee)_bs.Current;
            DialogResult confirm = MessageBox.Show("Xoá nhân viên " + cur.HoTen + " (" + cur.MaNV + ")?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                _employees.Remove(cur);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = ValidateInputs(out string errorControlName);
            if (err != null)
            {
                MessageBox.Show(err, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Control ctl = this.Controls.Find(errorControlName, true).FirstOrDefault();
                if (ctl != null) ctl.Focus();
                return;
            }

            Employee snap = SnapshotFromInputs();
            if (_isNew)
            {
                _employees.Add(snap);
                _bs.Position = _employees.Count - 1;
            }
            else
            {
                ApplyToCurrent(snap);
            }

            SetEditMode(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!_isNew && _editingSnapshot != null)
            {
                ApplyToCurrent(_editingSnapshot);
            }
            SetEditMode(false);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLowerInvariant();
            if (string.IsNullOrEmpty(keyword))
            {
                _bs.DataSource = _employees;
            }
            else
            {
                var filtered = _employees
                    .Where(x => (x.MaNV ?? "").ToLower().Contains(keyword)
                            || (x.HoTen ?? "").ToLower().Contains(keyword)
                            || (x.ChucVu ?? "").ToLower().Contains(keyword)
                            || (x.PhongBan ?? "").ToLower().Contains(keyword)
                            || (x.TrangThai ?? "").ToLower().Contains(keyword))
                    .ToList();
                _bs.DataSource = new BindingList<Employee>(filtered);
            }
            dgvEmployees.DataSource = _bs;
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (_bs.Current is Employee)
            {
                Employee cur = (Employee)_bs.Current;
                picAvatar.Image = BytesToImage(cur.AvatarBytes);
            }
            btnEdit.Enabled = _bs.Current != null && !btnSave.Enabled;
            btnDelete.Enabled = _bs.Current != null && !btnSave.Enabled;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(ofd.FileName);
                    picAvatar.Image = img;
                }
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "NhanVien.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    List<string> lines = new List<string>();
                    lines.Add("MaNV,HoTen,ChucVu,PhongBan,NgaySinh,GioiTinh,Email,SDT,TrangThai");
                    foreach (Employee e1 in _employees)
                    {
                        string line = string.Join(",", new[] {
                            EscapeCsv(e1.MaNV), EscapeCsv(e1.HoTen), EscapeCsv(e1.ChucVu),
                            EscapeCsv(e1.PhongBan), e1.NgaySinh.ToString("yyyy-MM-dd"),
                            EscapeCsv(e1.GioiTinh), EscapeCsv(e1.Email), EscapeCsv(e1.SDT),
                            EscapeCsv(e1.TrangThai)
                        });
                        lines.Add(line);
                    }
                    File.WriteAllLines(sfd.FileName, lines);
                    MessageBox.Show("Đã xuất CSV thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private static string EscapeCsv(string s)
        {
            if (s == null) return "";
            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n"))
            {
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            }
            return s;
        }

        private static byte[] ImageToBytes(Image img)
        {
            if (img == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private static Image BytesToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        // ====== Model ======
        public class Employee : ICloneable
        {
            public string MaNV { get; set; }
            public string HoTen { get; set; }
            public string ChucVu { get; set; }
            public string PhongBan { get; set; }
            public DateTime NgaySinh { get; set; }
            public string GioiTinh { get; set; }
            public string Email { get; set; }
            public string SDT { get; set; }
            public string TrangThai { get; set; }
            public byte[] AvatarBytes { get; set; }

            public object Clone()
            {
                Employee e = new Employee();
                e.MaNV = this.MaNV;
                e.HoTen = this.HoTen;
                e.ChucVu = this.ChucVu;
                e.PhongBan = this.PhongBan;
                e.NgaySinh = this.NgaySinh;
                e.GioiTinh = this.GioiTinh;
                e.Email = this.Email;
                e.SDT = this.SDT;
                e.TrangThai = this.TrangThai;
                e.AvatarBytes = this.AvatarBytes == null ? null : (byte[])this.AvatarBytes.Clone();
                return e;
            }
        }
    }
}
