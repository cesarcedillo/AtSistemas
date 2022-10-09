using AutoMapper;
using AtSistemas.Application.Contracts.Persistence;
using AtSistemas.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AtSistemas.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, string>
    {
        private readonly ILogger<CreateItemCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateItemCommandHandler(ILogger<CreateItemCommandHandler> logger, 
                                        IMapper mapper, 
                                        IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var itemEntity = _mapper.Map<Item>(request);

            _unitOfWork.Repository<Item>().AddEntity(itemEntity);
            var result  = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("the Item was not added");
                throw new Exception("the Item was not added");
            }
            return itemEntity.Id;
        }
    }
}
