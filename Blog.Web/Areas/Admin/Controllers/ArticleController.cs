using AutoMapper;
using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstract;
using Blog.Service.Services.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toast;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toast)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
    
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ViewArticleAdd { Categories = categories});
        }

        [HttpPost]
        public async Task<IActionResult> Add(ViewArticleAdd viewArticleAdd)
        {
            var map = mapper.Map<Article>(viewArticleAdd);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleService.CreateArticleAsync(viewArticleAdd);
                toast.AddSuccessToastMessage("İşlem başarılı");
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ViewArticleAdd { Categories = categories });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
            var categories = await categoryService.GetAllCategoriesNonDeleted();

            var viewArticleUpdate = mapper.Map<ViewArticleUpdate>(article);
            viewArticleUpdate.Categories = categories;

            return View(viewArticleUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ViewArticleUpdate viewArticleUpdate)
        {
            await articleService.UpdateArticleAsync(viewArticleUpdate);
            
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            viewArticleUpdate.Categories = categories;

            return View(viewArticleUpdate);
        }
        public async Task<IActionResult> Delete(Guid articleId)
        {
            await articleService.SafeDeleteArticleAsync(articleId);
            toast.AddSuccessToastMessage("Silme işlemi başarıyla gerçekleşti");

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}
