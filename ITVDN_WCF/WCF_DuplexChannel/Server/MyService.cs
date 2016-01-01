using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCF_DuplexChannel;
using System.ServiceModel;


namespace Server
{
    class MyService : IContractService
    {
        

        public void ServerMethod()
        {
            // Интерфейсная ссылка ICallbackMessage.
            WindowHost.callback =
                OperationContext.Current.GetCallbackChannel<IContractClient>();
            
        }
    }
}
