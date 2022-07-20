using Account.Application.Contracts;
using Account.Domain.Entities;
using Account.Infrastructure.Data;
using Account.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure
{
    public static class AddInfrastructureDependency
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection Services)
        {
            Services.AddScoped<IUserRepository<User>, UserRepository>();
            Services.AddScoped<IAccountContextDb, AccountContextDb>();


            return Services;
        }
    }
}
