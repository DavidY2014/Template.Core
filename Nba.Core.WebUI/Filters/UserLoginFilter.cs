﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Nba.Core.WebUI.Filters
{
    public class UserLoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.Keys.Contains("user"))
            {
                context.Result = new RedirectResult("/Account/Index");
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
