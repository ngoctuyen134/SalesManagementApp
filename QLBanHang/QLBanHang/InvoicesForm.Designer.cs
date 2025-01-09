namespace QLBanHang
{
    partial class InvoicesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInvoicesDetail = new System.Windows.Forms.DataGridView();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.cbMaHD = new System.Windows.Forms.ComboBox();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnCTHD = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNV_Update = new System.Windows.Forms.TextBox();
            this.timeLapHD_update = new System.Windows.Forms.DateTimePicker();
            this.cbKHID_Update = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TimeLapHD_add = new System.Windows.Forms.DateTimePicker();
            this.cbKHID_Add = new System.Windows.Forms.ComboBox();
            this.cbNVID_Add = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHDID_Add = new System.Windows.Forms.TextBox();
            this.btnHoanthanhHD = new System.Windows.Forms.Button();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.btnXuatHD = new System.Windows.Forms.Button();
            this.btnChonSP = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.btnTaoHD = new System.Windows.Forms.Button();
            this.txtSearchSP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSearchSP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicesDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "HÓA ĐƠN(Click vào hàng hóa đơn sẽ hiển thị CTHD đó trên bảng CTHD)";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(1020, 9);
            this.txtTenKH.Multiline = true;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(172, 29);
            this.txtTenKH.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(943, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "Tên KH:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(650, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // dgvInvoicesDetail
            // 
            this.dgvInvoicesDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoicesDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoicesDetail.Location = new System.Drawing.Point(654, 44);
            this.dgvInvoicesDetail.Name = "dgvInvoicesDetail";
            this.dgvInvoicesDetail.RowHeadersWidth = 82;
            this.dgvInvoicesDetail.RowTemplate.Height = 33;
            this.dgvInvoicesDetail.Size = new System.Drawing.Size(539, 294);
            this.dgvInvoicesDetail.TabIndex = 49;
            this.dgvInvoicesDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoicesDetail_CellClick);
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Location = new System.Drawing.Point(12, 47);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.RowHeadersWidth = 82;
            this.dgvInvoices.RowTemplate.Height = 33;
            this.dgvInvoices.Size = new System.Drawing.Size(619, 294);
            this.dgvInvoices.TabIndex = 48;
            this.dgvInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellClick);
            this.dgvInvoices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellContentClick);
            // 
            // cbMaHD
            // 
            this.cbMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaHD.FormattingEnabled = true;
            this.cbMaHD.Location = new System.Drawing.Point(17, 358);
            this.cbMaHD.Name = "cbMaHD";
            this.cbMaHD.Size = new System.Drawing.Size(143, 30);
            this.cbMaHD.TabIndex = 51;
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDeleteProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProduct.Location = new System.Drawing.Point(1074, 344);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(119, 44);
            this.btnDeleteProduct.TabIndex = 52;
            this.btnDeleteProduct.Text = "Xóa SP";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnCTHD
            // 
            this.btnCTHD.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCTHD.Location = new System.Drawing.Point(163, 347);
            this.btnCTHD.Name = "btnCTHD";
            this.btnCTHD.Size = new System.Drawing.Size(221, 52);
            this.btnCTHD.TabIndex = 53;
            this.btnCTHD.Text = "Xem Chi tiết hóa đơn";
            this.btnCTHD.UseVisualStyleBackColor = false;
            this.btnCTHD.Click += new System.EventHandler(this.btnCTHD_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(387, 347);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(122, 52);
            this.btnUpdate.TabIndex = 54;
            this.btnUpdate.Text = "Lưu hóa đơn";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(512, 347);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 52);
            this.btnDelete.TabIndex = 55;
            this.btnDelete.Text = "Xóa hóa đơn";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(661, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(410, 18);
            this.label4.TabIndex = 50;
            this.label4.Text = "Chọn sản phẩm (Để tạo hóa đơn và được hiển thị trên CTHD)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNV_Update);
            this.groupBox1.Controls.Add(this.timeLapHD_update);
            this.groupBox1.Controls.Add(this.cbKHID_Update);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 405);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 137);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sửa hóa đơn";
            // 
            // txtNV_Update
            // 
            this.txtNV_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNV_Update.Location = new System.Drawing.Point(120, 86);
            this.txtNV_Update.Multiline = true;
            this.txtNV_Update.Name = "txtNV_Update";
            this.txtNV_Update.Size = new System.Drawing.Size(106, 35);
            this.txtNV_Update.TabIndex = 13;
            // 
            // timeLapHD_update
            // 
            this.timeLapHD_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLapHD_update.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeLapHD_update.Location = new System.Drawing.Point(382, 56);
            this.timeLapHD_update.Name = "timeLapHD_update";
            this.timeLapHD_update.Size = new System.Drawing.Size(176, 27);
            this.timeLapHD_update.TabIndex = 2;
            // 
            // cbKHID_Update
            // 
            this.cbKHID_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKHID_Update.FormattingEnabled = true;
            this.cbKHID_Update.Location = new System.Drawing.Point(120, 38);
            this.cbKHID_Update.Name = "cbKHID_Update";
            this.cbKHID_Update.Size = new System.Drawing.Size(106, 28);
            this.cbKHID_Update.TabIndex = 1;
            this.cbKHID_Update.SelectedIndexChanged += new System.EventHandler(this.cbKHID_Update_SelectedIndexChanged_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(35, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Mã NV:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(294, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ngày lập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã KH:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TimeLapHD_add);
            this.groupBox2.Controls.Add(this.cbKHID_Add);
            this.groupBox2.Controls.Add(this.cbNVID_Add);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtHDID_Add);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(17, 548);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 142);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thêm hóa đơn";
            // 
            // TimeLapHD_add
            // 
            this.TimeLapHD_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLapHD_add.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TimeLapHD_add.Location = new System.Drawing.Point(380, 90);
            this.TimeLapHD_add.Name = "TimeLapHD_add";
            this.TimeLapHD_add.Size = new System.Drawing.Size(190, 27);
            this.TimeLapHD_add.TabIndex = 2;
            // 
            // cbKHID_Add
            // 
            this.cbKHID_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKHID_Add.FormattingEnabled = true;
            this.cbKHID_Add.Location = new System.Drawing.Point(380, 36);
            this.cbKHID_Add.Name = "cbKHID_Add";
            this.cbKHID_Add.Size = new System.Drawing.Size(122, 28);
            this.cbKHID_Add.TabIndex = 1;
            this.cbKHID_Add.SelectedIndexChanged += new System.EventHandler(this.cbKHID_Add_SelectedIndexChanged_1);
            // 
            // cbNVID_Add
            // 
            this.cbNVID_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNVID_Add.FormattingEnabled = true;
            this.cbNVID_Add.Location = new System.Drawing.Point(115, 90);
            this.cbNVID_Add.Name = "cbNVID_Add";
            this.cbNVID_Add.Size = new System.Drawing.Size(106, 28);
            this.cbNVID_Add.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mã NV:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(295, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mã KH:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(289, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày lập:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mã HĐ:";
            // 
            // txtHDID_Add
            // 
            this.txtHDID_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHDID_Add.Location = new System.Drawing.Point(115, 39);
            this.txtHDID_Add.Multiline = true;
            this.txtHDID_Add.Name = "txtHDID_Add";
            this.txtHDID_Add.Size = new System.Drawing.Size(106, 35);
            this.txtHDID_Add.TabIndex = 12;
            this.txtHDID_Add.TextChanged += new System.EventHandler(this.txtHDID_Add_TextChanged);
            // 
            // btnHoanthanhHD
            // 
            this.btnHoanthanhHD.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnHoanthanhHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanthanhHD.Location = new System.Drawing.Point(387, 696);
            this.btnHoanthanhHD.Name = "btnHoanthanhHD";
            this.btnHoanthanhHD.Size = new System.Drawing.Size(249, 51);
            this.btnHoanthanhHD.TabIndex = 58;
            this.btnHoanthanhHD.Text = "Hoàn thành hóa đơn";
            this.btnHoanthanhHD.UseVisualStyleBackColor = false;
            this.btnHoanthanhHD.Click += new System.EventHandler(this.btnHoanthanhHD_Click);
            // 
            // numSL
            // 
            this.numSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSL.Location = new System.Drawing.Point(741, 727);
            this.numSL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(117, 28);
            this.numSL.TabIndex = 63;
            this.numSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnXuatHD
            // 
            this.btnXuatHD.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXuatHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHD.Location = new System.Drawing.Point(1035, 714);
            this.btnXuatHD.Name = "btnXuatHD";
            this.btnXuatHD.Size = new System.Drawing.Size(157, 52);
            this.btnXuatHD.TabIndex = 61;
            this.btnXuatHD.Text = "Xuất hóa đơn";
            this.btnXuatHD.UseVisualStyleBackColor = false;
            this.btnXuatHD.Click += new System.EventHandler(this.btnXuatHD_Click);
            // 
            // btnChonSP
            // 
            this.btnChonSP.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnChonSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonSP.Location = new System.Drawing.Point(868, 714);
            this.btnChonSP.Name = "btnChonSP";
            this.btnChonSP.Size = new System.Drawing.Size(161, 52);
            this.btnChonSP.TabIndex = 62;
            this.btnChonSP.Text = "Chọn sản phẩm";
            this.btnChonSP.UseVisualStyleBackColor = false;
            this.btnChonSP.Click += new System.EventHandler(this.btnChonSP_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(654, 729);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 22);
            this.label10.TabIndex = 59;
            this.label10.Text = "Số lượng";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(653, 461);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 82;
            this.dgvSanPham.RowTemplate.Height = 33;
            this.dgvSanPham.Size = new System.Drawing.Size(539, 247);
            this.dgvSanPham.TabIndex = 60;
            // 
            // btnTaoHD
            // 
            this.btnTaoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoHD.Location = new System.Drawing.Point(17, 696);
            this.btnTaoHD.Name = "btnTaoHD";
            this.btnTaoHD.Size = new System.Drawing.Size(230, 51);
            this.btnTaoHD.TabIndex = 64;
            this.btnTaoHD.Text = "Tạo Hóa Đơn";
            this.btnTaoHD.UseVisualStyleBackColor = true;
            this.btnTaoHD.Click += new System.EventHandler(this.btnTaoHD_Click);
            // 
            // txtSearchSP
            // 
            this.txtSearchSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSP.Location = new System.Drawing.Point(654, 402);
            this.txtSearchSP.Multiline = true;
            this.txtSearchSP.Name = "txtSearchSP";
            this.txtSearchSP.Size = new System.Drawing.Size(418, 34);
            this.txtSearchSP.TabIndex = 65;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(661, 440);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(321, 18);
            this.label13.TabIndex = 67;
            this.label13.Text = "Nhập tên sản phẩm vào ô phía trên để tìm kiếm.";
            // 
            // btnSearchSP
            // 
            this.btnSearchSP.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSearchSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSP.Location = new System.Drawing.Point(1075, 396);
            this.btnSearchSP.Name = "btnSearchSP";
            this.btnSearchSP.Size = new System.Drawing.Size(118, 42);
            this.btnSearchSP.TabIndex = 68;
            this.btnSearchSP.Text = "Tìm kiếm";
            this.btnSearchSP.UseVisualStyleBackColor = false;
            this.btnSearchSP.Click += new System.EventHandler(this.btnSearchSP_Click);
            // 
            // InvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 785);
            this.Controls.Add(this.btnSearchSP);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSearchSP);
            this.Controls.Add(this.btnTaoHD);
            this.Controls.Add(this.numSL);
            this.Controls.Add(this.btnXuatHD);
            this.Controls.Add(this.btnChonSP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.btnHoanthanhHD);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbMaHD);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnCTHD);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvInvoicesDetail);
            this.Controls.Add(this.dgvInvoices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InvoicesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InvoicesForm";
            this.Load += new System.EventHandler(this.InvoicesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicesDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInvoicesDetail;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.ComboBox cbMaHD;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnCTHD;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker timeLapHD_update;
        private System.Windows.Forms.ComboBox cbKHID_Update;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker TimeLapHD_add;
        private System.Windows.Forms.ComboBox cbKHID_Add;
        private System.Windows.Forms.ComboBox cbNVID_Add;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHDID_Add;
        private System.Windows.Forms.Button btnHoanthanhHD;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Button btnXuatHD;
        private System.Windows.Forms.Button btnChonSP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.TextBox txtNV_Update;
        private System.Windows.Forms.Button btnTaoHD;
        private System.Windows.Forms.TextBox txtSearchSP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSearchSP;
    }
}