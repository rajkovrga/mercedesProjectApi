using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using FluentValidation;
using Application;
using Application.Commands;
using Application.Dto;
using Domen;
using Implementation.Validation;

namespace Implementation.Commands
{
    public class CreateProductCommand : ICreateProductCommand
    {
        private readonly Validation.ProductValidate _validations;
        private readonly DataAccess.DataContext _context;

        public CreateProductCommand(ProductValidate validations, DataAccess.DataContext context)
        {
            _validations = validations;
            _context = context;
        }

        public string Name => "Create product";

        public void Execute(ProductDto dto)
        {
            _validations.ValidateAndThrow(dto);

            var newProduct = new Product();

            newProduct.IsAir = dto.IsAir;
            newProduct.Name = dto.Name;
            newProduct.Kb = dto.Kb;
            newProduct.Km = dto.Km;
            newProduct.Ks = dto.Km;
            newProduct.Made = dto.Made;
            newProduct.TypeProductId = dto.TypeProductId;

            _context.Add(newProduct);

            _context.SaveChanges();
            

        }
    }
}

