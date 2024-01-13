using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApplication.IServices;
using MovieApplication.Models;
using MovieApplication.Models.DomainModels;
using MovieApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Services
{
    public class CategoryService : ICategoryService
    {
        #region Services
        private readonly MovieApplicationContext _context;
        private readonly IMapper _mapper;
        private bool changeTrackerTracking { get; set; } = false;
        #endregion
        #region Constructor
        public CategoryService(MovieApplicationContext context,IMapper mapper)
        {
            _context = context ?? throw new NullReferenceException();
            _mapper = mapper;
        }
        #endregion
        public async Task<bool> DeleteCategory(int id)
        {
            var category =await _context.Categories.FindAsync(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
              await  _context.SaveChangesAsync();
                return true;

            }
            return false;

        }

        public IEnumerable<CategoryListVM> GetCategories()
        {
            var categories =  _context.Categories.ToList();
            var mapCategories = _mapper.Map<List<CategoryListVM>>(categories);

            return mapCategories;
        }

        public Category GetCategory(int id)
        {
            var category =  _context.Categories.Find(id);

            if (category == null)
            {
                return null;
            }

            return category;
        }
        public async Task PostCategory(CategoryAddVM category)
        {
            var mapCategory=  _mapper.Map<Category>(category);
            await  _context.Categories.AddAsync(mapCategory);
               await _context.SaveChangesAsync();          
        }

        public async Task PutCategory(int id, CategoryUpdateVM Category)
        {
            var existingCategory =await _context.Categories.FindAsync(id);          
            existingCategory.Name = Category.Name;
            await _context.SaveChangesAsync();
             
        }
    }
}
