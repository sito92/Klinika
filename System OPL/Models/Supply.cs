using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace System_OPL.Models
{
    [MetadataType(typeof(SupplyMetaData))]
    public class Supply
    {      
        public int Id { get; set; }
        public string Name { get; set; }
        public bool WOSP { get; set; }        
    }

    public class SupplyMetaData
    {
        [Display(Name = "Nazwa zasobu")]
        public string Name { get; set; }

        [Display(Name = "Sfinansowane przez WOSP")]
        public bool WOSP { get; set; }   

    }
}