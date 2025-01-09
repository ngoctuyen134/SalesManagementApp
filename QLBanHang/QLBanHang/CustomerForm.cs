using QLBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class CustomerForm : Form
    {
        public DataProvider dataProvider = new DataProvider();
        int NoNotificationID = 0;
        public CustomerForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoaddgvCustomer();
        }

        private void LoaddgvCustomer()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT CustomerID AS [Mã khách hàng], CustomerFamily AS [Họ khách hàng], CustomerName AS [Tên khách hàng], BirthDate AS [Ngày sinh], Gender AS [Giới tính], Email AS [Email], Phone AS [Số điện thoại], Cus_Address AS [Địa chỉ] FROM Customer; ");
            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvCustomer.DataSource = dt;
        }

        private void btCloseCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;
            if (rowID < 0) rowID = 0;
            if (rowID == dgvCustomer.RowCount - 1) rowID = rowID - 1;
            DataGridViewRow row = dgvCustomer.Rows[rowID];
            NoNotificationID = 1;
            txtCustomerID.Text = row.Cells[0].Value.ToString();
            NoNotificationID = 0;
            txtHoCus.Text = row.Cells[1].Value.ToString();
            txtCustomerName.Text = row.Cells[2].Value.ToString();
            dateBirth.Value = Convert.ToDateTime(row.Cells[3].Value);
            cbGtinh.Text = row.Cells[4].Value.ToString();
            txtEMail.Text = row.Cells[5].Value.ToString();
            txtSdt.Text = row.Cells[6].Value.ToString();
            txtCustomerAddr.Text = row.Cells[7].Value.ToString();
        }



        //Kiểm tra sản phẩm có tồn tại chưa
        private bool IsCustomerIDExists(string CustomerID)
        {
            //bool isExists = false;
            //StringBuilder query = new StringBuilder("SELECT CustomerID FROM Customer WHERE CustomerID = '" + txtCustomerID.Text + "'");

            //DataTable result = dataProvider.ExecuteQuery(query.ToString());
            //if (result.Rows.Count > 0)
            //{
            //    isExists = true;
            //}

            //return isExists;

            // Câu truy vấn kiểm tra xem CustomerID đã tồn tại hay chưa
            string query = "SELECT COUNT(*) FROM Customer WHERE CustomerID = '" + CustomerID + "'";

            // Thực hiện truy vấn và trả về kết quả
            int count = Convert.ToInt32(dataProvider.ExecuteScalar(query));

            // Nếu số lượng trả về lớn hơn 0, nghĩa là CustomerID đã tồn tại
            return count > 0;
        }

        private void btAddCustomer_Click(object sender, EventArgs e)
        {
            string newCustomerID = GenerateNewCustomerID();
            txtCustomerID.Text = newCustomerID;
            if (!IsCustomerIDExists(txtCustomerID.Text))
            {
                if (txtCustomerID.Text == "" || txtHoCus.Text == "" || txtCustomerName.Text == "" || dateBirth.Text == "" || cbGtinh.Text == "" || txtEMail.Text == "" || txtSdt.Text == "" || txtCustomerAddr.Text == ""  )
                {
                    MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                }
                else if (cbGtinh.Text != "Male" && cbGtinh.Text != "Female" && cbGtinh.Text != "Other")
                {
                    MessageBox.Show("Giới tính không hợp lệ! Vui lòng chọn Male, Female hoặc Other.", "THÔNG BÁO");
                }
                else
                {
                    DateTime ngaysinh = dateBirth.Value;
                    StringBuilder query = new StringBuilder("EXEC PROC_AddCustomer ");
                    query.Append("@CustomerID = '" + txtCustomerID.Text + "', ");
                    query.Append("@CustomerFamily = N'" + txtHoCus.Text + "', ");
                    query.Append("@CustomerName = N'" + txtCustomerName.Text + "', ");
                    query.Append("@Gender = '" + cbGtinh.Text + "', ");  
                    query.Append("@BirthDate = '" + ngaysinh.ToString("yyyy-MM-dd") + "', "); 
                    query.Append("@Email = N'" + txtEMail.Text + "', ");
                    query.Append("@Phone = N'" + txtSdt.Text + "', ");
                    query.Append("@Cus_Address = N'" + txtCustomerAddr.Text + "'");
                    int result = dataProvider.ExecuteNonQuery(query.ToString());
                    if (result > 0)
                    {
                        LoaddgvCustomer();
                        MessageBox.Show("Thêm khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtCustomerID.Text = "";
                txtCustomerName.Text = "";
                MessageBox.Show("Mã khách hàng này đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        // hàm tự sinh mã khách hàng 
        private string GenerateNewCustomerID()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(CustomerID, 3, LEN(CustomerID) - 2) AS INT)) FROM Customer ";
            object result = dataProvider.ExecuteScalar(query);
            int newID;

            if (result != DBNull.Value)
            {
                newID = Convert.ToInt32(result) + 1;
            }
            else
            {
                newID = 1;
            }

            return "KH" + newID.ToString("D3"); 
        }

        private void btEditCustomer_Click(object sender, EventArgs e)
        {
            string CustomerID = txtCustomerID.Text.Trim();

            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật!", "Thông báo");
            }
            else
            {
                if (txtCustomerID.Text == "" || txtCustomerName.Text == "" || cbGtinh.Text == "" || txtCustomerAddr.Text == "" || txtSdt.Text == "" || dateBirth.Text == "" || txtEMail.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                }
                else if (cbGtinh.Text != "Male" && cbGtinh.Text != "Female" && cbGtinh.Text != "Other")
                {
                    MessageBox.Show("Giới tính không hợp lệ! Vui lòng chọn Male, Female hoặc Other.", "THÔNG BÁO");
                }
                else
                {
                    DateTime ngaysinh = dateBirth.Value;
                    StringBuilder query = new StringBuilder("EXEC PROC_EditCustomer ");
                    query.Append("@CustomerID = '" + txtCustomerID.Text + "', ");
                    query.Append("@CustomerFamily = N'" + txtHoCus.Text + "', ");
                    query.Append("@CustomerName = N'" + txtCustomerName.Text + "', ");
                    query.Append("@Gender = '" + cbGtinh.Text + "', ");  
                    query.Append("@BirthDate = '" + ngaysinh.ToString("yyyy-MM-dd") + "', ");  
                    query.Append("@Email = N'" + txtEMail.Text + "', ");
                    query.Append("@Phone = N'" + txtSdt.Text + "', ");
                    query.Append("@Cus_Address = N'" + txtCustomerAddr.Text + "'");
                    int result = dataProvider.ExecuteNonQuery(query.ToString());
                    if (result > 0)
                    {
                        LoaddgvCustomer();
                        MessageBox.Show("Update khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Update khách hàng không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btRemoveCustomer_Click(object sender, EventArgs e)
        {
            string CustomerID = txtCustomerID.Text.Trim();
            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM Customer WHERE CustomerID = '" + txtCustomerID.Text + "'";
                    int rowsAffected = dataProvider.ExecuteNonQuery(query);
                    if (rowsAffected > 0)
                    {
                        LoaddgvCustomer();
                        MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btSearchCustomer_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("SELECT CustomerID AS [Mã khách hàng], CustomerFamily AS [Họ khách hàng], CustomerName AS [Tên khách hàng], BirthDate AS [Ngày sinh], Gender AS [Giới tính], Email AS [Email], Phone AS [Số điện thoại], Cus_Address AS [Địa chỉ] FROM Customer WHERE 1=1");

            if (!string.IsNullOrEmpty(txtCustomerID.Text))
            {
                query.Append(" AND CustomerID LIKE N'%" + txtCustomerID.Text + "%'");
            }

            if (!string.IsNullOrEmpty(txtCustomerName.Text))
            {
                query.Append(" AND CustomerName LIKE N'%" + txtCustomerName.Text + "%'");
            }

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            dgvCustomer.DataSource = result;
        }

        

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có thay đổi trong trường CustomerID và nếu biến kiểm tra NoNotificationID là 0
            if (!string.IsNullOrEmpty(txtCustomerID.Text) && NoNotificationID == 0)
            {
                // Gọi hàm kiểm tra sự tồn tại của CustomerID
                if (IsCustomerIDExists(txtCustomerID.Text))
                {
                    // Nếu tồn tại thì thông báo cho người dùng
                    MessageBox.Show("Mã khách hàng đã tồn tại trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
