using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System_OPL.Models;
using WebMatrix.WebData;

namespace System_OPL
{
    public static class CreateRolesAndUsers
    {
        private static string AdminLogin = WebConfigurationManager.AppSettings["AdminLogin"];
        private static string AdminPassword = WebConfigurationManager.AppSettings["AdminPassword"];

        public static void CreateRolesAndUsersSeed()
        {
            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }

            if (!Roles.RoleExists("Doctor"))
            {
                Roles.CreateRole("Doctor");
            }

            if (!Roles.RoleExists("Nurse"))
            {
                Roles.CreateRole("Nurse");
            }


            if (!Roles.RoleExists("Ordynator"))
            {
                Roles.CreateRole("Ordynator");
            }


            List<Doctor> Doctors = new List<Doctor>()
            {
                new Doctor()
                {                    
                    Name = "Adam",
                    Surname = "Kowalski",
                    UserName = "akowalski",
                    ContactData = "Lepiej się nie kontaktować",
                    OfficeNumber = 12,
                    WorkHourId=1,
                }               
            };
            Doctors.ForEach(x =>
            {
                if (!WebSecurity.UserExists(x.UserName))
                {
                    WebSecurity.CreateUserAndAccount(x.UserName, "qwe",
                        new
                        {                           
                            Name = x.Name,
                            Surname = x.Surname,
                            UserName = x.UserName,
                            ContactData = x.ContactData,
                            OfficeNumber = x.OfficeNumber,
                            WorkHourId= x.WorkHourId,
                        });
                    Roles.AddUserToRole(x.UserName, "Doctor");
                }

            });
        
        }
    }
}