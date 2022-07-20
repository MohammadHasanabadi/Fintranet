using AutoMapper;
using MediatR;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Application.Features.StoreGroup.Commands.Create
{
    public class StoreGroupCreateHandlerCommand : IRequestHandler<StoreGroupCreateCommand, int>
    {
        private readonly IStoreGroupRepository _IStoreGroupRepository;
        private readonly IMapper _mapper;

        public StoreGroupCreateHandlerCommand(IStoreGroupRepository iStoreGroupRepository, IMapper mapper)
        {
            _IStoreGroupRepository = iStoreGroupRepository;
            _mapper = mapper;

        }

        public async Task<int> Handle(StoreGroupCreateCommand request, CancellationToken cancellationToken)
        {
            var parameter = _mapper.Map<Store.Domain.Entities.StoreGroup>(request);
            var result = await _IStoreGroupRepository.Create(parameter);

            return result.Id;
        }
    }
}
