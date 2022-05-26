using System;
using DocService.Models.Data;
using DocService.Models.Entities;
using DocService.Repositories.Interfaces;

namespace DocService.Repositories.Repos
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _database;
        public PatientRepository(AppDbContext database)
        {
            _database = database;
        }

        public  async Task<Patient> AddPatient(Patient patient)
        {
            var pataient = await _database.Patients.AddAsync(patient);
            await _database.SaveChangesAsync();
            return pataient.Entity;
        }

        public Task<Patient> DeletePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<Patient> GetAllPatients()
        {
           //
           var pataients = _database.Patients.ToList();
                    return pataients.ToList();
        }

        public Task<Patient> GetAPatient(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveDatabase()
        {
          _database.SaveChangesAsync();
        }

        public Task<IEnumerable<Patient>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
