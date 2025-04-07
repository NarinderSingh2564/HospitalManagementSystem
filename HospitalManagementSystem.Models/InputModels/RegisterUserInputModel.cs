namespace HospitalManagementSystem.Models.InputModels
{
    public class RegisterUserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDoctor { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool isActive { get; set; }
        public string IsStaff { get; set; } = "Yes";
    }

    public class AddPatientByUserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MaritalStatus { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public DateTime DOB { get; set; }
        public string BloodGroup { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool MedicalHistory { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string isActive { get; set; }
        public string IsStaff { get; set; }
    }

}