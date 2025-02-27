using HospitalManagementSystem.Data.DBClasses;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<AddressMaster> AddressMasters { get; set; }
        public DbSet<DepartmentMaster> DepartmentMaster { get; set; }
        public DbSet<DesignationMaster> DesignationMaster { get; set; }
        public DbSet<UserMaster> UserMaster { get; set; }
        public DbSet<PatientMaster> PatientMaster { get; set; }
        public DbSet<PatientMedicalHistoryMaster> PatientMedicalHistoryMaster { get; set; }

    }
}
