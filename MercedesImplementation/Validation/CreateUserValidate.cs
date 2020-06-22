using System;
using System.Linq;
using Application.Dto;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace Implementation.Validation
{
    public class CreateUserValidate : AbstractValidator<UserDto>
    {
        private readonly DataContext _context;

        public CreateUserValidate(DataContext context)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email je obavezan")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Email)
                     .EmailAddress()
                    .WithMessage("Email nije u dobrom formatu")
                    .DependentRules(() => {
                        RuleFor(x => x.Email)
                        .Must(x => !context.Users.Any(y => y.Email == x))
                        .WithMessage("Unet email je zauzet");
                    });
                });

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Lozinka je obavezna")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Password)
                    .MinimumLength(8)
                    .WithMessage("Lozinka mora biti duza od 8 karaktera");
                });


            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Korisničko ime je obavezno")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Username)
                    .MinimumLength(8)
                    .WithMessage("Korisničko ime mora biti duže od 8 karaktera");
                });
            _context = context;
        }


    }
}
