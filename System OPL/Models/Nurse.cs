using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace System_OPL.Models
{
    [MetadataType(typeof(NurseMetaData))]
    public class Nurse
    {
        public Nurse()
        {           
            this.Tests = new HashSet<Test>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactData { get; set; }
        public int OfficeNumber { get; set; }
        public int WorkHourId { get; set; }

        public virtual WorkHour WorkHours { get; set; }      
        public virtual ICollection<Test> Tests { get; set; }
    }

    public class NurseMetaData
    {
        [Required(ErrorMessage = "Imię jest wymagane.")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwa użytkownika jest wymagane.")]
        [Display(Name = "Nazwa uzytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Dane kontaktowe są wymagane.")]
        [Display(Name = "Dane kontaktowe")]
        public string ContactData { get; set; }

        [Required(ErrorMessage = "Numer pokoju jest wymagany.")]
        [Display(Name = "Numer pokoju")]
        public int OfficeNumber { get; set; }

        [Display(Name = "Godziny pracy")]
        public int WorkHourId { get; set; }

    }
}