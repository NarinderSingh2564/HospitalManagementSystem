using System.ComponentModel.DataAnnotations;
using HospitalManagementSystem.Models.Common;

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

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }
        public bool? status { get; set; }
        public string Message { get; set; }
        public ForgotPasswordUIModel forgotPassword { get; set; }
        public RegisterUserUIModel registerUser { get; set; }

    }

    public class ForgotPasswordUIModel
    {
        [Required]
        [Display(Name = "Value is required")]
        public string EmailPhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password is required")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password is required")]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }

    public class RegisterUserUIModel
    {
        [Required]
        [Display(Name = "First name is required")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phonenumber is required")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Select the valid option")]
        public bool IsDoctor { get; set; }

        public string DepartmentId { get; set; }
        public List<KeyValueModel<int, string>> DepartmentList { get; set; }

        public string DesignationId { get; set; }
        public List<KeyValueModel<int, string>> DesignationList { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password is required")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }       
        public string isActive { get; set; }

    }
}