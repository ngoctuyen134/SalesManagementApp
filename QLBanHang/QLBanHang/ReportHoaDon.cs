using QLBanHang.DAO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace QLBanHang
{
    public partial class ReportHoaDon : Form
    {
        private DataProvider dataProvider = new DataProvider();
        string InvoicesID;
        public ReportHoaDon(string InvoicesID)
        {
            InitializeComponent();
            this.InvoicesID = InvoicesID;
        }
        
        private void ReportHoaDon_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("EXEC PROC_PrintHD @InvoiceID = '" + InvoicesID + "'");

            dt = dataProvider.ExecuteQuery(query.ToString());
            
            reportViewer1.LocalReport.ReportPath = @"D:\Đồ Án Ngành\QLBanHang\QLBanHang\Report2.rdlc";

            ReportDataSource rds = new ReportDataSource("DataSetCTHD", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Thiết lập tham số thời gian (nếu cần)
            DateTime currentTime = DateTime.Now;
            reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportTime", currentTime.ToString()));

            reportViewer1.RefreshReport();
            reportViewer1.RefreshReport();

        }
    }
}
