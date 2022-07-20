using Micro.Services.ACC.Entity;

namespace Micro.Services.ACC.Repository
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllGroups();
        Task<Group> GetByID(string GroupID);
        Task<IEnumerable<Group>> GetByName(string Name);
        Task<bool> DeleteGroup(string GroupID);
        Task<bool> CreateGroup(Group group);
        Task<bool> UpdateGroup(Group group);
    }
}
