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
    public class LikeProductCommand : ILikeProductCommand
    {
        private readonly DataAccess.DataContext _context;
        private readonly IApplicationActor _actor;

        public LikeProductCommand(DataContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public string Name => "Like product";

        public void Execute(ProductLikeDto request)
        {
            var product = _context.Products.Find(request.ProductId);

            if (product == null)
            {
                throw new ModelNotFound();
            }

            _context.Likes.Add(new Domen.Entities.Like
            {
                UserId = _actor.Id,
                Id = Convert.ToInt32(request.ProductId.ToString() + _actor.Id.ToString()),
                ProductId = request.ProductId
            });

            _context.SaveChanges();
        }
    }
}
