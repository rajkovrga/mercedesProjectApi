using Bogus;
using DataAccess;
using Domen;
using Domen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataSeeder
{
    public class Seeder
    {
        private readonly DataContext _context;
        private List<int> productIds;
        private List<int> userIds;
        public Seeder(DataContext context)
        {
            _context = context;
            productIds = new List<int>();
            userIds = new List<int>();
        }

        public void Run()
        {
            RemoveAll();
            SeedUser();
            SeedProduct();
            productIds.AddRange(_context.Products.Select(x => x.Id).ToList());
            userIds.AddRange(_context.Users.Select(x => x.Id).ToList());
            SeedComments();
            SeedLikes();
            SeedCommentLikes();
        }
        public void SeedUser()
        {
            var roleIds = _context.Roles.Select(x => x.Id).ToList();
            var users = new Faker<User>()
                .RuleFor(x => x.RoleId, y => y.PickRandom(roleIds))
                .RuleFor(x => x.Email, y => y.Person.Email)
                .RuleFor(x => x.Username, y => y.Person.UserName)
                .RuleFor(x => x.Password, y => y.Random.String(15));

            var data = users.Generate(40);
            _context.Users.AddRange(data);
            _context.SaveChanges();

        }
        public void SeedProduct()
        {
            var typeIds = _context.ProductTypes.Select(x => x.Id).ToList();
            var products = new Faker<Product>()
                .RuleFor(x => x.Name, y => y.Random.Words(2))
                .RuleFor(x => x.Made, y => y.Random.Int(1960, (int)DateTime.Now.Year).ToString())
                .RuleFor(x => x.Ks, y => y.Random.Int(50, 400))
                .RuleFor(x => x.Kb, y => y.Random.Int(100000, 400000))
                .RuleFor(x => x.Km, y => y.Random.Int(0, 600000))
                .RuleFor(x => x.IsAir, y => y.Random.Bool())
                .RuleFor(x => x.TypeProductId, y => y.PickRandom(typeIds));

            var data = products.Generate(120);
            _context.Products.AddRange(data);
            _context.SaveChanges();

        }
        public void SeedComments()
        {

            var comments = new Faker<Comment>()
                .RuleFor(x => x.ProductId, y => y.PickRandom(productIds))
                .RuleFor(x => x.UserId, y => y.PickRandom(userIds))
                .RuleFor(x => x.CommentText, y => y.Random.Words(9));

            var data = comments.Generate(180);
            _context.Comments.AddRange(data);
            _context.SaveChanges();

        }
        public void RemoveAll()
        {
            _context.Database.ExecuteSqlRaw("delete from CommentLikes");
            _context.Database.ExecuteSqlRaw("delete from Comments");
            _context.Database.ExecuteSqlRaw("delete from Likes");
            _context.Database.ExecuteSqlRaw("delete from Products");
            _context.Database.ExecuteSqlRaw("delete from Users");
        }
        public void SeedLikes()
        {
            var likes = new Faker<Like>()
                .RuleFor(x => x.ProductId, y => y.PickRandom(productIds))
                .RuleFor(x => x.UserId, y => y.PickRandom(userIds));

            var data = likes.Generate(990);
            data = data.DistinctBy(p => new { p.ProductId, p.UserId }).Select(x => new Like {
                Id = Convert.ToInt32(x.ProductId.ToString() + x.UserId.ToString()),
                ProductId = x.ProductId,
                UserId = x.UserId
            }).ToList();
            _context.Likes.AddRange(data);
            _context.SaveChanges();
        }
        public void SeedCommentLikes()
        {
            var commentIds = _context.Comments.Select(x => x.Id).ToList();
            var ids = _context.Users.Select(x => x.Id).ToList();

            var likes = new Faker<CommentLike>()
                .RuleFor(x => x.CommentId, y => y.PickRandom(commentIds))
                .RuleFor(x => x.UserId, y => y.PickRandom(ids));

            var data = likes.Generate(1500);
            data = data.DistinctBy(p => new { p.CommentId, p.UserId }).Select(x => new CommentLike {
                Id = Convert.ToInt32(x.CommentId.ToString() + x.UserId.ToString()),
                CommentId = x.CommentId,
                UserId = x.UserId
            }).ToList();
            _context.CommentLikes.AddRange(data);
            _context.SaveChanges();
        }
    }
}
