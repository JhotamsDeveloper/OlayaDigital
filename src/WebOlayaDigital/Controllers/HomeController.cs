using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebOlayaDigital.Interfaces;
using WebOlayaDigital.Models;

namespace WebOlayaDigital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsServices _newServices;
        private readonly IPostService _postService;
        public HomeController(ILogger<HomeController> logger,
            INewsServices newServices, IPostService postService)
        {
            _logger = logger;
            _newServices = newServices;
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomeModel model = new HomeModel();
            model.Article = await _newServices.TopNewsNational();
            model.Post = await _postService.TopPost();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
