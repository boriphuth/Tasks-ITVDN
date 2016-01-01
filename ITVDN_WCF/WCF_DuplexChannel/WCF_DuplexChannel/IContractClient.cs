using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WCF_DuplexChannel
{
    public interface IContractClient
    {
        [OperationContract(IsOneWay = true)]
        void ClientMethod(string message);
    }
}
