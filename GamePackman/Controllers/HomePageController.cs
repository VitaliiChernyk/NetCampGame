using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GamePackman.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamePackman.Controllers
{
    [Route("home")]
    public class HomePageController : Controller
    {
        [Route("index")]
        [Route("/")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginData loginData)
        {
            return RedirectToAction("Game");
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Game")]
        //[Authorization()]
        public IActionResult Game()
        {
            return View();
        }
    }
}