using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Application.Exceptions;
using Application.Services;

namespace Application
{
    public class UseCaseExecutor
    {
        private IApplicationActor _actor;
        private readonly ILoggerService _logger;

        public UseCaseExecutor(IApplicationActor actor, ILoggerService logger)
        {
            this._actor = actor;
            _logger = logger;
        }


        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request, string action = null)
        {
            _logger.Log(_actor, command, request);
            if(action != null && !_actor.Can(action))
            {
                throw new ForbiddenException(command, _actor);
            }

            command.Execute(request);
        }

        public void ExecuteCommandWithId<TRequest>(
            ICommandWithId<TRequest> command,
            TRequest request, int id, string action = null)
        {
            _logger.Log(_actor, command, request);
            if (action != null && !_actor.Can(action))
            {
                throw new ForbiddenException(command, _actor);
            }

            command.Execute(request, id);
        }

        public TResult ExecuteQuery<TSearch, TResult>(
                IQuery<TSearch, TResult> query,
                TSearch search, string action = null
            )
        {
            _logger.Log(_actor, query, search);
            if (action != null)
            {
                if(!_actor.Can(action))
                {
                    throw new ForbiddenException(query, _actor);
                }
            }
            return query.Execute(search);
        }

        
    }
}
