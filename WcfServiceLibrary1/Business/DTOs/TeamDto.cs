using Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TeamDto : BaseDto
    {
        public string TeamName { get; set; }
        public string Country { get; set; }
        public DateTime DateCreation { get; set; }
        public decimal NetWorth { get; set; }
        public double AverageAgePlayers { get; set; }
    }
}
