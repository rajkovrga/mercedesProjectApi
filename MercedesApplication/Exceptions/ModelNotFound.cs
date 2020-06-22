using Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ModelNotFound : Exception
    {
        public ModelNotFound() : base($"Model not found")
        {
        }
    }
}
