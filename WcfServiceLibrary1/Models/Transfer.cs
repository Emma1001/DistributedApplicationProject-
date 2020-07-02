using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Transfer : BaseEntity
    {
        public int TeamLeftId { get; set; }
        public virtual Team TeamLeft { get; set; }
        public int TeamJoinedId { get; set; }
        public virtual Team TeamJoined { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        [Column(TypeName = "Money")]
        public decimal MoneyAmount { get; set; }
        public DateTime DateTransfer { get; set; }
    }
}
