using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_tic_tac_toe.business.BusinessDtos.TicTacToeDtos;

namespace webapi_tic_tac_toe.business.Models.TicTacToe
{
    public class TicTacToeDatabaseModel : TicTacToeGetDto
    {
        public string ComputerSymbol { get; }
        public string PlayerSymbol { get; }
    }
}
