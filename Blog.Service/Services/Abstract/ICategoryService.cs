using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstract
{
    public interface ICategoryService
    {
        public Task<ViewCategory> GetCategoryNonDeletedAsync(Guid categoryId);
        public Task<List<ViewCategory>> GetAllCategoriesNonDeletedAsync();
        Task<Category> GetCategoryByGuid(Guid id);
        public Task CreateCategoryAsync(ViewCategoryAdd viewCategoryAdd);
        public Task<string> UpdateArticleAsync(ViewCategoryUpdate viewCategoryUpdate);
        public Task<string> SafeDeleteCategoryAsync(Guid categoryId);
    }
}
