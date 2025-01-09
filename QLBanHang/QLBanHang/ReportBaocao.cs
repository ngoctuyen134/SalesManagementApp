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
    public partial class ReportBaocao : Form
    {
        private DataProvider dataProvider = new DataProvider();
        private DateTime start;
        private DateTime end;

        public ReportBaocao(DateTime start, DateTime end)
        {
            InitializeComponent();
            this.start = start;
            this.end = end;
        }

        private void ReportBaocao_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("EXEC PROC_PrintReport @start = '" + start + "', @end = '" + end + "'");

            dt = dataProvider.ExecuteQuery(query.ToString());

            reportViewer1.LocalReport.ReportPath = @"D:\Đồ Án Ngành\QLBanHang\QLBanHang\Report1.rdlc";

            ReportDataSource rds = new ReportDataSource("DataSetDoanhThu", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Thiết lập tham số thời gian 
            DateTime currentTime = DateTime.Now;
            reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportTimeBC", currentTime.ToString()));

            reportViewer1.RefreshReport();
        }
    }
}
