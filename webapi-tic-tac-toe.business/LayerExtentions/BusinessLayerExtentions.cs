using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_tic_tac_toe.business.MapConfigurations;
using webapi_tic_tac_toe.business.Services.ComputerPlayingService;
using webapi_tic_tac_toe.business.Services.GameFieldService;
using webapi_tic_tac_toe.data.LayerExtentions;

namespace webapi_tic_tac_toe.business.LayerExtentions
{
    public static class BusinessLayerExtentions
    {
        public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddDataLayerServices();

            services.AddScoped<ITicTacToeGame, TicTacToeGame>();
            services.AddScoped<ITicTacToeComputerService, TicTacToeComputerService>();
  
            services.AddAutoMapper(typeof(MapperConfigurations));

            return services;
        }
    }
}
