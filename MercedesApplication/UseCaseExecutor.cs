using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using MercedesApplication.Exceptions;

namespace MercedesApplication
{
    public class UseCaseExecutor
    {
        public UseCaseExecutor(IApplicationActor actor)
        {
            this.actor = actor;
        }

        public IApplicationActor actor { get; set; }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {

            Console.WriteLine($"Vreme: {DateTime.Now} ::: Korisnik {actor.Identity} je pokušao da {command.Name} sa prosledjenim podacima:" + $"{JsonConvert.SerializeObject(request)}");
        }

        
    }
}
