using Microsoft.Extensions.Logging;
using Store.Domain.Entities;
using Store.Infrastructure.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Infrastructure.Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext orderContext)
        {            
            if (!orderContext.StoreGroup.Any())
            {
                orderContext.StoreGroup.AddRange(GetPreconfiguredStore());
                await orderContext.SaveChangesAsync();
                //logger.LogInformation("Seed database associated with context {DbContextName}", typeof(StoreContext).Name);
            }
        }

        private static IEnumerable<StoreGroup> GetPreconfiguredStore()
        {
            return new List<StoreGroup>
            {
                new StoreGroup() {StoreGroupName = "Central", StoreGroupCode = "01" }
            };
        }
    }
}
