using Application.Commands;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly DataContext _context;

        public DeleteProductCommand(DataContext context)
        {
            _context = context;
        }

        public string Name => "Delete product";

        public void Execute(int id)
        {
            var product = _context.Products.Find(id);

            if(product == null)
            {
                throw new ModelNotFound();
            }

            product.DeletedAt = DateTime.Now;
            product.IsDeleted = true;
            product.IsActive = false;

            _context.SaveChanges();
        }
    }
}
