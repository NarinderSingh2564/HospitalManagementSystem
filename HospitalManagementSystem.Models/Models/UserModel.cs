namespace HospitalManagementSystem.Models.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDoctor { get; set; }
        public string IsStaff { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public bool isActive { get; set; }
        public string Password { get; set; }
        public string Area { get; set; }
    }
}