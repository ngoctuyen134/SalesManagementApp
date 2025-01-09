using QLBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLBanHang
{
    public partial class ReportForm : Form
    {
        private DataProvider dataProvider = new DataProvider();
       

        public ReportForm(string username)
        {
            InitializeComponent();
            txtusername.Text = username;
        }

        private void btThongke_Click(object sender, EventArgs e)
        {
            DateTime timeStart = TimeStart.Value;
            DateTime timeEnd = TimeEnd.Value;

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT s.ProductID as [Mã sản phẩm], s.ProductName as [Tên sản phẩm], SUM(cthd.Quantity) as [Số lượng], SUM(cthd.Quantity * s.SalePrice) as [Tổng tiền]");
            query.Append(" FROM Invoice hd JOIN InvoiceDetail cthd ON hd.InvoiceID = cthd.InvoiceID JOIN Product s ON cthd.ProductID = s.ProductID");
            query.Append(" WHERE hd.InvoiceDate BETWEEN '" + timeStart.ToString("yyyy-MM-dd") + "'");
            query.Append(" AND '" + timeEnd.ToString("yyyy-MM-dd") + "'");
            query.Append(" GROUP BY s.ProductID, s.ProductName");

            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvTKBC.DataSource = dt;

            int soluong = 0;
            decimal tongTien = 0;
            foreach (DataGridViewRow dgvrow in dgvTKBC.Rows)
            {
                if (dgvrow.Cells["Số lượng"].Value != null)
                {
                    soluong += Convert.ToInt32(dgvrow.Cells["Số lượng"].Value);
                }

                if (dgvrow.Cells["Tổng tiền"].Value != null)
                {
                    tongTien += Convert.ToDecimal(dgvrow.Cells["Tổng tiền"].Value);
                }
            }

            txtSoluong.Text = soluong.ToString();
            //txtDoanhthu.Text = tongTien.ToString();

            // Định dạng doanh thu theo kiểu tiền Việt Nam
            CultureInfo viVn = new CultureInfo("vi-VN");
            txtDoanhthu.Text = tongTien.ToString("N0", viVn) + " VND";
        }

        private void btXuatBC_Click(object sender, EventArgs e)
        {
            DateTime start = TimeStart.Value;
            DateTime end = TimeEnd.Value;

            ReportBaocao f = new ReportBaocao(start, end);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void ReportForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvTKBC.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvTKBC.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvTKBC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.reportViewer1.RefreshReport();
        }
    }
}
