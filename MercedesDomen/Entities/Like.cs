using System;
using System.Collections.Generic;
using System.Text;

namespace MercedesDomen.Entities
{
    public class Like : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
