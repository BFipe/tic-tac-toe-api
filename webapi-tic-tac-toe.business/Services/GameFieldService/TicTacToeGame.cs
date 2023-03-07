using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_tic_tac_toe.business.BusinessDtos.TicTacToeDtos;
using webapi_tic_tac_toe.business.Models.TicTacToe;
using webapi_tic_tac_toe.business.Services.ComputerPlayingService;
using webapi_tic_tac_toe.data.Repositories;
using webapi_tic_tac_toe.exceptions;

namespace webapi_tic_tac_toe.business.Services.GameFieldService
{
    public class TicTacToeGame : ITicTacToeGame
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TicTacToeGame> _logger;
        private readonly ITicTacToeRepository _ticTacToeRepository;
        private readonly ITicTacToeComputerService _computer;

        public TicTacToeGame(IMapper mapper, ILogger<TicTacToeGame> logger, ITicTacToeRepository ticTacToeRepository, ITicTacToeComputerService computer)
        {
            _mapper = mapper;
            _logger = logger;
            _ticTacToeRepository = ticTacToeRepository;
            _computer = computer;
        }

        public async Task<TicTacToeResponceDto> StartGame()
        {
            var game = await _ticTacToeRepository.CreateGameAsync();

            if (game.IsComputerFirst)
            {
                var computerMovement = _computer.MakeComputerMove(game.GameField, game.ComputerSymbol, game.PlayerSymbol);
                if (computerMovement.IsPlayerWon == false
                    && computerMovement.IsComputerWon == false
                    && computerMovement.IsDraw == false)
                {
                    game.GameField = computerMovement.GameField;
                    await _ticTacToeRepository.UpdateGameAsync(game);
                    return new TicTacToeResponceDto()
                    {
                        Id = game.Id,
                        GameField = computerMovement.GameField,
                    };
                }
                else
                {
                    throw new CustomDevelopmentException($"Incorrect return while starting the game. id {game.Id}");
                }
            }
            else
            {
                return new TicTacToeResponceDto()
                {
                    Id = game.Id,
                    GameField = game.GameField,
                };
            }
        }

        public async Task<TicTacToeResponceDto> GetGameFieldById(string id)
        {
            return _mapper.Map<TicTacToeResponceDto>(await _ticTacToeRepository.GetGameByIdAsync(id));
        }

        public async Task<TicTacToeResponceDto> MakeMove(TicTacToeGetDto playerBoard)
        {
            var databaseBoard = await _ticTacToeRepository.GetGameByIdAsync(playerBoard.Id);

            if (databaseBoard.GameFinished)
            {
                throw new GameAlreadyFinishedException(playerBoard.Id);
            }

            if (playerBoard.GameField.Length != 9
                || playerBoard.GameField.All(q => (q == "" || q == databaseBoard.ComputerSymbol || q == databaseBoard.PlayerSymbol)) == false)
            {
                _logger.LogWarning($"Incorrect game field was gained during the game (player field id - {playerBoard.Id})");
                throw new IncorrectGameFieldException();
            }

            CheckMove(playerBoard.GameField, databaseBoard.GameField, databaseBoard.PlayerSymbol);

            databaseBoard.GameField = playerBoard.GameField;

            var computerMovement = _computer.MakeComputerMove(databaseBoard.GameField, databaseBoard.ComputerSymbol, databaseBoard.PlayerSymbol);

            databaseBoard.GameField = computerMovement.GameField;

            await _ticTacToeRepository.UpdateGameAsync(databaseBoard);

            return new TicTacToeResponceDto()
            {
                Id = databaseBoard.Id,
                GameField = computerMovement.GameField,
                IsComputerWon = computerMovement.IsComputerWon,
                IsPlayerWon = computerMovement.IsPlayerWon,
                IsDraw = computerMovement.IsDraw,
            };
        }

        public async Task DeleteGame(string id)
        {
            await _ticTacToeRepository.DeleteGameByIdAsync(id);
        }

        private void CheckMove(string[] playerBoard,
            string[] storedBoard,
            string playerSymbol)
        {
            var totalFieldsChanged = 0;

            for (var i = 0; i < playerBoard.Length; i++)
            {
                if (playerBoard[i] != storedBoard[i])
                {
                    if (totalFieldsChanged >= 1) throw new IncorrectMovementException($"Player replaced 2 or more symbols instead of one");

                    if (storedBoard[i] != "") throw new IncorrectMovementException($"Player replaced symbol \"{storedBoard[i]}\" instead of an empty cell");

                    if (playerBoard[i] != playerSymbol) throw new IncorrectMovementException($"Player used incorrect replacement symbol - (\"{playerBoard[i]}\") instead of (\"{playerSymbol}\")");

                    totalFieldsChanged++;
                }
            }

            if (totalFieldsChanged == 0) throw new IncorrectMovementException($"No movement was made by user");
        }
    }
}
