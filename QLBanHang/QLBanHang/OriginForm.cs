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
    public partial class OriginForm : Form
    {
        public DataProvider dataProvider = new DataProvider();
        public OriginForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadDgvNguongoc();
        }
        private void btCloseOri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void LoadDgvNguongoc()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT OriginID AS [Mã nguồn gốc], OriginCountry AS [Xuất xứ] FROM ProductOrigin");
            dt = dataProvider.ExecuteQuery(query.ToString());
            dgvOrigin.DataSource = dt;
        }

        private void dgvOrigin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;
            if (rowID < 0) rowID = 0;
            if (rowID == dgvOrigin.RowCount - 1) rowID = rowID - 1;
            DataGridViewRow row = dgvOrigin.Rows[rowID];
            txtOriginID.Text = row.Cells[0].Value.ToString();
            txtOriginName.Text = row.Cells[1].Value.ToString();
        }

        private bool IsMaNguonGocExists(string OriginID)
        {
            bool isExists = false;
            StringBuilder query = new StringBuilder("SELECT OriginID FROM ProductOrigin WHERE OriginID = '" + txtOriginID.Text + "'");

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            if (result.Rows.Count > 0)
            {
                isExists = true;
            }

            return isExists;
        }

        private void btAddOri_Click(object sender, EventArgs e)
        {
            if (!IsMaNguonGocExists(txtOriginID.Text))
            {
                if (txtOriginID.Text == "" || txtOriginName.Text == "")
                {
                    MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
                }
                else
                {
                    StringBuilder query = new StringBuilder("EXEC PROC_AddOrigin ");
                    query.Append("@OriginID = '" + txtOriginID.Text + "' , ");
                    query.Append("@OriginCountry = N'" + txtOriginName.Text + "'");

                    int result = dataProvider.ExecuteNonQuery(query.ToString());
                    if (result > 0)
                    {
                        LoadDgvNguongoc();
                        MessageBox.Show("Thêm nguồn gốc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nguồn gốc không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtOriginID.Text = "";
                txtOriginName.Text = "";
                MessageBox.Show("Mã nguồn gốc này đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void btEditOri_Click(object sender, EventArgs e)
        {
            if (txtOriginID.Text == "" || txtOriginName.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin!", "THÔNG BÁO");
            }
            else
            {
                StringBuilder query = new StringBuilder("EXEC PROC_EditOrigin ");
                query.Append("@OriginID = '" + txtOriginID.Text + "' , ");
                query.Append("@OriginCountry = N'" + txtOriginName.Text + "'");

                int result = dataProvider.ExecuteNonQuery(query.ToString());
                if (result > 0)
                {
                    LoadDgvNguongoc();
                    MessageBox.Show("Sửa nguồn gốc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Sửa nguồn gốc không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btDeleteOri_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm " + txtOriginName.Text + " ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "DELETE FROM ProductOrigin WHERE OriginID = '" + txtOriginID.Text + "'";
                int result = dataProvider.ExecuteNonQuery(query.ToString());
                if (result > 0)
                {
                    LoadDgvNguongoc();
                    MessageBox.Show("Xóa nguồn gốc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa nguồn gốc không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btSearchOri_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("SELECT OriginID AS [Mã nguồn gốc], OriginCountry AS [Xuất xứ] FROM ProductOrigin WHERE 1=1");

            if (!string.IsNullOrEmpty(txtOriginID.Text))
            {
                query.Append(" AND OriginID LIKE N'%" + txtOriginID.Text + "%'");
            }

            if (!string.IsNullOrEmpty(txtOriginName.Text))
            {
                query.Append(" AND OriginCountry LIKE N'%" + txtOriginName.Text + "%'");
            }

            DataTable result = dataProvider.ExecuteQuery(query.ToString());
            dgvOrigin.DataSource = result;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Chọn file Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string excelPath = openFileDialog.FileName;

                // Mở file Excel
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = excelApp.Workbooks.Open(excelPath);
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;

                // Duyệt qua từng hàng trong file Excel, bắt đầu từ hàng 2 (bỏ qua tiêu đề)
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    string originID = (range.Cells[row, 1] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string originCountry = (range.Cells[row, 2] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();

                    // Kiểm tra xem mã nguồn gốc đã tồn tại chưa
                    if (!IsMaNguonGocExists(originID))
                    {
                        // Thêm dữ liệu nguồn gốc vào hệ thống (SQL Server)
                        StringBuilder query = new StringBuilder("EXEC PROC_AddOrigin ");
                        query.Append("@OriginID = '" + originID + "', ");
                        query.Append("@OriginCountry = N'" + originCountry + "'");

                        // Thực hiện truy vấn
                        dataProvider.ExecuteNonQuery(query.ToString());
                    }
                    else
                    {
                        MessageBox.Show($"Mã nguồn gốc {originID} đã tồn tại, bỏ qua.", "Thông báo", MessageBoxButtons.OK);
                    }
                }

                // Cập nhật lại DataGridView sau khi thêm dữ liệu từ Excel
                LoadDgvNguongoc();

                // Đóng file Excel và giải phóng tài nguyên
                workbook.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                MessageBox.Show("Nhập dữ liệu từ file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OriginForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvOrigin.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvOrigin.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvOrigin.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
