using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_tic_tac_toe.business.BusinessDtos.TicTacToeDtos;
using webapi_tic_tac_toe.business.Services.GameFieldService;

namespace webapi_tic_tac_toe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicTacToeController : ControllerBase
    {
        private readonly ILogger<TicTacToeController> _logger;
        private readonly ITicTacToeGame _ticTacToeGame;

        public TicTacToeController(ILogger<TicTacToeController> logger, ITicTacToeGame ticTacToeGame)
        {
            _logger = logger;
            _ticTacToeGame = ticTacToeGame;
        }

        [HttpGet(Name = "StartGame")]
        public async Task<ActionResult<TicTacToeResponceDto>> StartGame() 
        {
            return await _ticTacToeGame.StartGame();
        }
    }
}
