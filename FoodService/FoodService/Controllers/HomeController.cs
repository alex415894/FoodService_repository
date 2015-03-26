using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using Microsoft.AspNet.Identity;

namespace FoodService.Controllers
{
    public class HomeController : Controller
    {
          // [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }


        [Authorize(Roles = "admin")]
        public ActionResult UserData()
        {
            //HttpContext.Current.User.Identity.Name; фильтр для текущ польз
            var userName = User.Identity.Name;
            var userId = User.Identity.GetUserId();
            var principal = Thread.CurrentPrincipal;
            var _userId = principal.Identity.GetUserId();
            ViewBag.Message = userName;
            ViewBag.Message2 = userId;
            ViewBag.Message3 = _userId;
            return View();
        }
    }
}