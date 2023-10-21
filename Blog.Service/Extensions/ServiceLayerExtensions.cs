using Blog.DataAccess.Context;
using Blog.DataAccess.Repositories.Abstract;
using Blog.DataAccess.Repositories.Concrete;
using Blog.DataAccess.UnitofWorks;
using Blog.Service.Services.Abstract;
using Blog.Service.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();
            return services;
        }
    }
}
