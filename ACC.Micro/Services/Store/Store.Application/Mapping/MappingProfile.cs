using AutoMapper;
using Store.Application.Features.StoreGroup.Commands.Create;
using Store.Application.Features.StoreGroup.Commands.Delete;
using Store.Application.Features.StoreGroup.Commands.Update;
using Store.Application.Features.StoreGroup.Queries;
using Store.Domain.Entities;


namespace Store.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<StoreGroupDTO, StoreGroup>().ReverseMap();
            CreateMap<StoreGroupCreateCommand, StoreGroup>().ReverseMap();
            CreateMap<StoreGroupUpdateCommand, StoreGroup>().ReverseMap();
            CreateMap<StoreGroupDeleteCommand, StoreGroup>().ReverseMap();

        }
    }
}
