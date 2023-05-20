using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace VehicleRoutesBuildingWebApplication.Models.Domain
{
    public class Depot
    {
        [Key]
        public Guid Id { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }

        public Depot()
        {
                
        }

        public Depot(double latitude, double longitude, string adress, string name)
        {
            Id = Guid.NewGuid();
            Location = new Location(latitude, longitude, adress);
            Name = name;
        }
    }
}
