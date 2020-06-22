using Application.Dto;
using Application.Exceptions;
using Application.Queries;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetOneProduct : IGetOneProductQuery
    {
        private readonly DataContext _context;
        public GetOneProduct(DataContext context)
        {
            _context = context;
        }

        public string Name => "Get one product";

        public ProductResult Execute(int search)
        {
            var product = _context.Products.Include(x => x.Comments).Include(x => x.TypeProduct).Include(x => x.Likes).FirstOrDefault();

            if(product == null)
            {
                throw new ModelNotFound();
            }

            return new ProductResult
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
            };
        }
    }
}
