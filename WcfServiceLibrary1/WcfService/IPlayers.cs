using Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlayers" in both code and config file together.
    [ServiceContract]
    public interface IPlayers
    {
        [OperationContract]
        IEnumerable<PlayerDto> GetAllByTeam(string teamName);

        [OperationContract]
        IEnumerable<PlayerDto> GetAll();

        [OperationContract]
        PlayerDto GetById(int playerId);

        [OperationContract]
        string Create(PlayerDto player);

        [OperationContract]
        string Update(PlayerDto player);

        [OperationContract]
        string Delete(int playerId);
    }
}
