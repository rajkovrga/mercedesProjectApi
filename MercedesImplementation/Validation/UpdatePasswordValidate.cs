using Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Validations
{
    public class UpdatePasswordValidate : AbstractValidator<UserDto>
    {
        public UpdatePasswordValidate()
        {
            RuleFor(x => x.Password)
              .NotEmpty()
              .WithMessage("Lozinka je obavezna")
              .DependentRules(() =>
              {
                  RuleFor(x => x.Password)
                   .MinimumLength(8)
                    .WithMessage("Lozinka mora biti duza od 8 karaktera");
              });
            

        }
    }
}
