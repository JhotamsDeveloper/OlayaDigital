using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Core.QueryFilters
{
    public class PostQueryFilter
    {
        public int? IdUser { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
