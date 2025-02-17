using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class AddressMaster
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(6)")]
        public string PostalCode { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string State { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Country { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Required]
        [ForeignKey("UserMaster")]
        public int UserId { get; set; }
        public UserMaster UserMaster { get; set; }

    }
}
