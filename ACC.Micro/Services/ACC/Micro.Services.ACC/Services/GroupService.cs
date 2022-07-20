using Micro.Services.ACC.DTOs;
using Micro.Services.ACC.Entity;
using Micro.Services.ACC.Repository;

namespace Micro.Services.ACC.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository iGroupRepository;

        public GroupService(IGroupRepository IGroupRepository)
        {
            iGroupRepository = IGroupRepository;
        }

        public async Task<bool> CreateGroup(GroupDTO groupDTO)
        {
            var reult = await iGroupRepository.CreateGroup(new Group()
            {
                GroupName = groupDTO.GroupName,
                GroupCode = groupDTO.GroupCode
            });

            return reult;
        }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await iGroupRepository.GetAllGroups();
            
        }
    }
}
