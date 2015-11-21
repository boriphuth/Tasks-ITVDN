using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITVDN_ADO.NET_Task5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT EmployeeID, FName, LName, Salary FROM Employees; SELECT * FROM Orders; SELECT * FROM OrderDetails;";

        DataSet shopDB = new DataSet("ShopDB");
        SqlDataAdapter adapter;

        DataTable table;
        DataTable table2;
        DataTable table3;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter(commandString, connectionString);
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(shopDB);

            table = new DataTable("Employees");
            table2 = new DataTable("Orders");
            table3 = new DataTable("OrderDetails");

            table = shopDB.Tables[0];
            table2 = shopDB.Tables[1];
            table3 = shopDB.Tables[2];

            table.Columns.Add("TotalSold", typeof(double));

            shopDB.Relations.Add("Employees_Orders", table.Columns["EmployeeID"], table2.Columns["EmployeeID"]);
            shopDB.Relations.Add("Orders_OrderDetails", table2.Columns["OrderID"], table3.Columns["OrderID"]);

            int index = -1;

            foreach (DataRow item in table.Rows)
            {
                ++index;
                double sum = 0;
                var rowOrders = item.GetChildRows("Employees_Orders");
                if (rowOrders.Length != 0)
                {
                    foreach (DataRow rowOrder in rowOrders)
                    {
                        var rowOrderDetails = rowOrder.GetChildRows("Orders_OrderDetails");
                        foreach (var rowOrd in rowOrderDetails)
                        {
                            sum += double.Parse(rowOrd["TotalPrice"].ToString());
                        }
                    }
                    table.Rows[index]["TotalSold"] = sum; // добавление расчитываемого столбца, используемого связь                     
                }
            }
            dataGrid.ItemsSource = table.DefaultView;
        }
    }
}
