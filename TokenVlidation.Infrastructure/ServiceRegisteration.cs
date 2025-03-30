using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TokenVlidation.Data.Helpers;

namespace TokenVlidation.Infrastructure
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
        {

            var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

            services.AddSingleton(emailSettings);

            return services;
        }
    }
}
