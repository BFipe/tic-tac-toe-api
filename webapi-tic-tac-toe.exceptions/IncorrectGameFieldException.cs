using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.exceptions
{
    public class IncorrectGameFieldException : Exception
    {
        public IncorrectGameFieldException() : base($"Incorrect game field. Check if massive have 9 string values and they match player symbol (X), computer symbol (O) and the empty string (\"\")")
        {

        }
    }
}
