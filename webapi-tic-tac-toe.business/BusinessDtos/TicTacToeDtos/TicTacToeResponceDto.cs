using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.business.BusinessDtos.TicTacToeDtos
{
    public class TicTacToeResponceDto : TicTacToeBasicDto
    {
        public bool IsComputerWon { get; set; }
        public bool IsPlayerWon { get; set; }
        public bool IsDraw { get; set; }
    }
}
