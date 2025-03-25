namespace HospitalManagementSystem.Models.Models
{
    public class DesignationModel
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}