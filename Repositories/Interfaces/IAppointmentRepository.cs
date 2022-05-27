using System;
using DocService.Models.DTO;
using DocService.Models.Entities;

namespace DocService.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        //Add Appointment
        Task<AppointmentReadDTO> AddAppointment(AppointmentReadDTO appointment);
        //Display Appointments
        Task<IEnumerable<AppointmentReadDTO>> GetAppointments();

        //Display Appointment
        Task<AppointmentReadDTO> GetAppointment(int id);

        //Search Appointments

        IEnumerable<Appointment> SearchAppointments(string appointment);
    }
}
