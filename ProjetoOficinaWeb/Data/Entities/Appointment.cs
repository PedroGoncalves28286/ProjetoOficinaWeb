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

        public User User { get; set; }

        [Display(Name = "Order date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime? AppointmentDateLocal =>
        #pragma warning disable CS8073
           this.Date == null
         #pragma warning restore CS8073
           ? null
          : this.Date.ToLocalTime();

    }
}
