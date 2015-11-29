using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace System_OPL.Models
{
    public class OplContext : DbContext
    {
        public OplContext()
            : base("OPLConnection")
        {
        }

        public DbSet<Doctor> Doctors { get; set;}
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Infant> Infants { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }
        public DbSet<Supply> Supplies { get; set; }
    }
}