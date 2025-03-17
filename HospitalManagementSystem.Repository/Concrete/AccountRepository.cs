using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Models.UIModels;
using HospitalManagementSystem.Repository.Abstract;
using HospitalManagementSystem.Service.Interactions;

namespace HospitalManagementSystem.Repository.Concrete
{
    public class AccountRepository:IAccountRepository
    {
        ApplicationDBContext _dBContext;
        public AccountRepository(ApplicationDBContext applicationDBContext)
        {
            _dBContext = applicationDBContext;
        }
        public ReturnResponseModel<UserModel> LoginCredentialCheck(string email, string password)
        {
            using (AccountService accountService = new AccountService(_dBContext))
            {
                return accountService.LoginCredentialCheck(email,password);
            }
        }

        public ReturnResponseModel<UserModel> ForgotPasswordCheck(string emailphonenumber)
        {
            using (AccountService accountService = new AccountService(_dBContext))
            {
                return accountService.ForgotPasswordCheck(emailphonenumber);
            }
        }

        public ReturnResponseModel<RegisterUserUIModel> RegisterUser(RegisterUserInputModel registerUser)
        {
            using (AccountService accountService = new AccountService(_dBContext))
            {
                return accountService.RegisterUser(registerUser);
            }
        }

        public List<DesignationModel> GetDesignationList()
        {
            using (AccountService accountService = new AccountService(_dBContext))
            {
                return accountService.GetDesignationList();
            }
        }
        public List<DepartmentModel> GetDepartmentList()
        {
            using (AccountService accountService = new AccountService(_dBContext))
            {
                return accountService.GetDepartmentList();
            }
        }
    }
}
