using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.business.Models.TicTacToe
{
    public class TicTacToeGameStatusModel
    {
        public bool IsComputerWon { get; private set; }
        public bool IsPlayerWon { get; private set; }
        public bool IsDraw { get; private set; }
        public string[] GameField { get; private set; }

        public static TicTacToeGameStatusModel ComputerWon(string[] gameField)
        {
            return new TicTacToeGameStatusModel()
            {
                IsComputerWon = true,
                IsPlayerWon = false,
                IsDraw = false,
                GameField = gameField
            };
        }

        public static TicTacToeGameStatusModel PlayerWon(string[] gameField)
        {
            return new TicTacToeGameStatusModel()
            {
                IsComputerWon = false,
                IsPlayerWon = true,
                IsDraw = false,
                GameField = gameField
            };
        }

        public static TicTacToeGameStatusModel Draw(string[] gameField)
        {
            return new TicTacToeGameStatusModel()
            {
                IsComputerWon = false,
                IsPlayerWon = false,
                IsDraw = true,
                GameField = gameField
            };
        }

        public static TicTacToeGameStatusModel ContinueGame(string[] gameField)
        {
            return new TicTacToeGameStatusModel()
            {
                IsComputerWon = false,
                IsPlayerWon = false,
                IsDraw = false,
                GameField = gameField
            };
        }
    }
}
