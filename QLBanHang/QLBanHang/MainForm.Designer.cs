namespace QLBanHang
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductType = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBill = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateBill = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslbWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNVID = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCatalog,
            this.mnuBill,
            this.mnuImportProduct,
            this.mnuReport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(913, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCatalog
            // 
            this.mnuCatalog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStaff,
            this.mnuCustomer,
            this.mnuSupplier,
            this.mnuAccount,
            this.toolStripSeparator1,
            this.mnuProduct,
            this.mnuProductType,
            this.mnuOrigin,
            this.mnuExit});
            this.mnuCatalog.Image = ((System.Drawing.Image)(resources.GetObject("mnuCatalog.Image")));
            this.mnuCatalog.Name = "mnuCatalog";
            this.mnuCatalog.Size = new System.Drawing.Size(110, 24);
            this.mnuCatalog.Text = "&Danh Mục";
            // 
            // mnuStaff
            // 
            this.mnuStaff.Image = ((System.Drawing.Image)(resources.GetObject("mnuStaff.Image")));
            this.mnuStaff.Name = "mnuStaff";
            this.mnuStaff.Size = new System.Drawing.Size(189, 26);
            this.mnuStaff.Text = "Nhân Viên";
            this.mnuStaff.Click += new System.EventHandler(this.mnuStaff_Click);
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Image = ((System.Drawing.Image)(resources.GetObject("mnuCustomer.Image")));
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.Size = new System.Drawing.Size(189, 26);
            this.mnuCustomer.Text = "Khách Hàng";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // mnuSupplier
            // 
            this.mnuSupplier.Image = ((System.Drawing.Image)(resources.GetObject("mnuSupplier.Image")));
            this.mnuSupplier.Name = "mnuSupplier";
            this.mnuSupplier.Size = new System.Drawing.Size(189, 26);
            this.mnuSupplier.Text = "Nhà Cung Cấp";
            this.mnuSupplier.Click += new System.EventHandler(this.mnuSupplier_Click);
            // 
            // mnuAccount
            // 
            this.mnuAccount.Image = ((System.Drawing.Image)(resources.GetObject("mnuAccount.Image")));
            this.mnuAccount.Name = "mnuAccount";
            this.mnuAccount.Size = new System.Drawing.Size(189, 26);
            this.mnuAccount.Text = "Tài Khoản";
            this.mnuAccount.Click += new System.EventHandler(this.mnuAccount_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuProduct
            // 
            this.mnuProduct.Image = ((System.Drawing.Image)(resources.GetObject("mnuProduct.Image")));
            this.mnuProduct.Name = "mnuProduct";
            this.mnuProduct.Size = new System.Drawing.Size(189, 26);
            this.mnuProduct.Text = "Sản Phẩm";
            this.mnuProduct.Click += new System.EventHandler(this.mnuProduct_Click);
            // 
            // mnuProductType
            // 
            this.mnuProductType.Image = ((System.Drawing.Image)(resources.GetObject("mnuProductType.Image")));
            this.mnuProductType.Name = "mnuProductType";
            this.mnuProductType.Size = new System.Drawing.Size(189, 26);
            this.mnuProductType.Text = "Loại Sản Phẩm";
            this.mnuProductType.Click += new System.EventHandler(this.mnuProductType_Click);
            // 
            // mnuOrigin
            // 
            this.mnuOrigin.Image = ((System.Drawing.Image)(resources.GetObject("mnuOrigin.Image")));
            this.mnuOrigin.Name = "mnuOrigin";
            this.mnuOrigin.Size = new System.Drawing.Size(189, 26);
            this.mnuOrigin.Text = "Nguồn Gốc";
            this.mnuOrigin.Click += new System.EventHandler(this.mnuOrigin_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(189, 26);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuBill
            // 
            this.mnuBill.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateBill});
            this.mnuBill.Image = ((System.Drawing.Image)(resources.GetObject("mnuBill.Image")));
            this.mnuBill.Name = "mnuBill";
            this.mnuBill.Size = new System.Drawing.Size(103, 24);
            this.mnuBill.Text = "&Hóa Đơn";
            // 
            // mnuCreateBill
            // 
            this.mnuCreateBill.Image = ((System.Drawing.Image)(resources.GetObject("mnuCreateBill.Image")));
            this.mnuCreateBill.Name = "mnuCreateBill";
            this.mnuCreateBill.Size = new System.Drawing.Size(180, 26);
            this.mnuCreateBill.Text = "Lập Hóa Đơn";
            this.mnuCreateBill.Click += new System.EventHandler(this.mnuCreateBill_Click);
            // 
            // mnuImportProduct
            // 
            this.mnuImportProduct.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateOrder});
            this.mnuImportProduct.Image = ((System.Drawing.Image)(resources.GetObject("mnuImportProduct.Image")));
            this.mnuImportProduct.Name = "mnuImportProduct";
            this.mnuImportProduct.Size = new System.Drawing.Size(119, 24);
            this.mnuImportProduct.Text = "&Nhập Hàng";
            // 
            // mnuCreateOrder
            // 
            this.mnuCreateOrder.Image = ((System.Drawing.Image)(resources.GetObject("mnuCreateOrder.Image")));
            this.mnuCreateOrder.Name = "mnuCreateOrder";
            this.mnuCreateOrder.Size = new System.Drawing.Size(196, 26);
            this.mnuCreateOrder.Text = "Lập Phiếu Nhập";
            this.mnuCreateOrder.Click += new System.EventHandler(this.mnuCreateOrder_Click);
            // 
            // mnuReport
            // 
            this.mnuReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuReport.Image")));
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(127, 24);
            this.mnuReport.Text = "&Lập Báo Cáo";
            this.mnuReport.Click += new System.EventHandler(this.mnuReport_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbWelcome});
            this.statusStrip1.Location = new System.Drawing.Point(0, 493);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(913, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslbWelcome
            // 
            this.tsslbWelcome.Name = "tsslbWelcome";
            this.tsslbWelcome.Size = new System.Drawing.Size(172, 20);
            this.tsslbWelcome.Text = "Welcome to Bunny Mart!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(913, 485);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Chức vụ:";
            // 
            // txtNVID
            // 
            this.txtNVID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNVID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtNVID.Location = new System.Drawing.Point(121, 50);
            this.txtNVID.Name = "txtNVID";
            this.txtNVID.ReadOnly = true;
            this.txtNVID.Size = new System.Drawing.Size(168, 30);
            this.txtNVID.TabIndex = 11;
            this.txtNVID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 519);
            this.Controls.Add(this.txtNVID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hệ thống quản lý bán hàng";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalog;
        private System.Windows.Forms.ToolStripMenuItem mnuStaff;
        private System.Windows.Forms.ToolStripMenuItem mnuProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuProductType;
        private System.Windows.Forms.ToolStripMenuItem mnuOrigin;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuSupplier;
        private System.Windows.Forms.ToolStripMenuItem mnuAccount;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuBill;
        private System.Windows.Forms.ToolStripMenuItem mnuImportProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateBill;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateOrder;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslbWelcome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNVID;
    }
}