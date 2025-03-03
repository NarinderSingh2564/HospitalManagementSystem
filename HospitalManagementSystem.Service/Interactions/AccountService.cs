using System.ComponentModel;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.Models;

namespace HospitalManagementSystem.Service.Interactions
{
    public class AccountService : IDisposable
    {
        #region Private Variables
        private ApplicationDBContext _dbcontext;

        private Component component = new Component();
        private bool disposed = false;
        private IntPtr handle;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();
                CloseHandle(handle);
                handle = IntPtr.Zero;
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        #endregion

        #region Constructor
        public AccountService(ApplicationDBContext dBContext)
        {
            _dbcontext = dBContext;
        }
        #endregion

        #region Destructor
        ~AccountService()
        {
            Dispose(false);
        }
        #endregion
        public ReturnResponseModel<UserModel> LoginCredentialCheck(string email, string password)
        {
            var returnResponseModel = new ReturnResponseModel<UserModel>();

            dynamic dbUserMasterObj = _dbcontext.UserMaster.FirstOrDefault(u => u.Email == email) ??
                (dynamic) (_dbcontext.PatientMaster.FirstOrDefault(p => p.Email == email));

            if (dbUserMasterObj != null)
            {
                if (dbUserMasterObj.Password != password)
                {
                    returnResponseModel.status = false;
                    returnResponseModel.message = "Wrong Password.";
                }
                else if (!dbUserMasterObj.isActive)
                {
                    returnResponseModel.status = false;
                    returnResponseModel.message = "User is not active";
                }
                else
                {
                    returnResponseModel.Data = new UserModel
                    {
                        FirstName = string.Concat(dbUserMasterObj.FirstName, " ", dbUserMasterObj.LastName),
                        IsStaff = dbUserMasterObj?.IsStaff != null ? dbUserMasterObj.IsStaff : null,
                        Area = dbUserMasterObj.IsStaff != null ? "Staff" : "Patient",
                    };
                    returnResponseModel.status = true;
                }
            }
            else
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "Wrong Email";
            }
            return returnResponseModel;
        }

        public ReturnResponseModel<UserModel> ForgotPasswordCheck(string emailphonenumber)
        {
            var returnResponseModel = new ReturnResponseModel<UserModel>();

            var dbUserMasterObj = _dbcontext.UserMaster.FirstOrDefault(u => u.Email == emailphonenumber || u.PhoneNumber == emailphonenumber) ??
                (dynamic)(_dbcontext.PatientMaster.FirstOrDefault(p => p.Email == emailphonenumber || p.PhoneNumber == emailphonenumber));

            if (dbUserMasterObj != null)
            {
                returnResponseModel.status = true;
                returnResponseModel.message = "The email or phone number exists. You can change your password now.";
            }
            else
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "No user found with the provided email or phone number.";
            }
            return returnResponseModel;
        }
    }
}
