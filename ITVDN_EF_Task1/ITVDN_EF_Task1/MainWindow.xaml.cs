
using System.Linq;

using System.Windows;


namespace ITVDN_EF_Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            model = new MyDBEntities();
            model2 = new MyModelContainer();
            //model2.PersonaInfoes.Add(new PersonaInfo { FName = "Gregory", LName = "Terner", Skype = "45greg" });
            //model2.SaveChanges();
        }

        MyDBEntities model;
        MyModelContainer model2;
        
        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            dtGrid.ItemsSource = model.Employees.ToList();
        }

        private void btnLoadData1_Click(object sender, RoutedEventArgs e)
        {
            dtGrid1.ItemsSource = model2.PersonaInfoes.ToList();
        }
    }
}
