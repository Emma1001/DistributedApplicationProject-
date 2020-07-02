using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TeamService
    {
        public IEnumerable<TeamDto> GetAllByName(string name)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var teams = unitOfWork.TeamRepository.GetAll(t => t.TeamName == name);

                return teams.Select(team => new TeamDto
                {
                    Id = team.Id,
                    TeamName = team.TeamName,
                    Country = team.Country,
                    DateCreation = team.DateCreation,
                    NetWorth = team.NetWorth,
                    AverageAgePlayers = team.AverageAgePlayers
                });
            }
        }

        public IEnumerable<TeamDto> GetAllByCountry(string country)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var teams = unitOfWork.TeamRepository.GetAll(t => t.Country == country);

                return teams.Select(team => new TeamDto
                {
                    Id = team.Id,
                    TeamName = team.TeamName,
                    Country = team.Country,
                    DateCreation = team.DateCreation,
                    NetWorth = team.NetWorth,
                    AverageAgePlayers = team.AverageAgePlayers
                });
            }
        }

        public IEnumerable<TeamDto> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var teams = unitOfWork.TeamRepository.GetAll();

                return teams.Select(team => new TeamDto
                {
                    Id = team.Id,
                    TeamName = team.TeamName,
                    Country = team.Country,
                    DateCreation = team.DateCreation,
                    NetWorth = team.NetWorth,
                    AverageAgePlayers = team.AverageAgePlayers
                });
            }
        }

        public TeamDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var team = unitOfWork.TeamRepository.GetById(id);

                return team == null ? null : new TeamDto
                {
                    Id = team.Id,
                    TeamName = team.TeamName,
                    Country = team.Country,
                    DateCreation = team.DateCreation,
                    NetWorth = team.NetWorth,
                    AverageAgePlayers = team.AverageAgePlayers
                };
            }
        }

        public bool Create(TeamDto teamDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var team = new Team()
                {
                    TeamName = teamDto.TeamName,
                    Country = teamDto.Country,
                    DateCreation = teamDto.DateCreation,
                    NetWorth = teamDto.NetWorth
                };

                unitOfWork.TeamRepository.Create(team);

                return unitOfWork.Save();
            }
        }

        public bool Update(TeamDto teamDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.TeamRepository.GetById(teamDto.Id);

                if (result == null)
                {
                    return false;
                }

                result.Id = teamDto.Id;
                result.TeamName = teamDto.TeamName;
                result.Country = teamDto.Country;
                result.DateCreation = teamDto.DateCreation;
                result.NetWorth = teamDto.NetWorth;

                unitOfWork.TeamRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Team result = unitOfWork.TeamRepository.GetById(id);

                if (result == null)
                {
                    return false;
                }

                unitOfWork.TeamRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
