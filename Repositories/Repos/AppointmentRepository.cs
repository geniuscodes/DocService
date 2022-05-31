using System;
using AutoMapper;
using DocService.Models.Data;
using DocService.Models.DTO;
using DocService.Models.Entities;
using DocService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocService.Repositories.Repos
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _database;
        private readonly IMapper _mapper;

        public AppointmentRepository(AppDbContext database,
        IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
     

        public  Task<AppointmentCreateDTO> AddAppointment(AppointmentCreateDTO appointment)
        {

            var app = _mapper.Map<AppointmentCreateDTO, Appointment>(appointment);
            var newAppointment = _database.Appointments.Add(app);
             var newAppoint = _mapper.Map<Appointment, AppointmentCreateDTO>(newAppointment.Entity);
           
            _database.SaveChanges();
            return Task.FromResult(newAppoint);
        }

        public Task<AppointmentReadDTO> AppointmentDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentReadDTO> DeleteAppointment(AppointmentReadDTO appoint)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentReadDTO> EditAppointment(AppointmentReadDTO appointment)
        {
            //map 
            var fromDTOtoModel = _mapper.Map<AppointmentReadDTO, Appointment>(appointment);
            var UpdateModel = _database.Update(fromDTOtoModel);
            _database.SaveChanges();
            //map edited model back to DTO 
            var updatedModel = _mapper.Map<Appointment, AppointmentReadDTO>(UpdateModel.Entity);

            return Task.FromResult(updatedModel);
            

        }

        public async Task<AppointmentReadDTO> GetAppointment(int id)
        {

            //Tables
            var Appointments = _database.Appointments;
            var Doctors = _database.Doctors;
            var Patients = _database.Patients;
            var appointment =
                              (from appointments in Appointments
                              join doctors in Doctors on
                               appointments.doctorId equals (doctors.Id)
                              join patients in Patients on
                               appointments.PatientId equals (patients.Id)
                               where appointments.Id == id
                              select new AppointmentReadDTO
                           {
                               PatientName = patients.FirsName + " " + patients.LastName,
                               DoctorName = doctors.FirstName,
                           
                               Notes = appointments.Comment,
                               AppointmentDate = appointments.NextVisitDate,
                               AppointmentTime = appointments.NextVisitDate.ToString("HH:mm tt"),
                              
                              }).SingleOrDefaultAsync(); 
                             return  appointment.Result;
 
                
        }

        public async Task<IEnumerable<AppointmentReadDTO>> GetAppointments()
        {
            //Tables 
            var Appointments = _database.Appointments;
            var Doctors = _database.Doctors;
            var Patients = _database.Patients;
            var results = (from appointments in Appointments
                           join doctors in Doctors on
                           appointments.doctorId equals (doctors.Id)
                           join patients in Patients on
                           appointments.PatientId equals (patients.Id)
                           select new AppointmentReadDTO
                           {
                               PatientName = patients.FirsName + " " + patients.LastName,
                               DoctorName = doctors.FirstName,
                               Notes = appointments.Comment,
                               AppointmentDate = appointments.NextVisitDate,
                               AppointmentTime = appointments.NextVisitDate.ToString("HH:mm tt"),

                        }).ToList();

              return results;

        }


        public IEnumerable<Appointment> SearchAppointments(string appointment)
        {
            throw new NotImplementedException();
        }
    }
}
