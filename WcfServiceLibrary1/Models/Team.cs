using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Team : BaseEntity
    {
        [MaxLength(50)]
        public string TeamName { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }
        public DateTime DateCreation { get; set; }

        [Column(TypeName = "Money")]
        public decimal NetWorth { get; set; }

        public double AverageAgePlayers { get; set; }
    }
}
