using QLBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class OrderForm : Form
    {
        DataProvider dataProvider = new DataProvider();
        List<Product> listProcduct = new List<Product>();
        List<string> productsID = new List<string>();
        public OrderForm()
        {
            InitializeComponent();

        }

        public OrderForm(string username)
        {
            InitializeComponent();

            
        }

        private void Init()
        {
            //kho();
            LoaddgvOrder();
            LoaddgvOrderDetail();
            LoaddgvProduct();
            LoadcbCTHD();

            AddCheckBoxColumn(dgvProduct);
            UpdateCheckBoxes(dgvProduct);
        }

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

        private void LoaddgvOrderDetail()
        {
            dgvOrderDetail.Columns.Add("Mã sản phẩm", "Mã sản phẩm");
            dgvOrderDetail.Columns.Add("Tên sản phẩm", "Tên sản phẩm");
            dgvOrderDetail.Columns.Add("Số lượng", "Số lượng");
            dgvOrderDetail.Columns.Add("Tổng tiền", "Tổng tiền");
        }
        private void DgvOrderDetail(string Idphieunhap)
        {
            dgvOrderDetail.Rows.Clear();
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("Select A.ProductID as [Mã sản phẩm], ProductName as [Tên sản phẩm], A.Quantity as [Số lượng], A.Quantity * B.GiaNhap as [Tổng tiền]" +
            " from PurchaseOrderDetail A join Product B on A.ProductID = B.ProductID " +
            "where OrderID = '" + Idphieunhap + "'");
            dt = dataProvider.ExecuteQuery(query.ToString());
            foreach (DataRow row in dt.Rows)
            {
                string maSP = row["Mã sản phẩm"].ToString();
                string tenSP = row["Tên sản phẩm"].ToString();
                string soLuong = row["Số lượng"].ToString();
                string tongTien = row["Tổng tiền"].ToString();

                dgvOrderDetail.Rows.Add(maSP, tenSP, soLuong, tongTien);
            }
        }



        private void LoadcbCTHD()
        {
            //DataTable dt = new DataTable();
            //if (maNV_codinh.Contains("Admin"))
            //{
            //    dt = dataProvider.ExecuteQuery("select * from PurchaseOrder");
            //    cbMaPN.DisplayMember = "OrderID";
            //    cbMaPN.ValueMember = "OrderID";
            //    cbMaPN.DataSource = dt;
            //}
            //else
            //{
            //    dt = dataProvider.ExecuteQuery("select * from PurchaseOrder where EmployeeID = '" + maNV_codinh + "'");
            //    cbMaPN.DisplayMember = "OrderID";
            //    cbMaPN.ValueMember = "OrderID";
            //    cbMaPN.DataSource = dt;
            //}
        }

        private void LoaddgvOrder()
        {
            //DataTable dt = new DataTable();
            //if (maNV_codinh.Contains("Admin"))
            //{
            //    StringBuilder query = new StringBuilder("Select OrderID as [Mã PN], EmployeeID as [Mã NV], " +
            //    "OrderDate as [Ngày lập], TotalAmount as [Tổng tiền] from PurchaseOrder");
            //    dt = dataProvider.ExecuteQuery(query.ToString());
            //    dgvOrder.DataSource = dt;
            //}
            //else
            //{
            //    StringBuilder query = new StringBuilder("Select OrderID as [Mã PN], EmployeeID as [Mã NV], " +
            //    "Ngaylap as [Ngày lập], Tongtien as [Tổng tiền] from PurchaseOrder where EmployeeID = '" + maNV_codinh + "'");
            //    dt = dataProvider.ExecuteQuery(query.ToString());
            //    dgvOrder.DataSource = dt;
            //}

        }

        private void LoaddgvProduct()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("Select ProductID as [Mã sản phẩm], ProductName as [Tên sản phẩm],  PurchasePrice as [Giá nhập] from Product;");
            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvProduct.DataSource = dt;
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int rowID = e.RowIndex;
            //if (rowID < 0) rowID = 0;
            //if (rowID == dgvOrder.RowCount - 1) rowID = rowID - 1;
            //DataGridViewRow row = dgvOrder.Rows[rowID];
            //cbNVID_update.Text = row.Cells[1].Value.ToString();
            //timeLapPN_update.Value = Convert.ToDateTime(row.Cells[2].Value);
            //OrderID = row.Cells[0].Value.ToString();
            //DgvOrderDetail(OrderID);
            //cbMaPN.Text = OrderID;
            //rowCTPN = dgvOrderDetail.RowCount;

        }

        private void btnCTPN_Click(object sender, EventArgs e)
        {
            DgvOrderDetail(cbMaPN.Text);
        }

        private void ResetCheckBoxes(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell;
                checkBoxCell.Value = false;
            }
            numSL.Value = 50;
        }

        //Cập nhập kho
        private void LaySanPhamKho(string ProductID, int Quantity)
        {
            int slKho = GetCurrentStock("Product", ProductID);
            int slmoi = slKho - Quantity;
            UpdateStock(ProductID, slmoi);
        }
        private void ThemSanPhamKho(string ProductID, int Quantity)
        {
            int slKho = GetCurrentStock("Product", ProductID);
            int slmoi = slKho + Quantity;
            UpdateStock(ProductID, slmoi);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SuaSachKho(string ProductID, int Quantity)
        {

            //StringBuilder query = new StringBuilder("select Quantity from PurchaseOrderDetail where ProductID = '" + ProductID + "' and OrderID = '" + OrderID + "'");
            //DataTable dt = dataProvider.ExecuteQuery(query.ToString());
            //int slCTPN = (int)dt.Rows[0][0];
            //int slKho = GetCurrentStock("Product", ProductID);
            //if (slCTPN > Quantity)
            //{
            //    UpdateStock(ProductID, slKho - (slCTPN - Quantity));
            //}
            //else if (slCTPN < Quantity)
            //{
            //    UpdateStock(ProductID, slKho + (Quantity - slCTPN));
            //}
        }
        private int GetCurrentStock(string tableName, string ProductID)
        {
            StringBuilder query = new StringBuilder($"select Quantity from {tableName} where ProductID = '{ProductID}'");
            DataTable dt = dataProvider.ExecuteQuery(query.ToString());
            return (int)dt.Rows[0][0];
        }
        private void UpdateStock(string ProductID, int slMoi)
        {
            StringBuilder query = new StringBuilder("EXEC PROC_EditDepot");
            query.Append(" @ProductID = '" + ProductID + "'");
            query.Append(", @Quantity = '" + Convert.ToString(slMoi) + "'");
            int result = dataProvider.ExecuteNonQuery(query.ToString());
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'qLBanHangDataSet1.getListEmployeeID' table. You can move, or remove it, as needed.
            //this.getListEmployeeIDTableAdapter.Fill(this.qLBanHangDataSet1.getListEmployeeID);
            //// TODO: This line of code loads data into the 'qLBanHangDataSet.Employee' table. You can move, or remove it, as needed.
            //this.employeeTableAdapter.Fill(this.qLBanHangDataSet.Employee);
            //// TODO: This line of code loads data into the 'qLBanHangDataSet.PurchaseOrder' table. You can move, or remove it, as needed.
            //this.purchaseOrderTableAdapter.Fill(this.qLBanHangDataSet.PurchaseOrder);
            //loadDataProduct();
            //loadDataOrder();
            //loadKho();
        }

        private void btnChonProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
