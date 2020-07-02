using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateBirth { get; set; }

        [DisplayName("Market Value")]
        public decimal MarketValue { get; set; }
        public string Position { get; set; }
        public float Height { get; set; }

        [DisplayName("Team")]
        public int TeamId { get; set; }

        [DisplayName("Team")]
        public TeamViewModel Team { get; set; }
    }
}
