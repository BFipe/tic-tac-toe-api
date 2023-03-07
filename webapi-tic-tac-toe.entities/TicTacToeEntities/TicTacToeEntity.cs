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

        public bool IsComputerFirst { get; set; }
        public string ComputerSymbol { get; set; }
        public string PlayerSymbol { get; set; }

        public bool GameFinished { get; set; }

        public static TicTacToeEntity CreateGame()
        {
            var whoFirst = new Random().Next(0, 2);
            return new TicTacToeEntity()
            {
                Id = Guid.NewGuid().ToString(),
                GameField = new string[9] { "", "", "", "", "", "", "", "", "" },

                IsComputerFirst = whoFirst == 1 ? true : false,
                ComputerSymbol = whoFirst == 1 ? "X" : "O",
                PlayerSymbol = whoFirst == 1 ? "O" : "X",
            };
        }
    }
}
