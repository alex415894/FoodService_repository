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
            //ViewBag.Message = "Your application description page.";

            return View();
        }


        [Authorize(Roles = "admin")]
        public ActionResult UserData()
        {
            
            return View();
        }
    }
}