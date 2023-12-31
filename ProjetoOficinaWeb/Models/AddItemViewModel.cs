﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoOficinaWeb.Models
{
    public class AddItemViewModel
    {

        [Display(Name = "Service")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Service.")]
        public int ServiceId { get; set; }

        public string Description { get; set; }

        [Range (0.0001 , double.MaxValue,ErrorMessage = "The quantity must be a positive number.")]
        public int Price { get; set; }  

        public IEnumerable<SelectListItem> Services { get; set; }  

        
    }
}
