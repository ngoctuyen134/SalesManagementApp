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
    public partial class MainForm : Form
    {
        string manv;
        public MainForm(string Username)
        {
            InitializeComponent();
            txtNVID.Text = Username;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuProductType_Click(object sender, EventArgs e)
        {
            ProductTypeForm f  = new ProductTypeForm();
            f.ShowDialog();
        }

        private void mnuOrigin_Click(object sender, EventArgs e)
        {
            OriginForm f = new OriginForm();
            f.ShowDialog();
        }

        private void mnuStaff_Click(object sender, EventArgs e)
        {
            EmployeeForm f = new EmployeeForm();
            f.ShowDialog();
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm f = new CustomerForm();
            f.ShowDialog();
        }

        private void mnuSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm f = new SupplierForm();
            f.ShowDialog();
        }

        private void mnuAccount_Click(object sender, EventArgs e)
        {
            AccountForm f = new AccountForm();
            f.ShowDialog();
        }

        private void mnuCreateBill_Click(object sender, EventArgs e)
        {
            InvoicesForm f = new InvoicesForm();
            f.ShowDialog();

        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            ProductForm f = new ProductForm();
            f.ShowDialog();
        }

        private void mnuCreateOrder_Click(object sender, EventArgs e)
        {
            ProductForm f = new ProductForm();
            f.ShowDialog();
        }

        private void mnuReport_Click(object sender, EventArgs e)
        {

            manv = txtNVID.Text;
            if (!string.IsNullOrEmpty(manv) && manv.Contains("Admin") || !string.IsNullOrEmpty(manv) && manv.Contains("admin"))
            {
                ReportForm f = new ReportForm(txtNVID.Text);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
