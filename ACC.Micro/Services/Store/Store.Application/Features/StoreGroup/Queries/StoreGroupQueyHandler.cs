using AutoMapper;
using MediatR;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.StoreGroup.Queries
{
    public class StoreGroupQueyHandler : IRequestHandler<StoreGroupListQuery, IEnumerable<StoreGroupDTO>>
    {
        private readonly IStoreGroupRepository _repository;
        private readonly IMapper _mapper;

        public StoreGroupQueyHandler(IStoreGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StoreGroupDTO>> Handle(StoreGroupListQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllStoreGroups();
             return _mapper.Map<IEnumerable<StoreGroupDTO>>(data);


        }
    }
}
