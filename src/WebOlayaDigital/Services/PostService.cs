using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebOlayaDigital.Services
{
    public class PostService
    {
        #region "Field"
        private readonly IConfiguration _configuration;
        private readonly string getPostAPI = "GetAllApis:NewsAPI";
        #endregion
        public PostService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> TopPost()
        {
            Uri _getPostAPI = new Uri($"{_configuration.GetValue<string>(getPostAPI)}");
            var _httpClient = new HttpClient();
            var _json = await _httpClient.GetStringAsync(_getPostAPI);

            //IEnumerable<Article> article = JsonConvert.DeserializeObject<IEnumerable<Article>>(_json);
            //return article;
            return "HOLA";
        }
    }
}
