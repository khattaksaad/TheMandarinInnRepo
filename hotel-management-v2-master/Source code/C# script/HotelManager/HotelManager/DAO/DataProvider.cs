using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Application\Database\HotelManagement.mdf"";Integrated Security=True;"
        private static string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;initial catalog=""C:\Users\skhan\Downloads\New folder\New folder\HotelManagement.mdf"";Integrated Security=True;";
        //private static string connectionStr = "";
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameter(query, parameter, command);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public int ExecuteNoneQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameter(query, parameter, command);
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = new object();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameter(query, parameter, command);
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
        private void AddParameter(string query, object[] parameter, SqlCommand command)
        {
            if (parameter != null)
            {
                string[] listParameter = query.Split(' ');
                int i = 0;
                foreach (string item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        ++i;
                    }
                }
            }
        }
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                    //init connection string 

                    // Path to the file containing the connection string
                    string fileName = "connectionString.txt";
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                    try
                    {
                        // Read the connection string from the file
                        string connectionStringFromFile = File.ReadAllText(filePath);
                        //connectionStr = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

                        // Remove any leading or trailing white spaces
                        //connectionStr = connectionStringFromFile.Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return instance;
            }
            private set => instance = value;
        }
        private DataProvider() { }
    }
}