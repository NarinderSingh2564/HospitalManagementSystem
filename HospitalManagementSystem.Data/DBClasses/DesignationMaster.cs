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
        public virtual DepartmentMaster DepartmentMaster { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string DesignationName { get; set; }

        [Required]
        [Column(TypeName = "varchar(8)")]
        public string DesignationCode { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
