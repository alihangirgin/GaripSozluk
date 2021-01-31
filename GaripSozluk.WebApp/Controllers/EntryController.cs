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


        //like entries
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

        //dislike entries
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

        //add entry get
        [HttpGet]
        public IActionResult AddEntry()
        {
            return View();
        }

        //add entry post
        [HttpPost]
        public IActionResult AddEntry(EntryViewModel model, int postId)
        {
            var UserId=0;
            var user = HttpContext.User;
            var dbUser = _userManager.GetUserAsync(user).Result;
            UserId = dbUser.Id;
            if (ModelState.IsValid)
            {
                model.PostId = postId;
                model.UserId = UserId;
                var entryEntity = _entryService.AddEntry(model);
                if (entryEntity.Id > 0)
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

        //update entry get
        [HttpGet]
        public IActionResult UpdateEntry(int Id)
        {
            var entry = _entryService.Get(x => x.Id == Id);
            var entryViewModel = new EntryViewModel();
            if (entry != null)
            {
                entryViewModel.Id = entry.Id;
                entryViewModel.Content = entry.Content;
            }
            return View(entryViewModel);
        }

        //update entry post
        [HttpPost]
        public IActionResult UpdateEntry(EntryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _entryService.UpdateEntry(model);
                if (entity.Id > 0)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home", new { id = model.PostId });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kayıt başarısız");
                }
            }
            return View();
        }

    }
}
