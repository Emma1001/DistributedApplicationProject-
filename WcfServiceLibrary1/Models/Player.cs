using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }

        [Column(TypeName = "Money")]
        public decimal MarketValue { get; set; }

        [MaxLength(50)]
        public string Position { get; set; }
        public float Height { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
