using AutoMapper;
using MovieApplication.Models.DomainModels;
using MovieApplication.ViewModels;

namespace MovieApplication.AutoMapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieListVM>();
            CreateMap<Movie, MovieDetailsVM>();
            CreateMap<MovieUpdateVM, Movie>();
            //.ForMember(des => des.CategoryTitle, opt => opt.MapFrom(src => src.Category.Name)); // Replace MovieDto with the DTO (Data Transfer Object) class you want to use
            //CreateMap<Category, CategoryDto>(); // Replace CategoryDto with the DTO for categories
            // Add additional mappings as needed
        }
    }
}
