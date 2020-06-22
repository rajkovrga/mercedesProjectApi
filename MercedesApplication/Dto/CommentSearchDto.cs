using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class CommentSearchDto : PaginateSearchDto
    {
        public int ProductId { get; set; }
        
    }
}
