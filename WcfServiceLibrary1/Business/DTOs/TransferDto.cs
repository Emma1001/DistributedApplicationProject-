using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class TransferDto : BaseDto
    {
        public TeamDto TeamLeft { get; set; }
        public TeamDto TeamJoined { get; set; }
        public PlayerDto Player { get; set; }
        public decimal MoneyAmount { get; set; }
        public DateTime DateTransfer { get; set; }
    }
}
