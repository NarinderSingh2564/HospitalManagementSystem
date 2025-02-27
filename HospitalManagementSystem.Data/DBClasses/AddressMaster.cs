using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class AddressMaster
    {
        public int Id { get; set; }

        [ForeignKey("UserMaster")]
        public int? UserId { get; set; }
        public UserMaster UserMaster { get; set; }

        [ForeignKey("PatientMaster")]
        public int? PatientId { get; set; }
        public PatientMaster PatientMaster { get; set; }

        [Required]
        [StringLength(6)]
        [Column(TypeName = "varchar(6)")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string City { get; set; }

        [Required]
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool isActive { get; set; }
    }
}
