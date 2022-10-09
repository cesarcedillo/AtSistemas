using AutoMapper;
using AtSistemas.Application.Contracts.Persistence;
using AtSistemas.Application.Exceptions;
using AtSistemas.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AtSistemas.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteItemCommandHandler> _logger;

        public DeleteItemCommandHandler(IUnitOfWork unitOfWork,
                                        IMapper mapper,
                                        ILogger<DeleteItemCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var itemRepository = _unitOfWork.Repository<Item>();

            var item = await itemRepository.GetByIdAsync(request.Id);
            if (item == null)
            {
                _logger.LogError($"Item not found");
                throw new NotFoundException(nameof(item), request.Id);
            }

            itemRepository.DeleteEntity(item);
            await _unitOfWork.Complete();
            _logger.LogInformation($"The item [{item.Id}] was deleted");
            
            return Unit.Value;
        }
    }
}
