using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace System_OPL.Models
{

    public class Patient
    {
        public Patient()
        {
            this.Infants = new HashSet<Infant>();
            this.Tests = new HashSet<Test>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ContactDataId { get; set; }
        public int HealthStatusId { get; set; }
        public int DoctorId { get; set; }

        public virtual ContactData ContactData { get; set; }
        public virtual HealthStatus HealthStatus { get; set; }
        public virtual Doctor Doctors { get; set; }
        public virtual ICollection<Infant> Infants { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }

    //public class PatientMetaData
    //{
    //    [Required(ErrorMessage = "Imię jest wymagane.")]
    //    [Display(Name = "Imię")]
    //    public string Name { get; set; }

    //    [Required(ErrorMessage = "Nazwisko jest wymagane.")]
    //    [Display(Name = "Nazwisko")]
    //    public string Surname { get; set; }

    //    [Required(ErrorMessage = "Dane kontaktowe są wymagane.")]
    //    [Display(Name = "Dane kontaktowe")]
    //    public string ContactData { get; set; }

    //    [Required(ErrorMessage = "Stan zdrowia jest wymagany.")]
    //    [Display(Name = "Stan zdrowia")]
    //    public string HealthStatus { get; set; }

    //    [Required(ErrorMessage = "Lekarz prowadzący jest wymagany.")]
    //    [Display(Name = "Lekarz prowadzący")]
    //    public int DoctorId { get; set; }

    //    [Display(Name = "Lekarz prowadzący")]
    //    public virtual Doctor Doctors { get; set; }

    //}
}