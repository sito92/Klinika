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


namespace System_OPL.Controllers
{
    public class TestController : BaseController
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult List()
        {
            IQueryable<Test> tests;
            if (Roles.IsUserInRole("Ordynator"))
            {
                tests = context.Tests;
            }
            else
            {
                var userId = WebSecurity.GetUserId(User.Identity.Name);
                tests = context.Tests.Where(x => x.DoctorId == userId);

            }

            return View(tests);
        }

        //TODO Dodawanie badania + Widok
        //TODO Usuwanie badania + Widok
        //TODO Edytowanie badania + Widok

    }
}
