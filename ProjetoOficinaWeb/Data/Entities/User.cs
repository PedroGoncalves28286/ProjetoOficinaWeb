using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1}characters leght.")]
        public string FirstName { get; set; }

        [MaxLength(50,ErrorMessage = "The field {0} only can contain {1}characters leght.")]
        public string Adress { get; set; }

        public String PhoneNumber { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1}characters leght.")]
        public string LastName { get; set; }

        [Display(Name ="Full Name")]
        public string FullName => $"{ FirstName} {LastName}";

        public string ImageUrl { get; set; }

        public Client Client { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return null;
                }

                return $"https://localhost:44310{ImageUrl.Substring(1)}"; 
            }
        }
    }

}

