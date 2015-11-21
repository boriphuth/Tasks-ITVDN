using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ITVDN_ADO.NET
{
    static class TbaleExtensoinClass
    {
        // этот метод записывает данные в таблицу на основе DataReader
        public static void LoadWithSchema(this DataTable table, SqlDataReader reader)
        {
            table.CreateSchemaFromReader(reader);

            table.Load(reader); // Метод Load используется для загрузки в таблицу DataTable строк из источника данных. 
        }

        // этот метод создает ограничения на столбцы таблице на основе полученного объекта DataReader
        private static void CreateSchemaFromReader(this DataTable table, SqlDataReader reader)
        {
            DataTable schemaTable = reader.GetSchemaTable(); // Метод Возвращает таблицу описывающую метаданные столбца объекта SqlDataReader. 

            foreach (DataRow schemaRow in schemaTable.Rows)
            {
                DataColumn column = new DataColumn((string)schemaRow["ColumnName"]);    // создание столбца с именем столбца в источнике данных
                column.AllowDBNull = (bool)schemaRow["AllowDbNull"];                    // получение значения свойства AllowDBNull
                column.DataType = (Type)schemaRow["DataType"];                          // получение значения свойства DataType
                column.Unique = (bool)schemaRow["IsUnique"];                            // получение значения свойства Unique
                column.ReadOnly = (bool)schemaRow["IsReadOnly"];                        // получение значения свойства Readonly
                column.AutoIncrement = (bool)schemaRow["IsIdentity"];                   // получение значения свойства AutoIncrement

                if (column.DataType == typeof(string))                                  // если поле типа string
                    column.MaxLength = (int)schemaRow["ColumnSize"];                    // получить значение свойства MaxLength

                if (column.AutoIncrement == true)                                       // Если поле с автоинкрементом 
                { column.AutoIncrementStep = -1; column.AutoIncrementSeed = 0; }        // задать свойства AutoIncrementStep и AutoIncrementSeed

                table.Columns.Add(column);                                              // добавить созданный столбец в коллекцию Columns таблицы
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDB = new DataSet("ShopDB");
            DataTable orders = new DataTable("Orders");
            DataTable customers = new DataTable("Customers");

            string conStr = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                SqlCommand customersCmd = new SqlCommand("SELECT CustomerNo, LName, FName, Address1, Phone FROM Customers", connection);
                SqlCommand ordersCmd = new SqlCommand("SELECT OrderID, CustomerNo, OrderDate FROM Orders", connection);

                SqlDataReader ordersReader = ordersCmd.ExecuteReader(); // получение DataReader для таблицы OrderDetails

                // метод LoadWithSchema позволяет на основе объекта DataReader создать объект DataTable 
                //с ограничениями для столбцов как в базе данных и заполнить эту таблицу данными
                orders.LoadWithSchema(ordersReader);
                ordersReader.Close();

                SqlDataReader customersReader = customersCmd.ExecuteReader();
                customers.LoadWithSchema(customersReader);
                customersReader.Close();
            }







            customers.PrimaryKey = new DataColumn[] { customers.Columns[0] };

            shopDB.Tables.AddRange(new DataTable[] { customers, orders });
            // создание ограничения ForeignKeyConstraint для таблицы OrderDetails
            var FK_CustomersOrders = new ForeignKeyConstraint(customers.Columns["CustomerNo"], orders.Columns["CustomerNo"]);
            orders.Constraints.Add(FK_CustomersOrders);

            

            
            
            Console.ReadKey();
        }
    }
}
