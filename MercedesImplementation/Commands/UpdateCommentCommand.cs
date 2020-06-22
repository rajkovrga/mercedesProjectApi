using Application.Commands;
using Application.Dto;
using FluentValidation;
using Implementation.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Application;
using Application.Exceptions;

namespace Implementation.Commands
{
    public class UpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly CommentValidate _validations;
        private readonly DataContext _context;
        private readonly IApplicationActor _actor;

        public UpdateCommentCommand(CommentValidate validations, IApplicationActor actor, DataContext context)
        {
            _validations = validations;
            _actor = actor;
            _context = context;
        }

        public string Name => "Update comment";

        public void Execute(CommentDto request, int id)
        {
            _validations.ValidateAndThrow(request);

            var comment = _context.Comments.Find(id);

            if (comment == null)
            {
                throw new ModelNotFound();
            }

            if (comment.UserId != _actor.Id)
            {
                throw new ForbiddenException(this, _actor);
            }

            comment.CommentText = request.CommentText;

            _context.SaveChanges();

        }
    }
}
