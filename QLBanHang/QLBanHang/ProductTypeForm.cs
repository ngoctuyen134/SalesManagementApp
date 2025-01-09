using QLBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class ProductTypeForm : Form
    {
        private DataProvider dataProvider = new DataProvider();
        
        public ProductTypeForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoaddgvProductType();
        }

        private void LoaddgvProductType()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("Select ProductTypeID as [Mã loại sản phẩm], ProductTypeName as [Tên loại sản phẩm] From ProductType ");
            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvProductType.DataSource = dt;
        }


        private void btCloseType_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProductType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;
            if (rowID < 0) rowID = 0;
            if (rowID == dgvProductType.RowCount - 1) rowID = rowID - 1;
            DataGridViewRow row = dgvProductType.Rows[rowID];
            txtIdType.Text = row.Cells[0].Value.ToString();
            txtTypeName.Text = row.Cells[1].Value.ToString();
        }

        private bool IsProductTypeIDExists(string ProductTypeID)
        {
            bool isExists = false;
            StringBuilder query = new StringBuilder("SELECT ProductTypeID FROM ProductType WHERE ProductTypeID = '" + txtIdType.Text + "'");

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            if (result.Rows.Count > 0)
            {
                isExists = true;
            }

            return isExists;
        }

        private void btAddType_Click(object sender, EventArgs e)
        {
            if (!IsProductTypeIDExists(txtIdType.Text))
            {
                if (txtIdType.Text == "" || txtTypeName.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                }
                else
                {
                    StringBuilder query = new StringBuilder("EXEC PROC_AddProductType ");
                    query.Append("@ProductTypeID = '" + txtIdType.Text + "' , ");
                    query.Append("@ProductTypeName = N'" + txtTypeName.Text + "'");

                    int result = dataProvider.ExecuteNonQuery(query.ToString());
                    if (result > 0)
                    {
                        LoaddgvProductType();
                        MessageBox.Show("Thêm loại sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Thêm loại sản phẩm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtIdType.Text = "";
                txtTypeName.Text = "";
                MessageBox.Show("Mã loại sản phẩm này đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btRemoveType_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sản phẩm " + txtTypeName.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "DELETE FROM ProductType WHERE ProductTypeID = '" + txtIdType.Text + "'";
                int result = dataProvider.ExecuteNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgvProductType();
                    MessageBox.Show("Xóa loại sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa loại sản phẩm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btEditType_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdType.Text) || string.IsNullOrWhiteSpace(txtTypeName.Text))
            {
                MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                return; // Thoát hàm nếu thông tin không hợp lệ
            }

            StringBuilder query = new StringBuilder("EXEC PROC_EditProductType ");
            query.Append("@ProductTypeID = '" + txtIdType.Text + "' , ");
            query.Append("@ProductTypeName = N'" + txtTypeName.Text + "'");

           
           
                int result = dataProvider.ExecuteNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgvProductType(); // Tải lại danh sách loại sản phẩm
                    MessageBox.Show("Sửa loại sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Không có bản ghi nào được cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("SELECT ProductTypeID AS [Mã loại sản phẩm], ProductTypeName AS [Tên loại sản phẩm] FROM ProductType WHERE 1=1");

            if (!string.IsNullOrEmpty(txtIdType.Text))
            {
                query.Append(" AND ProductTypeID LIKE N'%" + txtIdType.Text + "%'");
            }

            if (!string.IsNullOrEmpty(txtTypeName.Text))
            {
                query.Append(" AND ProductTypeName LIKE N'%" + txtTypeName.Text + "%'");
            }

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            dgvProductType.DataSource = result;
        }

        private void ProductTypeForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvProductType.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvProductType.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvProductType.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
