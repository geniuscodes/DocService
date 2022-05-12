using DocService.Models.Entities;

namespace DocService.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> DeleteDoctor(int id);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<Doctor> AddDoctor(Doctor doctor);


        Task<Doctor> CheckDoc(int id);
        void SaveDatabase();
    }
}