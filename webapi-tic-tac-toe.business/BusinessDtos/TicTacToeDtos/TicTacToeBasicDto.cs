using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.business.BusinessDtos.TicTacToeDtos
{
    public class TicTacToeDto
    {
        public string Id { get; set; }

        public string[] GameField { get; set; }

        public string ComputerSymbol { get; set; }

        public string PlayerSymbol { get; set; }
    }
}
