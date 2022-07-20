using AutoMapper;
using MediatR;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.StoreGroup.Commands.Delete
{
    public class StoreGroupDeleteHandlerCommand : IRequestHandler<StoreGroupDeleteCommand, bool>
    {
        private readonly IStoreGroupRepository _IStoreGroupRepository;
        private readonly IMapper _mapper;
        public StoreGroupDeleteHandlerCommand(IStoreGroupRepository IStoreGroupRepository, IMapper mapper)
        {
            _IStoreGroupRepository = IStoreGroupRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(StoreGroupDeleteCommand request, CancellationToken cancellationToken)
        {
            var paramaeter = _mapper.Map<Store.Domain.Entities.StoreGroup>(request);
            await _IStoreGroupRepository.Delete(paramaeter);

            return true;

        }
    }
}
