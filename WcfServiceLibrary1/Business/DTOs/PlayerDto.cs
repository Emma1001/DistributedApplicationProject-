using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class PlayerDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public decimal MarketValue { get; set; }
        public string Position { get; set; }
        public float Height { get; set; }
        public int TeamId { get; set; }
        public TeamDto Team { get; set; }
    }
}
