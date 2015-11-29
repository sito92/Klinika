using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using System_OPL.Models;
using System_OPL.Controllers;
using System.ComponentModel.DataAnnotations;

namespace System_OPL
{
    public class SupplyController : BaseController
    {
        //
        // GET: /Supply/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult List()
        {
              IQueryable<Supply> supplies;
              supplies = context.Supplies;    
              return View(supplies);
        }

    }
}
