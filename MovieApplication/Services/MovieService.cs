using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplication.DataAccess;
using MovieApplication.IServices;
using MovieApplication.Models;
using MovieApplication.Models.DomainModels;
using MovieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieApplication.Services
{
 
    public class MovieService : IMovieService
    {
        #region Services
        private readonly MovieApplicationContext _context;
        private readonly IMapper _mapper;
        private bool changeTrackerTracking { get; set; } = false;
        #endregion
        #region Constructor
        public MovieService(MovieApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MovieListVM> GetMovies()
        {
            var movies =  _context.Movies.ToList();
            var mapMovies = _mapper.Map<List<MovieListVM>>(movies);
           return mapMovies;
        }

        public MovieDetailsVM GetMovie(int id)
        {
            var movie = _context.Movies
             .Include(m => m.MovieCategories)
             .ThenInclude(mc => mc.Category)
             .SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return null;
            }
            var mapMovies = _mapper.Map<MovieDetailsVM>(movie);
            return mapMovies;
        }

        public Movie PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
             _context.SaveChangesAsync();
            return movie;
        }

        public async Task PutMovie(int id, MovieUpdateVM movie)
        {
            var existingMovie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            // Update the existing movie with the new values
            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.Rating = movie.Rating;
           _mapper.Map<Movie>(existingMovie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie =  await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return false;
            }

            _context.Movies.Remove(movie);
           await  _context.SaveChangesAsync();

            return true;
        }

        public bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        public void AssignCategoryToMovie(int movieId, int categoryId)
        {
            var movie =  _context.Movies.Find(movieId);
            var category =  _context.Categories.Find(categoryId);
           
            if (movie.MovieCategories == null)
            {
                movie.MovieCategories = new List<MovieCategory>();
            }

            if (!movie.MovieCategories.Any(mc => mc.CategoryId == categoryId))
            {
                movie.MovieCategories.Add(new MovieCategory { MovieId = movieId, CategoryId = categoryId });
                 _context.SaveChanges();
            }
        }
        public IEnumerable<CategoryListVM> GetRelatedCategories(int movieId)
        {
            var relatedCategories = _context.MovieCategories
                .Where(mc => mc.MovieId == movieId)
                .Select(mc => mc.Category)
                .ToList();
            var mapRelatedCategories = _mapper.Map<List<CategoryListVM>>(relatedCategories);
            return mapRelatedCategories;
        }
        #endregion


    }
}
