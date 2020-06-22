using System;
using System.Collections.Generic;
using System.Text;
using Application.Exceptions;
using FluentValidation;
using Application;
using Application.Commands;
using Application.Dto;
using Implementation.Validation;

namespace Implementation.Commands
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly ProductValidate _validations;
        private readonly DataAccess.DataContext _context;

        public UpdateProductCommand(ProductValidate validations, DataAccess.DataContext context)
        {
            _validations = validations;
            _context = context;
        }
        public string Name => throw new NotImplementedException();

        public void Execute(ProductDto request, int id)
        {
            _validations.ValidateAndThrow(request);

            var product = _context.Products.Find(id);

            if(product == null)
            {
                throw new ModelNotFound();
            }

            product.IsAir = request.IsAir;
            product.Name = request.Name;
            product.Kb = request.Kb;
            product.Km = request.Km;
            product.Ks = request.Km;
            product.Made = request.Made;
            product.TypeProductId = request.TypeProductId;

            _context.SaveChanges();

        }
    }
}
