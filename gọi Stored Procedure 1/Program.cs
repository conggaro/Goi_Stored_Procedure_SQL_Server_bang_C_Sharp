using System;
using System.Data.SqlClient;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // chuỗi kết nối
            string connectionString = @"
                Server = localhost;
                Database = StudentDB;
                User ID = sa;
                Password = 123456;
                TrustServerCertificate=True";



            // khai báo đối tượng SqlConnection
            using SqlConnection connection = new SqlConnection(connectionString);



            // khai báo đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // thiết lập giá trị cho các thuộc tính
            command.CommandText = "select Id, Name, Email from Student";

            command.Connection = connection;

            command.CommandType = System.Data.CommandType.Text;



            // viết xong command thì mới mở kết nối
            connection.Open();



            // khai báo đối tượng SqlDataReader
            using SqlDataReader reader = command.ExecuteReader();



            // in kết quả đọc được ra màn hình
            while (reader.Read() == true)
            {
                Console.WriteLine($"{reader["Id"], -6} {reader["Name"], -10} {reader["Email"], -35}");
            }



            // giải phóng tài nguyên "SqlDataReader"
            reader.Close();

            // đóng kết nối
            connection.Close();

            // giải phóng tài nguyên "SqlConnection"
            connection.Dispose();
        }
    }
}