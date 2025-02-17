using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.Models;

namespace HospitalManagementSystem.Repository.Abstract
{
    public interface IAccountRepository
    {
        ReturnResponseModel<UserModel> Login(string email, string password);
    }
}
