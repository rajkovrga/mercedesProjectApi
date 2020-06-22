using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface ILoggerService
    {
        void Log(IApplicationActor actor, IUseCase useCase, object request);
    }
}
