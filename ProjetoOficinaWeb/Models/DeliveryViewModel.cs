using System.ComponentModel.DataAnnotations;
using System;

namespace ProjetoOficinaWeb.Models
{
    public class DeliveryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Schedule date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ScheduleDate { get; set; }
    }
}
