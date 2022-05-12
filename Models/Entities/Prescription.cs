using System.ComponentModel.DataAnnotations;

namespace DocService.Models.Entities
{


    public class Prescription
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PatientName { get; set; }

        [Required(ErrorMessage ="Amount is Required")]
        
        public decimal Amount { get; set; }

        [Required]
        public int Frequency { get; set; }
        //Doctors Object
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
    }
}   
