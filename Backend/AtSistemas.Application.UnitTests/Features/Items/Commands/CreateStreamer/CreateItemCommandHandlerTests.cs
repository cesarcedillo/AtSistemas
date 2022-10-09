using AutoMapper;
using AtSistemas.Application.Mappings;
using AtSistemas.Application.UnitTests.Mocks;
using AtSistemas.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;
using AtSistemas.Application.Features.Items.Commands.CreateItem;
using AtSistemas.Application.UnitTests.Constants;

namespace AtSistemas.Application.UnitTests.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateItemCommandHandler>> _logger;

        public CreateItemCommandHandlerTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<CreateItemCommandHandler>>();
        }

        [Fact]
        public async Task CreateItemCommand_InputItem_ReturnsNumber()
        {
            var itemInput = new CreateItemCommand
            {
                Name = InitialValues.Item.Name!,
                Type = InitialValues.Item.Type!,
                ExpirationDate = InitialValues.Item.ExpirationDate!.Value
            };

            var handler = new CreateItemCommandHandler(_logger.Object, _mapper, _unitOfWork.Object);
            var result = await handler.Handle(itemInput, CancellationToken.None);

            result.ShouldBeOfType<string>();
        }
    }
}
