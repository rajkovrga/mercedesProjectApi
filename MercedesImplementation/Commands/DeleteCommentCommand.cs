using Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Exceptions;
using System.Linq;
using Application;

namespace Implementation.Commands
{
    public class DeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly DataAccess.DataContext _context;
        private readonly IApplicationActor _actor;
        public DeleteCommentCommand(DataAccess.DataContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public string Name => "Delete comment";

        public void Execute(int request)
        {
            
            var comment = _context.Comments.Where(x => x.Id == request).FirstOrDefault();

            if(comment.UserId != _actor.Id)
            {
                throw new ForbiddenException(this, _actor);
            }

            if(comment == null)
            {
                throw new ModelNotFound();
            }

            comment.DeletedAt = DateTime.Now;
            comment.IsDeleted = true;
            comment.IsActive = false;

            _context.SaveChanges();
        }
    }
}
