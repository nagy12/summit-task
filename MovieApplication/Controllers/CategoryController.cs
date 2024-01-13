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
    public class CategoryController : ControllerBase
    {
        #region Services
        private readonly ICategoryService _categoryService;
        #endregion
        #region constructor
        public CategoryController(IServiceProvider serviceProvider)
        {
            _categoryService = serviceProvider.GetService<ICategoryService>();
        }
        #endregion
        [HttpGet("GetCategories")]
        public ActionResult<List<Movie>> GetCategories()
        {
            var getCategories = _categoryService.GetCategories();
            return Ok(getCategories);
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryAddVM category)
        {
            if (ModelState.IsValid)
            {
               await _categoryService.PostCategory(category);
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateVM updatedCategory)
        {
            await _categoryService.PutCategory(id, updatedCategory);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
