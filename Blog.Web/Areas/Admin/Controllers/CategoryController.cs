using AutoMapper;
using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;
using Blog.Entity.ViewModels.Categories;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstract;
using Blog.Service.Services.Concrete;
using Blog.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Category> validator;
        private readonly IToastNotification toast;

        public CategoryController(ICategoryService categoryService ,IMapper mapper, IValidator<Category> validator, IToastNotification toast)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesNonDeletedAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ViewCategoryAdd viewCategoryAdd)
        {
            var map = mapper.Map<Category>(viewCategoryAdd);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(viewCategoryAdd);
                toast.AddSuccessToastMessage(Messages.Category.Add(viewCategoryAdd.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] ViewCategoryAdd viewCategoryAdd)
        {
            var map = mapper.Map<Category>(viewCategoryAdd);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(viewCategoryAdd);
                toast.AddSuccessToastMessage(Messages.Category.Add(viewCategoryAdd.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                
                return Json(Messages.Category.Add(viewCategoryAdd.Name));
            }
            else
            {
                toast.AddErrorToastMessage(result.Errors.First().ErrorMessage,new ToastrOptions { Title = "İşlem Başarısız" });
                return Json (result.Errors.First().ErrorMessage); 
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await categoryService.GetCategoryByGuid(categoryId);
            var map = mapper.Map<Category, ViewCategoryUpdate>(category);

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ViewCategoryUpdate viewCategoryUpdate)
        {
            var map = mapper.Map<Category>(viewCategoryUpdate);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await categoryService.UpdateArticleAsync(viewCategoryUpdate);
                toast.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            result.AddToModelState(this.ModelState);
            return View();
        }
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            await categoryService.SafeDeleteCategoryAsync(categoryId);
            toast.AddSuccessToastMessage("Kategori silme işlemi başarıyla tamamlandı !");

            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}
