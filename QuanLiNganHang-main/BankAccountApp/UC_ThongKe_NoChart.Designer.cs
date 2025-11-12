
namespace BankAccountApp
{
    partial class UC_ThongKe_NoChart
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

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDemo = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.grpMonth = new System.Windows.Forms.GroupBox();
            this.pbMonth = new System.Windows.Forms.PictureBox();
            this.grpCategory = new System.Windows.Forms.GroupBox();
            this.pbCategory = new System.Windows.Forms.PictureBox();
            this.grpBalance = new System.Windows.Forms.GroupBox();
            this.pbBalance = new System.Windows.Forms.PictureBox();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblChenhLech = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblChi = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblThu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSoGD = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.table.SuspendLayout();
            this.grpMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonth)).BeginInit();
            this.grpCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).BeginInit();
            this.grpBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBalance)).BeginInit();
            this.grpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTop.Controls.Add(this.btnExport);
            this.pnlTop.Controls.Add(this.btnDemo);
            this.pnlTop.Controls.Add(this.btnFilter);
            this.pnlTop.Controls.Add(this.cboType);
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.dtpTo);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.dtpFrom);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.Size = new System.Drawing.Size(1100, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1018, 14);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 30);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Xuất CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnDemo
            // 
            this.btnDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDemo.Location = new System.Drawing.Point(946, 14);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(66, 30);
            this.btnDemo.TabIndex = 9;
            this.btnDemo.Text = "Demo";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.BtnDemo_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(874, 14);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(66, 30);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Items.AddRange(new object[] { "Tất cả", "Thu", "Chi" });
            this.cboType.Location = new System.Drawing.Point(406, 16);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(100, 28);
            this.cboType.TabIndex = 7;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.CboType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(360, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 23);
            this.label4.Text = "Loại:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(220, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(130, 27);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(170, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.Text = "Tìm:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(104, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(66, 27);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.ValueChanged += new System.EventHandler(this.Dtp_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(90, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 23);
            this.label2.Text = "→";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(24, 17);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(66, 27);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.Dtp_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 23);
            this.label1.Text = "Từ:";
            // 
            // table
            // 
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.Controls.Add(this.grpMonth, 0, 0);
            this.table.Controls.Add(this.grpCategory, 1, 0);
            this.table.Controls.Add(this.grpBalance, 0, 1);
            this.table.Controls.Add(this.grpPreview, 1, 1);
            this.table.Controls.Add(this.grpSummary, 0, 2);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 60);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(8);
            this.table.RowCount = 3;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.table.Size = new System.Drawing.Size(1100, 640);
            this.table.TabIndex = 1;
            // 
            // grpMonth
            // 
            this.grpMonth.Controls.Add(this.pbMonth);
            this.grpMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMonth.Location = new System.Drawing.Point(11, 11);
            this.grpMonth.Name = "grpMonth";
            this.grpMonth.Size = new System.Drawing.Size(538, 282);
            this.grpMonth.TabIndex = 1;
            this.grpMonth.TabStop = false;
            this.grpMonth.Text = "Thu / Chi theo tháng";
            // 
            // pbMonth
            // 
            this.pbMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMonth.Location = new System.Drawing.Point(3, 23);
            this.pbMonth.Name = "pbMonth";
            this.pbMonth.Size = new System.Drawing.Size(532, 256);
            this.pbMonth.TabIndex = 0;
            this.pbMonth.TabStop = false;
            // 
            // grpCategory
            // 
            this.grpCategory.Controls.Add(this.pbCategory);
            this.grpCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCategory.Location = new System.Drawing.Point(555, 11);
            this.grpCategory.Name = "grpCategory";
            this.grpCategory.Size = new System.Drawing.Size(534, 282);
            this.grpCategory.TabIndex = 2;
            this.grpCategory.TabStop = false;
            this.grpCategory.Text = "Chi theo danh mục";
            // 
            // pbCategory
            // 
            this.pbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCategory.Location = new System.Drawing.Point(3, 23);
            this.pbCategory.Name = "pbCategory";
            this.pbCategory.Size = new System.Drawing.Size(528, 256);
            this.pbCategory.TabIndex = 0;
            this.pbCategory.TabStop = false;
            // 
            // grpBalance
            // 
            this.grpBalance.Controls.Add(this.pbBalance);
            this.grpBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBalance.Location = new System.Drawing.Point(11, 299);
            this.grpBalance.Name = "grpBalance";
            this.grpBalance.Size = new System.Drawing.Size(538, 274);
            this.grpBalance.TabIndex = 3;
            this.grpBalance.TabStop = false;
            this.grpBalance.Text = "Số dư tích luỹ theo ngày";
            // 
            // pbBalance
            // 
            this.pbBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBalance.Location = new System.Drawing.Point(3, 23);
            this.pbBalance.Name = "pbBalance";
            this.pbBalance.Size = new System.Drawing.Size(532, 248);
            this.pbBalance.TabIndex = 0;
            this.pbBalance.TabStop = false;
            // 
            // grpPreview
            // 
            this.grpPreview.Controls.Add(this.dgvPreview);
            this.grpPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPreview.Location = new System.Drawing.Point(555, 299);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Size = new System.Drawing.Size(534, 274);
            this.grpPreview.TabIndex = 4;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "Xem nhanh dữ liệu lọc";
            // 
            // dgvPreview
            // 
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreview.BackgroundColor = System.Drawing.Color.White;
            this.dgvPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreview.Location = new System.Drawing.Point(3, 23);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.RowHeadersVisible = false;
            this.dgvPreview.RowTemplate.Height = 28;
            this.dgvPreview.Size = new System.Drawing.Size(528, 248);
            this.dgvPreview.TabIndex = 0;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.lblChenhLech);
            this.grpSummary.Controls.Add(this.label7);
            this.grpSummary.Controls.Add(this.lblChi);
            this.grpSummary.Controls.Add(this.label6);
            this.grpSummary.Controls.Add(this.lblThu);
            this.grpSummary.Controls.Add(this.label5);
            this.grpSummary.Controls.Add(this.lblSoGD);
            this.grpSummary.Controls.Add(this.label8);
            this.grpSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSummary.Location = new System.Drawing.Point(11, 579);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(538, 50);
            this.grpSummary.TabIndex = 0;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Tổng quan";
            // 
            // labels
            // 
            this.lblSoGD = new System.Windows.Forms.Label();
            this.lblSoGD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoGD.Location = new System.Drawing.Point(85, 18);
            this.lblSoGD.Size = new System.Drawing.Size(80, 24);
            this.lblSoGD.Text = "0";
            this.label8 = new System.Windows.Forms.Label();
            this.label8.Location = new System.Drawing.Point(14, 22);
            this.label8.Text = "Số GD:";

            this.lblThu = new System.Windows.Forms.Label();
            this.lblThu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThu.Location = new System.Drawing.Point(240, 18);
            this.lblThu.Size = new System.Drawing.Size(100, 24);
            this.lblThu.Text = "0";
            this.label5 = new System.Windows.Forms.Label();
            this.label5.Location = new System.Drawing.Point(190, 22);
            this.label5.Text = "Thu:";

            this.lblChi = new System.Windows.Forms.Label();
            this.lblChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChi.Location = new System.Drawing.Point(390, 18);
            this.lblChi.Size = new System.Drawing.Size(100, 24);
            this.lblChi.Text = "0";
            this.label6 = new System.Windows.Forms.Label();
            this.label6.Location = new System.Drawing.Point(350, 22);
            this.label6.Text = "Chi:";

            this.lblChenhLech = new System.Windows.Forms.Label();
            this.lblChenhLech.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChenhLech.Location = new System.Drawing.Point(520, 18);
            this.lblChenhLech.Size = new System.Drawing.Size(120, 24);
            this.lblChenhLech.Text = "0";
            this.label7 = new System.Windows.Forms.Label();
            this.label7.Location = new System.Drawing.Point(480, 22);
            this.label7.Text = "CL:";

            // 
            // UC_ThongKe_NoChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Controls.Add(this.pnlTop);
            this.Name = "UC_ThongKe_NoChart";
            this.Size = new System.Drawing.Size(1100, 700);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.table.ResumeLayout(false);
            this.grpMonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMonth)).EndInit();
            this.grpCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).EndInit();
            this.grpBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBalance)).EndInit();
            this.grpPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.grpSummary.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.GroupBox grpMonth;
        private System.Windows.Forms.PictureBox pbMonth;
        private System.Windows.Forms.GroupBox grpCategory;
        private System.Windows.Forms.PictureBox pbCategory;
        private System.Windows.Forms.GroupBox grpBalance;
        private System.Windows.Forms.PictureBox pbBalance;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblSoGD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblThu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblChi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblChenhLech;
        private System.Windows.Forms.Label label7;
    }
}
