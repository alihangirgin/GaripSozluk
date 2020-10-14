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

namespace GaripSozluk.WebApp.Controllers
{
    public class PostCategoryController : Controller
    {
        private readonly ILogger<PostCategoryController> _logger;
        private readonly IPostCategoryService _postCategoryService;

        public PostCategoryController(ILogger<PostCategoryController> logger, IPostCategoryService postCategoryService)
        {
            _logger = logger;
            _postCategoryService = postCategoryService;
        }


        public IActionResult Index()
        {
            ViewBag.queryCategory = _postCategoryService.GetAll();

            return View();

        }



        [HttpGet]
        public IActionResult AddPostCategory()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddPostCategory(PostCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _postCategoryService.AddPostCategory(model);
                if (entity.Id > 0)
                {
                    return RedirectToAction(nameof(PostCategoryController.Index), "PostCategory");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kayıt başarısız");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdatePostCategory(int id)
        {
            var model = _postCategoryService.Get(x => x.Id == id);
            var postCategoryViewModel = new PostCategoryViewModel() { Id = model.Id, Title = model.Title };
            return View(postCategoryViewModel);
        }

        [HttpPost]
        public IActionResult UpdatePostCategory(PostCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _postCategoryService.UpdatePostCategory(model);
                if (entity.Id > 0)
                {
                    return RedirectToAction(nameof(PostCategoryController.Index), "PostCategory");
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
