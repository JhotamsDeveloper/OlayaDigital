using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebOlayaDigital.Interfaces;

namespace WebOlayaDigital.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IPostService _postService;
        public AdminController(ILogger<AdminController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [Route("Administrador")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
