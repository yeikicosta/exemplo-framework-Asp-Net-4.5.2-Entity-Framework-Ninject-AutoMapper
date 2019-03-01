using AutoMapper;
using DomainProduct;
using WebAppTesteDev.Models;

namespace WebAppTesteDev.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ViewModelProduct, Product>();
            CreateMap<ViewModelCategory, Category>();
        }
    }
}