using Blog.Entity.Entities;

namespace Blog.Service.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllArticleAsync();
    }
}
