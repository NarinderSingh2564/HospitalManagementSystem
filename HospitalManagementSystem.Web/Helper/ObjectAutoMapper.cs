using AutoMapper;
using HospitalManagementSystem.Data.DBClasses;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Models.UIModels;

namespace HospitalManagementSystem.Web.Helper
{
    public class ObjectAutoMapper : Profile
    {
        public ObjectAutoMapper()
        {
            CreateMap<RegisterUserUIModel, RegisterUserInputModel>().ReverseMap();
            CreateMap<RegisterUserInputModel, UserMaster>().ReverseMap();


            CreateMap<PatientModel, PatientMaster>().ReverseMap();
            CreateMap<PatientAppointmentModel, PatientAppointmentMaster>().ReverseMap();
            CreateMap<PatientAppointmentMaster, PatientModel>().ForMember(dest => dest.PatientAppointmentModel, 
                opt => opt.MapFrom(src => src)).AfterMap((src, dest, ctx) => { 
                    ctx.Mapper.Map(src.PatientMaster, dest); });


            CreateMap<PatientInputModel, PatientUIModel>().ForMember(dest => dest.PatientAppointmentUIModel,
                opt => opt.MapFrom(src => src.PatientAppointmentInputModel)).ReverseMap();
            CreateMap<PatientAppointmentInputModel, PatientAppointmentUIModel>().ReverseMap();

            CreateMap<PatientInputModel, PatientMaster>().ReverseMap();
            CreateMap<PatientAppointmentInputModel, PatientAppointmentMaster>().ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PatientId, opt => opt.Ignore()).ReverseMap();


        }
    }
}
