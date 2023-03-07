using webapi_tic_tac_toe.business.BusinessDtos.TicTacToeDtos;

namespace webapi_tic_tac_toe.business.Services.GameFieldService
{
    public interface ITicTacToeGame
    {
        Task DeleteGame(string id);
        Task<TicTacToeResponceDto> GetGameFieldById(string id);
        Task<TicTacToeResponceDto> MakeMove(TicTacToeGetDto playerBoard);
        Task<TicTacToeResponceDto> StartGame();
    }
}