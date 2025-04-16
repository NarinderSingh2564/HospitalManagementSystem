using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class PatientAppointmentMaster
    {
        public int Id { get; set; }

        [ForeignKey("PatientMaster")]
        public int PatientId { get; set; }
        public virtual PatientMaster PatientMaster { get; set; }

        [ForeignKey("DepartmentMaster")]
        public int DepartmentId { get; set; }
        public virtual DepartmentMaster DepartmentMaster { get; set; }

        [ForeignKey("UserMaster")]
        public int DoctorId { get; set; }
        public virtual UserMaster UserMaster { get; set; }
        public DateTime AppointmentOn { get; set; }
        public int TimeSlotId { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string PatientType { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string CRMNumber { get; set; }

        [StringLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string ReasonForVisit { get; set; }

        [StringLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string DoctorNotes { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; } = "Scheduled";
        public DateTime? RescheduledOn { get; set; }
        public int? RescheduledTimeSlotId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
