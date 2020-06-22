using Domen.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ProductResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeProductName { get; set; }
        public int TypeProductId { get; set; }
        public bool IsAir { get; set; }
        public decimal Km { get; set; }
        public decimal Kb { get; set; }
        public decimal Ks { get; set; }
        public string Made { get; set; }
        public int NumberLikes { get; set; }
        public int NumberComments { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
