using webapi_tic_tac_toe.business.Models.TicTacToe;

namespace webapi_tic_tac_toe.business.Services.ComputerPlayingService
{
    public interface ITicTacToeComputerService
    {
        public TicTacToeGameStatusModel MakeComputerMove(string[] tictactoeField, string computerSymbol, string playerSymbol);
    }
}