using Microsoft.Extensions.DependencyInjection;
using TokenVlidation.Infrastructure.Implementaions;
using TokenVlidation.Infrastructure.Interfaces;

namespace TokenVlidation.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IBankService, BankService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEncryptionService, EncryptionService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
