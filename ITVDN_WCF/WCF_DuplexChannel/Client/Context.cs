using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCF_DuplexChannel;

namespace Client
{
    // КОНТЕКСТ (Клиентский сервис)
    class Context : IContractClient
    {
        public void ClientMethod(string message)
        {
            Console.WriteLine(message);
        }
    }
}
