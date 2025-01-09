namespace QLBanHang
{
    partial class OrderForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOrder = new System.Windows.Forms.TabPage();
            this.btnChonProduct = new System.Windows.Forms.Button();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.btnCreatePN = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TimeLapPN_add = new System.Windows.Forms.DateTimePicker();
            this.cbNVID_add = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPNID_add = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeLapPN_update = new System.Windows.Forms.DateTimePicker();
            this.cbNVID_update = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMaPN = new System.Windows.Forms.ComboBox();
            this.btnCTPN = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.dgvOrderDetail = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabKho = new System.Windows.Forms.TabPage();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.btCheckkho = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            this.tabKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1278, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOrder);
            this.tabControl1.Controls.Add(this.tabKho);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1278, 785);
            this.tabControl1.TabIndex = 1;
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.btnChonProduct);
            this.tabOrder.Controls.Add(this.numSL);
            this.tabOrder.Controls.Add(this.btnCreatePN);
            this.tabOrder.Controls.Add(this.btnXoaSP);
            this.tabOrder.Controls.Add(this.label10);
            this.tabOrder.Controls.Add(this.dgvProduct);
            this.tabOrder.Controls.Add(this.label4);
            this.tabOrder.Controls.Add(this.groupBox2);
            this.tabOrder.Controls.Add(this.groupBox1);
            this.tabOrder.Controls.Add(this.cbMaPN);
            this.tabOrder.Controls.Add(this.btnCTPN);
            this.tabOrder.Controls.Add(this.btnUpdate);
            this.tabOrder.Controls.Add(this.btnDelete);
            this.tabOrder.Controls.Add(this.txtTenNV);
            this.tabOrder.Controls.Add(this.dgvOrder);
            this.tabOrder.Controls.Add(this.dgvOrderDetail);
            this.tabOrder.Controls.Add(this.label3);
            this.tabOrder.Controls.Add(this.label2);
            this.tabOrder.Controls.Add(this.label1);
            this.tabOrder.Location = new System.Drawing.Point(4, 29);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrder.Size = new System.Drawing.Size(1270, 752);
            this.tabOrder.TabIndex = 0;
            this.tabOrder.Text = "Nhập Hàng";
            this.tabOrder.UseVisualStyleBackColor = true;
            // 
            // btnChonProduct
            // 
            this.btnChonProduct.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnChonProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonProduct.Location = new System.Drawing.Point(867, 677);
            this.btnChonProduct.Name = "btnChonProduct";
            this.btnChonProduct.Size = new System.Drawing.Size(163, 52);
            this.btnChonProduct.TabIndex = 35;
            this.btnChonProduct.Text = "Chọn sản phẩm";
            this.btnChonProduct.UseVisualStyleBackColor = false;
            this.btnChonProduct.Click += new System.EventHandler(this.btnChonProduct_Click);
            // 
            // numSL
            // 
            this.numSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSL.Location = new System.Drawing.Point(724, 690);
            this.numSL.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numSL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(119, 28);
            this.numSL.TabIndex = 34;
            this.numSL.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnCreatePN
            // 
            this.btnCreatePN.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCreatePN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePN.Location = new System.Drawing.Point(1054, 676);
            this.btnCreatePN.Name = "btnCreatePN";
            this.btnCreatePN.Size = new System.Drawing.Size(191, 52);
            this.btnCreatePN.TabIndex = 32;
            this.btnCreatePN.Text = "Tạo phiếu nhập";
            this.btnCreatePN.UseVisualStyleBackColor = false;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaSP.Location = new System.Drawing.Point(1110, 330);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(139, 52);
            this.btnXoaSP.TabIndex = 33;
            this.btnXoaSP.Text = "Xóa sản phẩm";
            this.btnXoaSP.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(619, 692);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 22);
            this.label10.TabIndex = 29;
            this.label10.Text = "Số lượng";
            // 
            // dgvProduct
            // 
            this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(619, 390);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersWidth = 82;
            this.dgvProduct.RowTemplate.Height = 33;
            this.dgvProduct.Size = new System.Drawing.Size(630, 277);
            this.dgvProduct.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(423, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Chọn Sản phẩm(Để tạo PN và được hiển thị trên CTPN)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TimeLapPN_add);
            this.groupBox2.Controls.Add(this.cbNVID_add);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtPNID_add);
            this.groupBox2.Location = new System.Drawing.Point(21, 535);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(562, 142);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thêm phiếu nhập";
            // 
            // TimeLapPN_add
            // 
            this.TimeLapPN_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLapPN_add.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TimeLapPN_add.Location = new System.Drawing.Point(369, 65);
            this.TimeLapPN_add.Name = "TimeLapPN_add";
            this.TimeLapPN_add.Size = new System.Drawing.Size(176, 28);
            this.TimeLapPN_add.TabIndex = 2;
            // 
            // cbNVID_add
            // 
            this.cbNVID_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNVID_add.FormattingEnabled = true;
            this.cbNVID_add.Location = new System.Drawing.Point(101, 92);
            this.cbNVID_add.Name = "cbNVID_add";
            this.cbNVID_add.Size = new System.Drawing.Size(132, 30);
            this.cbNVID_add.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mã NV:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày lập:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mã PN:";
            // 
            // txtPNID_add
            // 
            this.txtPNID_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPNID_add.Location = new System.Drawing.Point(101, 39);
            this.txtPNID_add.Multiline = true;
            this.txtPNID_add.Name = "txtPNID_add";
            this.txtPNID_add.Size = new System.Drawing.Size(132, 35);
            this.txtPNID_add.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeLapPN_update);
            this.groupBox1.Controls.Add(this.cbNVID_update);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(21, 402);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 127);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sửa phiếu nhập";
            // 
            // timeLapPN_update
            // 
            this.timeLapPN_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLapPN_update.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeLapPN_update.Location = new System.Drawing.Point(369, 56);
            this.timeLapPN_update.Name = "timeLapPN_update";
            this.timeLapPN_update.Size = new System.Drawing.Size(176, 28);
            this.timeLapPN_update.TabIndex = 2;
            // 
            // cbNVID_update
            // 
            this.cbNVID_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNVID_update.FormattingEnabled = true;
            this.cbNVID_update.Location = new System.Drawing.Point(82, 56);
            this.cbNVID_update.Name = "cbNVID_update";
            this.cbNVID_update.Size = new System.Drawing.Size(151, 30);
            this.cbNVID_update.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ngày lập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã NV:";
            // 
            // cbMaPN
            // 
            this.cbMaPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaPN.FormattingEnabled = true;
            this.cbMaPN.Location = new System.Drawing.Point(21, 340);
            this.cbMaPN.Name = "cbMaPN";
            this.cbMaPN.Size = new System.Drawing.Size(137, 30);
            this.cbMaPN.TabIndex = 19;
            // 
            // btnCTPN
            // 
            this.btnCTPN.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTPN.Location = new System.Drawing.Point(164, 329);
            this.btnCTPN.Name = "btnCTPN";
            this.btnCTPN.Size = new System.Drawing.Size(221, 52);
            this.btnCTPN.TabIndex = 20;
            this.btnCTPN.Text = "Chi tiết phiếu nhập";
            this.btnCTPN.UseVisualStyleBackColor = false;
            this.btnCTPN.Click += new System.EventHandler(this.btnCTPN_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(391, 329);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 52);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(490, 329);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 52);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTenNV.Location = new System.Drawing.Point(1090, 8);
            this.txtTenNV.Multiline = true;
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(172, 32);
            this.txtTenNV.TabIndex = 18;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(21, 46);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 82;
            this.dgvOrder.RowTemplate.Height = 33;
            this.dgvOrder.Size = new System.Drawing.Size(562, 277);
            this.dgvOrder.TabIndex = 16;
            this.dgvOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellClick);
            // 
            // dgvOrderDetail
            // 
            this.dgvOrderDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetail.Location = new System.Drawing.Point(619, 47);
            this.dgvOrderDetail.Name = "dgvOrderDetail";
            this.dgvOrderDetail.RowHeadersWidth = 82;
            this.dgvOrderDetail.RowTemplate.Height = 33;
            this.dgvOrderDetail.Size = new System.Drawing.Size(630, 276);
            this.dgvOrderDetail.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(996, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tên NV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(615, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "CHI TIẾT PHIẾU NHẬP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "PHIẾU NHẬP(Click vào hàng hóa đơn sẽ hiển thị CTPN đó trên bảng CTPN)";
            // 
            // tabKho
            // 
            this.tabKho.Controls.Add(this.btnThoat);
            this.tabKho.Controls.Add(this.dgvKho);
            this.tabKho.Controls.Add(this.btCheckkho);
            this.tabKho.Controls.Add(this.label11);
            this.tabKho.Location = new System.Drawing.Point(4, 29);
            this.tabKho.Name = "tabKho";
            this.tabKho.Padding = new System.Windows.Forms.Padding(3);
            this.tabKho.Size = new System.Drawing.Size(1270, 752);
            this.tabKho.TabIndex = 1;
            this.tabKho.Text = "Kho";
            this.tabKho.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(781, 588);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(192, 53);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvKho
            // 
            this.dgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKho.Location = new System.Drawing.Point(8, 11);
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.RowHeadersWidth = 51;
            this.dgvKho.RowTemplate.Height = 24;
            this.dgvKho.Size = new System.Drawing.Size(1254, 532);
            this.dgvKho.TabIndex = 17;
            // 
            // btCheckkho
            // 
            this.btCheckkho.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btCheckkho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCheckkho.Location = new System.Drawing.Point(548, 588);
            this.btCheckkho.Name = "btCheckkho";
            this.btCheckkho.Size = new System.Drawing.Size(192, 53);
            this.btCheckkho.TabIndex = 16;
            this.btCheckkho.Text = "Kiểm tra  ";
            this.btCheckkho.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(282, 605);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(218, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Kiểm tra số lượng sản phẩm";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 773);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabOrder.ResumeLayout(false);
            this.tabOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            this.tabKho.ResumeLayout(false);
            this.tabKho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOrder;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.DataGridView dgvOrderDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabKho;
        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.Button btCheckkho;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbMaPN;
        private System.Windows.Forms.Button btnCTPN;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChonProduct;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Button btnCreatePN;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker TimeLapPN_add;
        private System.Windows.Forms.ComboBox cbNVID_add;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPNID_add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker timeLapPN_update;
        private System.Windows.Forms.ComboBox cbNVID_update;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThoat;
    }
}