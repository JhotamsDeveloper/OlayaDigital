using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebOlayaDigital.Models;

namespace WebOlayaDigital.Interfaces
{
    public interface INewsServices
    {
        Task<IEnumerable<Article>> TopNewsNational();
    }
}
