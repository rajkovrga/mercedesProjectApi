using Application;
using Application.Commands;
using Application.Dto;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class DislikeProductCommand : IDislikeProductCommand
    {
        private readonly DataAccess.DataContext _context;
        private readonly IApplicationActor _actor;

        public DislikeProductCommand(DataContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public string Name => "Dislike product";

        public void Execute(ProductLikeDto request)
        {
            var like = _context.Likes.Where(x => x.ProductId == request.ProductId)
                .Where(x => x.UserId == _actor.Id).First();

            if (like == null)
            {
                throw new ModelNotFound();
            }

            _context.Likes.Remove(like);

            _context.SaveChanges();
        }
    }
}
