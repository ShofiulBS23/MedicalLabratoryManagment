using MedicalLabratoryManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalLabratoryManagment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<OrderDetials> OrderDetials { get; set; }
    }
}
