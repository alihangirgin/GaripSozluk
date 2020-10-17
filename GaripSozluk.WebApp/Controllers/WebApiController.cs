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
    public class WebApiController : Controller
    {

        private readonly IPostService _postService;
        private readonly IRestSharpService _restSharpService;
        private readonly ILogger<WebApiController> _logger;

        public WebApiController(ILogger<WebApiController> logger, IRestSharpService restSharpService, IPostService postService)
        {
            _logger = logger;
            _restSharpService = restSharpService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(RestApiSearchVM searchmodel = null)
        {
            searchmodel=_restSharpService.SearchApi(searchmodel);

            return View(searchmodel);
        }


        public IActionResult SearchFromPost(string itemTitle)
        {
           var queryPostApi = _restSharpService.SearchPostApi(itemTitle);

            return View(queryPostApi);
        }


        
        [HttpPost]
        public IActionResult AddFromApi(string[] ItemList)
        {
            _postService.AddPostFromArrayBook(ItemList);
            return Json(new { status = "success" });
        }








    }
}
