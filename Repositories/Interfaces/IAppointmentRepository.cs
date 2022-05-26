using System;
using DocService.Models.Entities;

namespace DocService.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        //Add Appointment
        Task<Appointment> AddAppointment();
    }
}
