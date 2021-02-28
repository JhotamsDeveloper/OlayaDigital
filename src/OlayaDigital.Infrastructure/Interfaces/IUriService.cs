using OlayaDigital.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actioUrl);
    }
}
