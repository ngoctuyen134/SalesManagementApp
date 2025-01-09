using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLBanHang.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLBanHang
{
    
    public partial class LoginForm : Form
    {
        private DataProvider dataProvider = new DataProvider();
        public LoginForm()
        {
            InitializeComponent();
            
            txtUsername.Focus();
        }
        int count = 0;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (CheckLogin(username, password))
            { 
                MainForm f = new MainForm(txtUsername.Text);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                count++;
                if (count <= 3)
                    MessageBox.Show("SAI TÊN ĐĂNG NHẬP HOẶC MẬT KHẨU!", "THÔNG BÁO");
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("BẠN ĐÃ NHẬP SAI 3 LẦN LIÊN TIẾP. THOÁT CHƯƠNG TRÌNH ?", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (d == DialogResult.OK)
                    {
                        Application.ExitThread();
                    }
                    count = 0;
                }
            }
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
       
        bool CheckLogin(string username, string password) 
        {
            DataTable dt = new DataTable();
            dt = dataProvider.ExecuteQuery("USP_Login @userName = '" + username + "' , @Acc_password = '" + password + "'");
            return dt.Rows.Count > 0;
        }   

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?","Thông báo", MessageBoxButtons.OKCancel) !=System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;

            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
