using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        ICollection<string> AllowUseCases { get;  }
    }
}
