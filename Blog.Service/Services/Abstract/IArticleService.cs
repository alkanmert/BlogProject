using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;

namespace Blog.Service.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<ViewArticle>> GetAllArticleAsync();
    }
}
