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
        private readonly IRestSharpService _restSharpService;
        private readonly IPostCategoryService _postCategoryService;
        private readonly IEntryService _entryService;
        private readonly IAccountService _accountService;

        public HomeController(ILogger<PostController> logger, IPostService postService, IPostCategoryService postCategoryService, IEntryService entryService, IAccountService accountService, IRestSharpService restSharpService)
        {
            _logger = logger;
            _postService = postService;
            _postCategoryService = postCategoryService;
            _entryService = entryService;
            _accountService = accountService;
            _restSharpService = restSharpService;
        }

        public IActionResult Index(string post="fasulye",int selectPageNumber=1, SearchViewModel searchModel = null)
        {

            var category = _postService.GetCategoryByPostString(post);           

            ViewBag.query = _postService.GetAllCount(category); //kategori id'ye göre bütün postları ve bütün entryleri getirir

            ViewBag.querySelectedPost = _postService.Get(x => x.NormalizedTitle == post);//postid ye göre tek post getirir
            ViewBag.queryCategory = _postCategoryService.GetAll();  //bütün kategorileri getirir
            ViewBag.querySelectedCategory = _postCategoryService.Get(x => x.NormalizedTitle == category); //kategori id'ye göre tek kategori getiir

            ViewBag.queryGetCurrentUserInfo = _accountService.GetUserInfos();
            ViewBag.NormalizedTitle = category;


            if (category == "Kitap" || category == "Yazar")
            {
                var title = _postService.GetTitleByNormalized(post);
                var queryPostApi = _restSharpService.SearchPostApi(title);
                var postListVM = new PostListVM();
                foreach (var item in queryPostApi.docs)
                {
                    var getEntry = new EntryRowVM();
                    getEntry.Content = item.title;
                    getEntry.UserId = 0;
                    getEntry.CreateDate = DateTime.Now;
                    getEntry.EntryId = 0;
                    getEntry.UserName = item.author_name?.FirstOrDefault().ToString();
                    getEntry.LikeCount = 0;
                    getEntry.DislikeCount = 0;
                    postListVM.EntryList.Add(getEntry);
                }
                return View(postListVM);
            }
            else
            {
                return View(_postService.GetPostById(post, selectPageNumber));
            }
            

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


        [HttpPost]
        public IActionResult GetPosts(string category)
        {
            ViewBag.querySelectedCategory = _postCategoryService.Get(x => x.NormalizedTitle == category); //kategori id'ye göre tek kategori getiir
            var model = _postService.GetPostByCategoryString(category);
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
