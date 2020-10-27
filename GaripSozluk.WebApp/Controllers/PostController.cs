using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GaripSozluk.WebApp.Models;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data;
using Microsoft.AspNetCore.Identity;
using GaripSozluk.Data.Domain;

namespace GaripSozluk.WebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IPostCategoryService _postCategoryService;
        private readonly ILogger<PostController> _logger;
        private readonly UserManager<User> _userManager;



        public PostController(ILogger<PostController> logger, IPostService postService, IPostCategoryService postCategoryService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _postService = postService;
            _postCategoryService = postCategoryService;
        }


        public IActionResult Index()
        {
            //ViewBag.query = _postService.GetAll();



            return View();

        }


        public IActionResult Random()
        {
            var randomId = _postService.GetRandomId();
            return Redirect(Url.Action("Index", "Home", new { category = "Kategori1", post = randomId }));
        }



        [HttpGet]
        public IActionResult AddPost(string category)
        {

            ViewBag.queryCategoryTwo = _postCategoryService.selectListItem(category);
            ViewBag.catagoryIdSelectItem = category;


            return View();
        }

        [HttpPost]
        public IActionResult AddPost(PostViewModel model)
        {
            var UserId = 0;
            var user = HttpContext.User;
            var dbUser = _userManager.GetUserAsync(user).Result;

            UserId = dbUser.Id;

            if (ModelState.IsValid)
            {

                model.UserId = UserId;
                var postId = _postService.AddPostsWithEntry(model);
                if (postId > 0)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home", new { category="Kategori1", post=postId });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kayıt başarısız");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdatePost(int id)
        {
            var model = _postService.Get(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdatePost(Post model)
        {
            if (ModelState.IsValid)
            {
                var entity = _postService.UpdatePost(model);
                if (entity.Id > 0)
                {
                    return RedirectToAction(nameof(PostController.Index), "Post");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kayıt başarısız");
                }
            }
            return View();
        }

        //public IActionResult DeletePost(int id)
        //{
        //    var model = _postService.DeletePost(id);

        //    return View(postViewModel);
        //}

        //[HttpPost]
        //public IActionResult UpdatePost(PostViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var entity = _postService.UpdatePost(model);
        //        if (entity.Id > 0)
        //        {
        //            return RedirectToAction(nameof(PostController.Index), "Post");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Kayıt başarısız");
        //        }
        //    }
        //    return View();
        //}




    }
}
