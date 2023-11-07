using AutoMapper;
using Blog.Entity.ViewModels.Articles;
using Blog.Service.Services.Abstract;
using Blog.Service.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
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
            await articleService.CreateArticleAsync(viewArticleAdd);
            RedirectToAction("Index","Article", new {Area = "Admin"});

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
    }
}
