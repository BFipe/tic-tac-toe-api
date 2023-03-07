using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.exceptions
{
    public class NotFoundException<T> : Exception
    {
        public NotFoundException(string text) : base($"Object not found exception in {nameof(T)} : {text}") { }
    }
}
