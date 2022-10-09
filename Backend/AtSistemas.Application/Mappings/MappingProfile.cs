using AtSistemas.Domain;
using AutoMapper;
using AtSistemas.Application.Features.Items.Commands.UpdateItem;
using AtSistemas.Application.Features.Items.Commands.CreateItem;
using AtSistemas.Application.Features.Items.Queries;

namespace AtSistemas.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemsVm>();
            CreateMap<UpdateItemCommand, Item>();
            CreateMap<CreateItemCommand, Item>();
        }
    }
}
