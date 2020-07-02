using Business.DTOs;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Transfers" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Transfers.svc or Transfers.svc.cs at the Solution Explorer and start debugging.
    public class Transfers : ITransfers
    {
        private readonly TransferService transferService = new TransferService();

        public IEnumerable<TransferDto> GetAll()
        {
            return transferService.GetAll();
        }

        public TransferDto GetById(int transferId)
        {
            return transferService.GetById(transferId);
        }

        public string Create(TransferDto transfer)
        {
            bool isCreated = transferService.Create(transfer);

            return isCreated ? "Transfer successfully added!" : "Failed to add new transfer!";
        }

        public string Update(TransferDto transfer)
        {
            bool isUpdated = transferService.Update(transfer);

            return isUpdated ? "Transfer successfully updated!" : "Failed to update new transfer!";
        }

        public string Delete(int transferId)
        {
            bool isDeleted = transferService.Delete(transferId);

            return isDeleted ? "Transfer successfully deleted!" : "Failed to delete new transfer!";
        }
    }
}
