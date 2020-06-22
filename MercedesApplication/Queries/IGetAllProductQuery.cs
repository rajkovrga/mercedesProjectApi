using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetAllProductQuery<T> : IQuery<ProductSearchDto, ResultPaginationDto<T>>
    {
    }
}
