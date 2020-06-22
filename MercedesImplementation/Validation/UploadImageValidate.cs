using Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validation
{
    public class UploadImageValidate : AbstractValidator<ImageDto>
    {
        public UploadImageValidate()
        {
            RuleFor(x => x.Image.Length).NotNull()
                .LessThanOrEqualTo(100)
                .WithMessage("Fajl je prevelik");

            RuleFor(x => x.Image.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("Ekstenzija nije dozvoljena");

            RuleFor(x => x.Id).NotNull().WithMessage("Nije odabran proizvod");

        }
    }
}
