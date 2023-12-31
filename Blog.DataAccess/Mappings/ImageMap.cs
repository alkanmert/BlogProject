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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("5A6B603D-C15A-4508-AE7C-49F82EA5E8B0"),
                FileName = "Deneme",
                FileType = "jpg",
                CreatedBy = "MertAlkan",
                CreatedDate = DateTime.Now,
                ModifiedBy = null,
                DeletedBy = null,
                IsDeleted = false,
            },
            new Image
            {
                Id = Guid.Parse("8A7B7E4B-956B-4907-9945-B6864F6B3CCB"),
                FileName = "Deneme2",
                FileType = "png",
                CreatedBy = "MertAlkan",
                CreatedDate = DateTime.Now,
                ModifiedBy = null,
                DeletedBy = null,
                IsDeleted = false
            });
        }
    }
}
