using System.ComponentModel.DataAnnotations;

namespace VehicleRoutesBuildingWebApplication.Models.Domain
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }
        public Coordinate Coordinate { get; set; }
        public string Adress { get; set; }

        public Location()
        {

        }

        public Location(double latitude, double longitude, string adress)
        {
            Id = Guid.NewGuid();
            Coordinate = new Coordinate(latitude, longitude);
            Adress = adress;
        }
    }
}
