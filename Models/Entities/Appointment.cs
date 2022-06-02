using System.Runtime.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocService.Models.Entities
{
    public class Appointment
    {

        [Key]
        public int Id { get; set; }

        public string PatientType { get; set; }

        public static DateTime AppointmentDate { get; set; }

        public string AppointmentTime { get; set; } 

       


        public DateTime NextVisitDate { get; set; }

        public string Advice { get; set; } //for the patient

        //previous file

        public string Comment { get; set; }

        //Relational Tables
        public Doctor doctor { get; set; }
        public int doctorId { get; set; }

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        //Created By A Logged in User


        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[MinLength(5)]
        //public int SerialNumber
        //{
        //    get; set;



        //}



        public DateTime CreatedDate { get; set; } = (DateTime.Today);

        //Add The Satuus codes as our Internal Tracking of 


    }
}


