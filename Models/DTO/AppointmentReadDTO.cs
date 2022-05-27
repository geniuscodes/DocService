using System;

namespace DocService.Models.DTO
{
    public class AppointmentReadDTO
    {
        //
        
        public string PatientName { get; set; }
        public string  DoctorName { get; set; }
        public int SerialNumber { get; set; }
        public string AppointmentTime { get; set; }
        public string Notes { get; set; }
        public DateTime AppointmentDate { get; set;}
        
     
        
    

        
        
        
        
    }

    public class AppointmentCreateDTO
    {


    }

}
