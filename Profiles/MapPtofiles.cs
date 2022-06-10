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
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Patient.Id))
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.doctor.FirstName))
            .ForMember(dest => dest.TotalCountDocs, opt => opt.MapFrom(src => src.TotalDocs))
            .ForMember(dest => dest.PatientType, op => op.MapFrom(src => src.PatientType))
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Comment))
            .ReverseMap();

            CreateMap<AppointmentReadDTO, Appointment>().ReverseMap();

            //

            CreateMap<Appointment, AppointmentCreateDTO>()
            .ForMember(dest => dest.PatientId, op => op.MapFrom(src => src.Patient.Id))
            .ForMember(dest => dest.DoctorId, op => op.MapFrom(src => src.doctor.Id))
            .ForMember(dest => dest.PatientType, op => op.MapFrom(src => src.PatientType))
            //.ForMember(dest => dest.SerialNumber, op => op.MapFrom(src => src.SerialNumber + 20))
            .ForMember(dest => dest.AppointmentDate, op => op.MapFrom(src => src.NextVisitDate))
     
            .ForMember(dest => dest.AppointmentTime, op => op.MapFrom(src => src.AppointmentTime))
            .ForMember(dest => dest.Advice, op => op.MapFrom(src => src.Advice))
            .ForMember(dest => dest.Comment, op => op.MapFrom(src => src.Comment))
            .ReverseMap();

            CreateMap<AppointmentCreateDTO, Appointment>().ReverseMap();


            //
            CreateMap<Appointment, AppointmentEditDTO>()
           .ForMember(dest => dest.PatientId, op => op.MapFrom(src => src.Patient.Id))
           .ForMember(dest => dest.DoctorId, op => op.MapFrom(src => src.doctor.Id))
           .ForMember(dest => dest.PatientType, op => op.MapFrom(src => src.PatientType))
           //.ForMember(dest => dest.SerialNumber, op => op.MapFrom(src => src.SerialNumber + 20))
           .ForMember(dest => dest.AppointmentDate, op => op.MapFrom(src => src.NextVisitDate))
           .ForMember(dest => dest.AppointmentTime, op => op.MapFrom(src => src.AppointmentTime))
           .ForMember(dest => dest.Advice, op => op.MapFrom(src => src.Advice))
           .ForMember(dest => dest.Comment, op => op.MapFrom(src => src.Comment))
           .ReverseMap();

            CreateMap<AppointmentEditDTO, Appointment>().ReverseMap();


        }
    }

}
