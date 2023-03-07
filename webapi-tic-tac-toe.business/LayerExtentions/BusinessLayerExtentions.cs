using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_tic_tac_toe.business.MapConfigurations;

namespace webapi_tic_tac_toe.business.LayerExtentions
{
    public static class BusinessLayerExtentions
    {
        public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperConfigurations));


            return services;
        }
    }
}
