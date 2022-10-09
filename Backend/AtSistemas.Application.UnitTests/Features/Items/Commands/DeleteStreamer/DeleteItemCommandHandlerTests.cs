using AutoMapper;
using AtSistemas.Application.Mappings;
using AtSistemas.Application.UnitTests.Mocks;
using AtSistemas.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;
using AtSistemas.Application.Features.Items.Commands.DeleteItem;
using AtSistemas.Application.UnitTests.Constants;

namespace AtSistemas.Application.UnitTests.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeleteItemCommandHandler>> _logger;

        public DeleteItemCommandHandlerTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<DeleteItemCommandHandler>>();
        }

        [Fact]
        public async Task DeleteItemCommand_InputItemById_ReturnsUnit()
        {
            var itemInput = new DeleteItemCommand
            {
                Id = InitialValues.Item.Id
            };

            var handler = new DeleteItemCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(itemInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
