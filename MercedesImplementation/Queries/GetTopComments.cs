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
    public class GetTopComments : ITopLikeCommentsQuery
    {
        private readonly DataContext _context;
        public GetTopComments(DataContext context)
        {
            _context = context;
        }
        public string Name => "Get popular comments";

        public List<ResultCommentDto> Execute(int search = 5)
        {
            var comments = _context.Comments.Include(x => x.CommentLikes).Include(x => x.User).OrderByDescending(x => x.CommentLikes.Count).Take(search).AsQueryable();

            return comments.Select(x => new ResultCommentDto {
                CreatedAt = x.CreatedAt,
                CommentText = x.CommentText,
                CountLikes = x.CommentLikes.Count,
                Id = x.Id,
                Username = x.User.Username,
                UserId = x.UserId
            }).ToList();
        }
    }
}
