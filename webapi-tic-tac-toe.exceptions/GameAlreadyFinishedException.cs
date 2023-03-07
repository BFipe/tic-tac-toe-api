using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.exceptions
{
    public class GameAlreadyFinishedException : Exception
    {
        public GameAlreadyFinishedException(string id) : base($"You're trying to play already finished game - id {id}"){ }
    }
}
