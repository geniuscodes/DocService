using System;

namespace DocService.Models.Entities.Departments
{
    public class Medicine 
    {
        public int id { get;set;}
        public string name { get;set;} 
       public virtual ICollection<Nurse> Nurses { get; set; }
       public virtual ICollection<Doctor> Doctors { get; set; }

        
    }
}
