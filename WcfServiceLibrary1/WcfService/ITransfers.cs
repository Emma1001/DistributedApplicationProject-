using Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransfers" in both code and config file together.
    [ServiceContract]
    public interface ITransfers
    {
        [OperationContract]
        IEnumerable<TransferDto> GetAll();

        [OperationContract]
        TransferDto GetById(int transferId);

        [OperationContract]
        string Create(TransferDto transfer);

        [OperationContract]
        string Update(TransferDto transfer);

        [OperationContract]
        string Delete(int transferId);
    }
}
