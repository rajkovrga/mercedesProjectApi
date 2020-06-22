using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domen.Entities
{
    public class ProductType : Entity
    {
        public string Name { get; set; }
        public ICollection<ProductImage> Products { get; set; } = new HashSet<ProductImage>();
    }
}
