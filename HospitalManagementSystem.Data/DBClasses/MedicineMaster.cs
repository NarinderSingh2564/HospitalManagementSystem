using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.DBClasses
{
    public class MedicineMaster
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string MedicineName { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string MedicineForm  { get; set; }

        [StringLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        public DateTime ExpiryDate { get; set; }

        public decimal PricePerUnit { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
