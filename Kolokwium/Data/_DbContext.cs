using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Data;

public class _DbContext: DbContext
{
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    public DbSet<AvailableProgram>  AvailablePrograms { get; set; }
    public DbSet<_Program> Programs { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    
    
    public _DbContext(DbContextOptions<_DbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "555-555-555"},
            new Customer {  CustomerId = 2, FirstName = "Jack", LastName = "Doe", PhoneNumber = null},
            new Customer {  CustomerId = 3, FirstName = "Julie", LastName = "Doe", PhoneNumber = "555-555-666"}
        });
        modelBuilder.Entity<_Program>().HasData(new List<_Program>
        {
            new _Program { ProgramId  =1, Name = "First", DurationMinutes = 90, TemperatureCelsius = 40},
            new _Program { ProgramId  =2, Name = "Second", DurationMinutes = 120, TemperatureCelsius = 30},
            new _Program {ProgramId  =3, Name = "Third", DurationMinutes = 60, TemperatureCelsius = 60 }
        });
        modelBuilder.Entity<WashingMachine>().HasData(new List<WashingMachine>
        {
            new WashingMachine { WashingMachineId = 1, MaxWeight = 30, SerialNumber = "1111"},
            new WashingMachine { WashingMachineId = 2, MaxWeight = 20, SerialNumber = "2222"},
            new WashingMachine { WashingMachineId = 3, MaxWeight = 25, SerialNumber = "3333"}
        });
        modelBuilder.Entity<AvailableProgram>().HasData(new List<AvailableProgram>
        {
            new AvailableProgram { AvailableProgramId = 1, ProgramId = 1, WashingMachineId = 1, Price = 30.0},
            new AvailableProgram { AvailableProgramId = 2, ProgramId = 2, WashingMachineId = 2, Price = 25.0},
            new AvailableProgram { AvailableProgramId = 3, ProgramId = 3, WashingMachineId = 3, Price = 20.0}
        });
        modelBuilder.Entity<PurchaseHistory>().HasData(new List<PurchaseHistory>
        {
            new PurchaseHistory { AvailableProgramId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2021-09-01"), Rating = null},
            new PurchaseHistory {AvailableProgramId = 2, CustomerId = 1, PurchaseDate = DateTime.Parse("2021-09-10"), Rating = 5 },
            new PurchaseHistory {AvailableProgramId = 3, CustomerId = 2, PurchaseDate = DateTime.Parse("2021-09-11"), Rating = null },
            new PurchaseHistory {AvailableProgramId = 2, CustomerId = 3, PurchaseDate = DateTime.Parse("2021-09-12"), Rating = 6 }
        });
        
        
    }
}