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
    public class LogController : Controller
    {
        private readonly ILogService _logService;


        public LogController(ILogger<PostController> logger, ILogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {

            var log=_logService.GetAll();
            return View(log);
        }

        [HttpPost]
        public IActionResult Index(LogViewModel model=null)
        {

           var log= _logService.GetAll(model);
            return View(log);

        }


    }
}
