using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.Models;
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
        public ReturnResponseModel<UserModel> CheckLoginDetails(string email, string password)
        {
            using (AccountService accountService = new AccountService(_dBContext))
            {
                return accountService.LoginCredentialCheck(email,password);
            }
        }
    }
}
