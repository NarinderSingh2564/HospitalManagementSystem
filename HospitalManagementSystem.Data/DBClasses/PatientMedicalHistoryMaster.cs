using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class PatientMedicalHistoryMaster
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("PatientMaster")]
        public int PatientId { get; set; }
        public PatientMaster PatientMaster { get; set; }

        [Required]
        [StringLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Disease { get; set; }

        [Required]
        [StringLength(250)]
        [Column(TypeName = "varchar(250)")]
        public string TreatmentBy { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        [Required]
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string Status { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool isActive { get; set; }
    }
}
