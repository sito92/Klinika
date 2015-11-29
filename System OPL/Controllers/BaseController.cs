using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System_OPL.Models;

namespace System_OPL.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/         
        protected OplContext context;
        public BaseController()
        {
            context = new OplContext();          
        }

    }
}
