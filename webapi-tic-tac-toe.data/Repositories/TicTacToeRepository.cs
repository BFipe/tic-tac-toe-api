using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_tic_tac_toe.entities.TicTacToeEntities;
using webapi_tic_tac_toe.exceptions;

namespace webapi_tic_tac_toe.data.Repositories
{
    public class TicTacToeRepository : ITicTacToeRepository
    {
        private readonly IDistributedCache _redis;
        private readonly ILogger<TicTacToeRepository> _logger;

        public TicTacToeRepository(IDistributedCache redis, ILogger<TicTacToeRepository> logger)
        {
            _redis = redis;
            _logger = logger;
        }

        public async Task<TicTacToeEntity> GetGameByIdAsync(string id)
        {
            var result = await _redis.GetStringAsync(id);

            if (result is null)
            {
                _logger.LogWarning($"Game with id {id} not found in {nameof(TicTacToeRepository)}.GetGameByIdAsync");
                throw new NotFoundException($"{nameof(TicTacToeRepository)}.GetGameByIdAsync", $"Game with id {id} not found");
            }
            var ticTacToeGame = JsonConvert.DeserializeObject<TicTacToeEntity>(result);

            _logger.LogInformation($"Returned info about game with id {ticTacToeGame.Id}");

            return ticTacToeGame;
        }

        public async Task<TicTacToeEntity> CreateGameAsync()
        {
            var ticTacToeGame = TicTacToeEntity.CreateGame();

            var serialisedGame = JsonConvert.SerializeObject(ticTacToeGame);

            await _redis.SetStringAsync(ticTacToeGame.Id, serialisedGame);

            _logger.LogInformation($"Created new game with id {ticTacToeGame.Id}");

            return ticTacToeGame;
        }

        public async Task<TicTacToeEntity> UpdateGameAsync(TicTacToeEntity ticTacToeGame)
        {
            var serialisedGame = JsonConvert.SerializeObject(ticTacToeGame);

            await _redis.SetStringAsync(ticTacToeGame.Id, serialisedGame);

            _logger.LogInformation($"Updated info about game with id {ticTacToeGame.Id}");

            return ticTacToeGame;
        }

        public async Task DeleteGameByIdAsync(string id)
        {
            await _redis.RemoveAsync(id);

            _logger.LogInformation($"Game with id {id} was removed");
        }
    }
}
