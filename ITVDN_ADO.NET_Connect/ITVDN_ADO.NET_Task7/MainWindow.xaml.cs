using System;
using System.Collections.Generic;
using System.Data;
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

namespace ITVDN_ADO.NET_Task7
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShopDB dataBase = new ShopDB();
            var empAdapter = new ShopDBTableAdapters.EmployeesTableAdapter();
            var employees = empAdapter.GetData();

            var ordAdapter = new ShopDBTableAdapters.OrdersTableAdapter();
            var orders = ordAdapter.GetData();

            var ordDetAdapter = new ShopDBTableAdapters.OrderDetailsTableAdapter();
            var orderDet = ordDetAdapter.GetData();

            employees.Columns.Add("TotalSum", typeof(decimal));

            var sum = from em in employees.AsQueryable()
                      join ord in orders.AsQueryable()
                      on em.EmployeeID equals ord.EmployeeID into ordGroup

                      from o in ordGroup
                      join det in orderDet.AsQueryable()
                      on o.OrderID equals det.OrderID into detGroup

                      select new
                      {
                          FName = em.FName, LName = em.LName,
                          Total = detGroup.Sum(od => od.TotalPrice)
                      };

            var full = from s in sum.AsQueryable()
                       group s by new { s.FName, s.LName } into g

                       select new
                       {
                           FName = g.Key.FName, LName = g.Key.LName,
                           Total = g.Sum(a => a.Total)
                       };

            dtgrd.ItemsSource = full;

            var custAdap = new ShopDBTableAdapters.CustomersTableAdapter();
            DataTable customers = custAdap.GetData();

            dtgrd2.ItemsSource = customers.Select("City = 'Киев'");

        }
    }
}
