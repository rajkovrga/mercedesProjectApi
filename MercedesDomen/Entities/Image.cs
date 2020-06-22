using System;
using System.Collections.Generic;
using System.Text;

namespace Domen.Entities
{
    public class Image : Entity
    {
        public string Url { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();

    }
}
