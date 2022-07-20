using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Infrastructure.Infrastructure;

namespace Store.Infrastructure.Infrastructure
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            //StoreContextSeed.SeedAsync(this).GetAwaiter();

        }

        public DbSet<StoreGroup> StoreGroup { get; set; }
    }
}
