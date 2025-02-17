namespace HospitalManagementSystem.Models.UIModels
{
    public class LoginUIModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool? status { get; set; }
        public string Message { get; set; }
    }
}