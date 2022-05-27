using System;
using AutoMapper;
using DocService.Models.DTO;
using DocService.Models.Entities;

namespace DocService.Profiles
{
    public class MapPtofiles : Profile
    {

        public MapPtofiles()
        {
           
             CreateMap<Appointment, AppointmentReadDTO>()
         
            
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FirsName))
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.doctor.FirstName))
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Comment))
            .ReverseMap();

            CreateMap<AppointmentReadDTO, Appointment>().ReverseMap();
       } 
}

}
