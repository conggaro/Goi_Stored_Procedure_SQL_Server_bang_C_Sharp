using System;
using System.Data;
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



            // GetStudentById là tên "Stored Procedure" trong SQL Server
            command.CommandText = "GetStudentById";

            command.Connection = connection;

            command.CommandType = System.Data.CommandType.StoredProcedure;



            // khai báo đối tượng SqlParameter
            SqlParameter id_parameter = new SqlParameter();

            id_parameter.ParameterName = "@Id";

            id_parameter.SqlDbType = SqlDbType.Int;

            id_parameter.Direction = ParameterDirection.Input;

            id_parameter.Value = 101;



            // thêm đối tượng SqlParameter
            // vào thuộc tính Parameters
            // của đối tượng SqlCommand
            command.Parameters.Add(id_parameter);



            // viết xong command thì mới mở kết nối
            connection.Open();



            // khai báo đối tượng SqlDataReader
            using SqlDataReader reader = command.ExecuteReader();


            // in ra kết quả đọc được
            Console.WriteLine("KET QUA 1:");
            while (reader.Read() == true)
            {
                Console.Write($"{reader["Id"],-8}");
                Console.Write($"{reader["Name"],-15}");
                Console.Write($"{reader["Email"],-32}");
                Console.WriteLine($"{reader["Mobile"],-12}");
            }



            // di chuyển sang kết quả của lệnh SELECT thứ hai
            // NextResult() sẽ trả về "true" hoặc "false"
            reader.NextResult();



            // in ra kết quả đọc được
            Console.WriteLine("\n\nKET QUA 2:");
            while (reader.Read() == true)
            {
                Console.Write($"{reader["Id"],-8}");
                Console.Write($"{reader["Name"],-15}");
                Console.Write($"{reader["Email"],-32}");
                Console.WriteLine($"{reader["Mobile"],-12}");
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