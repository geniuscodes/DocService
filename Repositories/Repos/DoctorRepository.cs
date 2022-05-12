using DocService.Models.Data;
using DocService.Models.Entities;
using DocService.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace DocService.Repositories.Repos
{

    public class DoctorRepository : IDoctorRepository
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _database;

        public DoctorRepository(AppDbContext database,
        UserManager<IdentityUser> userManager)
        {

            _database = database;
            _userManager = userManager;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            var docs = await _database.Doctors.AddAsync(doctor);
            await _database.SaveChangesAsync();
            return docs.Entity;
        }



        public async Task<Doctor> CheckDoc(int id)
        {
            var doc = await _database.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if (doc == null)
            {
                return null;
            }

            return doc;

        }

        public async Task<Doctor> DeleteDoctor(int id)
        {
            // await CheckDoc(id);
            var doc = await _database.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if (doc != null)
            {
                _database.Doctors.Remove(doc);
                SaveDatabase();
            }

            return doc;

        }

        public Task<Doctor> GetDoctorById(int id)
        {

            var doc = _database.Doctors.FirstOrDefault(x => x.Id == id);
            if (doc == null)
            {
                return null;
            }

            return Task.FromResult(doc);

        }

        public IEnumerable<Doctor> GetDoctors()
        {

            var docs = (from doc in _database.Doctors

                        select new
                        {

                            doc.FirstName,
                            doc.LastName,
                            doc.EmailAddress,
                            doc.Telephone,
                            doc.Speciality,
                            doc.RegNumber

                        }).ToList();

            return docs.Select(x => new Doctor
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmailAddress = x.EmailAddress,
                Telephone = x.Telephone,
                Speciality = x.Speciality,
                RegNumber = x.RegNumber,


            }).ToList();   
        }



        public void SaveDatabase()
        {
            _database.SaveChangesAsync();
        }

        public  Task<Doctor> UpdateDoctor(Doctor doctor)
        {
             var updatedDoc = _database.Update(doctor);
             _database.SaveChangesAsync();
            return Task.FromResult(updatedDoc.Entity);
        }
    }


}
