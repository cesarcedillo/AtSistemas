using AutoMapper;
using AtSistemas.Application.Contracts.Persistence;
using AtSistemas.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using AtSistemas.Domain;

namespace AtSistemas.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateItemCommandHandler> _logger;

        public UpdateItemCommandHandler(IUnitOfWork unitOfWork,
                                        IMapper mapper,
                                        ILogger<UpdateItemCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var itemRepository = _unitOfWork.Repository<Item>();

            var item = await itemRepository.GetByIdAsync(request.Id);
            if (item == null)
            {
                _logger.LogError($"Item not found");
                throw new NotFoundException(nameof(item), request.Id);
            }

            _mapper.Map(request, item, typeof(UpdateItemCommand), typeof(Item));
            itemRepository.UpdateEntity(item);
            await _unitOfWork.Complete();
            _logger.LogInformation($"The item [{item.Id}] was updated");

            return Unit.Value;
        }
    }
}
