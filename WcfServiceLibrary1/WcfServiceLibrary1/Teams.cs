using Business;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Teams" in both code and config file together.
    public class Teams : ITeams
    {
        private readonly TeamService teamService = new TeamService();

        public IEnumerable<TeamDto> GetAllByName(string name)
        {
            return teamService.GetAllByName(name);
        }

        public IEnumerable<TeamDto> GetAllByCountry(string country)
        {
            return teamService.GetAllByCountry(country);
        }

        public IEnumerable<TeamDto> GetAll()
        {
            return teamService.GetAll();
        }

        public TeamDto GetById(int teamId)
        {
            return teamService.GetById(teamId);
        }

        public string Create(TeamDto team)
        {
            bool isCreated = teamService.Create(team);

            return isCreated ? "Team successfully added!" : "Failed to create the team!";
        }

        public string Update(TeamDto team)
        {
            bool isUpdated = teamService.Update(team);

            return isUpdated ? "Team successfully updated!" : "Failed to update the team!";
        }

        public string Delete(int teamId)
        {
            bool isDeleted = teamService.Delete(teamId);

            return isDeleted ? "Team deleted!" : "Failed to delete the team!";
        }
    }
}
