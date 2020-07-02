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
    public class TransferService
    {
        public IEnumerable<TransferDto> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var transfers = unitOfWork.TransferRepository.GetAll();

                var result = transfers.Select(transfer => new TransferDto
                {
                    Id = transfer.Id,
                    TeamLeft = new TeamDto
                    {
                        Id = transfer.TeamLeftId,
                        TeamName = transfer.TeamLeft.TeamName,
                        Country = transfer.TeamLeft.Country,
                        DateCreation = transfer.TeamLeft.DateCreation,
                        NetWorth = transfer.TeamLeft.NetWorth
                    },
                    TeamJoined = new TeamDto
                    {
                        Id = transfer.TeamJoinedId,
                        TeamName = transfer.TeamJoined.TeamName,
                        Country = transfer.TeamJoined.Country,
                        DateCreation = transfer.TeamJoined.DateCreation,
                        NetWorth = transfer.TeamJoined.NetWorth
                    },
                    Player = new PlayerDto
                    {
                        Id = transfer.PlayerId,
                        FirstName = transfer.Player.FirstName,
                        LastName = transfer.Player.LastName,
                        DateBirth = transfer.Player.DateBirth,
                        MarketValue = transfer.Player.MarketValue,
                        Position = transfer.Player.Position,
                        Height = transfer.Player.Height
                    },
                    MoneyAmount = transfer.MoneyAmount,
                    DateTransfer = transfer.DateTransfer
                }).ToList();

                return result;
            }
        }

        public TransferDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var transfer = unitOfWork.TransferRepository.GetById(id);

                return transfer == null ? null : new TransferDto
                {
                    Id = transfer.Id,
                    TeamLeft = new TeamDto
                    {
                        Id = transfer.TeamLeftId,
                        TeamName = transfer.TeamLeft.TeamName,
                        Country = transfer.TeamLeft.Country,
                        DateCreation = transfer.TeamLeft.DateCreation,
                        NetWorth = transfer.TeamLeft.NetWorth
                    },
                    TeamJoined = new TeamDto
                    {
                        Id = transfer.TeamJoinedId,
                        TeamName = transfer.TeamJoined.TeamName,
                        Country = transfer.TeamJoined.Country,
                        DateCreation = transfer.TeamJoined.DateCreation,
                        NetWorth = transfer.TeamJoined.NetWorth
                    },
                    Player = new PlayerDto
                    {
                        Id = transfer.PlayerId,
                        FirstName = transfer.Player.FirstName,
                        LastName = transfer.Player.LastName,
                        DateBirth = transfer.Player.DateBirth,
                        MarketValue = transfer.Player.MarketValue,
                        Position = transfer.Player.Position,
                        Height = transfer.Player.Height
                    },
                    MoneyAmount = transfer.MoneyAmount,
                    DateTransfer = transfer.DateTransfer
                };
            }
        }

        public bool Create(TransferDto transferDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var transfer = new Transfer()
                {
                    TeamLeftId = transferDto.TeamLeft.Id,
                    TeamJoinedId = transferDto.TeamJoined.Id,
                    PlayerId = transferDto.Player.Id,
                    MoneyAmount = transferDto.MoneyAmount,
                    DateTransfer = transferDto.DateTransfer
                };

                unitOfWork.TransferRepository.Create(transfer);

                return unitOfWork.Save();
            }
        }

        public bool Update(TransferDto transferDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.TransferRepository.GetById(transferDto.Id);

                if (result == null)
                    return false;

                result.TeamLeftId = transferDto.TeamLeft.Id;
                result.TeamJoinedId = transferDto.TeamJoined.Id;
                result.PlayerId = transferDto.Player.Id;
                result.MoneyAmount = transferDto.MoneyAmount;
                result.DateTransfer = transferDto.DateTransfer;

                unitOfWork.TransferRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.TransferRepository.GetById(id);

                if (result == null)
                    return false;

                unitOfWork.TransferRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
