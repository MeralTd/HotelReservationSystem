using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Context;

public class DataContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<ReservationHotelEntity> ReservationHotels { get; set; }

    public DataContext()
    {

    }
    public DataContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DBConnectionString"));
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HotelReservationDb;Username=postgres;Password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }



}
