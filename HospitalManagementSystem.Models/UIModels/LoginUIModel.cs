using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalManagementSystem.Models.Common;
using HospitalManagementSystem.Models.Models;

namespace HospitalManagementSystem.Models.UIModels
{
    public class LoginUIModel
    {
        public LoginUIModel()
        {
            forgotPassword = new ForgotPasswordUIModel();
            registerUser = new RegisterUserUIModel();
        }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }
        public bool? Status { get; set; }
        public string Message { get; set; }
        public ForgotPasswordUIModel forgotPassword { get; set; }
        public RegisterUserUIModel registerUser { get; set; }
    }

    public class ForgotPasswordUIModel
    {
        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }

    public class RegisterUserUIModel
    {
        public RegisterUserUIModel()
        {
            DepartmentList = new List<KeyValueModel<int, string>>();
            DesignationList = new List<KeyValueModel<int, string>>();
        }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression("^[a-zA-Z0-9@.]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phonenumber is required.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Select the valid option.")]
        public bool? IsDoctor { get; set; }

        [Required(ErrorMessage = "Select the valid option.")]
        public int DepartmentId { get; set; }
        public List<KeyValueModel<int, string>> DepartmentList { get; set; }

        [Required(ErrorMessage = "Select the valid option.")]
        public int? DesignationId { get; set; }
        public List<KeyValueModel<int, string>> DesignationList { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool isActive { get; set; } = true;
        public string Message { get; set; }
        public bool Status { get; set; }
    }

}