using System;
using System.ComponentModel.DataAnnotations;

namespace DocService.Models.Entities
{
    //This will be My Base Entity Class that all my Models will Inherit from
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Role { get; set; }
        public string EmailAddress { get; set; }

        //Relationship
        public LineManger LineManager { get; set; }
        
        
        
        
        
        
        
        

        
    }
}
