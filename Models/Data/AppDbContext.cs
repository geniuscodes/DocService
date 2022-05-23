using System;
using DocService.Models.Entities;
using DocService.Models.Entities.Departments;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DocService.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<LineManger> LineManagers { get; set; }
        public DbSet<Digital> Digital { get; set; }
        public DbSet<Medicine> MedicineDept { get; set; }
        public DbSet< Patient> Patients { get; set; }
        
        

        
        
    }
}