using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Exceptions;

namespace Application
{
    public static class ApiExtensions
    {
        public static bool Can(this IApplicationActor actor, string action)
        {
            if(!actor.AllowUseCases.Contains(action))
            {
                return false;
            }
            return true;
        }
    }
}
