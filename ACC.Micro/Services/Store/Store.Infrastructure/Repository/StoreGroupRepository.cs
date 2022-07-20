using System.Collections.Generic;
using System.Linq;
using Store.Application.Contracts.Persistence;
using Store.Domain.Entities;
using Store.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Store.Infrastructure.Repository
{
    public class StoreGroupRepository : IStoreGroupRepository
    {
        private readonly StoreContext _context;

        public StoreGroupRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<StoreGroup> Create(StoreGroup entity)
        {
            await _context.StoreGroup.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<StoreGroup> Delete(StoreGroup entity)
        {
            _context.StoreGroup.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<StoreGroup>> GetAllStoreGroups()
        {
            var result = await _context.StoreGroup.ToListAsync();
            return result;
        }

        public async Task<StoreGroup> Update(StoreGroup entity)
        {
            _context.StoreGroup.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
