using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class Repair : IEntity
    {
        public int Id { get; set; }

        public string  Vehicle { get; set; }


        
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }

        public string Service { get; set; }

        public string ServiceId { get; set; }

        public DateTime Appointment { get; set; }

        public string AppointmentId { get; set; }
        
        public string Mechanic { get; set; }

        public User User { get; set; }
    }
}
