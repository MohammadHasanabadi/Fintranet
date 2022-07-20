using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Contracts.Persistence;
using Store.Infrastructure.Infrastructure;
using Store.Infrastructure.Repository;

namespace Store.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection Services,IConfiguration config)
        {
            Services.AddDbContext<StoreContext>((options) =>
            {
                options.UseSqlServer(config.GetConnectionString("StoreConnectionString"));
            });

            Services.AddScoped(typeof(IStoreGroupRepository), typeof(StoreGroupRepository));

            return Services;
        }
    }
}
