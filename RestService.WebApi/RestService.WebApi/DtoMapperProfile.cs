
using AutoMapper;
using RestService.Domain.Models;
using RestService.WebApi.Dto.Products.Dto.In;

namespace RestService.WebApi
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<ProductModel, ProductDtoIn>().ReverseMap();
        }
    }
}