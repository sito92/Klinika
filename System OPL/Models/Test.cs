using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace System_OPL.Models
{
    [MetadataType(typeof(TestMetaData))]
    public class Test
    {
        public Test()
        {
            this.Supplies = new HashSet<Supply>();            
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }        //Dzien badania
        public DateTime StartHour { get; set; }   // Godzina rozpoczęcia badania. Każde badanie dla uproszczenia trwa godzinę       
        public int ObjectId { get; set; }
        public int DoctorId { get; set; }
        public int NurseId { get; set; }

        public virtual Patient Object { get; set; }        
        public virtual Doctor Doctors { get; set; }
        public virtual Nurse Nurses { get; set; }        
        public virtual ICollection<Supply> Supplies { get; set; }
    }

    public class TestMetaData
    {    
        [Required(ErrorMessage="Typ jest wymagany.")]
        [Display(Name="Rodzaj badania")]
        public string Type { get; set; }

        [Required(ErrorMessage="Data badania jest wymagana.")]
        [DataType(DataType.Date)]
        [Display(Name="Data badania")]
        public DateTime Date { get; set; }  
        
        [Required(ErrorMessage="Godzina rozpoczęcia badania wymagane.")]
        [DataType(DataType.Time)]        
        [Display(Name="Godzina rozpoczęcia badania")]
        public DateTime StartHour { get; set; } 
        
        [Required(ErrorMessage="Pacjent jest wymagany.")]
        [Display(Name="Pacjent")]     
        public int ObjectId { get; set; }    
                
        [Display(Name="Pielęgniarka pomocniczka")]
        public int NurseId { get; set; }

        [Display(Name = "Pacjent")]
        public virtual Patient Object { get; set; }

        [Display(Name = "Lekarz")]
        public virtual Doctor Doctors { get; set; }

        [Display(Name = "Pielęgniarka pomocniczka")]
        public virtual Nurse Nurses { get; set; }

        [Display(Name = "Wykorzystywane zasoby")]
        public virtual ICollection<Supply> Supplies { get; set; }


    }
}