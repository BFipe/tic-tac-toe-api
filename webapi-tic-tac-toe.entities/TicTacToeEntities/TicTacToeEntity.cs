using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.entities.TicTacToeEntities
{
    public class TicTacToeEntity
    {
        public string Id { get; set; }

        public string[] GameField { get; set; }

        public bool IsComputerFirst { get; }
        public string ComputerSymbol { get; }
        public string PlayerSymbol { get; }

        public TicTacToeEntity() 
        {
            Id = Guid.NewGuid().ToString();
            GameField = new string[9] { "", "", "", "", "", "", "", "", "" };

            IsComputerFirst = new Random().Next(0, 2) == 1 ? true : false;
            ComputerSymbol = IsComputerFirst ? "X" : "O";
            PlayerSymbol = IsComputerFirst ? "O" : "X";
        }
    }
}
