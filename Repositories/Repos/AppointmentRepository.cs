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
            app.AppointmentTime = appointment.AppointmentDate.ToLongTimeString();
            var newAppointment = _database.Appointments.Add(app);
             var newAppoint = _mapper.Map<Appointment, AppointmentCreateDTO>(newAppointment.Entity);
           
            _database.SaveChanges();
            return Task.FromResult(newAppoint);
        }

        public Task<AppointmentReadDTO> AppointmentDetails(int id)
        {
            throw new NotImplementedException();
        }

        public  Task<AppointmentReadDTO> DeleteAppointment(int appointmentId)
        {
            //Check
            var SearchEntity =  _database.Appointments.FirstOrDefault(x=> x.Id == appointmentId);
            var FoundDTO = _mapper.Map<Appointment, AppointmentReadDTO>(SearchEntity);
            if (SearchEntity != null)
            {
                _database.Remove(SearchEntity);
                _database.SaveChanges();
                return Task.FromResult(FoundDTO);
            }
            else
                return null;
        }

        public Task<AppointmentEditDTO> EditAppointment(AppointmentEditDTO appointment)
        {
            //map 
            var fromDTOtoModel = _mapper.Map<AppointmentEditDTO, Appointment>(appointment);
            var UpdateModel = _database.Update(fromDTOtoModel);
            _database.SaveChanges();
            //map edited model back to DTO 
            var updatedModel = _mapper.Map<Appointment, AppointmentEditDTO>(UpdateModel.Entity);

            return Task.FromResult(updatedModel);
            

        }

        public  AppointmentReadDTO GetAppointment(int id)
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
                               Id = appointments.Id,
                               PatientName = patients.FirsName + " " + patients.LastName,
                               PatientType = appointments.PatientType,
                               DoctorName = doctors.FirstName,
                               Notes = appointments.Comment,
                               AppointmentDate = appointments.NextVisitDate,
                               AppointmentTime = appointments.AppointmentTime,
                              
                              }).FirstOrDefault();
            
            return appointment;  
                
 
                
        }


        public AppointmentReadDTO GetAppointmentByPatientName(string  PatName)
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
                               where appointments.Patient.FirsName == PatName
                               select new AppointmentReadDTO
                               {
                                   PatientName = patients.FirsName + " " + patients.LastName,
                                   DoctorName = doctors.FirstName,
                                   Notes = appointments.Comment,
                                   AppointmentDate = appointments.NextVisitDate,
                                   AppointmentTime = appointments.AppointmentTime,

                               }).FirstOrDefault();
            return appointment;


        }

        public IEnumerable<AppointmentReadDTO> GetAppointments()
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
                               Id = appointments.Id,
                               PatientName = patients.FirsName + " " + patients.LastName,
                               DoctorName = doctors.FirstName,
                               PatientType = appointments.PatientType,
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
