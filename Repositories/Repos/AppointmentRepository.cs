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
     

        public  Task<AppointmentReadDTO> AddAppointment(AppointmentReadDTO appointment)
        {
            var app = _mapper.Map<AppointmentReadDTO, Appointment>(appointment);
            var newAppointment = _database.Appointments.Add(app);
             var newAppoint = _mapper.Map<Appointment, AppointmentReadDTO>(newAppointment.Entity);
             _database.SaveChangesAsync();
            return Task.FromResult(newAppoint);
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
                               SerialNumber = appointments.SeralNumber,
                               Notes = appointments.Comment,
                               AppointmentDate = appointments.NextVisitDate,
                               AppointmentTime = appointments.NextVisitDate.ToString("HH:mm tt"),
                              
                              }).SingleOrDefaultAsync(); 
                             return  (appointment.Result);
 
                
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
                               SerialNumber = appointments.SeralNumber,
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
