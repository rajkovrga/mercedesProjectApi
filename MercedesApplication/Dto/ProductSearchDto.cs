using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ProductSearchDto : PaginateSearchDto
    {
        public string Name { get; set; }
        public bool? IsAir { get; set; }
        public decimal KmMin { get; set; }
        public decimal KmMax { get; set; }
        public List<int> TypeProductIds { get; set; }
        public decimal KbMax { get; set; }
        public decimal KbMin { get; set; }
        public decimal KsMax { get; set; }
        public decimal KsMin { get; set; }
        public string MadeMin { get; set; }
        public string MadeMax { get; set; }

    }
}
