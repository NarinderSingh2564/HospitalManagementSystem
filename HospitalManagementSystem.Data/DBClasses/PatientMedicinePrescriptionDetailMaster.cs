using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.DBClasses
{
    public  class PatientMedicinePrescriptionDetailMaster
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

        [ForeignKey("MedicineMaster")]
        public int MedicineId { get; set; }
        public virtual MedicineMaster MedicineMaster { get; set; }

        public decimal DosageQuantity { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string DosageUnit { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Frequency { get; set; }

        public int FrequencyUnit { get;set; }


        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Timing { get; set; }

        public int duration { get; set; }


        [StringLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Instructions { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
