using Application;
using Application.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Services
{
    public class CPLogger  : ILoggerService
    {
        public void Log(IApplicationActor actor, IUseCase useCase, object request)
        {
            Console.WriteLine($"Vreme: {DateTime.Now} ::: Korisnik {actor.Identity} je pokušao da {useCase.Name} sa prosledjenim podacima:" + $"{JsonConvert.SerializeObject(request)}");
        }
    }
}
