using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GamePackman.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamePackman.Controllers
{
    //[Route("Login")]
    public class LoginController : Controller
    {
        //ApplicationContext appContext = new ApplicationContext();
        UserDataAccessLayour objUser = new UserDataAccessLayour();
        //[Route("RegisterUser")]
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        //[Route("RegisterUser")]
        [HttpPost]
        public IActionResult RegisterUser([Bind] UserData user)
        {
            if (ModelState.IsValid)
            {
                string registrationStatus = objUser.RegisterUser(user);
                if (registrationStatus == "Success")
                {
                    ModelState.Clear();
                    TempData["Success"] = "Registration Successful!";
                    return View();
                }
                else
                {
                    TempData["Fail"] = "This User ID already exists. Registration Failed.";
                    return View();
                }
            }
            return View();
        }
        //[Route("UserLogin")]
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
        //[Route("Userlogin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin([Bind] UserData user)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");

            if (ModelState.IsValid)
            {
                string LoginStatus = objUser.ValidateLogin(user);

                if (LoginStatus == "Success")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserLogin)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("UserHome", "User");
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                    return View();
                }
            }
            else
                return View();

        }
        public IActionResult About()
        {
            return View();
        }
    }
}