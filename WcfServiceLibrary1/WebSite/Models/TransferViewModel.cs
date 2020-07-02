using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class TransferViewModel
    {
        public int Id { get; set; }

        [DisplayName("Team Left")]
        public int TeamLeftId { get; set; }
        public TeamViewModel TeamLeft { get; set; }

        [DisplayName("Team Joined")]
        public int TeamJoinedId { get; set; }
        public TeamViewModel TeamJoined { get; set; }

        [DisplayName("Player")]
        public int PlayerId { get; set; }
        public PlayerViewModel Player { get; set; }

        [DisplayName("Money")]
        public decimal MoneyAmount { get; set; }

        [DisplayName("Date")]
        public DateTime DateTransfer { get; set; }
    }
}
