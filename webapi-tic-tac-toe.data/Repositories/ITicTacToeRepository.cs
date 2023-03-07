using webapi_tic_tac_toe.entities.TicTacToeEntities;

namespace webapi_tic_tac_toe.data.Repositories
{
    public interface ITicTacToeRepository
    {
        Task<TicTacToeEntity> CreateGameAsync();
        Task DeleteGameByIdAsync(string id);
        Task<TicTacToeEntity> GetGameByIdAsync(string id);
        Task<TicTacToeEntity> UpdateGameAsync(TicTacToeEntity ticTacToeGame);
    }
}