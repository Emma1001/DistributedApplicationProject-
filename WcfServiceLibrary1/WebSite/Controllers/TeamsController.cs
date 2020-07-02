using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamReference;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        public async Task<ActionResult> Index(string option, string search)
        {
            TeamsClient teamsClient = new TeamsClient();

            TeamDto[] teams;

            if (option == "TeamName")
                teams = await teamsClient.GetAllByNameAsync(search);
            else if (option == "Country")
                teams = await teamsClient.GetAllByCountryAsync(search);
            else
                teams = await teamsClient.GetAllAsync();

            var result = teams
                .Select(t => new TeamViewModel
                {
                    Id = t.Id,
                    TeamName = t.TeamName,
                    Country = t.Country,
                    DateCreation = t.DateCreation,
                    NetWorth = Math.Round(t.NetWorth, 2),
                    AverageAgePlayers = Math.Round(t.AverageAgePlayers, 2)
                })
                .ToArray();

            await teamsClient.CloseAsync();

            return View(result);
        }

        // GET: Teams/Details/5
        public async Task<ActionResult> Details(int id)
        {
            TeamsClient teamsClient = new TeamsClient();

            var team = await teamsClient.GetByIdAsync(id);

            if(team == null)
            {
                return NotFound();
            }

            var result = new TeamViewModel
            {
                Id = team.Id,
                TeamName = team.TeamName,
                Country = team.Country,
                DateCreation = team.DateCreation,
                NetWorth = Math.Round(team.NetWorth, 2),
                AverageAgePlayers = Math.Round(team.AverageAgePlayers, 2)

            };

            await teamsClient.CloseAsync();

            return View(result);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeamViewModel team)
        {
            try
            {
                TeamsClient teamsClient = new TeamsClient();

                var teamDto = new TeamDto
                {
                    TeamName = team.TeamName,
                    Country = team.Country,
                    DateCreation = team.DateCreation,
                    NetWorth = team.NetWorth
                };

                await teamsClient.CreateAsync(teamDto);

                await teamsClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Teams/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            TeamsClient teamsClient = new TeamsClient();

            var team = await teamsClient.GetByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            var result = new TeamViewModel
            {
                Id = team.Id,
                TeamName = team.TeamName,
                Country = team.Country,
                DateCreation = team.DateCreation,
                NetWorth = team.NetWorth,
                AverageAgePlayers = team.AverageAgePlayers

            };

            await teamsClient.CloseAsync();

            return View(result);
        }

        // POST: Teams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TeamViewModel team)
        {
            team.Id = id;

            try
            {
                TeamsClient teamsClient = new TeamsClient();

                var teamDto = new TeamDto
                {
                    Id = team.Id,
                    TeamName = team.TeamName,
                    Country = team.Country,
                    DateCreation = team.DateCreation,
                    NetWorth = team.NetWorth
                };

                await teamsClient.UpdateAsync(teamDto);

                await teamsClient.CloseAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Teams/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TeamsClient teamsClient = new TeamsClient();

            var team = await teamsClient.GetByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            var result = new TeamViewModel
            {
                Id = team.Id,
                TeamName = team.TeamName,
                Country = team.Country,
                DateCreation = team.DateCreation,
                NetWorth = team.NetWorth,
                AverageAgePlayers = team.AverageAgePlayers

            };

            await teamsClient.CloseAsync();

            return View(result);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                TeamsClient teamsClient = new TeamsClient();

                await teamsClient.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}