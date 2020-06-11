using System;
using System.Collections.Generic;
using System.Text;

namespace MercedesApplication.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException(IUseCase useCase, IApplicationActor actor) : base($"Korisnik {actor.Identity} je pokusao da {useCase.Name}")
        {
        }
    }
}
