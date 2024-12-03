using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure;

public class AMContext : DbContext
{
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Traveller> Travellers { get; set; }
    public DbSet<Staff> Staffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=AirportManagementDB;Integrated Security=true;
              MultipleActiveResultSets=true");
        base.OnConfiguring(optionsBuilder);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlaneConfiguration());
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        modelBuilder.ApplyConfiguration(new PassengerConfiguration());
        // modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
        // Configurer les propriétés commençant par "code" comme clés primaires
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var codeProperties = entityType.ClrType.GetProperties()
                .Where(p => p.Name.StartsWith("code", StringComparison.OrdinalIgnoreCase));

            foreach (var property in codeProperties)
            {
                modelBuilder.Entity(entityType.ClrType)
                    .HasKey(property.Name);
            }
        }
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //Le type des colonnes correspondantes à ces propriétés dans la base de données doit être “date” à la place de type par défaut “datetime2”

        configurationBuilder.Properties<DateTime>().HaveColumnType("date");

        // toutes les prop de type string ne dépassent pas 250

        configurationBuilder.Properties<string>().HaveMaxLength(250);

        //// toutes les prop qui commencent par "code" sont des clés primaires
        //configurationBuilder.Properties<string>()
        //.Where(prop => prop.Name.StartsWith("code", StringComparison.OrdinalIgnoreCase))
        //.AreKey();
    }
}
        