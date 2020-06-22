using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.Configurations;
using DataAccess.Migrations;
using Domen;
using Domen.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-65G2VIO\MSSQLSERVER01;Initial Catalog=mercedes;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration<Product>(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration<User>(new UserConfig());
            modelBuilder.ApplyConfiguration<Permission>(new PermissionsConfig());

            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Comment>().HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Like>().Property(x => x.Id).HasMaxLength(30);
            modelBuilder.Entity<Like>().HasKey(x => x.Id);
            modelBuilder.Entity<CommentLike>().Property(x => x.Id).HasMaxLength(30);
            modelBuilder.Entity<CommentLike>().HasKey(x => x.Id);
            modelBuilder.Entity<CommentLike>().Property(x => x.CommentId).HasMaxLength(30);
            modelBuilder.Entity<CommentLike>().Property(x => x.UserId).HasMaxLength(30);

            modelBuilder.SeedPermissions();
            modelBuilder.SeedRoles();
            modelBuilder.SeedRolePermission();
            modelBuilder.SeedTypes();
        }


        public override int SaveChanges()
        {
            var items = ChangeTracker.Entries();
            foreach(var item in items)
            {
                if(item.Entity is Entity e)
                {
                    switch(item.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.Now;
                            e.IsActive = true;
                            e.IsDeleted = false;
                            break;

                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

    }
}
