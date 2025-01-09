namespace QLBanHang
{
    partial class AccountForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbProfileAcc = new System.Windows.Forms.GroupBox();
            this.btExit = new System.Windows.Forms.Button();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.btDeleteAccount = new System.Windows.Forms.Button();
            this.btEditAccount = new System.Windows.Forms.Button();
            this.btAddAccount = new System.Windows.Forms.Button();
            this.btSearchAcc = new System.Windows.Forms.Button();
            this.txtAccountPass = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.lblSupplierAddress = new System.Windows.Forms.Label();
            this.lblPRoleAcc = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.grbAccountList = new System.Windows.Forms.GroupBox();
            this.dgvListAccount = new System.Windows.Forms.DataGridView();
            this.grbProfileAcc.SuspendLayout();
            this.grbAccountList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // grbProfileAcc
            // 
            this.grbProfileAcc.Controls.Add(this.btExit);
            this.grbProfileAcc.Controls.Add(this.cmbRole);
            this.grbProfileAcc.Controls.Add(this.btDeleteAccount);
            this.grbProfileAcc.Controls.Add(this.btEditAccount);
            this.grbProfileAcc.Controls.Add(this.btAddAccount);
            this.grbProfileAcc.Controls.Add(this.btSearchAcc);
            this.grbProfileAcc.Controls.Add(this.txtAccountPass);
            this.grbProfileAcc.Controls.Add(this.txtAccountName);
            this.grbProfileAcc.Controls.Add(this.txtAccountID);
            this.grbProfileAcc.Controls.Add(this.lblSupplierAddress);
            this.grbProfileAcc.Controls.Add(this.lblPRoleAcc);
            this.grbProfileAcc.Controls.Add(this.lblAccountName);
            this.grbProfileAcc.Controls.Add(this.lblAccountID);
            this.grbProfileAcc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbProfileAcc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProfileAcc.Location = new System.Drawing.Point(0, 0);
            this.grbProfileAcc.Name = "grbProfileAcc";
            this.grbProfileAcc.Size = new System.Drawing.Size(1065, 248);
            this.grbProfileAcc.TabIndex = 0;
            this.grbProfileAcc.TabStop = false;
            this.grbProfileAcc.Text = "Thông tin tài khoản";
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.Location = new System.Drawing.Point(785, 184);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(114, 44);
            this.btExit.TabIndex = 55;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Admin",
            "Nhân Viên",
            "Kho"});
            this.cmbRole.Location = new System.Drawing.Point(706, 108);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(198, 31);
            this.cmbRole.TabIndex = 3;
            // 
            // btDeleteAccount
            // 
            this.btDeleteAccount.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btDeleteAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteAccount.Location = new System.Drawing.Point(453, 184);
            this.btDeleteAccount.Name = "btDeleteAccount";
            this.btDeleteAccount.Size = new System.Drawing.Size(114, 44);
            this.btDeleteAccount.TabIndex = 6;
            this.btDeleteAccount.Text = "Xóa";
            this.btDeleteAccount.UseVisualStyleBackColor = false;
            this.btDeleteAccount.Click += new System.EventHandler(this.btDeleteAccount_Click);
            // 
            // btEditAccount
            // 
            this.btEditAccount.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btEditAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditAccount.Location = new System.Drawing.Point(297, 184);
            this.btEditAccount.Name = "btEditAccount";
            this.btEditAccount.Size = new System.Drawing.Size(114, 44);
            this.btEditAccount.TabIndex = 5;
            this.btEditAccount.Text = "Lưu";
            this.btEditAccount.UseVisualStyleBackColor = false;
            this.btEditAccount.Click += new System.EventHandler(this.btEditAccount_Click);
            // 
            // btAddAccount
            // 
            this.btAddAccount.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddAccount.Location = new System.Drawing.Point(141, 184);
            this.btAddAccount.Name = "btAddAccount";
            this.btAddAccount.Size = new System.Drawing.Size(114, 44);
            this.btAddAccount.TabIndex = 4;
            this.btAddAccount.Text = "Thêm";
            this.btAddAccount.UseVisualStyleBackColor = false;
            this.btAddAccount.Click += new System.EventHandler(this.btAddAccount_Click);
            // 
            // btSearchAcc
            // 
            this.btSearchAcc.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btSearchAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearchAcc.Location = new System.Drawing.Point(609, 184);
            this.btSearchAcc.Name = "btSearchAcc";
            this.btSearchAcc.Size = new System.Drawing.Size(134, 45);
            this.btSearchAcc.TabIndex = 8;
            this.btSearchAcc.Text = "Tìm kiếm";
            this.btSearchAcc.UseVisualStyleBackColor = false;
            this.btSearchAcc.Click += new System.EventHandler(this.btSearchAcc_Click);
            // 
            // txtAccountPass
            // 
            this.txtAccountPass.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountPass.Location = new System.Drawing.Point(706, 67);
            this.txtAccountPass.Name = "txtAccountPass";
            this.txtAccountPass.Size = new System.Drawing.Size(321, 30);
            this.txtAccountPass.TabIndex = 2;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(205, 105);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(321, 30);
            this.txtAccountName.TabIndex = 1;
            // 
            // txtAccountID
            // 
            this.txtAccountID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountID.Location = new System.Drawing.Point(205, 67);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(321, 30);
            this.txtAccountID.TabIndex = 0;
            // 
            // lblSupplierAddress
            // 
            this.lblSupplierAddress.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierAddress.Location = new System.Drawing.Point(571, 69);
            this.lblSupplierAddress.Name = "lblSupplierAddress";
            this.lblSupplierAddress.Size = new System.Drawing.Size(100, 23);
            this.lblSupplierAddress.TabIndex = 54;
            this.lblSupplierAddress.Text = "Mật khẩu";
            this.lblSupplierAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPRoleAcc
            // 
            this.lblPRoleAcc.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPRoleAcc.Location = new System.Drawing.Point(571, 108);
            this.lblPRoleAcc.Name = "lblPRoleAcc";
            this.lblPRoleAcc.Size = new System.Drawing.Size(129, 23);
            this.lblPRoleAcc.TabIndex = 53;
            this.lblPRoleAcc.Text = "Chức vụ";
            this.lblPRoleAcc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountName
            // 
            this.lblAccountName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.Location = new System.Drawing.Point(32, 98);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(172, 40);
            this.lblAccountName.TabIndex = 52;
            this.lblAccountName.Text = "Tên đăng nhập";
            this.lblAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountID
            // 
            this.lblAccountID.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountID.Location = new System.Drawing.Point(32, 62);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(158, 37);
            this.lblAccountID.TabIndex = 51;
            this.lblAccountID.Text = "Mã nhân viên";
            this.lblAccountID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbAccountList
            // 
            this.grbAccountList.Controls.Add(this.dgvListAccount);
            this.grbAccountList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbAccountList.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAccountList.Location = new System.Drawing.Point(0, 248);
            this.grbAccountList.Name = "grbAccountList";
            this.grbAccountList.Size = new System.Drawing.Size(1065, 333);
            this.grbAccountList.TabIndex = 1;
            this.grbAccountList.TabStop = false;
            this.grbAccountList.Text = "Danh sách tài khoản";
            // 
            // dgvListAccount
            // 
            this.dgvListAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListAccount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListAccount.Location = new System.Drawing.Point(3, 26);
            this.dgvListAccount.Name = "dgvListAccount";
            this.dgvListAccount.RowHeadersWidth = 51;
            this.dgvListAccount.RowTemplate.Height = 24;
            this.dgvListAccount.Size = new System.Drawing.Size(1059, 304);
            this.dgvListAccount.TabIndex = 0;
            this.dgvListAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListAccount_CellClick);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 581);
            this.Controls.Add(this.grbAccountList);
            this.Controls.Add(this.grbProfileAcc);
            this.Name = "AccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tài khoản";
            this.grbProfileAcc.ResumeLayout(false);
            this.grbProfileAcc.PerformLayout();
            this.grbAccountList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbProfileAcc;
        private System.Windows.Forms.GroupBox grbAccountList;
        private System.Windows.Forms.Button btSearchAcc;
        private System.Windows.Forms.TextBox txtAccountPass;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.Label lblSupplierAddress;
        private System.Windows.Forms.Label lblPRoleAcc;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Button btDeleteAccount;
        private System.Windows.Forms.Button btEditAccount;
        private System.Windows.Forms.Button btAddAccount;
        private System.Windows.Forms.DataGridView dgvListAccount;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btExit;
    }
}