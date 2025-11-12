namespace BankAccountApp
{
    partial class UC_KhachHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnInterest = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelFindOwner = new System.Windows.Forms.Label();
            this.txtFindOwner = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.labelFrom = new System.Windows.Forms.Label();
            this.btnFindBalance = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.btnFindOwner = new System.Windows.Forms.Button();
            this.listViewAccounts = new System.Windows.Forms.ListView();
            this.colNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpened = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnInterest);
            this.groupBox1.Controls.Add(this.btnSort);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblOwner);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.txtBalance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOwner);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1287, 55);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gray;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(872, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(43, 25);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = " Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(800, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 23);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnInterest
            // 
            this.btnInterest.Location = new System.Drawing.Point(1017, 8);
            this.btnInterest.Name = "btnInterest";
            this.btnInterest.Size = new System.Drawing.Size(65, 23);
            this.btnInterest.TabIndex = 9;
            this.btnInterest.Text = "Cộng lãi";
            this.btnInterest.Click += new System.EventHandler(this.btnInterest_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(946, 9);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(65, 23);
            this.btnSort.TabIndex = 8;
            this.btnSort.Text = "Sắp xếp";
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(729, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(658, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(539, 8);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 5;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(493, 11);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(40, 13);
            this.lblNumber.TabIndex = 2;
            this.lblNumber.Text = "Số TK:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::BankAccountApp.Properties.Resources.man_avatar_user_account_confirm_approve_complete_icon_153151;
            this.label3.Location = new System.Drawing.Point(451, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 39);
            this.label3.TabIndex = 28;
            this.label3.Text = " ";
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(55, 13);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(46, 13);
            this.lblOwner.TabIndex = 0;
            this.lblOwner.Text = "Chủ TK:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(287, 11);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(38, 13);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "Số dư:";
            this.lblBalance.Click += new System.EventHandler(this.lblBalance_Click);
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(331, 10);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(80, 20);
            this.txtBalance.TabIndex = 4;
            this.txtBalance.TextChanged += new System.EventHandler(this.txtBalance_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::BankAccountApp.Properties.Resources.bagofmoney_5108__1_;
            this.label2.Location = new System.Drawing.Point(255, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 39);
            this.label2.TabIndex = 27;
            this.label2.Text = " ";
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(107, 9);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(120, 20);
            this.txtOwner.TabIndex = 3;
            this.txtOwner.TextChanged += new System.EventHandler(this.txtOwner_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.labelFindOwner);
            this.groupBox2.Controls.Add(this.txtFindOwner);
            this.groupBox2.Controls.Add(this.btnTransfer);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.labelAmount);
            this.groupBox2.Controls.Add(this.labelTo);
            this.groupBox2.Controls.Add(this.txtTo);
            this.groupBox2.Controls.Add(this.labelFrom);
            this.groupBox2.Controls.Add(this.btnFindBalance);
            this.groupBox2.Controls.Add(this.txtFrom);
            this.groupBox2.Controls.Add(this.txtMax);
            this.groupBox2.Controls.Add(this.labelMax);
            this.groupBox2.Controls.Add(this.labelMin);
            this.groupBox2.Controls.Add(this.txtMin);
            this.groupBox2.Controls.Add(this.btnFindOwner);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1287, 51);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // labelFindOwner
            // 
            this.labelFindOwner.AutoSize = true;
            this.labelFindOwner.Location = new System.Drawing.Point(6, 12);
            this.labelFindOwner.Name = "labelFindOwner";
            this.labelFindOwner.Size = new System.Drawing.Size(65, 13);
            this.labelFindOwner.TabIndex = 10;
            this.labelFindOwner.Text = "Tìm chủ TK:";
            // 
            // txtFindOwner
            // 
            this.txtFindOwner.Location = new System.Drawing.Point(77, 9);
            this.txtFindOwner.Name = "txtFindOwner";
            this.txtFindOwner.Size = new System.Drawing.Size(150, 20);
            this.txtFindOwner.TabIndex = 11;
            this.txtFindOwner.TextChanged += new System.EventHandler(this.txtFindOwner_TextChanged);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(1042, 7);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(70, 23);
            this.btnTransfer.TabIndex = 24;
            this.btnTransfer.Text = "Chuyển";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(960, 9);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(80, 20);
            this.txtAmount.TabIndex = 23;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(908, 12);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(46, 13);
            this.labelAmount.TabIndex = 20;
            this.labelAmount.Text = "Amount:";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(795, 12);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(23, 13);
            this.labelTo.TabIndex = 19;
            this.labelTo.Text = "To:";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(822, 10);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(80, 20);
            this.txtTo.TabIndex = 22;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(670, 10);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(33, 13);
            this.labelFrom.TabIndex = 18;
            this.labelFrom.Text = "From:";
            // 
            // btnFindBalance
            // 
            this.btnFindBalance.Location = new System.Drawing.Point(555, 8);
            this.btnFindBalance.Name = "btnFindBalance";
            this.btnFindBalance.Size = new System.Drawing.Size(90, 23);
            this.btnFindBalance.TabIndex = 17;
            this.btnFindBalance.Text = "Lọc số dư";
            this.btnFindBalance.Click += new System.EventHandler(this.btnFindBalance_Click);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(709, 7);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(80, 20);
            this.txtFrom.TabIndex = 21;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(469, 9);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(80, 20);
            this.txtMax.TabIndex = 16;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(433, 12);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(30, 13);
            this.labelMax.TabIndex = 14;
            this.labelMax.Text = "Max:";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(314, 12);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(27, 13);
            this.labelMin.TabIndex = 13;
            this.labelMin.Text = "Min:";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(347, 8);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(80, 20);
            this.txtMin.TabIndex = 15;
            // 
            // btnFindOwner
            // 
            this.btnFindOwner.Location = new System.Drawing.Point(233, 9);
            this.btnFindOwner.Name = "btnFindOwner";
            this.btnFindOwner.Size = new System.Drawing.Size(75, 23);
            this.btnFindOwner.TabIndex = 12;
            this.btnFindOwner.Text = "Tìm";
            this.btnFindOwner.Click += new System.EventHandler(this.btnFindOwner_Click);
            // 
            // listViewAccounts
            // 
            this.listViewAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumber,
            this.colOwner,
            this.colBalance,
            this.colOpened,
            this.colNote});
            this.listViewAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAccounts.FullRowSelect = true;
            this.listViewAccounts.HideSelection = false;
            this.listViewAccounts.Location = new System.Drawing.Point(0, 106);
            this.listViewAccounts.Name = "listViewAccounts";
            this.listViewAccounts.OwnerDraw = true;
            this.listViewAccounts.Size = new System.Drawing.Size(1287, 487);
            this.listViewAccounts.TabIndex = 32;
            this.listViewAccounts.UseCompatibleStateImageBehavior = false;
            this.listViewAccounts.View = System.Windows.Forms.View.Details;
            this.listViewAccounts.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewAccounts_DrawColumnHeader);
            this.listViewAccounts.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listViewAccounts_DrawSubItem);
            this.listViewAccounts.SelectedIndexChanged += new System.EventHandler(this.listViewAccounts_SelectedIndexChanged);
            // 
            // colNumber
            // 
            this.colNumber.Text = "Số TK";
            this.colNumber.Width = 180;
            // 
            // colOwner
            // 
            this.colOwner.Text = "Chủ TK";
            this.colOwner.Width = 280;
            // 
            // colBalance
            // 
            this.colBalance.Text = "Số dư";
            this.colBalance.Width = 150;
            // 
            // colOpened
            // 
            this.colOpened.Text = "Ngày mở";
            this.colOpened.Width = 150;
            // 
            // colNote
            // 
            this.colNote.Text = "Ghi Chú";
            this.colNote.Width = 310;
            // 
            // UC_KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewAccounts);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_KhachHang";
            this.Size = new System.Drawing.Size(1287, 593);
            this.Load += new System.EventHandler(this.UC_KhachHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnInterest;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelFindOwner;
        private System.Windows.Forms.TextBox txtFindOwner;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Button btnFindBalance;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Button btnFindOwner;
        private System.Windows.Forms.ListView listViewAccounts;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colOwner;
        private System.Windows.Forms.ColumnHeader colBalance;
        private System.Windows.Forms.ColumnHeader colOpened;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader colNote;
    }
}
