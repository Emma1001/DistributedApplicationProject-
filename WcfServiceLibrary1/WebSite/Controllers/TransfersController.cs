using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlayerReference;
using ServiceReference1;
using TransfersReference;

namespace WebSite.Models
{
    public class TransfersController : Controller
    {
        // GET: Transfers
        public async Task<ActionResult> Index()
        {
            TransfersClient transfersClient = new TransfersClient();

            var transfers = await transfersClient.GetAllAsync();

            var result = transfers
                .Select(t => new TransferViewModel
                {
                    Id = t.Id,
                    MoneyAmount = t.MoneyAmount,
                    DateTransfer = t.DateTransfer,
                    TeamLeftId = t.TeamLeft.Id,
                    TeamLeft = new TeamViewModel
                    {
                        Id = t.TeamLeft.Id,
                        TeamName = t.TeamLeft.TeamName
                    },
                    TeamJoinedId = t.TeamJoined.Id,
                    TeamJoined = new TeamViewModel
                    {
                        Id = t.TeamJoined.Id,
                        TeamName = t.TeamJoined.TeamName
                    },
                    PlayerId = t.Player.Id,
                    Player = new PlayerViewModel
                    {
                        Id = t.Player.Id,
                        FirstName = t.Player.FirstName,
                        LastName = t.Player.LastName,
                        DateBirth = t.Player.DateBirth,
                        MarketValue = t.Player.MarketValue,
                        Position = t.Player.Position,
                        Height = t.Player.Height
                    }

                }).ToArray();

            await transfersClient.CloseAsync();

            return View(result);
        }

        // GET: Transfers/Details/5
        public async Task<ActionResult> Details(int id)
        {
            TransfersClient transfersClient = new TransfersClient();

            var t = await transfersClient.GetByIdAsync(id);

            if (t == null)
                return NotFound();

            var result = new TransferViewModel
            {
                Id = t.Id,
                MoneyAmount = t.MoneyAmount,
                DateTransfer = t.DateTransfer,
                TeamLeftId = t.TeamLeft.Id,
                TeamLeft = new TeamViewModel
                {
                    Id = t.TeamLeft.Id,
                    TeamName = t.TeamLeft.TeamName
                },
                TeamJoinedId = t.TeamJoined.Id,
                TeamJoined = new TeamViewModel
                {
                    Id = t.TeamJoined.Id,
                    TeamName = t.TeamJoined.TeamName
                },
                PlayerId = t.Player.Id,
                Player = new PlayerViewModel
                {
                    Id = t.Player.Id,
                    FirstName = t.Player.FirstName,
                    LastName = t.Player.LastName,
                    DateBirth = t.Player.DateBirth,
                    MarketValue = t.Player.MarketValue,
                    Position = t.Player.Position,
                    Height = t.Player.Height
                }

            };

            await transfersClient.CloseAsync();

            return View(result);
        }

        // GET: Transfers/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Teams = await GetAllTeamsAsync();
            ViewBag.Players = await GetAllPlayersAsync();

            return View();
        }

