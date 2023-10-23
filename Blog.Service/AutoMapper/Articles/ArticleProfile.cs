using AutoMapper;
using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;

namespace Blog.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ViewArticle, Article>().ReverseMap();
        }
    }
}
