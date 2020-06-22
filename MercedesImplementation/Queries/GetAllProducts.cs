using Application.Dto;
using Application.Queries;
using DataAccess;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetAllProducts : IGetAllProductQuery<ProductResult>
    {
        private readonly DataContext _context;

        public GetAllProducts(DataContext context)
        {
            _context = context;
        }

        public string Name => "Get all products";

        public ResultPaginationDto<ProductResult> Execute(ProductSearchDto search)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                products = products.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.KsMax != 0 && search.KsMin != 0)
            {
                products = products.Where(x => x.Ks >= search.KsMin && x.Ks <= search.KsMax);
            }

            if (search.KmMax != 0 && search.KmMin != 0)
            {
                products = products.Where(x => x.Km >= search.KmMin && x.Ks <= search.KmMax);
            }

            if (search.KbMax != 0 && search.KbMin != 0)
            {
                products = products.Where(x => x.Kb >= search.KbMin && x.Kb <= search.KbMax);
            }

            if (Convert.ToInt32(search.MadeMax) <= Convert.ToInt32(DateTime.Now.Year) && Convert.ToInt32(search.MadeMin) >= 1920)
            {
                products = products.Where(x => Convert.ToInt32(x.Made) >= Convert.ToInt32(search.MadeMin) 
                && Convert.ToInt32(x.Made) <= Convert.ToInt32(search.MadeMax));
            }

            if(search.IsAir.HasValue)
            {
                products = products.Where(x => x.IsAir == search.IsAir);
            }

            if(search.TypeProductIds != null)
            {
                products = products.Where(x => search.TypeProductIds.Contains(x.TypeProductId));
            }

            var countItems = products.Count();
            products = products.Skip(search.PerPage * (search.Page - 1)).Take(search.PerPage);

            var result = new ResultPaginationDto<ProductResult>
            {
                Items = products.Select(x => new ProductResult
                {
                    Id = x.Id,
                    NumberComments = x.Comments.Count,
                    NumberLikes = x.Likes.Count,
                    Name = x.Name,
                    Made = x.Made,
                    TypeProductId = x.TypeProductId,
                    TypeProductName = x.TypeProduct.Name.ToString(),
                    Kb = x.Kb,
                    Km = x.Km,
                    Ks = x.Ks,
                    IsAir = x.IsAir,
                    CreatedAt = x.CreatedAt
                }).ToList(),
                CountItems = countItems,
                PerPage = search.PerPage,
                CurrentPage = search.Page
            };

            return result;

        } 

    }
}
