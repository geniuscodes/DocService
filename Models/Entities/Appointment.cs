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

        public string AppointmentTime { get; set; } = AppointmentDate.ToString("hh:mm");


        public DateTime NextVisitDate { get; set; } 

        public string Advice { get; set; }

        //previous file

        public string Comment { get; set; }

        //Relational Tables
        public Doctor doctor { get; set; }

        public Patient Patient { get; set; }
        //Created By A Logged in User

        private int value = 100;


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MinLength(5)]
        public int SeralNumber
        {
            get
            {
                return value;
            }
            set
            {

                for (int i = value; i < int.MaxValue; i++)
                    value = i;
            }
        }

    public DateTime CreatedDate{get; set;} = (DateTime.Today);


    }
}

