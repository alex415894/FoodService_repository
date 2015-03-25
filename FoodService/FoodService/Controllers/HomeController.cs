using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodService.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            

            return View();
        }


        [Authorize]
        public ActionResult Profile()
        {
            ViewBag.Message = User.Identity.Name;
            ViewBag.Message2 = User.Identity.AuthenticationType;
            ViewBag.Message3 = User.Identity.IsAuthenticated;
            return View();
        }
    }
}