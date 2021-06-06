using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebOlayaDigital.Models
{
    public class ResponsePOST
    {
        public string Msg { get; set; }
        public ICollection<GetPostWithTableRelation> Data { get; set; }
    }
}
