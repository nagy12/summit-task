using System.Linq.Expressions;
using System;
using MovieApplication.DataAccess;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.Models.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApplication.ViewModels;
using MovieApplication.Services;

namespace MovieApplication.IServices
{
    public interface IMovieService
    {
      IEnumerable<MovieListVM> GetMovies();
        MovieDetailsVM GetMovie(int id);
       Movie PostMovie(Movie movie);
       Task PutMovie(int id, MovieUpdateVM movie);
        Task<bool> DeleteMovie(int id);
        bool MovieExists(int id);
        void AssignCategoryToMovie(int movieId, int categoryId);
        IEnumerable<CategoryListVM> GetRelatedCategories(int movieId);
    }
}
