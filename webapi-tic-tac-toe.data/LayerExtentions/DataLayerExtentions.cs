using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_tic_tac_toe.data.Repositories;

namespace webapi_tic_tac_toe.data.LayerExtentions
{
    public static class DataLayerExtentions
    {
        public static IServiceCollection AddDataLayerServices(this IServiceCollection services)
        {
            services.AddScoped<ITicTacToeRepository, TicTacToeRepository>();

            services.AddStackExchangeRedisCache(q =>
            {
                q.Configuration = Environment.GetEnvironmentVariable("RedisConnection");
            });

            return services;
        }
    }
}
