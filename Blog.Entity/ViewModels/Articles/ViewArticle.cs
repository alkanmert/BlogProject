﻿using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.ViewModels.Articles
{
    public class ViewArticle
    {
        public Guid Id {  get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ViewCategory Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public Image Image { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int ViewCount { get; set; }
        public string Author { get; set; }

    }
}
