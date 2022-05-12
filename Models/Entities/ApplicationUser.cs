using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DocService.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //The Users Configuration for Identity User
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public int Telephone { get; set; }






    }
}
