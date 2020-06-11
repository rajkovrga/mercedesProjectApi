using System;
using System.Collections.Generic;
using System.Text;

namespace MercedesApplication
{
    public interface IApplicationActor
    {
        public int Id { get;  }
        public string Identity { get; set; }
        public ICollection<int> AllowUseCases { get; }
    }
}
