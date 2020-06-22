using System;
using System.Collections.Generic;
using System.Text;

namespace Domen.Entities
{
    public class ProductImage : Entity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }

    }
}
