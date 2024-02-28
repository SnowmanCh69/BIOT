using BIO.Models;
using Microsoft.EntityFrameworkCore;

namespace BIO.Context
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Employee> TestPerformers { get; set; }
        public DbSet<GeneticTest> GeneticTests { get; set; }
        public DbSet<GeneticVariant> GeneticMutations { get; set; }

    }
}
