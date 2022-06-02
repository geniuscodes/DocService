namespace DocService.Models.DTO
{
    public class AppointmentEditDTO
    {
        //
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string PatientType { get; set; }
   
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Advice { get; set; }
        public string Comment { get; set; }
       
    }
}
