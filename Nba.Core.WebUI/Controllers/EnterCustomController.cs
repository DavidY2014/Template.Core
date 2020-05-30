using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nba.Core.WebUI.Filters;

namespace Nba.Core.WebUI.Controllers
{
    [UserLoginFilter]
    public class EnterCustomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}