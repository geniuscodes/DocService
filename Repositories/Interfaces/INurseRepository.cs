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
       Task<Nurse> GetANurse(int id);

        //UpdateNurseInformation
        Task<Nurse> UpdateProfile (Nurse nurse);   
        //DeleteNurse
        Task<Nurse> DeleteNurse(Nurse nurse);
        Task SaveDatabase();
        //Check The Nurse
        //Status 
        //Nurse can Update Shift 
        //Search by Name Method
        Task<IEnumerable<Nurse>> SearchByName(string name);


        //Search by Department

    }
}
