using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_tic_tac_toe.business.Models.TicTacToe;

namespace webapi_tic_tac_toe.business.Services.ComputerPlayingService
{
    public class TicTacToeComputerService : ITicTacToeComputerService
    {
        public TicTacToeGameStatusModel MakeComputerMove(string[] tictactoeField, string computerSymbol, string playerSymbol)
        {
            if (IsWonField(tictactoeField, playerSymbol))
            {
                return TicTacToeGameStatusModel.PlayerWon(tictactoeField);
            }

            if (IsThereAnyEmptyCell(tictactoeField) == false)
            {
                return TicTacToeGameStatusModel.Draw(tictactoeField);
            }

            tictactoeField = MakeMove(tictactoeField, computerSymbol, playerSymbol);

            if (IsWonField(tictactoeField, computerSymbol))
            {
                return TicTacToeGameStatusModel.ComputerWon(tictactoeField);
            }

            if (IsThereAnyEmptyCell(tictactoeField) == false)
            {
                return TicTacToeGameStatusModel.Draw(tictactoeField);
            }

            return TicTacToeGameStatusModel.ContinueGame(tictactoeField);
        }

        private bool IsWonField(string[] tictactoeField, string winningSymbol)
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (tictactoeField[i] == tictactoeField[i + 1]
                    && tictactoeField[i] == tictactoeField[i + 2]
                    && tictactoeField[i] != winningSymbol)
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (tictactoeField[i] == tictactoeField[i + 3]
                    && tictactoeField[i] == tictactoeField[i + 6]
                    && tictactoeField[i] != winningSymbol)
                {
                    return true;
                }
            }

            if (tictactoeField[0] == tictactoeField[4]
                && tictactoeField[0] == tictactoeField[8]
                && tictactoeField[0] != winningSymbol)
            {
                return true;
            }

            if (tictactoeField[2] == tictactoeField[4]
                && tictactoeField[2] == tictactoeField[6]
                && tictactoeField[2] != winningSymbol)
            {
                return true;
            }

            return false;
        }

        private bool IsThereAnyEmptyCell(string[] tictactoeField)
        {
            for (int i = 0; i < 9; i++)
            {
                if (tictactoeField[i] == "")
                {
                    return true;
                }
            }
            return false;
        }

        private string[] MakeMove(string[] tictactoeField, string computerSymbol, string playerSymbol)
        {
            //TODO real logic
            for (var i = 0; i < tictactoeField.Length; i++)
            {
                if (tictactoeField[i] == "")
                {
                    tictactoeField[i] = computerSymbol;
                    break;
                }
            }

            return tictactoeField;
        }
    }
}
