using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            ViewBag.PageTitle = "Discover your customers with enaging social commerce apps.";
            return View();
        }
        public ActionResult About()
        {
            ViewBag.PageTitle = "About. Your questions answered.";
            return View();
        }

        public ActionResult Services()
        {
            ViewBag.PageTitle = "Services.";
            return View();
        }
     
    }
}
