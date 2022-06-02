using System;
using System.ComponentModel.DataAnnotations;

namespace DocService.Models.Entities
{
    public class Patient
    {

#nullable disable

        [Key]
        public int Id { get; set; }
        [Required]
        public string PatientCode { get; set; }
         [Required]
        public string FirsName { get; set; }
         [Required]
        public string LastName { get; set; }

         [Required]
        public string Gender { get; set; }
         [Required]

        public string BloodType { get; set; }    
         [Required]
        public DateTime DateOfBirth { get; set; }
        [Phone]
         [Required]
        public int Phone { get; set; }
        [EmailAddress]
         [Required]
        public string EmailAddress { get; set; }
         [Required]
        public string Address { get; set; }
        public string Agreement { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
      

        //The PATIENT CAN BE CREATED by Nurse or Doctor Nurse or Admin 
        
        
        
        
        
        
        
        
        
        
        
        
    }
}
