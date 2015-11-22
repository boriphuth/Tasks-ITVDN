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

namespace ITVDN_ADO.NET_Task8
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
        string commandString = "SELECT * FROM Employees";

        DataTable employees = new DataTable("Employees");

        SqlDataAdapter adapter;

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                adapter.Update(employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Update succeeded");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            ConfigureEmployeesAdapter(adapter);
            adapter.FillSchema(employees, SchemaType.Mapped);

            employees.Columns[0].AutoIncrementSeed = -1;

            adapter.Fill(employees);

            dtgrd.ItemsSource = employees.DefaultView;

            adapter.RowUpdated += adapter_RowUpdated;
        }
        void adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                var insertedRow = e.Row;

                try
                {
                    insertedRow.Table.Columns[0].ReadOnly = false;

                    insertedRow[0] = e.Command.Parameters["NewEmployeeNo"].Value;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    insertedRow.Table.Columns[0].ReadOnly = true;
                }
            }
        }

        //TODO: continue change query on employees
        private static void ConfigureEmployeesAdapter(SqlDataAdapter employeessAdapter)
        {
            #region Configure UpdateCommand

            string commandString = "UPDATE Employees " +
                              "SET FName = @FName," +
                              "LName = @LName," +
                              "MName= @Mname," +
                              "Salary = @Salary," +
                              "PriorSalary = @PriorSalary," +
                              "HireDate = @HireDate," +
                              "TerminationDate = @TerminationDate," +
                              "ManagerEmpID = @ManagerEmpID " +
                              "WHERE EmployeeID = @EmployeeID";

            employeessAdapter.UpdateCommand = new SqlCommand(commandString,
                                                            employeessAdapter.SelectCommand.Connection);

            var updateParameters = employeessAdapter.UpdateCommand.Parameters;
            updateParameters.Add("EmployeeID", SqlDbType.Int, 0, "EmployeeID");
            updateParameters.Add("FName", SqlDbType.NVarChar, 20, "FName");
            updateParameters.Add("LName", SqlDbType.NVarChar, 20, "Lname");
            updateParameters.Add("MName", SqlDbType.NVarChar, 20, "MName");
            updateParameters.Add("Salary", SqlDbType.Money, 0, "Salary");
            updateParameters.Add("PriorSalary", SqlDbType.Money, 0, "PriorSalary");
            updateParameters.Add("HireDate", SqlDbType.Date, 0, "HireDate");
            updateParameters.Add("TerminationDate", SqlDbType.Date, 0, "TerminationDate");
            updateParameters.Add("ManagerEmpID", SqlDbType.Int, 0, "ManagerEmpID");

            #endregion

            #region Configure DeleteCommand

            employeessAdapter.DeleteCommand = new SqlCommand("DELETE Employees WHERE EmployeeID = @EmployeeID",
                                            employeessAdapter.SelectCommand.Connection);

            var deleteParameters = employeessAdapter.DeleteCommand.Parameters;
            deleteParameters.Add("@EmployeeID", SqlDbType.Int, 0, "EmployeeID");

            #endregion

            #region Configure InsertCommand

            employeessAdapter.InsertCommand =
            new SqlCommand("INSERT Employees " +
                           "VALUES (@FName, @LName, @MName, @Salary, @PriorSalary, @HireDate, @TerminationDate, @ManagerEmpID);" +

                           "DECLARE @NewEmployeeID int; " +
                           "SET @NewEmployeeID =  @@IDENTITY;",
                           employeessAdapter.SelectCommand.Connection);

            var insertParameters = employeessAdapter.InsertCommand.Parameters;
            insertParameters.Add("EmployeeID", SqlDbType.Int, 0, "EmployeeID");
            insertParameters.Add("FName", SqlDbType.NVarChar, 20, "FName");
            insertParameters.Add("LName", SqlDbType.NVarChar, 20, "Lname");
            insertParameters.Add("MName", SqlDbType.NVarChar, 20, "MName");
            insertParameters.Add("Salary", SqlDbType.Money, 0, "Salary");
            insertParameters.Add("PriorSalary", SqlDbType.Money, 0, "PriorSalary");
            insertParameters.Add("HireDate", SqlDbType.Date, 0, "HireDate");
            insertParameters.Add("TerminationDate", SqlDbType.Date, 0, "TerminationDate");
            insertParameters.Add("ManagerEmpID", SqlDbType.Int, 0, "ManagerEmpID");

            var outputParameter = insertParameters.Add("NewEmployeeID", SqlDbType.Int);
            outputParameter.Direction = ParameterDirection.Output;

            #endregion
        }
        
    }
}