        // POST: Transfers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TransferViewModel transfer)
        {
            try
            {
                TransfersClient transfersClient = new TransfersClient();

                TeamsClient teamsClient = new TeamsClient();
                
                var teamJoined = await teamsClient.GetByIdAsync(transfer.TeamJoinedId);

                PlayersClient playersClient = new PlayersClient();
                var player = await playersClient.GetByIdAsync(transfer.PlayerId);

                var teamLeft = await teamsClient.GetByIdAsync(player.Team.Id);

                var transferDto = new TransferDto
                {
                    Id = transfer.Id,
                    MoneyAmount = transfer.MoneyAmount,
                    DateTransfer = transfer.DateTransfer,
                    TeamLeft = new TransfersReference.TeamDto
                    {
                        Id = teamLeft.Id,
                        TeamName = teamLeft.TeamName,
                        Country = teamLeft.Country,
                        DateCreation = teamLeft.DateCreation,
                        NetWorth = teamLeft.NetWorth
                    },
                    TeamJoined = new TransfersReference.TeamDto
                    {
                        Id = teamJoined.Id,
                        TeamName = teamJoined.TeamName,
                        Country = teamJoined.Country,
                        DateCreation = teamJoined.DateCreation,
                        NetWorth = teamJoined.NetWorth
                    },
                    Player = new TransfersReference.PlayerDto
                    {
                        Id = player.Id,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        DateBirth = player.DateBirth,
                        MarketValue = player.MarketValue,
                        Position = player.Position,
                        Height = player.Height
                    }
                };

                await transfersClient.CreateAsync(transferDto);

                await teamsClient.CloseAsync();
                await playersClient.CloseAsync();
                await transfersClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Transfers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            TransfersClient transfersClient = new TransfersClient();
            var t = await transfersClient.GetByIdAsync(id);

            if (t == null)
                return NotFound();

            var result = new TransferViewModel
            {
                Id = t.Id,
                MoneyAmount = t.MoneyAmount,
                DateTransfer = t.DateTransfer,
                TeamLeftId = t.TeamLeft.Id,
                TeamLeft = new TeamViewModel
                {
                    Id = t.TeamLeft.Id,
                    TeamName = t.TeamLeft.TeamName
                },
                TeamJoinedId = t.TeamJoined.Id,
                TeamJoined = new TeamViewModel
                {
                    Id = t.TeamJoined.Id,
                    TeamName = t.TeamJoined.TeamName
                },
                PlayerId = t.Player.Id,
                Player = new PlayerViewModel
                {
                    Id = t.Player.Id,
                    FirstName = t.Player.FirstName,
                    LastName = t.Player.LastName,
                    DateBirth = t.Player.DateBirth,
                    MarketValue = t.Player.MarketValue,
                    Position = t.Player.Position,
                    Height = t.Player.Height
                }
            };

            ViewBag.Teams = await GetAllTeamsAsync();
            ViewBag.Players = await GetAllPlayersAsync();

            await transfersClient.CloseAsync();

            return View(result);
        }

        // POST: Transfers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TransferViewModel transfer)
        {
            try
            {
                TransfersClient transfersClient = new TransfersClient();

                var transferDto = new TransferDto
                {
                    Id = transfer.Id,
                    MoneyAmount = transfer.MoneyAmount,
                    DateTransfer = transfer.DateTransfer,
                    TeamLeft = new TransfersReference.TeamDto
                    {
                        Id = transfer.TeamLeftId
                    },
                    TeamJoined = new TransfersReference.TeamDto
                    {
                        Id = transfer.TeamJoinedId
                    },
                    Player = new TransfersReference.PlayerDto
                    {
                        Id = transfer.PlayerId
                    }
                };

                await transfersClient.UpdateAsync(transferDto);

                await transfersClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Transfers/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            TransfersClient transfersClient = new TransfersClient();

            var t = await transfersClient.GetByIdAsync(id);

            if (t == null)
                return NotFound();

            var result = new TransferViewModel
            {
                Id = t.Id,
                MoneyAmount = t.MoneyAmount,
                DateTransfer = t.DateTransfer,
                TeamLeftId = t.TeamLeft.Id,
                TeamLeft = new TeamViewModel
                {
                    Id = t.TeamLeft.Id,
                    TeamName = t.TeamLeft.TeamName
                },
                TeamJoinedId = t.TeamJoined.Id,
                TeamJoined = new TeamViewModel
                {
                    Id = t.TeamJoined.Id,
                    TeamName = t.TeamJoined.TeamName
                },
                PlayerId = t.Player.Id,
                Player = new PlayerViewModel
                {
                    Id = t.Player.Id,
                    FirstName = t.Player.FirstName,
                    LastName = t.Player.LastName
                }
            };

            await transfersClient.CloseAsync();

            return View(result);
        }

        // POST: Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                TransfersClient transfersClient = new TransfersClient();

                await transfersClient.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<IEnumerable<SelectListItem>> GetAllTeamsAsync()
        {
            TeamsClient teamsClient = new TeamsClient();

            var teams = await teamsClient.GetAllAsync();

            var result = teams
                .Select(t => new TeamViewModel
                {
                    Id = t.Id,
                    TeamName = t.TeamName,
                    Country = t.Country,
                    DateCreation = t.DateCreation,
                    NetWorth = t.NetWorth,
                    AverageAgePlayers = t.AverageAgePlayers
                })
                .ToArray();


            return result.Select(team => new SelectListItem(team.TeamName, team.Id.ToString()));
        }

        private async Task<IEnumerable<SelectListItem>> GetAllPlayersAsync()
        {
            PlayersClient playersClient = new PlayersClient();

            var players = await playersClient.GetAllAsync();

            var result = players
                .Select(p => new PlayerViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    DateBirth = p.DateBirth,
                    MarketValue = p.MarketValue,
                    Position = p.Position,
                    Height = p.Height,
                    TeamId = p.TeamId
                })
                .ToArray();

            return result.Select(player => new SelectListItem(player.FirstName + " " + player.LastName, player.Id.ToString()));
        }
    }
}