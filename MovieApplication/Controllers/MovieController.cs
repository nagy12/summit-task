using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApplication.IServices;
using MovieApplication.Models;
using MovieApplication.Models.DomainModels;
using MovieApplication.Services;
using MovieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        #region Services
        private readonly IMovieService _movieService;
        #endregion
        #region constructor
        public MovieController(MovieApplicationContext context, IServiceProvider serviceProvider)
        {
            _movieService = serviceProvider.GetService<IMovieService>();
        }
        #endregion
        #region Methods
        [AllowAnonymous]
        [HttpGet("GetMovies")]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            var movies =  _movieService.GetMovies();
            return Ok(movies);
        }
        [HttpGet("GetMovie/{id}")]
        public  ActionResult<MovieDetailsVM> GetMovie(int id)
        {
            var movie =  _movieService.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
        [HttpPost("{movieId}/categories/{categoryId}")]
        public  IActionResult AssignCategoryToMovie(int movieId, int categoryId)
        {

            _movieService.AssignCategoryToMovie(movieId, categoryId);
            return Ok();
        }
        [HttpGet("{movieId}/related-categories")]
        public IActionResult GetRelatedCategories(int movieId)
        {
            var relatedCategories = _movieService.GetRelatedCategories(movieId);
            return Ok(relatedCategories);
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] MovieUpdateVM updatedMovie)
        {
            await _movieService.PutMovie(id, updatedMovie);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteMovie(id);
            return Ok();
        }

        #endregion
    }
}
