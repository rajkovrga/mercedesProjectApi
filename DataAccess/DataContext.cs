using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.Configurations;
using MercedesDomen;
using MercedesDomen.Entities;
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

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Name = "admin"
            },
            new Role 
            { 
                Name = "user"
            });

            modelBuilder.ApplyConfiguration<Product>(new ProductConfig());
            modelBuilder.ApplyConfiguration<User>(new UserConfig());
            modelBuilder.ApplyConfiguration<Permission>(new PermissionsConfig());

            modelBuilder.Entity<User>().Property(X => X.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Product>().Property(X => X.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Comment>().Property(X => X.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Like>().Property(X => X.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<CommentLike>().Property(X => X.CreatedAt).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<User>().HasQueryFilter(x => x.DeletedAt != null);
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.DeletedAt != null);
            modelBuilder.Entity<Comment>().HasQueryFilter(x => x.DeletedAt != null);

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
