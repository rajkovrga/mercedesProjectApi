using Application.Commands;
using Application.Dto;
using Application.Exceptions;
using FluentValidation;
using Implementation.Validation;
using Domen.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Implementation.Commands
{
    public class UploadProductPhotoCommand : IUploadProductPhotoCommand
    {
        private readonly UploadImageValidate _validations;
        private readonly DataAccess.DataContext _context;

        public UploadProductPhotoCommand(UploadImageValidate validations, DataAccess.DataContext context)
        {
            _validations = validations;
            _context = context;
        }

        public string Name => "Upload photo";

        public void Execute(ImageDto request)
        {
            _validations.ValidateAndThrowAsync(request);

            var product = _context.Products.Find(request.Id);

            if(product == null)
            {
                throw new ModelNotFound();
            }

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);

            var path = Path.Combine("wwwroot", "images", guid + extension);

            using(var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }

            product.ProductImages.Add(new ProductImage {
                Image = new Image { Url = guid + extension}
            });

            _context.SaveChanges();

        }
    }
}
