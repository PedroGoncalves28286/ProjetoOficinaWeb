using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }

        public string AppointmentId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Subject { get; set; } 

       

    }
}
