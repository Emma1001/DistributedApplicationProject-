using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeams" in both code and config file together.
    [ServiceContract]
    public interface ITeams
    {
        [OperationContract]
        IEnumerable<TeamDto> GetAllByName(string name);

        [OperationContract]
        IEnumerable<TeamDto> GetAllByCountry(string country);

        [OperationContract]
        IEnumerable<TeamDto> GetAll();

        [OperationContract]
        TeamDto GetById(int id);

        [OperationContract]
        string Create(TeamDto team);

        [OperationContract]
        string Update(TeamDto team);

        [OperationContract]
        string Delete(int teamId);
    }
}
