using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorApplicationForm.DataAccess.EntityFramework
{
    public class BloodBankDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Donation> Donation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

            optionsBuilder.UseSqlServer(BloodBankDbConnection.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Donation>().HasKey(i => new { i.PersonId, i.At });
        }

        public static readonly LoggerFactory MyLoggerFactory
    = new LoggerFactory(new[] { new DebugLoggerProvider() });
    }

    /// <summary>
    /// Object-relational mapping to Person database table.
    /// </summary>
    public class Person
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int BloodGroup { get; set; }
        public DateTime BirthDate { get; set; }
    }

    /// <summary>
    /// Object-relational mapping to Donation database table.
    /// </summary>
    public class Donation
    {
        public Guid PersonId { get; set; }
        public DateTime At { get; set; }
        public double Milliliters { get; set; }
    }
}
