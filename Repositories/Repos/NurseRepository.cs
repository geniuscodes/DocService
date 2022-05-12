using System;
using DocService.Models.Data;
using DocService.Models.Entities;
using DocService.Repositories.Interfaces;

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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Nurse>> GetAllNurses()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Nurse>> GetANurse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Nurse> UpdateProfile(Nurse nurse)
        {
            throw new NotImplementedException();
        }
    }
}
