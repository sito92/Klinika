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
    public class PatientController : BaseController
    {
        //
        // GET: /Patient/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/Register

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
        public ActionResult Register(Patient model)
        {
            if (ModelState.IsValid)
            {                
                try
                {
                    var doctor = context.Doctors.FirstOrDefault(x => x.UserName == WebSecurity.CurrentUserName);
                    model.DoctorId=doctor.Id;
                    context.Patients.Add(model);
                    context.SaveChanges();                   
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("","Rejestracja Pacjentki nie powiodła się.");
                }
            }
            
            return View(model);
        }

        [Authorize]
        public ActionResult List()
        {
            IQueryable<Patient> patients;
            if (Roles.IsUserInRole("Ordynator"))
            {
                patients = context.Patients;
            }
            else
            {
                var userId = WebSecurity.GetUserId(User.Identity.Name);
                patients = context.Patients.Where(x => x.DoctorId == userId);

            }

            return View(patients);
        }

       
            

    }
}
