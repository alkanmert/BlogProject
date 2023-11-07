using AutoMapper;
using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<ViewCategory, Category>().ReverseMap();
        }
    }
}
