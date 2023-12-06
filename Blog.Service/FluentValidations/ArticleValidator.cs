using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.FluentValidations
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(31)
                .MinimumLength(3)
                .WithName("Başlık");
            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(31)
                .MinimumLength(3)
                .WithName("İçerik");
        }
    }
}
