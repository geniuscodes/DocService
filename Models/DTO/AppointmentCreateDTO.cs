using System;

namespace DocService.Models.DTO
{
    public class AppointmentCreateDTO
    {
        //Create DTO for appointment
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string PatientType { get; set; }
        //public int SerialNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Advice { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }




    }
}
