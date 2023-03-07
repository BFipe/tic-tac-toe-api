using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.exceptions
{
    public class CustomDevelopmentException : Exception
    {
        public CustomDevelopmentException(string text) : base($"Unexpected development error : {text}")
        {

        }
    }
}
