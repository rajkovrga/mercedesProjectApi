using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Dto;
using Application.Exceptions;
using Application.Queries;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Implementation.Queries
{
    public class GetTopProducts : ITopLikeProductsQuery
    {
        private readonly DataContext _context;
        public GetTopProducts(DataContext context)
        {
            _context = context;
        }
        public string Name => "Get popular products";

        public List<ProductResult> Execute(int search)
        {
            var products = _context.Products.Include(x => x.Comments).Include(x => x.Likes).OrderByDescending(x => x.Likes.Count).Take(search);

            if (products == null)
            {
                throw new ModelNotFound();
            }

            return products.Select(product => new ProductResult
            {
                Id = product.Id,
                NumberComments = product.Comments.Count,
                NumberLikes = product.Likes.Count,
                Name = product.Name,
                Made = product.Made,
                TypeProductId = product.TypeProductId,
                TypeProductName = product.TypeProduct.Name.ToString(),
                Kb = product.Kb,
                Km = product.Km,
                Ks = product.Ks,
                IsAir = product.IsAir,
                CreatedAt = product.CreatedAt
            }).ToList();
        }
    }
}
