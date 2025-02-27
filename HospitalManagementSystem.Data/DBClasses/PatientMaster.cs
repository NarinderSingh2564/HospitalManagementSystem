using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class PatientMaster
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string Password { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string MaritalStatus { get; set; }

        [StringLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string FatherName { get; set; }

        [StringLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string MotherName { get; set; }
        
        [StringLength(30)]
        [Column(TypeName = "varchar(30)")] 
        public string SpouseName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(8)]
        [Column(TypeName = "varchar(8)")]
        public string BloodGroup { get; set; }

        [Required]
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string EmergencyPhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; }

        public DateTime AdmissionDate { get; set; }

        public bool MedicalHistory { get; set; }

        public bool IsInsured { get; set; }

        [StringLength(150)]
        [Column(TypeName ="Varchar(150)")]
        public string InsuranceCompany { get; set; }

        [StringLength(30)]
        [Column(TypeName = "Varchar(30)")]
        public string InsuranceNumber { get; set; }

        [StringLength(4)]
        [Column(TypeName = "varchar(4)")]
        public string IsStaff { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool isActive { get; set; }
    }
}
