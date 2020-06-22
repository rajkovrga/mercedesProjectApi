using FluentValidation;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validation
{
    public class CommentValidate : AbstractValidator<CommentDto>
    {
        public CommentValidate()
        {
            RuleFor(x => x.CommentText)
                .NotEmpty()
                .WithMessage("Ne možete uneti prazan komentar")
                .DependentRules(() => {
                    RuleFor(x => x.CommentText)
                    .MinimumLength(10)
                    .WithMessage("Komentar mora imati više od 10 karaktera");
                });
        }
    }
}
