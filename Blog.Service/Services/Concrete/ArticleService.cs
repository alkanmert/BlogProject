using AutoMapper;
using Blog.DataAccess.UnitofWorks;
using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;
using Blog.Service.Services.Abstract;

namespace Blog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateArticleAsync(ViewArticleAdd viewArticleAdd)
        {
            var userId = Guid.Parse("5746464F-C6D1-4F4C-91F8-A106E489E20E");
            var imageId = Guid.Parse("5A6B603D-C15A-4508-AE7C-49F82EA5E8B0");
            var article = new Article(viewArticleAdd.Title,viewArticleAdd.Content,userId,viewArticleAdd.CategoryId,imageId);

            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();
        }


        public async Task<List<ViewArticle>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ViewArticle>>(articles);
            return map;
        }
        public async Task<ViewArticle> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category);
            var map = mapper.Map<ViewArticle>(article);
            return map;
        }

        public async Task SafeDeleteArticleAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
           
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateArticleAsync(ViewArticleUpdate viewArticleUpdate) 
        { 
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == viewArticleUpdate.Id, x => x.Category);
            
            article.Title = viewArticleUpdate.Title;
            article.Content = viewArticleUpdate.Content;
            article.CategoryId = viewArticleUpdate.CategoryId;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
        }
    }
}
