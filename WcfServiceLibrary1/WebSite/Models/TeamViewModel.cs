using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class TeamViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        [DisplayName("Team")]
        public string TeamName { get; set; }

        [Required, MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [DisplayName("Date of Creation")]
        public DateTime DateCreation { get; set; }
        public decimal NetWorth { get; set; }

        [DisplayName("Average Age")]
        public double AverageAgePlayers { get; set; }
    }
}
