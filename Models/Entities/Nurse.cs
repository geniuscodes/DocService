using System;
using DocService.Models.Entities.Departments;

namespace DocService.Models.Entities
{
    public class Nurse : Employee
    {
        //Department
        public Medicine deployed { get; set; }
        public int Medicineid { get; set; }
        
        
        
    }
}
