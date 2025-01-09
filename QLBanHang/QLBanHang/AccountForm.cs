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
    public partial class AccountForm : Form
    {
        private DataProvider dataProvider = new DataProvider();
        //private string stRole;
        public AccountForm()
        {
            InitializeComponent();

            Init();
        }
        private void Init()
        {
            LoaddgvListAccount();

            string query = "SELECT EmployeeID as [Mã Nhân Viên], Username as [Tên đăng nhập], Acc_Password as [Mật khẩu], Acc_Role as [Chức vụ] FROM Account";

            //string query = "EXEC USP_Login @Username , @Acc_Password";



            dgvListAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] {"Admin", "Abc123", "NV001", "Abc456" });


        }

        private void LoaddgvListAccount()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT EmployeeID as [Mã Nhân Viên], Username as [Tên đăng nhập], Acc_Password as [Mật khẩu], Acc_Role as [Chức vụ] FROM Account ");
            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvListAccount.DataSource = dt;
        }

        private void dgvListAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;
            if (rowID < 0) rowID = 0;
            if (rowID == dgvListAccount.RowCount - 1) rowID = rowID - 1;
            DataGridViewRow row = dgvListAccount.Rows[rowID];
            txtAccountID.Text = row.Cells[0].Value.ToString();
            txtAccountName.Text = row.Cells[1].Value.ToString();
            txtAccountPass.Text = row.Cells[2].Value.ToString();
            cmbRole.Text = row.Cells[3].Value.ToString();
        }


        private bool IsUsernameExists(string EmployeeID)
        {
            bool isExists = false;
            StringBuilder query = new StringBuilder("SELECT EmployeeID FROM Account WHERE EmployeeID = '" + txtAccountID.Text + "'");

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            if (result.Rows.Count > 0)
            {
                isExists = true;
            }

            return isExists;
        }

        private void btAddAccount_Click(object sender, EventArgs e)
        {
            if (!IsUsernameExists(txtAccountID.Text))
            {
                if (txtAccountID.Text == "" || txtAccountName.Text == "" || txtAccountPass.Text == "" || cmbRole.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                }
                else
                {
                    StringBuilder query = new StringBuilder("EXEC PROC_AddAccount ");
                    query.Append("@EmployeeID = '" + txtAccountID.Text + "', ");
                    query.Append("@Username = N'" + txtAccountName.Text + "', ");
                    query.Append("@Acc_Password = N'" + txtAccountPass.Text + "', ");
                    query.Append("@Acc_Role = '" + cmbRole.Text + "'");

                    int result = dataProvider.ExecuteNonQuery(query.ToString());
                    if (result > 0)
                    {
                        LoaddgvListAccount();
                        MessageBox.Show("Thêm tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtAccountID.Text = "";
                txtAccountName.Text = "";
                MessageBox.Show("Tài khoản này đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }


        }

        private void btEditAccount_Click(object sender, EventArgs e)
        {
            if (txtAccountID.Text == "" || txtAccountName.Text == "" || txtAccountPass.Text == "" || cmbRole.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
            }
            else
            {
                StringBuilder query = new StringBuilder("EXEC PROC_EditAccount ");
                query.Append("@EmployeeID = '" + txtAccountID.Text + "', ");
                query.Append("@Username = N'" + txtAccountName.Text + "', ");
                query.Append("@Acc_Password = N'" + txtAccountPass.Text + "', ");
                query.Append("@Acc_Role = '" + cmbRole.Text + "'");

                int result = dataProvider.ExecuteNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgvListAccount();
                    MessageBox.Show("Sửa thông tin tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Sửa thông tin tài khoản không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn tài khoản " + txtAccountName.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "DELETE FROM Account WHERE EmployeeID = '" + txtAccountID.Text + "'";
                int result = dataProvider.ExecuteNonQuery(query.ToString());
                if (result > 0)
                {
                    LoaddgvListAccount();
                    MessageBox.Show("Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btSearchAcc_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("SELECT EmployeeID as [Mã Nhân Viên], Username as [Tên đăng nhập], Acc_Password as [Mật khẩu], Acc_Role as [Chức vụ] FROM Account WHERE 1=1");

            if (!string.IsNullOrEmpty(txtAccountID.Text))
            {
                query.Append(" AND EmployeeID LIKE N'%" + txtAccountID.Text + "%'");
            }

            if (!string.IsNullOrEmpty(txtAccountName.Text))
            {
                query.Append(" AND Username LIKE N'%" + txtAccountName.Text + "%'");
            }

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            dgvListAccount.DataSource = result;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
