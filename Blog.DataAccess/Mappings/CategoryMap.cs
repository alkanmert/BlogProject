using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("B78B5EF8-714B-4C4D-93AA-F7C09863CF9B"),
                Name = "ASP.Net Core",
                CreatedDate = DateTime.Now
            },
            new Category
            {
                Id = Guid.Parse("31E1CB79-1160-47E3-ACE7-33AFCACB763E"),
                Name = "Dünya",
                CreatedDate = DateTime.Now
            });
        }
    }
}
