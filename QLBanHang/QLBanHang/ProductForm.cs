using QLBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class ProductForm : Form
    {
        private DataProvider dataProvider = new DataProvider();
        private string stNguonGoc;
        private string stLoaiSP;
        private string stNhaCC;
        int NoNotificationID = 0;

        public ProductForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoaddgvProduct();
            LoadcbMaNG_Product();
            LoadcbMaLoaiSP_Product();
            LoadcbMaNCC_Product();
        }

        private void LoaddgvProduct()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT A.ProductID as [Mã sản phẩm], A.ProductName as [Tên sản phẩm], B.OriginID as [Nguồn gốc], A.ProductTypeID as [Loại hàng], A.SupplierID as [Nhà cung cấp], A.Quantity as [Số lượng], A.PurchasePrice as [Giá nhập], A.SalePrice as [Giá bán], A.Pro_Image as [Hình ảnh], A.Notes as [Ghi chú] FROM Product A JOIN ProductOrigin B ON A.OriginID = B.OriginID  ");
            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvProduct.DataSource = dt;

        }

        private void LoadcbMaNG_Product()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.ExecuteQuery("select * from ProductOrigin");
            cbMaNG.DisplayMember= "OriginCountry";
            cbMaNG.ValueMember= "OriginID";
            cbMaNG.DataSource= dt;
        }
       
        private void LoadcbMaLoaiSP_Product()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.ExecuteQuery("select * from ProductType");
            cbMaLoaiSP.DisplayMember = "ProductTypeName";
            cbMaLoaiSP.ValueMember = "ProductTypeID";
            cbMaLoaiSP.DataSource = dt;
        }

        private void LoadcbMaNCC_Product()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.ExecuteQuery("select * from Supplier");
            cbMaNCC.DisplayMember = "SupplierName";
            cbMaNCC.ValueMember = "SupplierID";
            cbMaNCC.DataSource = dt;
        }
        

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;
            if (rowID < 0) rowID = 0;
            if (rowID == dgvProduct.RowCount - 1) rowID = rowID - 1;
            DataGridViewRow row = dgvProduct.Rows[rowID];
            NoNotificationID = 1;
            txtProductID.Text = row.Cells[0].Value.ToString();
            NoNotificationID = 0;
            txtProductName.Text = row.Cells[1].Value.ToString();
            cbMaNG.Text = row.Cells[2].Value.ToString();
            cbMaLoaiSP.Text = row.Cells[3].Value.ToString();
            cbMaNCC.Text = row.Cells[4].Value.ToString();
            txtProductQuatity.Text = row.Cells[5].Value.ToString();
            numGiaNhap.Value = Convert.ToInt32(row.Cells[6].Value);
            numGiaBan.Value = Convert.ToInt32(row.Cells[7].Value);

        }

        //Kiểm tra sản phẩm có tồn tại chưa
        private bool IsProductIDExists(string ProductID)
        {
            bool isExists = false;
            StringBuilder query = new StringBuilder("SELECT ProductID FROM Product WHERE ProductID = '" + txtProductID.Text + "'");

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            if (result.Rows.Count > 0)
            {
                isExists = true;
            }

            return isExists;
        }

        
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!IsProductIDExists(txtProductID.Text))
            {
                // Sinh mã sản phẩm tự động
                string newProductID = GenerateNewProductID();
                txtProductID.Text = newProductID;

                if (txtProductID.Text == "" || txtProductName.Text == "" || cbMaNG.Text == "" || cbMaLoaiSP.Text == "" || cbMaNCC.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                }
                else
                {
                    if (Convert.ToInt32(numGiaBan.Value) > Convert.ToInt32(numGiaNhap.Value))
                    {
                        StringBuilder query = new StringBuilder("EXEC PROC_AddProduct ");
                        query.Append("@ProductID = '" + txtProductID.Text + "', ");
                        query.Append("@ProductName = N'" + txtProductName.Text + "', ");
                        query.Append("@OriginID = '" + stNguonGoc + "', ");
                        query.Append("@ProductTypeID = '" + stLoaiSP + "', ");
                        query.Append("@SupplierID = '" + stNhaCC + "', ");
                        query.Append("@SalePrice = " + numGiaBan.Value + ", ");
                        query.Append("@PurchasePrice = " + numGiaNhap.Value + ", ");
                        query.Append("@Quantity = " + txtProductQuatity.Text + ", ");
                        query.Append("@Pro_Image = " + (string.IsNullOrEmpty(txtImage.Text) ? "NULL" : "N'" + txtImage.Text + "'") + ", ");
                        query.Append("@Notes = " + (string.IsNullOrEmpty(txtNotes.Text) ? "NULL" : "N'" + txtNotes.Text + "'"));

                        int result = dataProvider.ExecuteNonQuery(query.ToString());

                        if (result > 0)
                        {
                            LoaddgvProduct();
                            MessageBox.Show("Thêm sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Thêm sản phẩm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Giá nhập không được lớn hơn giá bán!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                txtProductID.Text = "";
                txtProductName.Text = "";
                MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void cbMaNG_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            stNguonGoc = comboBox.SelectedValue.ToString();
        }

        private void cbMaLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            stLoaiSP = comboBox.SelectedValue.ToString();
        }

        private void cbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            stNhaCC = comboBox.SelectedValue.ToString();
        }
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text == "" || txtProductName.Text == "" || cbMaNG.Text == "" || cbMaLoaiSP.Text == "" || cbMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
            }
            else
            {
                if (Convert.ToInt32(numGiaBan.Value) > Convert.ToInt32(numGiaNhap.Value))
                {
                    StringBuilder query = new StringBuilder("EXEC PROC_EditProduct ");
                    query.Append("@ProductID = '" + txtProductID.Text + "', ");
                    query.Append("@ProductName = N'" + txtProductName.Text + "', ");
                    query.Append("@OriginID = '" + stNguonGoc + "', ");
                    query.Append("@ProductTypeID = '" + stLoaiSP + "', ");
                    query.Append("@SupplierID = '" + stNhaCC + "', ");
                    query.Append("@SalePrice = " + numGiaBan.Value + ", ");
                    query.Append("@PurchasePrice = " + numGiaNhap.Value + ", ");
                    query.Append("@Quantity = " + txtProductQuatity.Text + ", ");
                    query.Append("@Pro_Image = " + (string.IsNullOrEmpty(txtImage.Text) ? "NULL" : "N'" + txtImage.Text + "'") + ", ");
                    query.Append("@Notes = " + (string.IsNullOrEmpty(txtNotes.Text) ? "NULL" : "N'" + txtNotes.Text + "'"));

                    int result = dataProvider.ExecuteNonQuery(query.ToString());
                    if (result > 0)
                    {
                        LoaddgvProduct();
                        MessageBox.Show("Cập nhập sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhập sản phẩm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Giá nhập không được lớn hơn giá bán!", "Thông báo", MessageBoxButtons.OK);
                }

            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm " + txtProductName.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "DELETE FROM Product WHERE ProductID = '" + txtProductID.Text + "'";
                int result = dataProvider.ExecuteNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgvProduct();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("SELECT A.ProductID as [Mã sản phẩm], A.ProductName as [Tên sản phẩm], B.OriginID as [Nguồn gốc], A.ProductTypeID as [Loại hàng], A.SupplierID as [Nhà cung cấp], " +
                "A.Quantity as [Số lượng], A.PurchasePrice as [Giá nhập], A.SalePrice as [Giá bán], A.Pro_Image as [Hình ảnh], A.Notes as [Ghi chú] " +
                "FROM Product A JOIN ProductOrigin B ON A.OriginID = B.OriginID WHERE 1=1 ");

            if (!string.IsNullOrEmpty(txtProductID.Text))
            {
                query.Append(" AND A.ProductID LIKE N'%" + txtProductID.Text + "%'");
            }

            if (!string.IsNullOrEmpty(txtProductName.Text))
            {
                query.Append(" AND A.ProductName COLLATE Vietnamese_CI_AI LIKE N'%" + txtProductName.Text + "%'");
            }

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            dgvProduct.DataSource = result;
        }

        private void btnListProduct_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng Excel
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false; 

            // Tạo một workbook và worksheet
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            // Xuất tiêu đề cột
            for (int i = 0; i < dgvProduct.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dgvProduct.Columns[i].HeaderText;
            }

            // Xuất dữ liệu
            for (int i = 0; i < dgvProduct.Rows.Count; i++)
            {
                for (int j = 0; j < dgvProduct.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgvProduct.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Lưu file Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            saveFileDialog.Title = "Save an Excel File";
            saveFileDialog.FileName = "ProductData.xlsx"; // Tên file mặc định

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Đóng workbook và ứng dụng Excel
            workbook.Close();
            excelApp.Quit();

            // Giải phóng tài nguyên
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Select an Excel File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string excelPath = openFileDialog.FileName;

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = excelApp.Workbooks.Open(excelPath);
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;

                // Duyệt qua từng hàng trong file Excel, bắt đầu từ hàng 2 (bỏ qua tiêu đề)
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    // Tự động sinh mã sản phẩm cho mỗi sản phẩm
                    string productID = GenerateNewProductID();

                    string productName = (range.Cells[row, 2] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    string originID = (range.Cells[row, 3] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    string productTypeID = (range.Cells[row, 4] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    string supplierID = (range.Cells[row, 5] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                    int quantity = Convert.ToInt32((range.Cells[row, 6] as Microsoft.Office.Interop.Excel.Range).Value2);
                    decimal purchasePrice = Convert.ToDecimal((range.Cells[row, 7] as Microsoft.Office.Interop.Excel.Range).Value2);
                    decimal salePrice = Convert.ToDecimal((range.Cells[row, 8] as Microsoft.Office.Interop.Excel.Range).Value2);
                    string image = (range.Cells[row, 9] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string notes = (range.Cells[row, 10] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();

                    // Thêm dữ liệu sản phẩm vào hệ thống (SQL Server)
                    StringBuilder query = new StringBuilder("EXEC PROC_AddProduct ");
                    query.Append("@ProductID = '" + productID + "', ");
                    query.Append("@ProductName = N'" + productName + "', ");
                    query.Append("@OriginID = '" + originID + "', ");
                    query.Append("@ProductTypeID = '" + productTypeID + "', ");
                    query.Append("@SupplierID = '" + supplierID + "', ");
                    query.Append("@SalePrice = " + salePrice + ", ");
                    query.Append("@PurchasePrice = " + purchasePrice + ", ");
                    query.Append("@Quantity = " + quantity + ", ");
                    query.Append("@Pro_Image = " + (string.IsNullOrEmpty(image) ? "NULL" : "N'" + image + "'") + ", ");
                    query.Append("@Notes = " + (string.IsNullOrEmpty(notes) ? "NULL" : "N'" + notes + "'"));

                    // Thực hiện truy vấn
                    dataProvider.ExecuteNonQuery(query.ToString());
                }

                // Cập nhật lại DataGridView sau khi thêm dữ liệu từ Excel
                LoaddgvProduct();

                // Đóng file Excel 
                workbook.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                MessageBox.Show("Nhập dữ liệu từ file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public string GenerateNewProductID()
        {
            // Lấy mã sản phẩm lớn nhất hiện tại trong hệ thống
            string query = "SELECT TOP 1 ProductID FROM Product ORDER BY ProductID DESC";
            DataTable result = dataProvider.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                // Lấy mã sản phẩm cuối cùng và tăng số thứ tự
                string lastProductID = result.Rows[0]["ProductID"].ToString();
                string numberPart = lastProductID.Substring(2); // Lấy phần số của mã (VD: SP001 -> 001)
                int newNumber = int.Parse(numberPart) + 1;

                // Tạo mã mới, đảm bảo có 3 chữ số (VD: SP002, SP010)
                return "SP" + newNumber.ToString("D3");
            }
            else
            {
                // Nếu chưa có sản phẩm nào trong hệ thống, bắt đầu từ SP001
                return "SP001";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvProduct.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                txtImage.Text = imagePath;
                picProduct.Image = Image.FromFile(imagePath);
                if (dgvProduct.CurrentRow != null)
                {
                    dgvProduct.CurrentRow.Cells["Hình ảnh"].Value = imagePath;  
                }
            }
        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow != null)
            {
                string imagePath = dgvProduct.CurrentRow.Cells["Hình ảnh"].Value?.ToString();
                txtImage.Text = imagePath;

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    picProduct.Image = Image.FromFile(imagePath);
                }
                else
                {
                    txtImage.Text = string.Empty;
                    picProduct.Image = null;
                }
            }
        }
    }
}
