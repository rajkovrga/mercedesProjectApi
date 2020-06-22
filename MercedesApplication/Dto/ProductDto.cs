using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int TypeProductId { get; set; }
        public bool IsAir { get; set; }
        public decimal Km { get; set; }
        public decimal Kb { get; set; }
        public decimal Ks { get; set; }
        public string Made { get; set; }
    }
}
