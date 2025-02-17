using HospitalManagementSystem.Data.DBClasses;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<DepartmentMaster> DepartmentMaster { get; set; }
        public DbSet<DesignationMaster> DesignationMaster { get; set; }

        public DbSet<UserMaster> UserMaster { get; set; }
        public DbSet<AddressMaster> AddressMasters { get; set; }

    }
}
