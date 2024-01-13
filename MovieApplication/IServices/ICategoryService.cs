using MovieApplication.Models.DomainModels;
using MovieApplication.Services;
using MovieApplication.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApplication.IServices
{
    public interface ICategoryService
    {
       IEnumerable<CategoryListVM> GetCategories();
       Category GetCategory(int id);
        Task PostCategory(CategoryAddVM categoryAddVM);
        Task PutCategory(int id, CategoryUpdateVM categoryUpdateVM);
        Task<bool> DeleteCategory(int id);
    }
}
