using asp_net_microservice_template.DAO;
using asp_net_microservice_template.Models;
using asp_net_microservice_template.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace asp_net_microservice_template
{
    public class ServiceConfiguration
    {
        public static void AddConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PortfolioDatabaseSettings>(configuration.GetSection(nameof(PortfolioDatabaseSettings)));
        }
        
        // ReSharper disable once InconsistentNaming
        public static void AddDAOs(IServiceCollection services)
        {
            services.AddScoped<IAboutContentDao, AboutContentDao>();
            services.AddScoped<PortfolioContentService>();
        }

        public static void AddSingletons(IServiceCollection services)
        {
            services.AddSingleton<IPortfolioDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PortfolioDatabaseSettings>>().Value);
        }
    }
}