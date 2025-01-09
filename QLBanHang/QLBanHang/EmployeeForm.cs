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
    public partial class EmployeeForm : Form
    {
        private DataProvider dataProvider = new DataProvider();
        int NoNotificationID = 0;
        public EmployeeForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoaddgvEmployee();
        }

        private void LoaddgvEmployee()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("Select EmployeeID as [Mã nhân viên], EmployeeFamily as [Họ nhân viên],EmployeeName as [Tên nhân viên], " +
                "BirthDate as [Ngày sinh],Gender as [Giới tính], Phone as [Số điện thoại], " +
                "Emp_Address as [Địa chỉ] from Employee ");
            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvEmployee.DataSource = dt;
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;
            if (rowID < 0) rowID = 0;
            if (rowID == dgvEmployee.RowCount - 1) rowID = rowID - 1;
            DataGridViewRow row = dgvEmployee.Rows[rowID];
            NoNotificationID = 1;
            txtStaffId.Text = row.Cells[0].Value.ToString();
            NoNotificationID = 0;
            txtFamilyName.Text = row.Cells[1].Value.ToString();
            txtStaffName.Text = row.Cells[2].Value.ToString();
            dateEmpl.Value = Convert.ToDateTime(row.Cells[3].Value);
            cbGtinh.Text = row.Cells[4].Value.ToString();
            txtStaffAddress.Text = row.Cells[5].Value.ToString();
            txtPhone.Text = row.Cells[6].Value.ToString();
            
        }

        private void btAddEmpl_Click(object sender, EventArgs e)
        {
            string newEmployeeID = GenerateNewEmployeeID();
            txtStaffId.Text = newEmployeeID;
            if (!IsEmployeeIDExists(txtStaffId.Text))
            {
                if (txtStaffId.Text == "" || txtFamilyName.Text == "" || txtStaffName.Text == "" || dateEmpl.Text == "" || cbGtinh.Text == "" || txtPhone.Text == "" || txtStaffAddress.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                }
                else
                {
                    DateTime BirthDate = dateEmpl.Value;
                    StringBuilder query = new StringBuilder("EXEC PROC_AddEmployee ");
                    query.Append("@EmployeeID = '" + txtStaffId.Text + "', ");
                    query.Append("@EmployeeFamily = N'" + txtFamilyName.Text + "', ");
                    query.Append("@EmployeeName = N'" + txtStaffName.Text + "', ");
                    query.Append("@BirthDate = '" + BirthDate.ToString("yyyy-MM-dd") + "', ");
                    query.Append("@Gender = N'" + cbGtinh.Text + "', ");
                    query.Append("@Phone = N'" + txtPhone.Text + "', ");
                    query.Append("@Emp_Address = N'" + txtStaffAddress.Text + "'");
                    //query.Append("@Acc_Role = N'" + cbbRoleEmp.Text + "', ");

                    int result = dataProvider.ExecuteNonQuery(query.ToString());
                    if (result > 0)
                    {
                        LoaddgvEmployee();
                        MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtStaffId.Text = "";
                txtStaffName.Text = "";
                MessageBox.Show("Mã nhân viên này đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }

        }
        private string GenerateNewEmployeeID()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(EmployeeID, 2, LEN(EmployeeID) - 1) AS INT)) FROM Employee ";
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

            return "E" + newID.ToString("D3");
        }

        private void btEditEmpl_Click(object sender, EventArgs e)
        {
            string EmployeeID = txtStaffId.Text.Trim();

            if (txtStaffId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật!", "Thông báo");
            }
            else
            {
                if (txtStaffId.Text == "" || txtFamilyName.Text == "" || txtStaffName.Text == "" || dateEmpl.Text == "" || cbGtinh.Text == "" || txtPhone.Text == "" || txtStaffAddress.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                }
                else
                {
                    DateTime BirthDate = dateEmpl.Value;
                    StringBuilder query = new StringBuilder("EXEC PROC_EditEmployee ");
                    query.Append("@EmployeeID = '" + txtStaffId.Text + "', ");
                    query.Append("@EmployeeFamily = N'" + txtFamilyName.Text + "', ");
                    query.Append("@EmployeeName = N'" + txtStaffName.Text + "', ");
                    query.Append("@BirthDate = '" + BirthDate.ToString("yyyy-MM-dd") + "', ");
                    query.Append("@Gender = N'" + cbGtinh.Text + "', ");
                    query.Append("@Phone = N'" + txtPhone.Text + "', ");
                    query.Append("@Emp_Address = N'" + txtStaffAddress.Text + "'");
                    //query.Append("@Acc_Role = N'" + cbbRoleEmp.Text + "', ");

                    int result = dataProvider.ExecuteNonQuery(query.ToString());
                    if (result > 0)
                    {
                        LoaddgvEmployee();
                        MessageBox.Show("Cập nhật nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật nhân viên không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btRemoveEmpl_Click(object sender, EventArgs e)
        {
            string EmployeeID = txtStaffId.Text.Trim();
            if (txtStaffId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM EMployee WHERE EmployeeID  = '" + txtStaffId.Text + "'";
                    int rowsAffected = dataProvider.ExecuteNonQuery(query);
                    if (rowsAffected > 0)
                    {
                        LoaddgvEmployee();
                        MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btSearchEmpl_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("SELECT EmployeeID AS [Mã nhân viên], EmployeeFamily AS [Họ nhân viên], EmployeeName AS [Tên nhân viên], BirthDate AS [Ngày sinh], Gender AS [Giới tính], Phone AS [Số điện thoại], Emp_Address AS [Địa chỉ] FROM Employee WHERE 1=1");

            if (!string.IsNullOrEmpty(txtStaffId.Text))
            {
                query.Append(" AND EmployeeID LIKE N'%" + txtStaffId.Text + "%'");
            }

            if (!string.IsNullOrEmpty(txtStaffName.Text))
            {
                query.Append(" AND EmployeeName LIKE N'%" + txtStaffName.Text + "%'");
            }

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            dgvEmployee.DataSource = result;
        }

        private bool IsEmployeeIDExists(string EmployeeID)
        {
            string query = "Select count(*) from Employee where EmployeeID = '" + EmployeeID + "'";

            int count = Convert.ToInt32(dataProvider.ExecuteScalar(query));
            return count > 0;
        }
        

        private void txtStaffId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStaffId.Text) && NoNotificationID == 0)
            {
                if (IsEmployeeIDExists(txtStaffId.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
