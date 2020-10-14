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
using Microsoft.AspNetCore.Authorization;

namespace GaripSozluk.WebApp.Controllers
{
    public class EntryController : Controller
    {
        private readonly IEntryService _entryService;
        private readonly IEntryRatingService _entryRatingService;
        private readonly ILogger<EntryController> _logger;
        private readonly UserManager<User> _userManager;



        public EntryController(ILogger<EntryController> logger, IEntryService entryService,IEntryRatingService entryRatingService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _entryService = entryService;
            _entryRatingService = entryRatingService;
        }


        public IActionResult Index()
        {
            ViewBag.query = _entryService.GetAll();

            return View();

        }






        [Authorize]
        public IActionResult Like(EntryRatingViewModel model, int entryLikeId, int postId)
        {
            var UserId = 0;
            var user = HttpContext.User;
            var dbUser = _userManager.GetUserAsync(user).Result;

            UserId = dbUser.Id;


            if (ModelState.IsValid)
            {
                model.EntryId = entryLikeId;
                model.UserId = UserId;
                _entryRatingService.AddLike(model);
            }
              return RedirectToAction(nameof(HomeController.Index), "Home", new { id=postId });

        }
        [Authorize]
        public IActionResult Dislike(EntryRatingViewModel model, int entryDislikeId, int postId)
        {
            var UserId = 0;
            var user = HttpContext.User;
            var dbUser = _userManager.GetUserAsync(user).Result;

            UserId = dbUser.Id;


            if (ModelState.IsValid)
            {
                model.EntryId = entryDislikeId;
                model.UserId = UserId;
                _entryRatingService.AddDislike(model);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home", new { id = postId });

        }


        [HttpGet]
        public IActionResult AddEntry()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddEntryAsync(EntryViewModel model, int addEntryId)
        {
            var UserId = 0;
            var user = HttpContext.User;
            var dbUser = _userManager.GetUserAsync(user).Result;

            UserId = dbUser.Id;


            if (ModelState.IsValid)
            {
                model.Id = addEntryId;
                model.UserId = UserId;
                var entity = _entryService.AddEntry(model);
                if (entity.Id > 0)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kayıt başarısız");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateEntry(int id)
        {
            var model = _entryService.Get(x => x.Id == id);
            var entryViewModel = new EntryViewModel() { Id = model.Id, Content = model.Content };
            return View(entryViewModel);
        }

        [HttpPost]
        public IActionResult UpdateEntry(EntryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _entryService.UpdateEntry(model);
                if (entity.Id > 0)
                {
                    return RedirectToAction(nameof(EntryController.Index), "Entry");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kayıt başarısız");
                }
            }
            return View();
        }

        //public IActionResult DeleteEntry(int id)
        //{
        //    var model = _entryService.DeleteEntry(id);

        //    return View(entryViewModel);
        //}

        //[HttpPost]
        //public IActionResult UpdateEntry(EntryViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var entity = _entryService.UpdateEntry(model);
        //        if (entity.Id > 0)
        //        {
        //            return RedirectToAction(nameof(EntryController.Index), "Entry");
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
