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
        IEnumerable<AppointmentReadDTO> GetAppointments();

        //Display Appointment
        AppointmentReadDTO GetAppointment(int id);

        //Search Appointments

        IEnumerable<Appointment> SearchAppointments(string appointment);

        //Edit Appoint

        Task<AppointmentEditDTO> EditAppointment(AppointmentEditDTO appointment);

        //Delete
        Task<AppointmentReadDTO> DeleteAppointment(int appointmentId);

        //Details

        Task<AppointmentReadDTO> AppointmentDetails(int id);

        //
       AppointmentReadDTO GetAppointmentByPatientName(string PatName);



    }
}
