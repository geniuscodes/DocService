using System;
using DocService.Models.Entities;

namespace DocService.Repositories.Interfaces
{
    public interface INurseRepository
    {

        /// <summary>
         //All  The Gets Methods Must Use LINQ for Joins
        ///<Summary>

        
        //AddNurse
        Task<Nurse> AddNurseAsyn(Nurse nurse);

        //GetAllNurses
        Task<IEnumerable<Nurse>> GetAllNurses();
        //GetANurse
        Task<IEnumerable<Nurse>> GetANurse(int id);

        //UpdateNurseInformation
        Task<Nurse> UpdateProfile (Nurse nurse);   
        //DeleteNurse
        Task<Nurse> DeleteNurse(Nurse nurse);
        //Check The Nurse
        //Status 
        //Nurse can Update Shift 

    }
}
