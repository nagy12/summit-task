using AutoMapper;
using MovieApplication.Models.DomainModels;
using MovieApplication.Services;
using MovieApplication.ViewModels;

namespace MovieApplication.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListVM>();
            CreateMap<CategoryAddVM, Category>();

        }
    
    }
}
