using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_tic_tac_toe.business.BusinessDtos.TicTacToeDtos;
using webapi_tic_tac_toe.entities.TicTacToeEntities;

namespace webapi_tic_tac_toe.business.MapConfigurations
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            CreateMap<TicTacToeEntity, TicTacToeResponceDto>().ReverseMap();
            CreateMap<TicTacToeEntity, TicTacToeGetDto>().ReverseMap();
        }
    }
}
