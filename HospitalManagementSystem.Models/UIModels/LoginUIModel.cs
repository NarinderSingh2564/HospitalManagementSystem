namespace HospitalManagementSystem.Models.UIModels
{
    public class LoginUIModel
    {
        public LoginUIModel()
        {
            forgotPassword = new ForgotPassword();

        }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool? status { get; set; }
        public string Message { get; set; }
        public ForgotPassword forgotPassword { get; set; }

    }

    public class ForgotPassword
    {
        public string EmailPhoneNumber { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}