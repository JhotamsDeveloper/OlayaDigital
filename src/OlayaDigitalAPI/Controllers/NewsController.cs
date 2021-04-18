using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlayaDigitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public NewsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<Article>> National()
        {
            var apiKey = _configuration.GetValue<string>("NewsAPI:apiKey");

            var newsApiClient = new NewsApiClient(apiKey);

            var articlesResponseAsync = newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
            {
                Country = Countries.CO,
                Language = Languages.ES,
                Category = Categories.Science,
                PageSize = 12,
            });

            var articlesResult = await articlesResponseAsync;

            List<Article> listNewsNational = new List<Article>();

            foreach (var item in articlesResult.Articles)
            {
                Article article = new Article();
                //article.Source = item.Source;
                article.Author = item.Author;
                article.Title = item.Title;
                article.Description = item.Description;
                article.Url = item.Url;
                article.UrlToImage = item.UrlToImage;
                article.PublishedAt = item.PublishedAt;
                article.Content = item.Content;

                listNewsNational.Add(article);
            }
            return listNewsNational;
        }
    }
}