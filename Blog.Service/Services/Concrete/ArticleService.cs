using AutoMapper;
using Blog.Core.Entities;
using Blog.DataAccess.UnitofWorks;
using Blog.Entity.Entities;
using Blog.Entity.Enums;
using Blog.Entity.ViewModels.Articles;
using Blog.Service.Extensions;
using Blog.Service.Helpers.Images;
using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using System.Security.Claims;

namespace Blog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.imageHelper = imageHelper;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateArticleAsync(ViewArticleAdd viewArticleAdd)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInUserEmail();

            var imageUpload = await imageHelper.Upload(viewArticleAdd.Title, viewArticleAdd.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, viewArticleAdd.Photo.ContentType, userEmail);
            await unitOfWork.GetRepository<Image>().AddAsync(image);

            var article = new Article(viewArticleAdd.Title, viewArticleAdd.Content, userId, userEmail, viewArticleAdd.CategoryId, image.Id);

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
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image);
            var map = mapper.Map<ViewArticle>(article);
            
            return map;
        }
        public async Task<string> UpdateArticleAsync(ViewArticleUpdate viewArticleUpdate)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == viewArticleUpdate.Id, x => x.Category, i => i.Image);
            
            if (viewArticleUpdate.Photo != null)
            {
                imageHelper.Delete(article.Image.FileName);

                var imageUpload = await imageHelper.Upload(viewArticleUpdate.Title, viewArticleUpdate.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, viewArticleUpdate.Photo.ContentType, userEmail);
                await unitOfWork.GetRepository<Image>().AddAsync(image);

                article.ImageId = image.Id;
                await unitOfWork.SaveAsync();
            }

            article.Title = viewArticleUpdate.Title;
            article.Content = viewArticleUpdate.Content;
            article.CategoryId = viewArticleUpdate.CategoryId;
            article.UpdatedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;

        }

        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
           
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            
            await unitOfWork.SaveAsync();
            return article.Title;
        }
    }
}
