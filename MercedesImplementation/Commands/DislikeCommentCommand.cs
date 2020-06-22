using Application.Exceptions;
using DataAccess;
using Application;
using Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Dto;

namespace Implementation.Commands
{
    public class DislikeCommentCommand : IDislikeCommentCommand
    {
        private readonly DataAccess.DataContext _context;
        private readonly IApplicationActor _actor;

        public DislikeCommentCommand(DataContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public string Name => "Dislike comment";

        public void Execute(CommentLikeDto request)
        {
            var like = _context.CommentLikes.Where(x => x.CommentId == request.CommentId)
                .Where(x => x.UserId == _actor.Id).First();

            if (like == null)
            {
                throw new ModelNotFound();
            }

            _context.CommentLikes.Remove(like);

            _context.SaveChanges();
        }
    }
}
