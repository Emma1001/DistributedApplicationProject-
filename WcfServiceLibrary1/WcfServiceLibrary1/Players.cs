using Business.DTOs;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Players" in both code and config file together.
    public class Players : IPlayers
    {
        private readonly PlayerService playerService = new PlayerService();

        public IEnumerable<PlayerDto> GetAllByTeam(string teamName)
        {
            return playerService.GetAllByTeam(teamName);
        }

        public IEnumerable<PlayerDto> GetAll()
        {
            return playerService.GetAll();
        }

        public PlayerDto GetById(int playerId)
        {
            return playerService.GetById(playerId);
        }

        public string Create(PlayerDto player)
        {
            bool isCreated = playerService.Create(player);

            return isCreated ? "Player successfully added!" : "Failed to add new player!";
        }

        public string Update(PlayerDto player)
        {
            bool isUpdated = playerService.Update(player);

            return isUpdated ? "Player successfully updated!" : "Failed to update new player!";
        }

        public string Delete(int playerId)
        {
            bool isDeleted = playerService.Delete(playerId);

            return isDeleted ? "Player successfully deleted!" : "Failed to delete new player!";
        }
    }
}
