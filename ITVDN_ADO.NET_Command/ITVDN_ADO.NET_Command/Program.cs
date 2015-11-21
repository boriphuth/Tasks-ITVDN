using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ITVDN_ADO.NET_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr); // создание подключения
            //GetData(connection);
            GetDataAsync(connection);
            Console.WriteLine("Do query from main");
            Console.ReadKey();
        }

        private async static void GetDataAsync(SqlConnection connection)
        {
            Console.WriteLine("Enter ProductId");
            int prodId = int.Parse(Console.ReadLine()); // получение данных от пользователя

            SqlCommand cmd = new SqlCommand("InfoByProductId", connection) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ID", prodId);

            await connection.OpenAsync();

            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);

                Console.WriteLine();
            }

            connection.Close();
        }

        private static void GetData(SqlConnection connection)
        {
            Console.WriteLine("Enter ProductId");
            int prodId = int.Parse(Console.ReadLine()); // получение данных от пользователя

            SqlCommand cmd = new SqlCommand("InfoByProductId", connection) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ID", prodId);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);

                Console.WriteLine();
            }

            connection.Close();
        }
    }
}
