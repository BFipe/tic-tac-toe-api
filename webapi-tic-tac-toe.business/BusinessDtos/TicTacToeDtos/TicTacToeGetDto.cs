using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi_tic_tac_toe.business.BusinessDtos.TicTacToeDtos
{
    public class TicTacToeGetDto : TicTacToeBasicDto
    {
        [Required]
        public override string Id { get => base.Id; set => base.Id = value; }
    }
}
