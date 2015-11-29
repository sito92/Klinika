using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System_OPL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(!Request.IsAuthenticated)
            {
                ViewBag.Message = "Witaj Niezalogowany";
                return View();
            }
            else
            {
                ViewBag.Message = User.Identity.Name ;
                return View();
            }
        }       
    }
}
