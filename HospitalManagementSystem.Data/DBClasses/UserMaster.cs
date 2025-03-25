using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class UserMaster
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
        public string PhoneNumber { get; set; }
        public bool IsDoctor { get; set; }

        [Required]
        [ForeignKey("DesignationMaster")]
        public int? DesignationId { get; set; }
        public virtual DesignationMaster DesignationMaster { get; set; }

        [Required]
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string Password { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [Required]
        [StringLength(4)]
        [Column(TypeName = "varchar(4)")]
        public string IsStaff { get; set; }
        public bool isActive { get; set; }
    }
}
