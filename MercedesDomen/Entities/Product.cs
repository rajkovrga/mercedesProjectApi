using Domen.Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace Domen
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public ProductType TypeProduct { get; set; }
        public int TypeProductId { get; set; }
        public bool IsAir { get; set; }
        public decimal Km { get; set; }
        public decimal Kb { get; set; }
        public decimal Ks { get; set; }
        public string Made { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();
        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
