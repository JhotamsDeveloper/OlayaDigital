using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebOlayaDigital.Interfaces;
using WebOlayaDigital.Models;

namespace WebOlayaDigital.Services
{
    public class NewsServices : INewsServices
    {
        #region "Field"
        private readonly IConfiguration _configuration;
        #endregion
        public NewsServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Article>> TopNewsNational()
        {
            Uri _getUrlNewNoticeNationals = new Uri($"{_configuration.GetValue<string>("GetAllApis:NewsAPI")}");
            var _httpClient = new HttpClient();
            var _json = await _httpClient.GetStringAsync(_getUrlNewNoticeNationals);

            IEnumerable<Article> article = JsonConvert.DeserializeObject<IEnumerable<Article>>(_json);
            return article;

        }
    }
}
