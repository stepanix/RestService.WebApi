using AutoMapper;
using RestService.Domain.Entities;
using RestService.Domain.Models;

namespace RestService.Domain
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
