using System;
using DocService.Models.DTO;
using DocService.Models.Entities;

namespace DocService.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        //Add Appointment
        Task<AppointmentCreateDTO> AddAppointment(AppointmentCreateDTO appointment);
        //Display Appointments
        Task<IEnumerable<AppointmentReadDTO>> GetAppointments();

        //Display Appointment
        Task<AppointmentReadDTO> GetAppointment(int id);

        //Search Appointments

        IEnumerable<Appointment> SearchAppointments(string appointment);

        //Edit Appoint

        Task<AppointmentReadDTO> EditAppointment(AppointmentReadDTO appointment);

        //Delete
        Task<AppointmentReadDTO> DeleteAppointment(AppointmentReadDTO appoint);

        //Details

        Task<AppointmentReadDTO> AppointmentDetails(int id);

        
    }
}
