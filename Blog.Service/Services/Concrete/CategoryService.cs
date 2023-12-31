using AutoMapper;
using Blog.DataAccess.UnitofWorks;
using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;
using Blog.Entity.ViewModels.Categories;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Blog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<ViewCategory> GetCategoryNonDeletedAsync(Guid categoryId)
        {
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryId);
            var map = mapper.Map<ViewCategory>(category);

            return map;
        }
        public async Task<List<ViewCategory>> GetAllCategoriesNonDeletedAsync()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<ViewCategory>>(categories);
            return map;
        }
        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
            return category;
        }
        public async Task CreateCategoryAsync(ViewCategoryAdd viewCategoryAdd)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            Category category = new(viewCategoryAdd.Name, userEmail);

            await unitOfWork.GetRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();
        }
        public async Task<string> UpdateArticleAsync(ViewCategoryUpdate viewCategoryUpdate)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == viewCategoryUpdate.Id);

            category.Name = viewCategoryUpdate.Name;
            category.ModifiedBy = userEmail;
            category.UpdatedDate = DateTime.Now;

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();

            return category.Name;
        }
        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);

            category.IsDeleted = true;
            category.DeletedBy = userEmail;
            category.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);

            await unitOfWork.SaveAsync();
            return category.Name;
        }


    }
}
