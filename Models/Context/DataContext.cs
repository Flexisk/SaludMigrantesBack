using BackSaludMigrantes.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackSaludMigrantes.Models.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MigrantsAcreditadom>().HasNoKey().ToView("MIGRANTES_ACREDITADOM");
        }

        public DbSet<Location> Location { get; set; }
        public DbSet<MigrantsAcreditadom> MigrantsAcreditadom { get; set; }
        public DbSet<MigrantsStatements> MigrantsStatements { get; set; }

    }
}
