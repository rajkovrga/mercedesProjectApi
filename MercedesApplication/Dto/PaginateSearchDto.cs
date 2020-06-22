using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class PaginateSearchDto
    {
        public int PerPage { get; set; } = 9;
        public int Page { get; set; } = 1;
    }
}
