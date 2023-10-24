using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccess.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //DataSeed
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Deneme",
                Content = "Merhababaaaababababababa",
                ViewCount = 1,
                Author = "Mertcan Alkan",
                CategoryId = Guid.Parse("B78B5EF8-714B-4C4D-93AA-F7C09863CF9B"),
                ImageId = Guid.Parse("5A6B603D-C15A-4508-AE7C-49F82EA5E8B0"),
                UserId = Guid.Parse("5746464F-C6D1-4F4C-91F8-A106E489E20E")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Deneme2",
                Content = "LoremLoremloremmmmmmmmmm",
                ViewCount = 1,
                Author = "Mertcan Alkan",
                CategoryId = Guid.Parse("31E1CB79-1160-47E3-ACE7-33AFCACB763E"),
                ImageId = Guid.Parse("8A7B7E4B-956B-4907-9945-B6864F6B3CCB"),
                UserId = Guid.Parse("A5C8D88A-6A51-4B46-B192-867138C8654F")
            });
            
        }
    }
}
