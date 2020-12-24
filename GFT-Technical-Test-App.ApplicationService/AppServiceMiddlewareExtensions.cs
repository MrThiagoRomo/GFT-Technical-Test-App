using GFT_Technical_Test_App.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace GFT_Technical_Test_App.ApplicationService
{
    public static class AppServiceMiddlewareExtensions
    {
        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            services.AddDomain();

            services.AddTransient<IOrderAppService, OrderAppService>();

            return services;
        }
    }
}
