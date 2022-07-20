using Micro.Services.ACC.DTOs;
using Micro.Services.ACC.Entity;

namespace Micro.Services.ACC.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllGroups();
        Task<bool> CreateGroup(DTOs.GroupDTO groupDTO);
    }
}
