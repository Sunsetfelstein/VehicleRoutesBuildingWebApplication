using Microsoft.EntityFrameworkCore;
using VehicleRoutesBuildingWebApplication.Models.Domain;

namespace VehicleRoutesBuildingWebApplication.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public DbSet<Depot> Depots { get; set; }
}