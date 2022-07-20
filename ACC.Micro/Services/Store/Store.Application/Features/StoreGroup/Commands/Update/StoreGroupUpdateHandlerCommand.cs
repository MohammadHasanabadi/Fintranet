using AutoMapper;
using MediatR;
using Store.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.StoreGroup.Commands.Update
{
    internal class StoreGroupUpdateHandlerCommand : IRequestHandler<StoreGroupUpdateCommand, bool>
    {
        private readonly IStoreGroupRepository _repository;
        private readonly IMapper _mapper;

        public StoreGroupUpdateHandlerCommand(IStoreGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(StoreGroupUpdateCommand request, CancellationToken cancellationToken)
        {
            var parameter = _mapper.Map<Store.Domain.Entities.StoreGroup>(request);
            await _repository.Update(parameter);

            return true;

        }
    }
}
