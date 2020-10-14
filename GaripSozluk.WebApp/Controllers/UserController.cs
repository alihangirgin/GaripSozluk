using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GaripSozluk.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IBlockedUserService _blockedUserService;

        public UserController(IBlockedUserService blockedUserService)
        {
            _blockedUserService = blockedUserService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Block(UserBlockVM model,int blockUserId, int postId)
        {
            var user = HttpContext.User;
            var UserId = int.Parse(user.Claims.ToList().First(x=>x.Type==ClaimTypes.NameIdentifier).Value);

            if (ModelState.IsValid)
            {
                model.UserId = UserId;
                model.BlockedUserId = blockUserId;
            }

             _blockedUserService.AddBlock(model);

            return RedirectToAction(nameof(HomeController.Index), "Home", new { id = postId });

        }



        public IActionResult GetBlockedUsers(int blockCurrentUserId)
        {
            ViewBag.queryGetBlockedUser=_blockedUserService.GetAll(blockCurrentUserId);


            return View();
        }

        public IActionResult RemoveBlock(UserBlockVM model,int blockCurrentUserId, int blockBlockedUserId)
        {
            if (ModelState.IsValid)
            {
                model.UserId = blockCurrentUserId;
                model.BlockedUserId = blockBlockedUserId;
                //model.BlockedUserId
            }
            _blockedUserService.RemoveBlock(model);

            return RedirectToAction(nameof(UserController.GetBlockedUsers), "User", new { blockCurrentUserId = model.UserId });
        }

    }
}
