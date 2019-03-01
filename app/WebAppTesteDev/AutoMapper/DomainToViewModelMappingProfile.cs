using AutoMapper;
using DomainProduct;
using WebAppTesteDev.Models;

namespace WebAppTesteDev.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ViewModelProduct>();
            CreateMap<Category, ViewModelCategory>();
        }
    }
}