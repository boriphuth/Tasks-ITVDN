using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WCF_DuplexChannel
{
    [ServiceContract(CallbackContract = typeof(IContractClient))]
    public interface IContractService
    {
        [OperationContract(IsOneWay = true)]
        void ServerMethod();
    }
}
