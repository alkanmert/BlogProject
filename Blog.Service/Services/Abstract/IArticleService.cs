using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;

namespace Blog.Service.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<ViewArticle>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<ViewArticle> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
        Task UpdateArticleAsync(ViewArticleUpdate viewArticleUpdate);
        Task CreateArticleAsync(ViewArticleAdd viewArticleAdd);

        Task SafeDeleteArticleAsync(Guid articleId);
    }
}
