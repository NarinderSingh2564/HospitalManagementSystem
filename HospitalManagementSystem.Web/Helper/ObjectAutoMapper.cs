using AutoMapper;
using HospitalManagementSystem.Data.DBClasses;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.UIModels;

namespace HospitalManagementSystem.Web.Helper
{
    public class ObjectAutoMapper:Profile
    {
        public ObjectAutoMapper()
        {
            CreateMap<RegisterUserUIModel,RegisterUserInputModel>().ReverseMap();
            CreateMap<RegisterUserInputModel, UserMaster>().ReverseMap();
        }
    }
}
