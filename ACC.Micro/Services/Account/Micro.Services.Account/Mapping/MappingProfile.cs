using ACC.Bus.Common.Events;
using Account.Domain.Entities;
using AutoMapper;

namespace Micro.Services.Account.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserCreateEvent>().ReverseMap();
        }
    }
}
