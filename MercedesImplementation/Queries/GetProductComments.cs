using Application.Dto;
using Application.Queries;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class GetProductComments : IGetProductCommentsQuery
    {
        private readonly DataContext _context;

        public GetProductComments(DataContext context)
        {
            _context = context;
        }
        public string Name => "Get comments for product";

        public ResultPaginationDto<ResultCommentDto> Execute(CommentSearchDto search)
        {
            var comments = _context.Comments.Include(x => x.User).Include(x => x.CommentLikes).Where(x => x.ProductId == search.ProductId).AsQueryable();

            var countItems = comments.Count();
            comments = comments.Skip(search.PerPage * (search.Page - 1)).Take(search.PerPage);

            return new ResultPaginationDto<ResultCommentDto>
            {
                Items = comments.Select(x => new ResultCommentDto { 
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    CountLikes = x.CommentLikes.Count(),
                    CommentText = x.CommentText,
                    UserId = x.UserId,
                    Username = x.User.Username
                }).ToList(),
                CountItems = countItems,
                PerPage = search.PerPage,
                CurrentPage = search.Page
            };
        }
    }
}
