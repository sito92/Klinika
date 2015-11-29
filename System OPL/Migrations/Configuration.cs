using System.Collections.Generic;
using System_OPL.Models;
using DotNetOpenAuth.Messaging;
using WebMatrix.WebData;

namespace System_OPL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<System_OPL.Models.OplContext>    
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OplContext context)
        {
            List<WorkHour> WorkHours = new List<WorkHour>()
            {
                new WorkHour()
                {                    
                    Name = "Pierwsza zmiana",
                    StartHour = 7,
                    StopHour = 14,
                }
            };
            WorkHours.ForEach(x => context.WorkHours.AddOrUpdate(x));
            context.SaveChanges();

            List<Doctor> Doctors = new List<Doctor>()
            {
                new Doctor()
                {
                    UserName ="Doktorek",
                    Name = "Damian",
                    Surname = "Szymański",
                    ContactData = "Lepiej się nie kontaktować",
                    OfficeNumber = 12,
                    WorkHourId=1,
         
                }
               
            };
            Doctors.ForEach(x => context.Doctors.AddOrUpdate(x));
            context.SaveChanges();
        }
    }
}