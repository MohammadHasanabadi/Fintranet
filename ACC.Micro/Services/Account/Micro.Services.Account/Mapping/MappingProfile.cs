using ACC.Bus.Common.Events;
using Account.Application.Features;
using Account.Domain.Entities;
using AutoMapper;

namespace Micro.Services.Account.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, UserCreateEvent>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Mob, y => y.MapFrom(g => g.Mob))
                .ForMember(x => x.CreatedDate, y => y.Ignore())
                .ForMember(x => x.Name, y => y.MapFrom(y => y.UserName))
                .ForMember(x => x.Familly, y => y.MapFrom(y => y.Familly));

            CreateMap<UserCreateEvent, CreateUserCommand>()
                .ForMember(x => x.UserName, y => y.MapFrom(y => y.Name))
                .ForMember(x => x.Mob, y => y.MapFrom(g => g.Mob))
                .ForMember(x => x.Familly, y => y.MapFrom(g => g.Familly))
                 .ForMember(x => x.Password, y => y.Ignore())
                .ForMember(x => x.Name, y => y.MapFrom(g => g.Name));

        }
    }
}
