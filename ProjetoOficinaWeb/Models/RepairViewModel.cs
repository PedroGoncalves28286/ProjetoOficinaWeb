using ProjetoOficinaWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ProjetoOficinaWeb.Models
{
    public class RepairViewModel :Repair
    {

        public int Id { get; set; } 

        public String  Appointments { get; set; }


        [Display(Name = "Schedule date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime RepairDate { get; set; }

        public String  Services { get; set; }

        public String Vehicles { get; set; }

        public String Users { get; set; }
    }
}
