using DataAccess;
using FluentValidation;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Implementation.Validation
{
    public class ProductValidate : AbstractValidator<ProductDto>
    {
        public ProductValidate(DataContext context)
        {
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Obavezan naziv proizvoda")
                .DependentRules(() => {
                    RuleFor(x => x.Name).MinimumLength(6)
                    .WithMessage("Naziv mora biti duži od 6 karaktera");
                });
            

            RuleFor(x => x.Made)
                .NotEmpty()
                .WithMessage("Obavezna godina proizvodnje");

            RuleFor(x => x.IsAir)
                .NotEmpty()
                .WithMessage("Obavezan unos klime");

            RuleFor(x => x.Km)
                .NotEmpty()
                .WithMessage("Unos predjenih km obavezan")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Km)
                    .GreaterThan(0)
                    .WithMessage("Predjeni kilometri nisu u dobrom formatu")
                    .DependentRules(() => {
                        RuleFor(x => x.Km)
                        .LessThan(1000000)
                        .WithMessage("Predjeni kilometri nisu u dobrom formatu");
                    });
                });

            RuleFor(x => x.Kb)
                .NotEmpty()
                .WithMessage("Unos kubikaže obavezan")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Kb)
                    .GreaterThan(100000)
                    .WithMessage("Kubikaža nije u dobrom formatu")
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.Kb)
                        .LessThan(700000)
                        .WithMessage("Kubikaža nije u dobrom formatu");
                    });
                });



            RuleFor(x => x.Ks)
                .NotEmpty()
                .WithMessage("Unos konjskih snaga obavezan")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Ks)
                    .GreaterThan(25)
                    .WithMessage("Konjske snage nisu u dobrom formatu")
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.Ks)
                        .LessThan(2000)
                        .WithMessage("Konjske snage nisu u dobrom formatu");
                    });
                });
               

            RuleFor(x => x.TypeProductId)
                .NotEmpty()
                .WithMessage("Obavezan unos tipa vozila")
                .DependentRules(() =>
                {
                    RuleFor(x => x.TypeProductId)
                    .Must(x => context.ProductTypes.Any(y => y.Id == x))
                    .WithMessage("Ne postoji ovaj tip vozila u bazi");
                });
                
        }
    }
}
