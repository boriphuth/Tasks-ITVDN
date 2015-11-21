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

namespace ITDVN_ADO.NET_Task4
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
        string commandString = "SELECT * FROM Customers;";
        SqlDataAdapter adapter;
        DataTable table;
        DataTable newTable = new DataTable("Changed Rows");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter(commandString, connectionString);

            table = new DataTable("Customers");
            lblCurrentTable.Content = table.TableName;
            adapter.Fill(table);
            dataGridCurrent.ItemsSource = table.DefaultView;
            lblChangeTable.Content = newTable.TableName;
        }

        private void btnShowChange_Click(object sender, RoutedEventArgs e)
        {
            
            DataRowCollection row = table.Rows;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                
                if (row[i].RowState == DataRowState.Modified)
                {
                    adapter.Fill(i, 1, newTable);
                    row[i].AcceptChanges();
                }
            }
            
            if (newTable.Rows.Count == 0)
                return;
            
            dataGridChanged.ItemsSource = newTable.DefaultView;
        }

        private void txtCmd_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtCmd_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                commandString = txtCmd.Text;
                adapter = new SqlDataAdapter(commandString, connectionString);

                table = new DataTable("Customers");
                //lblCurrentTable.Content = table.TableName;
                adapter.Fill(table);
                dataGridCurrent.ItemsSource = table.DefaultView;
                lblChangeTable.Content = newTable.TableName;
            }
        }
    }
}
