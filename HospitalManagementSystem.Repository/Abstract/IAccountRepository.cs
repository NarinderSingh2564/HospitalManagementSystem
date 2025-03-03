using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.Models;

namespace HospitalManagementSystem.Repository.Abstract
{
    public interface IAccountRepository
    {
        ReturnResponseModel<UserModel> CheckLoginDetails(string email, string password);
        ReturnResponseModel<UserModel> ForgetPasswordDetails(string emailphoneNumber);
    }
}
