using System;
using System.ComponentModel.DataAnnotations;

namespace DocService.Models.Entities
{
    //This will be My Base Entity Class that all my Models will Inherit from
    public class Employee : BaseEntity
    {


        #nullable disable

        public LineManger LineManager { get; set; }
        public int LineManagerId { get; set; }


    }
}
