using System.ComponentModel;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Service.Interactions
{
    public class AccountService:IDisposable
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
        public ReturnResponseModel<UserModel> Login(string email, string password)
        {
            var returnResponseModel = new ReturnResponseModel<UserModel>();

            var userMasterObj = _dbcontext.UserMaster.Where(u => u.Email == email).FirstOrDefault();

            if (userMasterObj != null)
            {
                if (userMasterObj.Password != password)
                {
                    returnResponseModel.status = false;
                    returnResponseModel.message = "Wrong Password";
                }
                else if (!userMasterObj.isActive)
                {
                    returnResponseModel.status = false;
                    returnResponseModel.message = "User is not active";
                }
                else
                {
                    returnResponseModel.status = true;
                    returnResponseModel.Data = new UserModel
                    {
                        FirstName = string.Concat(userMasterObj.FirstName, " ", userMasterObj.LastName),
                        //Designation = userMasterObj.DesignationMaster.DesignationName,
                        Designation = userMasterObj.DesignationMaster != null ? userMasterObj.DesignationMaster.DesignationName : "No Designation",
                        isActive = userMasterObj.isActive,
                        IsDoctor = userMasterObj.IsDoctor
                        
                    };
                    returnResponseModel.message = $"User: {userMasterObj.FirstName} {userMasterObj.LastName}, Active: {userMasterObj.isActive}";
                }
            }
            else
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "Wrong Email";
            }

            return returnResponseModel;
        }

    }
}
