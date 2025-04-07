using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Repository.Abstract;
using HospitalManagementSystem.Service.Interactions;

namespace HospitalManagementSystem.Repository.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        ApplicationDBContext _dBContext;
        IMapper _mapper;
        public AccountRepository(ApplicationDBContext applicationDBContext, IMapper mapper)
        {
            _dBContext = applicationDBContext;
            _mapper = mapper;
        }
        public ReturnResponseModel<UserModel> LoginCredentialCheck(string email, string password)
        {
            using (AccountService accountService = new AccountService(_dBContext, _mapper))
            {
                return accountService.LoginCredentialCheck(email, password);
            }
        }

        public ReturnResponseModel<string> CheckUserByEmailOrPhoneNumber(string emailphonenumber)
        {
            using (AccountService accountService = new AccountService(_dBContext, _mapper))
            {
                return accountService.CheckUserByEmailOrPhoneNumber(emailphonenumber);
            }
        }

        public ReturnResponseModel<string> RegisterUser(RegisterUserInputModel registerUser)
        {
            using (AccountService accountService = new AccountService(_dBContext, _mapper))
            {
                return accountService.RegisterUser(registerUser);
            }
        }
       
        public List<DepartmentModel> GetDepartmentList()
        {
            using (AccountService accountService = new AccountService(_dBContext, _mapper))
            {
                return accountService.GetDepartmentList();
            }
        }

        //public List<DesignationModel> GetDesignationList()
        //{
        //    using (AccountService accountService = new AccountService(_dBContext, _mapper))
        //    {
        //        return accountService.GetDesignationList();
        //    }
        //}

        public List<KeyValueModel<int, string>> GetDesignationsByDepartmentId(int departmentId)
        {
            using (AccountService accountService = new AccountService(_dBContext, _mapper))
            {
                return accountService.GetDesignationsByDepartmentId(departmentId);
            }
        }

        public ReturnResponseModel<UserModel> UpdatePassword(string emailphonenumber, string newPassword, string confirmPassword)
        {
            using (AccountService accountService = new AccountService(_dBContext, _mapper))
            {
                return accountService.UpdatePassword(emailphonenumber, newPassword, confirmPassword);
            }
        }
    }
}
