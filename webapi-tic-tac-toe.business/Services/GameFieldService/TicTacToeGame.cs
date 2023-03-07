using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_tic_tac_toe.business.BusinessDtos.TicTacToeDtos;
using webapi_tic_tac_toe.data.Repositories;
using webapi_tic_tac_toe.exceptions;

namespace webapi_tic_tac_toe.business.Services.GameFieldService
{
    public class TicTacToeGame
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TicTacToeGame> _logger;
        private readonly ITicTacToeRepository _ticTacToeRepository;

        public TicTacToeGame(IMapper mapper, ILogger<TicTacToeGame> logger, ITicTacToeRepository ticTacToeRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _ticTacToeRepository = ticTacToeRepository;
        }

        public async Task<TicTacToeDto> StartGame()
        {
            var game = _ticTacToeRepository.CreateGameAsync();

            var gameDto = _mapper.Map<TicTacToeDto>(game);

            return gameDto;
        }

        public async Task<TicTacToeDto> MadeMove(TicTacToeDto playerBoard)
        {
            var databaseBoard = await _ticTacToeRepository.GetGameByIdAsync(playerBoard.Id);

            if (playerBoard.GameField.Length != 9 
                || playerBoard.GameField.All(q => (q == "" || q == databaseBoard.ComputerSymbol || q == databaseBoard.PlayerSymbol)) == false)
            {
                _logger.LogWarning($"Incorrect game field was gained during the game (player field id - {playerBoard.Id})");
                throw new IncorrectGameFieldException();
            }

            var storedBoard = _mapper.Map<TicTacToeDto>(databaseBoard);

            var isCorrectMovement = CheckMove(playerBoard, storedBoard, databaseBoard.IsComputerFirst, databaseBoard.ComputerSymbol, databaseBoard.PlayerSymbol);

            return null;
        }

        private bool CheckMove(TicTacToeDto playerBoard,
            TicTacToeDto storedBoard,
            bool isComputerFirst,
            string computerSymbol,
            string playerSymbol)
        {

            return false;
        }
    }
}
