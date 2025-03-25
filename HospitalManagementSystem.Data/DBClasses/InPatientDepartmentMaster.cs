using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class InPatientDepartmentMaster
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

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string WardNumber { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string BedNumber { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; }
        public DateTime? AdmittedOn { get; set; }

        public bool? IsSurgery { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string SurgeryName { get; set; }

        public DateTime? SurgeryOn { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string SurgeryStatus { get; set; }

        public bool? IsDischarged { get; set; }
        public DateTime? DischargerOn { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
