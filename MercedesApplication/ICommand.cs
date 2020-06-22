using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface ICommand
    {

    }
    public interface ICommand<TRequest> : IUseCase, ICommand
    {
        void Execute(TRequest request);
    }
    public interface ICommandWithId<TRequest> : IUseCase, ICommand
    {
        void Execute(TRequest request, int id);
    }

}
