using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class DepartmentMaster
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        [Column(TypeName = "varchar(60)")]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(8)]
        [Column(TypeName ="varchar(8)")]
        public string DepartmentCode { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
