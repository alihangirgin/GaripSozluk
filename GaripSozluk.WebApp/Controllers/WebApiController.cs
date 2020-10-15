using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GaripSozluk.WebApp.Controllers
{
    public class WebApiController : Controller
    {

        private readonly IRestSharpService _restSharpService;
        private readonly ILogger<WebApiController> _logger;

        public WebApiController(ILogger<WebApiController> logger, IRestSharpService restSharpService)
        {
            _logger = logger;
            _restSharpService = restSharpService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WebApiSearch(string authorName= "J.R.R. Tolkien")
        {
            _restSharpService.Search(authorName);
            return View();
        }
    }
}
