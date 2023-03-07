using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.exceptions
{
    public class IncorrectMovementException : Exception
    {
        public IncorrectMovementException(string reason) : base($"Incorrect movement on field detected : {reason}") { }
    }
}
