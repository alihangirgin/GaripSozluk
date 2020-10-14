using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GaripSozluk.WebApp.Models;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Data.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data;

namespace GaripSozluk.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;
        private readonly IPostCategoryService _postCategoryService;
        private readonly IEntryService _entryService;
        private readonly IAccountService _accountService;

        public HomeController(ILogger<PostController> logger, IPostService postService, IPostCategoryService postCategoryService, IEntryService entryService, IAccountService accountService)
        {
            _logger = logger;
            _postService = postService;
            _postCategoryService = postCategoryService;
            _entryService = entryService;
            _accountService = accountService;
        }

        public IActionResult Index(int postCategoryId=1, int Id=2 ,int selectPageNumber=1, SearchViewModel searchModel = null)
        {
            ViewBag.query = _postService.GetAllCount(postCategoryId); //kategori id'ye göre bütün postları ve bütün entryleri getirir
          
            ViewBag.querySelectedPost = _postService.Get(x => x.Id == Id);//postid ye göre tek post getirir
            ViewBag.queryCategory = _postCategoryService.GetAll();  //bütün kategorileri getirir
            ViewBag.querySelectedCategory = _postCategoryService.Get(x => x.Id == postCategoryId); //kategori id'ye göre tek kategori getiir

            ViewBag.queryGetCurrentUserInfo = _accountService.GetUserInfos();
            ViewBag.postCategoryId= postCategoryId;

            return View(_postService.GetPostById(Id, selectPageNumber));

        }
        [HttpPost]
        public IActionResult Index()
        {
            //var querySelectByString = _postService.GetAllByString(searchModel.searchText);
            return View();
        }

        [HttpPost]
        public IActionResult SearchResult(SearchViewModel searchModel = null)
        {
            ViewBag.querySelectByString = _postService.GetAllByString(searchModel.searchText);
            return View();
        }


        public IActionResult DetailedSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DetailedSearch(DetailedSearchViewModel searchmodel=null)
        {
            ViewBag.queryDetailedSelect = _postService.GetAllDetailed(searchmodel);

            return View();
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
