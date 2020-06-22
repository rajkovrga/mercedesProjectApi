using Application;
using Application.Commands;
using Application.Dto;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class LikeCommentCommand : ILikeCommentCommand
    {
        private readonly DataAccess.DataContext _context;
        private readonly IApplicationActor _actor;

        public LikeCommentCommand(DataContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public string Name => "Like comment";

        public void Execute(CommentLikeDto request)
        {
            var comment = _context.Comments.Find(request.CommentId);

            if(comment == null)
            {
                throw new ModelNotFound();
            }

            comment.CommentLikes.Add(new Domen.Entities.CommentLike
            {
                UserId = _actor.Id,
                Id = Convert.ToInt32(request.CommentId.ToString() + _actor.Id.ToString())
            });

            _context.SaveChanges();
        }
    }
}
