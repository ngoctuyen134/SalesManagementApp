using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        public DataProvider() { }

        private string connectionSTR = @"Data Source=LAPTOP-8JPIFHUC\MSSQLSERVER01;Initial Catalog=QLBanHangg;Integrated Security=True";

      

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connession = new SqlConnection(connectionSTR))
            {
                connession.Open();

                SqlCommand command = new SqlCommand(query, connession);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connession.Close();
            }
            return data;
            //dgvListAccount.DataSource = data;
        }


        public int ExecuteNonQuery(string query, object[] paramater = null)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (paramater != null)
                {
                    string[] lisrPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisrPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return data;
        }



        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connession = new SqlConnection(connectionSTR))
            {
                connession.Open();

                SqlCommand command = new SqlCommand(query, connession);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connession.Close();
            }
            return data;
        }
    }
}
