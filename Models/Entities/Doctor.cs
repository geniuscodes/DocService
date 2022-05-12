using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocService.Models.Entities
{
    //Model For Doctor
    public class Doctor
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        [Phone]
        public string Telephone { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Speciality { get; set; }
        public string Address { get; set; }
        public int RegNumber { get; set; }


        public virtual ICollection<Prescription> Prescriptions { get; set; }
















    }
}