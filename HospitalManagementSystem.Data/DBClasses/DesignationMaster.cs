using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class DesignationMaster
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("DepartmentMaster")]
        public int DepartmentId { get; set; }
        public DepartmentMaster DepartmentMaster { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string DesignationName { get; set; }

        [Required]
        [StringLength(8)]
        [Column(TypeName = "varchar(8)")]
        public string DesignationCode { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
