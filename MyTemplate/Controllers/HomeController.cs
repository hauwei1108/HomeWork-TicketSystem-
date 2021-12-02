using ApplicationCore.Commons.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyTemplateWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userAct)
        {
            //檢查是否空值
            if (string.IsNullOrEmpty(userAct))
            {
                return View();
            }

            //設定測試Cookie
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            };

            //設定帳號 和 識別碼
            Response.Cookies.Append(CookieConstants.CLIENT_USER_NAME, userAct, options);
            Response.Cookies.Append(CookieConstants.CLIENT_TICKET, Guid.NewGuid().ToString(), options);

            return Redirect("~/Index.html");
        }

    }
}

