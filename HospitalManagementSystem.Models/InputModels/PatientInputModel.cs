using HospitalManagementSystem.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.InputModels
{
    public class PatientInputModel
    {
        public PatientInputModel()
        {
            PatientAppointmentInputModel = new PatientAppointmentInputModel();
        }
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
        public DateTime? AdmissionDate { get; set; }
        //public bool MedicalHistory { get; set; } = false;
        //public string IsInsured { get; set; }
        //public string InsuranceCompany { get; set; }
        //public string InsuranceNumber { get; set; }
        public string isActive { get; set; } = "Yes";
        public string IsStaff { get; set; }
        public PatientAppointmentInputModel PatientAppointmentInputModel { get; set; }

    }
    public class PatientAppointmentInputModel
    {
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public List<KeyValueModel<int, string>> DepartmentList { get; set; }
        public List<KeyValueModel<int, string>> DoctorList { get; set; }
        public DateTime AppointmentOn { get; set; }
        public int TimeSlotId { get; set; }
        public string PatientType { get; set; }
        public string CRMNumber { get; set; }
        public string ReasonForVisit { get; set; }
        //public string DoctorNotes { get; set; }
        public string Status { get; set; }
        //public DateTime? RescheduledOn { get; set; }
        //public int? RescheduledTimeSlotId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool isActive { get; set; } = true;
    }

      
}
