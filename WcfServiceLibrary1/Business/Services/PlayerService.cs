using Business.DTOs;
using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PlayerService
    {
        public IEnumerable<PlayerDto> GetAllByTeam(string team)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var players = unitOfWork.PlayerRepository.GetAll(p => p.Team.TeamName == team);

                var result = players.Select(player => new PlayerDto
                {
                    Id = player.Id,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    DateBirth = player.DateBirth,
                    MarketValue = player.MarketValue,
                    Position = player.Position,
                    Height = player.Height,
                    Team = new TeamDto
                    {
                        Id = player.TeamId,
                        TeamName = player.Team.TeamName,
                        Country = player.Team.Country,
                        DateCreation = player.Team.DateCreation,
                        NetWorth = player.Team.NetWorth
                    }
                }).ToList();

                return result;
            }
        }

        public IEnumerable<PlayerDto> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var players = unitOfWork.PlayerRepository.GetAll();

                var result = players.Select(player => new PlayerDto
                {
                    Id = player.Id,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    DateBirth = player.DateBirth,
                    MarketValue = player.MarketValue,
                    Position = player.Position,
                    Height = player.Height,
                    Team = new TeamDto
                    {
                        Id = player.TeamId,
                        TeamName = player.Team.TeamName,
                        Country = player.Team.Country,
                        DateCreation = player.Team.DateCreation,
                        NetWorth = player.Team.NetWorth
                    }
                }).ToList();

                return result;
            }
        }

        public PlayerDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var player = unitOfWork.PlayerRepository.GetById(id);

                return player == null ? null : new PlayerDto
                {
                    Id = player.Id,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    DateBirth = player.DateBirth,
                    MarketValue = player.MarketValue,
                    Position = player.Position,
                    Height = player.Height,
                    Team = new TeamDto
                    {
                        Id = player.TeamId,
                        TeamName = player.Team.TeamName,
                        Country = player.Team.Country,
                        DateCreation = player.Team.DateCreation,
                        NetWorth = player.Team.NetWorth
                    }
                };
            }
        }

        public bool Create(PlayerDto playerDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var player = new Player()
                {
                    FirstName = playerDto.FirstName,
                    LastName = playerDto.LastName,
                    DateBirth = playerDto.DateBirth,
                    MarketValue = playerDto.MarketValue,
                    Position = playerDto.Position,
                    Height = playerDto.Height,
                    TeamId = playerDto.Team.Id
                };

                unitOfWork.PlayerRepository.Create(player);

                return unitOfWork.Save();
            }
        }

        public bool Update(PlayerDto playerDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.PlayerRepository.GetById(playerDto.Id);

                if (result == null)
                    return false;

                result.FirstName = playerDto.FirstName;
                result.LastName = playerDto.LastName;
                result.DateBirth = playerDto.DateBirth;
                result.MarketValue = playerDto.MarketValue;
                result.Position = playerDto.Position;
                result.Height = playerDto.Height;
                result.TeamId = playerDto.Team.Id;

                unitOfWork.PlayerRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Player result = unitOfWork.PlayerRepository.GetById(id);

                if (result == null)
                    return false;

                unitOfWork.PlayerRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
