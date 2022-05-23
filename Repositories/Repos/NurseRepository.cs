using System;
using DocService.Models.Data;
using DocService.Models.Entities;
using DocService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocService.Repositories.Repos
{
    public class NurseRepository : INurseRepository
    {

        private readonly AppDbContext _database;

        public NurseRepository(AppDbContext dbContext)
        {
            _database = dbContext;
            
        }

        public async Task<Nurse> AddNurseAsyn(Nurse nurse)
        {
           //
           var newNurse = await _database.Nurses.AddAsync(nurse);
           await _database.SaveChangesAsync();
           return newNurse.Entity;
        }

        public Task<Nurse> DeleteNurse(Nurse nurse)
        {
            
            // NURSERY
            var nurseToDelete = _database.Nurses.FirstOrDefault(n => n.Id == nurse.Id);
            _database.Nurses.Remove(nurseToDelete);
            Task.Run(() => _database.SaveChangesAsync());
            return Task.FromResult(nurseToDelete);

        }

        public async Task<IEnumerable<Nurse>> GetAllNurses()
        {
           var results = _database.Nurses
           .ToList();
              return  results;
                  
        }

        public  Task<Nurse> GetANurse(int id)
        {
            var nurse = _database.Nurses
            .FirstOrDefault(n=>n.Id == id);
            return Task.FromResult(nurse);
        }

        public  Task SaveDatabase()
        {
            return _database.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nurse>> SearchByName(string name)
        {
            var nurses = _database.Nurses
            .Where(n => n.FirstName.Contains(name))
            .ToList();
            return nurses;
        }

        public Task<Nurse> UpdateProfile(Nurse nurse)
        {
            var nurseToUpdate = _database.Nurses.FirstOrDefault(n => n.Id == nurse.Id);
          _database.Nurses.Update(nurseToUpdate);
            Task.Run(() => _database.SaveChangesAsync());
            return Task.FromResult(nurseToUpdate);
        }
    }
}
