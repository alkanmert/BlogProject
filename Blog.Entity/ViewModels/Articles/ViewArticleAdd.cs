using Blog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.ViewModels.Articles
{
    public class ViewArticleAdd
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IList<ViewCategory> Categories { get; set; }
    }
}
