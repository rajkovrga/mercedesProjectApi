using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercedesApplication;

namespace Api.Core
{
    public static class ApiExtensions
    {
        public static bool Can(this IApplicationActor actor)
        {
            
            return true;
        }
    }
}
