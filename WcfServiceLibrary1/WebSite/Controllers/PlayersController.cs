using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlayerReference;
using ServiceReference1;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public async Task<ActionResult> Index(string search)
        {
            PlayersClient playersClient = new PlayersClient();

            PlayerDto[] players;

            if (search != null)
                players = await playersClient.GetAllByTeamAsync(search);
            else
                players = await playersClient.GetAllAsync();

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
                    TeamId = p.TeamId,
                    Team = new TeamViewModel
                    {
                        Id = p.Team.Id,
                        TeamName = p.Team.TeamName,
                        Country = p.Team.Country,
                        DateCreation = p.Team.DateCreation,
                        NetWorth = p.Team.NetWorth,
                        AverageAgePlayers = p.Team.AverageAgePlayers
                    }
                }).ToArray();

            await playersClient.CloseAsync();

            return View(result);
        }

        // GET: Players/Details/5
        public async Task<ActionResult> Details(int id)
        {
            PlayersClient playersClient = new PlayersClient();

            var p = await playersClient.GetByIdAsync(id);

            if (p == null)
                return NotFound();

            var result = new PlayerViewModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateBirth = p.DateBirth,
                MarketValue = p.MarketValue,
                Position = p.Position,
                Height = p.Height,
                TeamId = p.TeamId,
                Team = new TeamViewModel
                {
                    TeamName = p.Team.TeamName
                }
            };

            await playersClient.CloseAsync();

            return View(result);
        }

        // GET: Players/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Teams = await GetAllTeamsAsync();

            return View();
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

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlayerViewModel player)
        {
            try
            {
                PlayersClient playersClient = new PlayersClient();

                TeamsClient teamsClient = new TeamsClient();

                var team = await teamsClient.GetByIdAsync(player.TeamId);

                var playerDto = new PlayerDto
                {
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    DateBirth = player.DateBirth,
                    MarketValue = player.MarketValue,
                    Position = player.Position,
                    Height = player.Height,
                    TeamId = player.TeamId,
                    Team = new PlayerReference.TeamDto
                    {
                        Id = team.Id,
                        TeamName = team.TeamName,
                        Country = team.Country,
                        DateCreation = team.DateCreation,
                        NetWorth = team.NetWorth
                    }
                };

                await playersClient.CreateAsync(playerDto);

                await playersClient.CloseAsync();
                await teamsClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Players/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            PlayersClient playersClient = new PlayersClient();
            var p = await playersClient.GetByIdAsync(id);

            if (p == null)
                return NotFound();

            TeamsClient teamsClient = new TeamsClient();
            var team = await teamsClient.GetByIdAsync(p.TeamId);

            var result = new PlayerViewModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateBirth = p.DateBirth,
                MarketValue = p.MarketValue,
                Position = p.Position,
                Height = p.Height
            };

            //ViewBag.Teams = await GetAllTeamsAsync();

            await playersClient.CloseAsync();

            await teamsClient.CloseAsync();

            return View(result);
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PlayerViewModel player)
        {
            try
            {
                PlayersClient playersClient = new PlayersClient();
                var playerForTeamId = playersClient.GetById(id);
                int idTeam = playerForTeamId.Team.Id;

                //TeamsClient teamsClient = new TeamsClient();

                //var team = await teamsClient.GetByIdAsync(player.TeamId);

                var playerDto = new PlayerDto
                {
                    Id = id,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    DateBirth = player.DateBirth,
                    MarketValue = player.MarketValue,
                    Position = player.Position,
                    Height = player.Height,
                    Team = new PlayerReference.TeamDto
                    {
                        Id = idTeam
                    }
                };

                await playersClient.UpdateAsync(playerDto);

                await playersClient.CloseAsync();
                //await teamsClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Players/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            PlayersClient playersClient = new PlayersClient();
            var p = await playersClient.GetByIdAsync(id);

            if (p == null)
                return NotFound();

            var result = new PlayerViewModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateBirth = p.DateBirth,
                MarketValue = p.MarketValue,
                Position = p.Position,
                Height = p.Height,
                Team = new TeamViewModel
                {
                    TeamName = p.Team.TeamName
                }
            };

            await playersClient.CloseAsync();

            return View(result);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                PlayersClient playersClient = new PlayersClient();

                await playersClient.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}