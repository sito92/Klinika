using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace System_OPL.Models
{
    [MetadataType(typeof(InfantMetaData))]
    public class Infant
    {
        public int Id { get; set; }   
        public string HealthStatus { get; set; }
        public int MotherId { get; set; }

        public virtual Patient Mother { get; set; }    
       
    }

    public class InfantMetaData
    {     
        [Required(ErrorMessage = "Numer pokoju jest wymagany.")]
        [Display(Name = "Stan zdrowia")]
        public string HealthStatus { get; set; }

        [Required(ErrorMessage = "Id matki jest wymagane.")]
        [Display(Name = "Id matki")]
        public int MotherId { get; set; }

        [Display(Name = "Matka")]
        public virtual Patient Mother { get; set; }    

    }
}