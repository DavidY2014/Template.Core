using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nba.Core.Common;
using Nba.Core.IService;
using Nba.Core.Models.Entites;
using Nba.Core.Models.Enums;

namespace Nba.Core.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login()
        {
            string username = Request.Form["username"].TryToString();
            string password = Request.Form["password"].TryToString();
            UserInfo user = _userService.UserLogin(username, password);
            if (user != null)
            {
                HttpContext.Session.SetString("user", JsonSerializerHelper.Serialize(user));
                return Json(new { code = 1, msg = "OK" });
            }
            return Json(new { code = 0, msg = "登录失败" });
        }


        [HttpPost]
        public IActionResult SignIn()
        {                
            string username = Request.Form["username"].TryToString();
            string password = Request.Form["password"].TryToString();
            string email = Request.Form["email"].TryToString();
            UserInfo newUserInfo = new UserInfo()
            {
                UserName=username,
                Email = email,
            };
            int userId = _userService.AddUser(newUserInfo, password);
            return Json(new { code = 1, msg = "注册成功" });
        }



        [HttpGet]
        public IActionResult LoginOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}