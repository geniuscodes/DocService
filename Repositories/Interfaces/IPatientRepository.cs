using System;
using DocService.Models.Entities;


namespace DocService.Repositories.Interfaces
{
    public interface IPatientRepository
    {

        //This Whill Handle the Patients Operations handled by the Nurse
        /*
            Thish Needs to be on pateint Info
        */

        //AddPatient
        Task<Patient> AddPatient(Patient patient);

        //
        Task<Patient> DeletePatient(Patient patient);
        //
        IEnumerable<Patient> GetAllPatients();

        // GetAPatient
        Task<Patient> GetAPatient(int id);

        // UpdatePatient
        Task<Patient> UpdatePatient(Patient patient);

        // SearchByName
        Task<IEnumerable<Patient>> SearchByName(string name);

    }
}
