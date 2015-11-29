using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace System_OPL.Models
{
    [MetadataType(typeof(WorkHourMetaData))]
    public class WorkHour                       //Istnieje kilka Name-typów WorkHour np. pierwsza lub druga zmiana. Ten typ jest przypisywany do lekarza zamiast niestandardowych godzin. 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartHour { get; set; }   //Spore uproszczenie. Każde badanie trwa godzinę więc nie stanowi to problemu.
        public int StopHour { get; set; }
    }

    public class WorkHourMetaData
    {

    }
}