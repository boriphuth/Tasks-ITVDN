
using System.Windows;

using WCF_DuplexChannel;
using System.ServiceModel;

namespace Server
{
    /// <summary>
    /// Host
    /// </summary>
    public partial class WindowHost : Window
    {
        public WindowHost()
        {
            InitializeComponent();

            host = new ServiceHost(typeof(MyService));

            host.AddServiceEndpoint(
                
                typeof(IContractService), 
                new NetTcpBinding(), 
                "net.tcp://localhost:9000/MyService"
                );

            host.Open();
        }

        // канал связи с клиентом
        public static IContractClient callback;

        // Хостинг для сервиса.
        private ServiceHost host;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            WindowHost.callback.ClientMethod(textBox.Text);
        }
    }
}
