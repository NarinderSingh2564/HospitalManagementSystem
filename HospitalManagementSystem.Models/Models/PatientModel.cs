namespace HospitalManagementSystem.Models.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
        public bool IsInsured { get; set; }
        public string InsuranceCompany { get; set; }
        public string InsuranceNumber { get; set; }
        public bool isActive { get; set; }
        public string IsStaff { get; set; }


    }
}
