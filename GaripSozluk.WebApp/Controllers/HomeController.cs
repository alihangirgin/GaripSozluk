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

        //main screen-returns the selected post in the selected category with entries to the index page, and also get data to viewbags to pass layout
        public IActionResult Index(int postCategoryId=1, int postId = 2 ,int selectPageNumber=1)
        {
            ViewBag.UserInfo = _accountService.GetUserInfos();
            ViewBag.SelectedCategory = _postCategoryService.GetSelectedCategory(x => x.Id == postCategoryId);
            ViewBag.CategoryList = _postCategoryService.GetAllCategories();
            ViewBag.PostList = _postService.GetPostListByCategoryWithEntries(postCategoryId);
            ViewBag.postCategoryId = postCategoryId;

            var postWithEntriesViewModel = new PostWithEntriesWithPaginationViewModel();
            postWithEntriesViewModel = _postService.GetSelectedPostWithEntries(postId, selectPageNumber);
            return View(postWithEntriesViewModel);
        }

    }
}
