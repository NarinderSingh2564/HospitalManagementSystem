using System.ComponentModel;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Data.DBClasses;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.InputModels;
using HospitalManagementSystem.Models.Models;
using HospitalManagementSystem.Models.UIModels;
using Microsoft.EntityFrameworkCore;

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

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "Email and Password are required.";
                return returnResponseModel;
            }

            dynamic dbUserMasterObj = _dbcontext.UserMaster.FirstOrDefault(u => u.Email == email);

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

        public ReturnResponseModel<UserModel> CheckUserByEmailOrPhoneNumber(string emailphonenumber)
        {
            var returnResponseModel = new ReturnResponseModel<UserModel>();

            if (string.IsNullOrEmpty(emailphonenumber))
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "Email or phone number is required.";
                return returnResponseModel;
            }

            var dbUserEmailObj = _dbcontext.UserMaster.FirstOrDefault(u => u.Email == emailphonenumber);
            var dbUserPhoneNumberObj = _dbcontext.UserMaster.FirstOrDefault(u => u.PhoneNumber == emailphonenumber);

            if (dbUserEmailObj != null)
            {
                returnResponseModel.status = true;
                returnResponseModel.message = "The email exists. You can change your password now.";
            }
            else if (dbUserPhoneNumberObj != null)
            {
                returnResponseModel.status = true;
                returnResponseModel.message = "The phone number exists. You can change your password now.";
            }
            else
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "No user found with the provided data.";
            }
            return returnResponseModel;
        }

        public ReturnResponseModel<UserModel> UpdatePassword(string emailphonenumber, string newPassword, string confirmPassword)
        {
            var returnResponseModel = new ReturnResponseModel<UserModel>();

            if (string.IsNullOrEmpty(emailphonenumber))
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "Email/Phone number is required.";
                return returnResponseModel;
            }
            else if (string.IsNullOrEmpty(newPassword))
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "New password is required.";
                return returnResponseModel;
            }
            else if (string.IsNullOrEmpty(confirmPassword))
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "Confirm password is required.";
                return returnResponseModel;
            }

            if (newPassword != confirmPassword)
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "New password and confirm password do not match.";
                return returnResponseModel;
            }

            var dbUserObj = _dbcontext.UserMaster.FirstOrDefault(u => u.Email == emailphonenumber || u.PhoneNumber == emailphonenumber);

            if (dbUserObj == null)
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "No user found with the provided data.";
                return returnResponseModel;
            }
            else if (dbUserObj.Password == newPassword)
            {
                returnResponseModel.status = false;
                returnResponseModel.message = "New password cannot be the same as the old password.";
                return returnResponseModel;
            }
            else
            {
                dbUserObj.Password = newPassword;
                _dbcontext.SaveChanges();

                returnResponseModel.status = true;
                returnResponseModel.message = "Password updated successfully. Please Login";
            }
            return returnResponseModel;
        }

        public ReturnResponseModel<RegisterUserUIModel> RegisterUser(RegisterUserInputModel registerUser)
        {
            var returnResponseModel = new ReturnResponseModel<RegisterUserUIModel>();
            var dbEmailExist = _dbcontext.UserMaster.FirstOrDefault(u => u.Email == registerUser.Email);

            if (dbEmailExist != null)
            {
                returnResponseModel.message = "Email already exists. Please Login...";
                returnResponseModel.status = false;
            }
            else
            {
                var dbPhoneNumberExist = _dbcontext.UserMaster.FirstOrDefault(u => u.PhoneNumber == registerUser.PhoneNumber);
                if (dbPhoneNumberExist != null)
                {
                    returnResponseModel.message = "Phone number already exists. Please Login...";
                    returnResponseModel.status = false;
                }
                else
                {
                    var userMaster = new UserMaster
                    {
                        FirstName = registerUser.FirstName,
                        LastName = registerUser.LastName,
                        Email = registerUser.Email,
                        PhoneNumber = registerUser.PhoneNumber,
                        IsDoctor = registerUser.IsDoctor,
                        DesignationId = Convert.ToInt32(registerUser.DesignationId),
                        Password = registerUser.Password,
                        CreatedBy = 1,
                        CreatedOn = DateTime.UtcNow,
                        IsStaff = "Yes",
                        isActive = true
                    };
                    _dbcontext.UserMaster.Add(userMaster);
                    _dbcontext.SaveChanges();

                    returnResponseModel.message = "Registration successful! Please Login...";
                    returnResponseModel.status = true;
                }
            }
            return returnResponseModel;
        }

        public List<DesignationModel> GetDesignationList()
        {
            var designationList = new List<DesignationModel>();
            var dbDesignationList = _dbcontext.DesignationMaster.Include(d => d.DepartmentMaster)
            .Where(d => d.DepartmentId == d.DepartmentMaster.Id).Distinct().ToList();

            foreach (var item in dbDesignationList)
            {
                designationList.Add(new DesignationModel
                {
                    Id = item.Id,
                    Department = item.DepartmentMaster.DepartmentName + " ( " + item.DepartmentMaster.DepartmentCode + " )",
                    Designation = item.DesignationName + " ( " + item.DesignationCode + " )"
                });
            }
            return designationList;
        }

        public List<DepartmentModel> GetDepartmentList()
        {
            var designationList = new List<DepartmentModel>();
            var dbDesignationList = _dbcontext.DepartmentMaster.Distinct().ToList();

            foreach (var item in dbDesignationList)
            {
                designationList.Add(new DepartmentModel
                {
                    Id = item.Id,
                    Department = item.DepartmentName + " ( " + item.DepartmentCode + " )"
                });
            }
            return designationList;
        }
    }
}
