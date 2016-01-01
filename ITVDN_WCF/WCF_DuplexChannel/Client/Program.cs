using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCF_DuplexChannel;

namespace Client
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.Title = "Client";
            Console.WriteLine("Press any key to connect to server");
            Console.ReadKey();

            // InstanceContext - представляет метод вызываемый сервисом на клиенте.
            InstanceContext context = new InstanceContext(new Context());

            // Создаем фабрику дуплексных каналов на клиенте.
            DuplexChannelFactory<IContractService> factory = new DuplexChannelFactory<IContractService>(
                context,
                new NetTcpBinding(),
                "net.tcp://localhost:9000/MyService"
                );

            // Создаем конкретный канал.
            IContractService server = factory.CreateChannel();

            
            server.ServerMethod();

            Console.WriteLine("Connected");

            Console.ReadKey();

            

            Console.ReadKey();
        }
    }
}
