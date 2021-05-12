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
    public class PostService : IPostService
    {
        #region "Field"
        private readonly IConfiguration _configuration;
        private readonly string getPostAPI = "GetAllApis:GetPost";
        #endregion
        public PostService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<GetPostWithTableRelation>> TopPost()
        {
            Uri _getPostAPI = new Uri($"{_configuration.GetValue<string>(getPostAPI)}");
            var _httpClient = new HttpClient();
            var _json = await _httpClient.GetStringAsync(_getPostAPI);

            GetPostWithTableRelation getPostWithTableRelation =
                new GetPostWithTableRelation();

            IEnumerable<GetPostWithTableRelation> _post = JsonConvert
                .DeserializeObject<IEnumerable<GetPostWithTableRelation>>(_json);

            return _post;
        }
    }
}
