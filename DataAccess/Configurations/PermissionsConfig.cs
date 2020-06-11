using MercedesDomen.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class PermissionsConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasMany(x => x.RolePermissions)
                .WithOne(x => x.Permission)
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                    new Permission
                    {
                        Name = "create-product"
                    },
                    new Permission
                    {
                        Name = "update-product"
                    },
                    new Permission
                    {
                        Name = "delete-product"
                    },
                    new Permission
                    {
                        Name = "like-product"
                    },
                    new Permission
                    {
                        Name = "comment-product"
                    },
                    new Permission
                    {
                        Name = "like-comment"
                    },
                    new Permission
                    {
                        Name = "use-admin-panel"
                    },
                    new Permission
                    {
                        Name = "change-status"
                    }, new Permission
                    {
                        Name = ""
                    });
        }
    }
}
