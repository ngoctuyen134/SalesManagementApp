using QLBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Globalization;

namespace QLBanHang
{
    public partial class InvoicesForm : Form
    {
        private DataProvider dataProvider = new DataProvider();
        string EmployeeID_codinh, ProductIDCTHD, InvoicesID = "";
        List<string> ProductIDAdd_UpdateInvoiceDetail = new List<string>();
        int slnoupdate = 0, rowInvoiceDetail = 0;

        public InvoicesForm()
        {
            InitializeComponent();
            Init();

        }
        //public InvoicesForm(string username)
        //{
        //    if (!string.IsNullOrEmpty(username))
        //    {
        //        InitializeComponent();
        //        EmployeeID_codinh = username;
                
        //        cbNVID_Add.Text = username;
        //        cbNVID_Update.Text = username;
        //        cbNVID_Add.Enabled = false;
        //        cbNVID_Update.Enabled = false;

        //    }
        //    else
        //    {
        //        MessageBox.Show("Lỗi: Tên nhân viên không hợp lệ.");
        //    }
        //}

        // Để thêm cột CheckBox vào DataGridView
        private void AddCheckBoxColumn(DataGridView dataGridView)
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Chọn";
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridView.Columns.Insert(0, checkBoxColumn);
        }
        // Để cập nhật trạng thái checkbox dựa trên dữ liệu
        private void UpdateCheckBoxes(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"];
                checkBox.Value = false; // Set giá trị ban đầu cho checkbox là false (không chọn)
            }
        }

        // Đặt lại các checkbox, chỉ cho phép chọn một hàng tại một thời điểm
        private void ResetCheckBoxes(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell;
                checkBoxCell.Value = false;
            }
            numSL.Value = 1;
        }

        private void Init()
        {
            LoaddgvInvoices();
            LoaddgvSanPham();
            LoadcbKHID_Update();
            LoadcbKHID_Add();
            LoaddgvInvoicesDetail();
            LoadcbNVID_Add();
            

            AddCheckBoxColumn(dgvSanPham);
            UpdateCheckBoxes(dgvSanPham);
        }

        private void LoaddgvInvoicesDetail()
        {
            dgvInvoicesDetail.Columns.Add("Mã sản phẩm", "Mã sản phẩm");
            dgvInvoicesDetail.Columns.Add("Tên sản phẩm", "Tên sản phẩm");
            dgvInvoicesDetail.Columns.Add("Số lượng", "Số lượng");
            dgvInvoicesDetail.Columns.Add("Tổng tiền", "Tổng tiền");
            //dgvInvoices.DataSource = dt; // Sau đó gán dữ liệu
        }

        private void DgvInvoicesDetail(string Idhoadon)
        {
            dgvInvoicesDetail.Rows.Clear();
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("Select A.ProductID as [Mã sản phẩm], ProductName as [Tên sản phẩm], A.Quantity as [Số lượng]," +
                " A.Quantity * B.SalePrice as [Tổng tiền]" +
            " from InvoiceDetail A join Product B on A.ProductID = B.ProductID " +
            "where InvoiceID = '" + Idhoadon + "'");
            dt = dataProvider.ExecuteQuery(query.ToString());
            foreach (DataRow row in dt.Rows)
            {
                string maSanPham = row["Mã sản phẩm"].ToString();
                string tenSanPham = row["Tên sản phẩm"].ToString();
                string soLuong = row["Số lượng"].ToString();
               
                string tongTien = row["Tổng tiền"].ToString();

                // Thêm thông tin về sản phẩm vào dgvCTHD
                dgvInvoicesDetail.Rows.Add(maSanPham, tenSanPham, soLuong, tongTien);
            }
        }

        private void loadcbCTHD()
        {
            DataTable dt = new DataTable();
            //if (EmployeeID_codinh.Contains("Admin"))
            //{
                dt = dataProvider.ExecuteQuery("select * from Invoice");
                cbMaHD.DisplayMember = "InvoiceID";
                cbMaHD.ValueMember = "Invoice";
                cbMaHD.DataSource = dt;
            //}
            //else
            //{
            //    dt = dataProvider.ExecuteQuery("select * from Invoice where EmployeeID = '" + EmployeeID_codinh + "'");
            //    cbMaHD.DisplayMember = "InvoiceID";
            //    cbMaHD.ValueMember = "InvoiceID";
            //    cbMaHD.DataSource = dt;
            //}
        }

        private void LoaddgvInvoices()
        {
            DataTable dt = new DataTable();
            //if (EmployeeID_codinh.Contains("Admin"))
            //{
                StringBuilder query = new StringBuilder("Select InvoiceID as [Mã HD], CustomerID as [Mã KH], EmployeeID as [Mã NV]," +
               "InvoiceDate as [Ngày lập], TotalAmount as [Tổng tiền] from Invoice ;");
                dt = dataProvider.ExecuteQuery(query.ToString());
                dgvInvoices.DataSource = dt;
                loadcbCTHD();
            //}
            //else
            //{
            //    StringBuilder query = new StringBuilder("Select InvoiceID as [Mã HD], CustomerID as [Mã KH], EmployeeID as [Mã NV]," +
            //   "InvoiceDate as [Ngày lập], TotalAmount as [Tổng tiền] from Invoice where EmployeeID = '" + EmployeeID_codinh + "'");
            //    dt = dataProvider.ExecuteQuery(query.ToString());
            //    dgvInvoices.DataSource = dt;
            //    loadcbCTHD();
            //}
        }

        private void LoadcbKHID_Add()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.ExecuteQuery("select * from Customer");
            cbKHID_Add.DisplayMember = "CustomerID";
            cbKHID_Add.ValueMember = "CustomerID";
            cbKHID_Add.DataSource = dt;
        }
        private void LoadcbKHID_Update()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.ExecuteQuery("select * from Customer");
            cbKHID_Update.DisplayMember = "CustomerID";
            cbKHID_Update.ValueMember = "CustomerID";
            cbKHID_Update.DataSource = dt;
        }

        private void LoadcbNVID_Add()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.ExecuteQuery("select * from Employee ");
            cbNVID_Add.DisplayMember = "EmployeeID";
            cbNVID_Add.ValueMember = "EmployeeID";
            cbNVID_Add.DataSource = dt;

        }


        private void btnCTHD_Click(object sender, EventArgs e)
        {
            DgvInvoicesDetail(cbMaHD.Text);
        }

        //Hiển thị nội dung cột hóa đơn và CTHD
        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;
            if (rowID < 0) rowID = 0;
            if (rowID == dgvInvoices.RowCount - 1) rowID = rowID - 1;
            DataGridViewRow row = dgvInvoices.Rows[rowID];
            cbKHID_Update.Text = row.Cells[1].Value.ToString();
            txtNV_Update.Text = row.Cells[2].Value.ToString();
            timeLapHD_update.Value = Convert.ToDateTime(row.Cells[3].Value);
            InvoicesID = row.Cells[0].Value.ToString();
            DgvInvoicesDetail(InvoicesID);
            LoadtxtCustomerName(InvoicesID);
            cbMaHD.Text = InvoicesID;
            //Kiểm tra xem dgvCTHD có bao nhiu hàng để khi thêm vào CTHD đã có
            
            rowInvoiceDetail = dgvInvoicesDetail.RowCount;
            
        }

        private void LoadtxtCustomerName(string InvoiceID)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("Select C.CustomerName " +
                "from InvoiceDetail A join Invoice B on B.InvoiceID = A.InvoiceID join " +
                "Customer C on C.CustomerID = B.CustomerID where B.InvoiceID = '" + InvoiceID + "'");
            dt = dataProvider.ExecuteQuery(query.ToString());

            // Kiểm tra xem DataTable có dữ liệu không
            if (dt.Rows.Count > 0)
            {
                
                // Lấy giá trị từ dòng đầu tiên của cột KH_Name
                string tenKH = dt.Rows[0]["CustomerName"].ToString();

                // Gán giá trị vào TextBox
                txtTenKH.Text = tenKH;
            }
            else
            {
                txtTenKH.Text = ""; // Nếu không có dữ liệu, gán giá trị rỗng cho TextBox
                MessageBox.Show("Không có dữ liệu để hiển thị!");
            }
        }

        private void LoaddgvSanPham()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("Select ProductID as [Mã sản phẩm], ProductName as [Tên sản phẩm], SalePrice as [Giá bán] from Product;");
            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvSanPham.DataSource = dt;
        }
        //private void InvoicesForm_Load(object sender, EventArgs e)
        //{
        //    LoaddgvInvoices(); // Nạp danh sách hóa đơn
        //    LoaddgvSanPham();  // Nạp danh sách sản phẩm
        //    LoaddgvInvoicesDetail(); // Nạp chi tiết hóa đơn (có thể điều chỉnh khi cần)
        //}

        

        //Gán vào ô tên khách hàng
        private void CapnhapTenKH(ComboBox comboBox)
        {
            if (comboBox.SelectedItem != null)
            {
                string selectedKHID = comboBox.SelectedValue.ToString();

                DataTable dt = new DataTable();
                StringBuilder query = new StringBuilder("SELECT CustomerName FROM Customer WHERE CustomerID = '" + selectedKHID + "'");
                dt = dataProvider.ExecuteQuery(query.ToString());

                if (dt.Rows.Count > 0)
                {
                    string tenKH = dt.Rows[0]["CustomerName"].ToString();

                    txtTenKH.Text = tenKH;
                }
                else
                {
                    txtTenKH.Text = "";
                }
            }
            txtTenKH.ReadOnly = true;
        }

        private void cbKHID_Update_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CapnhapTenKH(cbKHID_Update);
        }

        private void cbKHID_Add_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CapnhapTenKH(cbKHID_Add);
        }

        //Thêm hóa đơn
        private void ThemSPCTHD()
        {
            bool coHangDuocChon = false;
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(checkBoxCell.Value))
                {
                    coHangDuocChon = true;

                    string maSanPham = row.Cells["Mã sản phẩm"].Value.ToString();
                    string tenSanPham = row.Cells["Tên sản phẩm"].Value.ToString();
                    string giaBan = row.Cells["Giá bán"].Value.ToString();
                    int soLuong = Convert.ToInt32(numSL.Value);
                    int slkho = GetCurrentStock("Product", maSanPham);
                    if (slkho < soLuong)
                    {
                        MessageBox.Show("Hàng này hiện tại đang hết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        LaySPKho(maSanPham, soLuong);
                        //Gán mã SP đã chọn vào biến mã SP để thêm SP tring trường hợp sửa CTHD
                        ProductIDAdd_UpdateInvoiceDetail.Add(maSanPham);

                        // Thêm SP vào chi tiết hóa đơn
                        ThemSPExistsCTHD(maSanPham, tenSanPham, giaBan, soLuong);
                    }
                }
            }

            if (coHangDuocChon)
            {
                ResetCheckBoxes(dgvSanPham);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi thêm vào hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ThemSPExistsCTHD(string maSanPham, string tenSanPham, string giaBan, int soLuong)
        {
            // Kiểm tra số lượng sản phẩm đã nhập
            if (soLuong == 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool found = false;
            foreach (DataGridViewRow dgvRow in dgvInvoicesDetail.Rows)
            {
                if (dgvRow.Cells["Mã sản phẩm"].Value != null && dgvRow.Cells["Mã sản phẩm"].Value.ToString() == maSanPham)
                {
                    int soLuongCu = Convert.ToInt32(dgvRow.Cells["Số lượng"].Value);
                    dgvRow.Cells["Số lượng"].Value = soLuongCu + soLuong;

                    decimal giaBanCu = Convert.ToDecimal(giaBan);
                    decimal tongTienCu = Convert.ToDecimal(dgvRow.Cells["Tổng tiền"].Value);
                    dgvRow.Cells["Tổng tiền"].Value = (soLuongCu + soLuong) * giaBanCu;

                    found = true;
                    break;
                }
            }
            if (!found)
            {
                dgvInvoicesDetail.Rows.Add(maSanPham, tenSanPham, soLuong, soLuong * Convert.ToDecimal(giaBan));
            }
        }



        //Cập nhập kho
        private void LaySPKho(string maSanPham, int soluong)
        {
            int slKho = GetCurrentStock("Product", maSanPham);
            if (slKho < soluong)
            {
                // Xử lý trường hợp không đủ hàng trong kho
                MessageBox.Show("Không đủ số lượng trong kho");
                return;
            }
            int slmoi = slKho - soluong;
            UpdateStock(maSanPham, slmoi);
        }

        private void ThemSPKho(string maSanPham, int soluong)
        {
            int slKho = GetCurrentStock("Product", maSanPham);
            int slmoi = slKho + soluong;
            UpdateStock(maSanPham, slmoi);
        }

        private void SuaSPKho(string maSanPham, int soluong)
        {
            string query = "SELECT Quantity FROM InvoiceDetail WHERE ProductID = @ProductID AND InvoiceID = @InvoiceID";
            DataTable dt = dataProvider.ExecuteQuery(query, new object[] { maSanPham, InvoicesID });

            if (dt.Rows.Count > 0)
            {
                int slCTHD = (int)dt.Rows[0][0]; // Số lượng chi tiết hóa đơn
                int slKho = GetCurrentStock("Product", maSanPham); // Số lượng hiện tại trong kho

                if (slCTHD > soluong)
                {
                    UpdateStock(maSanPham, slKho + (slCTHD - soluong));
                }
                else if (slCTHD < soluong)
                {
                    UpdateStock(maSanPham, slKho - (soluong - slCTHD));
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm trong chi tiết hóa đơn");
            }
        }

        

        private int GetCurrentStock(string tableName, string maSanPham)
        {
           
            string query = $"SELECT Quantity FROM {tableName} WHERE ProductID = '{maSanPham}'";
            
            DataTable dt = dataProvider.ExecuteQuery(query.ToString());

            // Kiểm tra nếu DataTable có ít nhất 1 dòng
            if (dt.Rows.Count > 0)
            {
                // Lấy số lượng sản phẩm từ cột đầu tiên của dòng đầu tiên
                // Kiểm tra giá trị trước khi ép kiểu
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    return Convert.ToInt32(dt.Rows[0][0]); // Chuyển đổi sang int
                }
                else
                {
                    // Trường hợp số lượng là null trong cơ sở dữ liệu
                    return 0; // Trả về 0 nếu không có số lượng
                }
            }
            else
            {
                // Nếu không có kết quả, trả về giá trị mặc định
                return 0; // Giá trị mặc định khi không có dữ liệu
            }
        }

        private void btnChonSP_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem có hàng nào trong cthd k, nếu có thì thêm SP đang là sửa lại CTHD trong hóa đơn đã có
            if (rowInvoiceDetail > 0)
            {
                ThemSPCTHD();
            }
            //Nếu không thì chúng ta chọn SP là đang tạo hóa đơn
            else if (txtHDID_Add.Text == "" || cbKHID_Add.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin hóa đơn trước khi thêm sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ThemSPCTHD();
            }
        }

        private void UpdateStock(string maSanPham, int slMoi)
        {
            StringBuilder query = new StringBuilder("EXEC PROC_EditDepot ");
            query.Append(" @ProductID = '" + maSanPham + "'");

            query.Append(",@Quantity = '" + Convert.ToString(slMoi) + "'");
            int result = dataProvider.ExecuteNonQuery(query.ToString());
        }

       

        private void btnHoanthanhHD_Click(object sender, EventArgs e)
        {
            if (txtHDID_Add.Text == "" || cbKHID_Add.Text == "" || dgvInvoicesDetail.RowCount == 1)
            {
                MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
            }
            else
            {

                DateTime ngaylap = TimeLapHD_add.Value;
                StringBuilder query = new StringBuilder("EXEC PROC_AddInvoice ");
                query.Append("@InvoiceID = '" + txtHDID_Add.Text + "', ");
                query.Append("@CustomerID = '" + cbKHID_Add.Text + "', ");
                query.Append("@EmployeeID = '" + cbNVID_Add.Text + "', ");
                query.Append("@InvoiceDate = '" + ngaylap.ToString("yyyy-MM-dd") + "', ");
                query.Append("@TotalAmount = " + CalculateTotal().ToString());
                int result1 = dataProvider.ExecuteNonQuery(query.ToString());


                foreach (DataGridViewRow dgvRow in dgvInvoicesDetail.Rows)
                {
                    if(dgvRow.Cells["Mã sản phẩm"].Value != null && dgvRow.Cells["Số lượng"].Value != null && dgvRow.Cells["Tổng tiền"].Value != null )
            {
                        // Tạo câu truy vấn thêm chi tiết hóa đơn
                        query = new StringBuilder("EXEC PROC_AddInvoiceDetail ");
                        query.Append("@InvoiceID = '" + txtHDID_Add.Text + "',  ");
                        query.Append("@ProductID = '" + dgvRow.Cells["Mã sản phẩm"].Value.ToString() + "', ");
                        query.Append("@Quantity = '" + dgvRow.Cells["Số lượng"].Value.ToString() + "', ");
                        query.Append("@TotalPrice = " + dgvRow.Cells["Tổng tiền"].Value.ToString());

                        // Thực thi truy vấn thêm chi tiết hóa đơn
                        int result2 = dataProvider.ExecuteNonQuery(query.ToString());

                        // Cập nhật kho hàng
                        //LaySPKho(dgvRow.Cells["Mã sản phẩm"].Value.ToString(), Convert.ToInt32(dgvRow.Cells["Số lượng"].Value));
                    }
                }


                if (result1 > 0)
                {
                    dgvInvoicesDetail.Rows.Clear();
                    txtHDID_Add.Text = "";
                    LoaddgvInvoices();
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private decimal CalculateTotal()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow dgvRow in dgvInvoicesDetail.Rows)
            {
                if (dgvRow.Cells["Mã sản phẩm"].Value != null && dgvRow.Cells["Số lượng"].Value != null && dgvRow.Cells["Tổng tiền"].Value != null)
                {
                    tongTien += Convert.ToDecimal(dgvRow.Cells["Tổng tiền"].Value);
                }
            }
            return tongTien;
        }

        private bool IsHDIDExists(string InvoicesID)
        {
            string query = "Select count(*) from Invoice where InvoiceID = '" + InvoicesID + "'";

            int count = Convert.ToInt32(dataProvider.ExecuteScalar(query));
            return count > 0;
        }

        //Khi nhập ô Mã HĐ nếu đã có tồn tại thì hiển thị thông báo
        private void txtHDID_Add_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHDID_Add.Text))
            {
                dgvInvoicesDetail.Rows.Clear();
            }
            if (!string.IsNullOrEmpty(txtHDID_Add.Text))
            {
                if (IsHDIDExists(txtHDID_Add.Text))
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Xóa Hóa đơn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbMaHD.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Thông báo");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    foreach (DataGridViewRow dgvRow in dgvInvoicesDetail.Rows)
                    {
                        if (dgvRow.Cells["Mã sản phẩm"].Value != null && dgvRow.Cells["Số lượng"].Value != null && dgvRow.Cells["Tổng tiền"].Value != null)
                        {
                            ThemSPKho(dgvRow.Cells["Mã sản phẩm"].Value.ToString(), Convert.ToInt32(dgvRow.Cells["Số lượng"].Value));
                        }
                    }
                    string query = "DELETE FROM InvoiceDetail WHERE InvoiceID = '" + cbMaHD.Text + "'";
                    int rowsAffected1 = dataProvider.ExecuteNonQuery(query);
                    query = "DELETE FROM Invoice WHERE InvoiceID = '" + cbMaHD.Text + "'";
                    int rowsAffected2 = dataProvider.ExecuteNonQuery(query);

                    if (rowsAffected1 > 0 && rowsAffected2 > 0)
                    {
                        dgvInvoicesDetail.Rows.Clear();
                        LoaddgvInvoices();
                        MessageBox.Show("Xóa hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Sửa hóa đơn
        private void dgvInvoicesDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;
            if (rowID < 0) rowID = 0;
            if (rowID == dgvInvoicesDetail.RowCount - 1) rowID = rowID - 1;
            DataGridViewRow row = dgvInvoicesDetail.Rows[rowID];
            numSL.Value = Convert.ToInt32(row.Cells[2].Value);
            //Kiểm tra xem biến số lượng có thay đổi không
            slnoupdate = Convert.ToInt32(row.Cells[2].Value);
            ProductIDCTHD = row.Cells[0].Value.ToString();
        }

       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string maKH = cbKHID_Update.Text;
            string maNV = txtNV_Update.Text;
            DateTime ngayLap = timeLapHD_update.Value;
            decimal tongTien = CalculateTotal(); // Tính tổng tiền của hóa đơn
                                                 //Kiểm tra xem ô mã nv và mã kh có nội dung không
            if (cbKHID_Update.Text == "" || txtNV_Update.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng và nhân viên cần cập nhật!", "Thông báo");
            }
            else
            {
                //Trường hợp này là sửa hóa đơn khi xóa sản phẩm 
                //Vì khi xóa sản phẩm đã xóa trong CTHD rồi nên khi Cập nhập lại CTHD sẽ bị sai
                if (dgvInvoicesDetail.RowCount < rowInvoiceDetail)
                {
                    UpdateHoadon(InvoicesID);
                }
                //Trường hợp này là sửa hóa đơn khi thêm sản phẩm bắt buộc phải cập nhập lại CTHD
                else if (dgvInvoicesDetail.RowCount > rowInvoiceDetail)//kiểm tra xem dgvCTHD có thêm hàng nào không
                {
                    int result = 0;
                    foreach (string maSP in ProductIDAdd_UpdateInvoiceDetail)
                    {
                        foreach (DataGridViewRow dgvRow in dgvInvoicesDetail.Rows)
                        {
                            if (dgvRow.Cells["Mã sản phẩm"].Value == maSP  && dgvRow.Cells["Số lượng"].Value != null && dgvRow.Cells["Tổng tiền"].Value != null)
                            {
                                StringBuilder query = new StringBuilder("EXEC PROC_AddInvoiceDetail ");
                                query.Append("@InvoiceID = '" + InvoicesID + "', ");  
                                query.Append("@ProductID = '" + dgvRow.Cells["Mã sản phẩm"].Value.ToString() + "', ");
                                query.Append("@Quantity = '" + dgvRow.Cells["Số lượng"].Value.ToString() + "', ");
                                query.Append("@TotalPrice = " + dgvRow.Cells["Tổng tiền"].Value.ToString());

                                result += dataProvider.ExecuteNonQuery(query.ToString());
                            }
                        }
                    }
                    ProductIDAdd_UpdateInvoiceDetail.Clear();
                    if (result > 0)
                    {
                        UpdateHoadon(InvoicesID);
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công!", "Thông báo");
                    }
                }
                //Trường hợp còn lại là sửa hóa đơn khi sửa sách bắt buộc phải cập nhập lại CTHD
                else
                {
                    string query = "SELECT InvoiceDate FROM Invoice where InvoiceID = '" + InvoicesID + "'";
                    DataTable data = dataProvider.ExecuteQuery (query);
                    DateTime ngaylapCSDL = Convert.ToDateTime(data.Rows[0][0]);
                    string query1 = "SELECT CustomerID FROM Invoice where InvoiceID = '" + InvoicesID + "'";
                    DataTable data1 = dataProvider.ExecuteQuery(query1);
                    string KH_CSDL = Convert.ToString(data1.Rows[0][0]);
                    if (timeLapHD_update.Value != ngaylapCSDL || cbKHID_Update.Text != KH_CSDL)
                    {
                        //Trường hợp này sửa hóa đơn khi thay đổi thông tin hóa đơn mà không thay đổi thông tin CTPN
                        UpdateHoadon(InvoicesID);
                    }
                    else
                    {
                        int slkho = GetCurrentStock("Product", ProductIDCTHD);
                        int slCTHD = GetCurrentStock("InvoiceDetail", ProductIDCTHD);
                        int slthaydoi = (int)numSL.Value;

                        if (slthaydoi > slCTHD && slkho < (slthaydoi - slCTHD))
                        {
                            MessageBox.Show("Sản phẩm tạm hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            SuaSPKho(ProductIDCTHD, slthaydoi);
                            //Trường hợp này là sửa hóa đơn khi sửa sản phẩm bắt buộc phải cập nhập lại CTHD
                            UpdateCTHD(InvoicesID, ProductIDCTHD, slthaydoi);
                        }

                    }
                }
            }
        }

        private void UpdateHoadon(string InvoiceID)
        {
            decimal Tongtien = CalculateTotal();
            DateTime ngaylap = timeLapHD_update.Value;
            StringBuilder query = new StringBuilder("EXEC PROC_EditInvoice ");
            query.Append("@InvoiceID = '" + InvoiceID + "', ");
            query.Append("@CustomerID = '" + cbKHID_Update.Text + "', ");
            query.Append("@EmployeeID = '" + txtNV_Update.Text + "', ");
            query.Append("@InvoiceDate = '" + ngaylap.ToString("yyyy-MM-dd") + "', ");
            query.Append("@TotalAmount = " + Tongtien); ;
            int result = dataProvider.ExecuteNonQuery(query.ToString());

            if (result > 0)
            {
                LoaddgvInvoices();
                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Cập nhật hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void UpdateCTHD(string InvoiceID, string ProductID, int Quantity)
        {
            StringBuilder query = new StringBuilder("EXEC PROC_EditInvoiceDetail ");
            query.Append("@InvoiceID = '" + InvoiceID + "'");
            query.Append("@ProductID = '" + ProductID + "', ");
            query.Append("@Quantity = '" + Quantity + "'");

            int result = dataProvider.ExecuteNonQuery(query.ToString());

            if (result > 0)
            {
                DgvInvoicesDetail(InvoiceID);
                UpdateHoadon(InvoiceID);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin chi tiết hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvInvoicesDetail.SelectedCells.Count > 0)
            {
                // Lấy chỉ số hàng của ô được chọn
                int rowIndex = dgvInvoicesDetail.SelectedCells[0].RowIndex;

                // Lấy mã sản phẩm của dòng được chọn
                string ProductID = dgvInvoicesDetail.Rows[rowIndex].Cells["Mã sản phẩm"].Value.ToString();
                int Quantity = Convert.ToInt32(dgvInvoicesDetail.Rows[rowIndex].Cells["Số lượng"].Value);
                ThemSPKho(ProductID, Quantity);

                // Xóa dòng được chọn trong DataGridView
                dgvInvoicesDetail.Rows.RemoveAt(rowIndex);

                // Thực hiện xóa sản phẩm khỏi CTHD trong cơ sở dữ liệu
                string query = "DELETE FROM InvoiceDetail WHERE InvoiceID = '" + InvoicesID + "' AND ProductID = '" + ProductID + "'";

                int result = dataProvider.ExecuteNonQuery(query.ToString());

                if (result > 0)
                {
                    MessageBox.Show("Xóa sản phẩm khỏi chi tiết hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cập nhật tổng tiền của hóa đơn
                    if (txtHDID_Add == null)
                    {
                        UpdateHoadon(InvoicesID);
                    }
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm khỏi chi tiết hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            string maHoaDonLonNhat = LayMaHoaDonLonNhat();
            string maHoaDonMoi = TaoMaHoaDonMoi(maHoaDonLonNhat);
            txtHDID_Add.Text = maHoaDonMoi;
        }

        private void dgvInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            if (InvoicesID == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ReportHoaDon f = new ReportHoaDon(InvoicesID);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
        }

        //Tìm kiếm sản phẩm ở dgvSanPham
        private void btnSearchSP_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchSP.Text.Trim();
            StringBuilder query = new StringBuilder("SELECT ProductID as [Mã sản phẩm], ProductName as [Tên sản phẩm], " +
                                                     "SalePrice as [Giá bán] FROM Product WHERE 1=1 ");
            if (!string.IsNullOrEmpty(searchValue))
            {
                query.Append(" AND ProductName COLLATE Vietnamese_CI_AI LIKE N'%" + searchValue + "%'");
            }

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            dgvSanPham.DataSource = result;
        }

        public string LayMaHoaDonLonNhat()
        {
            string maHoaDonLonNhat = "";
            string query = "SELECT TOP 1 InvoiceID FROM Invoice ORDER BY CAST(SUBSTRING(InvoiceID, 3, LEN(InvoiceID)-2) AS INT) DESC";  // Truy vấn mã hóa đơn lớn nhất
            
            maHoaDonLonNhat = (string)dataProvider.ExecuteScalar(query);
            return maHoaDonLonNhat;
        }
        public string TaoMaHoaDonMoi(string maHoaDonLonNhat)
        {
            // Giả sử mã hóa đơn có dạng HD001, HD002, ...
            int soThuTu = int.Parse(maHoaDonLonNhat.Substring(2)); // Lấy phần số từ mã hóa đơn (bỏ 2 ký tự đầu "HD")
            soThuTu++; // Tăng số thứ tự lên 1
            return "HD" + soThuTu.ToString("D3"); // Tạo mã hóa đơn mới dạng HD###, ví dụ: HD004
        }


        private void InvoicesForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvInvoices.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvInvoices.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvInvoices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Định dạng cột Tổng tiền theo kiểu Việt Nam bảng Hóa đơn
            dgvInvoices.Columns["Tổng tiền"].DefaultCellStyle.Format = "N0";  // Hiển thị với phân cách hàng nghìn
            dgvInvoices.Columns["Tổng tiền"].DefaultCellStyle.FormatProvider = new CultureInfo("vi-VN");

            // Định dạng cột Tổng tiền theo kiểu Việt Nam bảng CTHD
            foreach (DataGridViewColumn column in dgvInvoicesDetail.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvInvoicesDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvInvoicesDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvInvoicesDetail.Columns["Tổng tiền"].DefaultCellStyle.Format = "N0";  // Hiển thị với phân cách hàng nghìn
            dgvInvoicesDetail.Columns["Tổng tiền"].DefaultCellStyle.FormatProvider = new CultureInfo("vi-VN");


            //định dạng bảng sản phẩm
            foreach (DataGridViewColumn column in dgvSanPham.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvSanPham.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSanPham.Columns["Giá bán"].DefaultCellStyle.Format = "N0";  // Hiển thị với phân cách hàng nghìn
            dgvSanPham.Columns["Giá bán"].DefaultCellStyle.FormatProvider = new CultureInfo("vi-VN");

        }

    }

}
