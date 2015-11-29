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
    public class InfantController : BaseController
    {
        //
        // GET: /Infant/

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Infant model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool jestTakaMatka=true;     //TODO warunek który nie wpuści do ifa jeśli podano nieistniejące Id 
                    if (jestTakaMatka)
                    {
                        context.Infants.Add(model);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nie istnieje matka o podanym Id.");
                    }
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", "Rejestracja noworodka nie powiodła się.");
                }
            }

            return View(model);
        }

        [Authorize]
        public ActionResult List()
        {
            IQueryable<Infant> infants;          
                         
                infants = context.Infants;           

            return View(infants);
        }

    }
}
