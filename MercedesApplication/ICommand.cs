using System;
using System.Collections.Generic;
using System.Text;

namespace MercedesApplication
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

}
