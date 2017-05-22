using AutoMapper;
using RestService.Domain.Entities;
using RestService.Domain.Models;

namespace RestService.Domain
{
    public class DomainMapper : Profile
    {
        public DomainMapper()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
