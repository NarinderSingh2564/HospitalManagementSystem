using HospitalManagementSystem.Models.Common;

namespace HospitalManagementSystem.Models.InputModels
{
    public class RegisterUserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDoctor { get; set; }
        public string DepartmentId { get; set; }
        public List<KeyValueModel<int, string>> DepartmentList { get; set; }
        public string DesignationId { get; set; }
        public List<KeyValueModel<int, string>> DesignationList { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string isActive { get; set; }

    }
}