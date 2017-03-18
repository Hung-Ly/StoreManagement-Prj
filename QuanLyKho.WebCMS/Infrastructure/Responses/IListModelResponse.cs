using System;
using System.Collections.Generic;

namespace QuanLyKho.WebCMS.Infrastructure.Responses
{
    public interface IListModelResponse<TModel> : IResponse
    {
        int PageSize { get; set; }

        int PageNumber { get; set; }

        int TotalPages { get; set; }

        IEnumerable<TModel> Model { get; set; }
    }
}
