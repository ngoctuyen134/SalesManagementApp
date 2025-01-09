using QLBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class SupplierForm : Form
    {
        private DataProvider dataProvider = new DataProvider();
        public SupplierForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoaddgvSupplier();
        }

        private void LoaddgvSupplier()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("Select SupplierID as [Mã NCC], SupplierName as [Tên NCC], Supp_Address as [Địa chỉ], Supp_Phone as [Số diện thoại] From Supplier ");
            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvSupplier.DataSource = dt;
        }

        private void btCloseSup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;
            if (rowID < 0) rowID = 0;
            if (rowID == dgvSupplier.RowCount - 1) rowID = rowID - 1;
            DataGridViewRow row = dgvSupplier.Rows[rowID];
            txtSupplierID.Text = row.Cells[0].Value.ToString();
            txtSupplierName.Text = row.Cells[1].Value.ToString();
            txtSupplierAddress.Text = row.Cells[2].Value.ToString();
            txtPhoneSupp.Text = row.Cells[3].Value.ToString();

        }

        private bool IsSupplierIDExists(string SupplierID)
        {
            bool isExists = false;
            StringBuilder query = new StringBuilder("SELECT SupplierID FROM Supplier WHERE SupplierID = '" + txtSupplierID.Text + "'");

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            if (result.Rows.Count > 0)
            {
                isExists = true;
            }

            return isExists;
        }

        private void btAddSup_Click(object sender, EventArgs e)
        {
            string newSupplierID = GenerateNewSupplierID();
            txtSupplierID.Text = newSupplierID;
            if (!IsSupplierIDExists(txtSupplierID.Text))
            {
                if (txtSupplierID.Text == "" || txtSupplierName.Text == "" || txtSupplierAddress.Text == "" || txtPhoneSupp.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                }
                else
                {
                    StringBuilder query = new StringBuilder("EXEC PROC_AddSupplier ");
                    query.Append("@SupplierID = '" + txtSupplierID.Text + "', ");
                    query.Append("@SupplierName = N'" + txtSupplierName.Text + "', ");
                    query.Append("@Supp_Address = N'" + txtSupplierAddress.Text + "', ");
                    query.Append("@Supp_Phone = '" + txtPhoneSupp.Text + "'");

                    int result = dataProvider.ExecuteNonQuery(query.ToString());
                    if (result > 0)
                    {
                        LoaddgvSupplier();
                        MessageBox.Show("Thêm nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhà cung cấp không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtSupplierID.Text = "";
                txtSupplierName.Text = "";
                MessageBox.Show("Mã nhà cung cấp này đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private string GenerateNewSupplierID()
        {
            // Lấy mã NCC lớn nhất từ cơ sở dữ liệu
            string query = "SELECT MAX(CAST(SUBSTRING(SupplierID, 4, LEN(SupplierID) - 3) AS INT)) FROM Supplier "; 
            object result = dataProvider.ExecuteScalar(query);
            int newID;

            if (result != DBNull.Value)
            {
                newID = Convert.ToInt32(result) + 1; // Tăng mã NCC lên 1
            }
            else
            {
                newID = 1; // Nếu chưa có nhà cung cấp nào, bắt đầu từ 1
            }

            return "NCC" + newID.ToString("D3"); // Tạo mã NCC mới với định dạng "NCC001"
        }

        private void btEditSup_Click(object sender, EventArgs e)
        {
            if (txtSupplierID.Text == "" || txtSupplierName.Text == "" || txtSupplierAddress.Text == "" || txtPhoneSupp.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
            }
            else
            {
                StringBuilder query = new StringBuilder("EXEC PROC_EditSupplier ");
                query.Append("@SupplierID = '" + txtSupplierID.Text + "', ");
                query.Append("@SupplierName = N'" + txtSupplierName.Text + "', ");
                query.Append("@Supp_Address = N'" + txtSupplierAddress.Text + "', ");
                query.Append("@Supp_Phone = '" + txtPhoneSupp.Text + "'");

                int result = dataProvider.ExecuteNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgvSupplier();
                    MessageBox.Show("Sửa nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Sửa nhà cung cấp không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btRemoveSup_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sản phẩm " + txtSupplierName.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "DELETE FROM Supplier WHERE SupplierID = '" + txtSupplierID.Text + "'";
                int result = dataProvider.ExecuteNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgvSupplier();
                    MessageBox.Show("Xóa nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa nhà cung cấp không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btTKSup_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("Select SupplierID as [Mã NCC], SupplierName as [Tên NCC], Supp_Address as [Địa chỉ], Supp_Phone as [Số diện thoại] From Supplier WHERE 1=1");

            if (!string.IsNullOrEmpty(txtSupplierID.Text))
            {
                query.Append(" AND SupplierID LIKE N'%" + txtSupplierID.Text + "%'");
            }

            if (!string.IsNullOrEmpty(txtSupplierName.Text))
            {
                query.Append(" AND SupplierName LIKE N'%" + txtSupplierName.Text + "%'");
            }

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            dgvSupplier.DataSource = result;

        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvSupplier.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvSupplier.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvSupplier.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    } 
    
}
