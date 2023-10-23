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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("5746464F-C6D1-4F4C-91F8-A106E489E20E"),
                RoleId = Guid.Parse("C4D933C2-411E-4485-BC06-006604EC11FA")
            }, 
            
            new AppUserRole
            {
                UserId = Guid.Parse("A5C8D88A-6A51-4B46-B192-867138C8654F"),
                RoleId = Guid.Parse("7750A061-FD25-462D-A4EE-CD8929525408")
            });
        }
    }
}
