using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GaripSozluk.WebApp.Controllers
{
    public class ApiPostController : Controller
    {

        private readonly IRestSharpService _restSharpService;

        public ApiPostController(ILogger<ApiPostController> logger, IRestSharpService restSharpService, IPostService postService)
        {
            _restSharpService = restSharpService;
        }
        
        public IActionResult GetPosts()
        {
            var result = _restSharpService.ApiGetPost();

            return View(result);
        }
    }
}
