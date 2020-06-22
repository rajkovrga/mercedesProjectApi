using Bogus;
using Domen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Migrations
{
    public static class ModelCreatingExtensions
    {
        public static void SeedTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType
                {
                    Id = 1,
                    Name = "Limuzina"
                },
                new ProductType
                {
                    Id = 2,
                    Name = "Karavan"
                },
                new ProductType
                {
                    Id = 3,
                    Name = "Hedžbek"
                },
                new ProductType
                {
                    Id = 4,
                    Name = "Kabriolet"
                },
                new ProductType
                {
                    Id = 5,
                    Name = "Kupe"
                },
                new ProductType
                {
                    Id = 6,
                    Name = "Dzip"
                }
            );
        }
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role{
                    Id = 1,
                    Name = "Users"
                },
                new Role
                {
                    Id = 2,
                    Name = "Admin"
                });
        }
        public static void SeedPermissions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(
                new Permission
                {
                    Id = 1,
                    Name = "likes"
                },
                new Permission
                {
                    Id = 2,
                    Name = "comments"
                },
                 new Permission
                 {
                     Id = 3,
                     Name = "update-profile"
                 },
                new Permission
                {
                    Id = 4,
                    Name = "create-product"
                },
                new Permission
                {
                    Id = 5,
                    Name = "update-product"
                },
                new Permission
                {
                    Id = 6,
                    Name = "delete-product"
                },
                new Permission
                {
                    Id = 7,
                    Name = "change-status"
                },
                new Permission
                {
                    Id = 8,
                    Name = "use-admin-panel"
                });
        }
        public static void SeedRolePermission(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission { 
                    Id = 1,
                    RoleId = 1,
                    PermissionId = 1
                },
                new RolePermission
                {
                    Id = 2,
                    RoleId = 1,
                    PermissionId = 2
                },
                new RolePermission
                {
                    Id = 3,
                    RoleId = 1,
                    PermissionId = 3
                },
                new RolePermission
                {
                    Id = 4,
                    RoleId = 2,
                    PermissionId = 1
                },
                new RolePermission
                {
                    Id = 5,
                    RoleId = 2,
                    PermissionId = 2
                },
                new RolePermission
                {
                    Id = 6,
                    RoleId = 2,
                    PermissionId = 3
                },
                  new RolePermission
                  {
                      Id = 7,
                      RoleId = 2,
                      PermissionId = 4
                  },
                    new RolePermission
                    {
                        Id = 8,
                        RoleId = 2,
                        PermissionId = 5
                    },
                      new RolePermission
                      {
                          Id = 9,
                          RoleId = 2,
                          PermissionId = 6
                      },
                        new RolePermission
                        {
                            Id = 10,
                            RoleId = 2,
                            PermissionId = 7
                        },
                          new RolePermission
                          {
                              Id = 11,
                              RoleId = 2,
                              PermissionId = 8
                          });
        }
    }
}
