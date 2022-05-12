using DocService.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DocService.Models.Data.Identity
{
    public class IdentityAppDbContext : IdentityDbContext
    {
         public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        
    }
}