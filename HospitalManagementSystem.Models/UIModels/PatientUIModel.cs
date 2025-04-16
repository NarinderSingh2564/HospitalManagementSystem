using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalManagementSystem.Models.Common;

namespace HospitalManagementSystem.Models.UIModels
{
    public class PatientUIModel
    {
        public PatientUIModel()
        {
            PatientAppointmentUIModel = new PatientAppointmentUIModel();
        }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[a-zA-Z0-9@.]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required.")]
        //[DataType(DataType.Password)]
        //[MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        //public string Password { get; set; }

        [Required(ErrorMessage = "Martial Status is required.")]
        public string MaritalStatus { get; set; }
        
        [Required(ErrorMessage = "Father name is required.")]
        public string FatherName { get; set; }
        
        [Required(ErrorMessage = "Mother name is required.")]
        public string MotherName { get; set; }
        
        [Required(ErrorMessage = "Spouse name is required.")]
        public string SpouseName { get; set; }

        [Required(ErrorMessage = "DOB is required.")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Blood group is required.")]
        public string BloodGroup { get; set; }

        [Required(ErrorMessage = "Phonenumber is required")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Emergency number is required")]
        [StringLength(15)]
        public string EmergencyPhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        //[Required]
        //public bool MedicalHistory { get; set; }

        //[Required]
        //public string IsInsured { get; set; }

        //[Required]
        //[StringLength(150)]
        //[Column(TypeName = "Varchar(150)")]
        //public string InsuranceCompany { get; set; }

        //[StringLength(30)]
        //[Column(TypeName = "Varchar(30)")]
        //public string InsuranceNumber { get; set; }

        public string isActive { get; set; } = "Yes";
        public string IsStaff { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public PatientAppointmentUIModel PatientAppointmentUIModel { get; set; }
    }

    public class PatientAppointmentUIModel
    {
        public PatientAppointmentUIModel()
        {
            DepartmentList = new List<KeyValueModel<int, string>>();
            DoctorList = new List<KeyValueModel<int, string>>();
        }
        
        [Required(ErrorMessage ="Please select Department name")]
        public int DepartmentId { get; set; }
        
        [Required(ErrorMessage ="Please select Doctor name")]
        public int DoctorId { get; set; }
        
        [Required(ErrorMessage ="Please select Appointment Date")]
        public DateTime? AppointmentOn { get; set; }

        [Required(ErrorMessage = "Please select Time Slot")]
        public TimeSlotId TimeSlotId { get; set; }

        [Required(ErrorMessage ="Select Patient type")]
        public string PatientType { get; set; }
        
        [Required(ErrorMessage ="CRM Number is required")]
        public string CRMNumber { get; set; }
        
        [Required(ErrorMessage ="Please write reason for visit")]
        public string ReasonForVisit { get; set; }

        //[Required]
        //public string DoctorNotes { get; set; }

        //[Required]
        //public DateTime? RescheduledOn { get; set; }

        //[Required]
        //public int? RescheduledTimeSlotId { get; set; }


        [Required(ErrorMessage = "Select the valid option.")]
        public List<KeyValueModel<int, string>> DepartmentList { get; set; }

        [Required(ErrorMessage = "Select the Doctor Name.")]
        public List<KeyValueModel<int, string>> DoctorList { get; set; }

        public bool isActive { get; set; } = true;
        public string Message { get; set; }
        public string Status { get; set; }

    }
    
    public enum TimeSlotId
    {
        [Display(Name = "08:00 AM - 09:00 AM")]
        Slot_08_09 = 1,

        [Display(Name = "09:00 AM - 10:00 AM")]
        Slot_09_10 = 2,

        [Display(Name = "10:00 AM - 11:00 AM")]
        Slot_10_11 = 3,

        [Display(Name = "11:00 AM - 12:00 PM")]
        Slot_11_12 = 4,

        [Display(Name = "12:00 PM - 01:00 PM")]
        Slot_12_13 = 5,

        [Display(Name = "02:00 PM - 03:00 PM")]
        Slot_14_15 = 6
    }
}
