using System;
using System.ComponentModel.DataAnnotations;

namespace DocService.Models.Entities
{
    public class BaseEntity
    {
         [Key]
        public int Id { get; set; }
        #nullable disable
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string  Role { get; set; }
        [Required]
        [EmailAddress]
        [Editable(false)]
        public string EmailAddress { get; set; }
        
    }
}
