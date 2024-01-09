using System;
using System.Data.SqlClient;

// phải cài đặt thư viện "System.Data.SqlClient"

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



            // GetAllStudent là tên "Stored Procedure" trong SQL Server
            command.CommandText = "GetAllStudent";

            command.Connection = connection;

            command.CommandType = System.Data.CommandType.StoredProcedure;



            // viết xong command thì mới mở kết nối
            connection.Open();



            // khai báo đối tượng SqlDataReader
            using SqlDataReader reader = command.ExecuteReader();



            // in kết quả đọc được ra màn hình
            Console.WriteLine("Bang Student:");
            while (reader.Read() == true)
            {
                Console.Write($"{reader["Id"], -8}");
                Console.Write($"{reader["Name"],-15}");
                Console.Write($"{reader["Email"],-32}");
                Console.WriteLine($"{reader["Mobile"],-12}");
            }



            // di chuyển sang kết quả của lệnh SELECT thứ hai
            // NextResult() sẽ trả về "true" hoặc "false"
            reader.NextResult();



            // in kết quả đọc được ra màn hình
            Console.WriteLine("\n\nBang Course:");
            while (reader.Read() == true)
            {
                Console.Write($"{reader["Id"],-8}");
                Console.Write($"{reader["Name"],-15}");
                Console.Write($"{((DateTime)reader["StartDate"]).ToString("dd/MM/yyyy"),-15}");
                Console.WriteLine($"{((DateTime)reader["EndDate"]).ToString("dd/MM/yyyy"),-15}");
            }



            // giải phóng tài nguyên
            reader.Close();

            // đóng kết nối
            connection.Close();

            // giải phóng tài nguyên
            connection.Dispose();
        }
    }
}