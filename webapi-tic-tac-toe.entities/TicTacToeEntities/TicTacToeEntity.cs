using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.entities.TicTacToeEntities
{
    public class TicTacToeEntity
    {
        public string Id { get; set; }

        public string[] GameField { get; set; }

        public TicTacToeEntity() 
        {
            Id = Guid.NewGuid().ToString();
            GameField = new string[9] { "", "", "", "", "", "", "", "", "" };
        }
    }
}
