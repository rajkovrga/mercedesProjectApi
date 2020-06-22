using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class SearchUserDto : PaginateSearchDto
    {
        public string SearchText { get; set; }
    }
}
