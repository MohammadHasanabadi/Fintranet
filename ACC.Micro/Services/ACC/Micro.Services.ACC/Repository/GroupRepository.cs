using Micro.Services.ACC.Data;
using Micro.Services.ACC.Entity;
using MongoDB.Driver;


namespace Micro.Services.ACC.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IACCdbContext _context;
        public GroupRepository(IACCdbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CreateGroup(Group group)
        {
            await _context.Groups.InsertOneAsync(group);
            return true;

        }

        public async Task<bool> DeleteGroup(string GroupID)
        {
            FilterDefinition<Group> filter = Builders<Group>.Filter.Eq(a => a.Id, GroupID);
            DeleteResult result = await _context
                                      .Groups
                                      .DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;

        }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {

            return await _context.Groups.Find(a => true).ToListAsync();
        }

        public async Task<Group> GetByID(string GroupID)
        {
            return await _context.Groups.Find(x => x.Id == GroupID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Group>> GetByName(string Name)
        {
            FilterDefinition<Group> filter = Builders<Group>.Filter.Eq(a => a.GroupName, Name);
            return await _context
                   .Groups
                   .Find(filter)
                   .ToListAsync();

        }

        public async Task<bool> UpdateGroup(Group group)
        {
            ReplaceOneResult result = await _context.Groups.ReplaceOneAsync(filter: g => g.Id == group.Id, replacement: group);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

    }
}
