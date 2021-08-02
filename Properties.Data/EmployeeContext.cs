using System;
using Employee.Domain;
using Microsoft.EntityFrameworkCore;


namespace Properties.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ADVILLEG-MOBL\\ALEXDB;Database=EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=true");            
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
            .HasIndex(p => new { p.FirstName, p.LastName, p.Email }).IsUnique();
        }
    }
}
