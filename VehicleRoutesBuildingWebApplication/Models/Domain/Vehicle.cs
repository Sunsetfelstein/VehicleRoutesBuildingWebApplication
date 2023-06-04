using System.ComponentModel.DataAnnotations;

namespace VehicleRoutesBuildingWebApplication.Models.Domain
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double FuelConsumption { get; set; }
        public int Iterations { get; set; }


        public Vehicle()
        {

        }

        public Vehicle(string name, int capacity, double fuelConsumption, int iterations)
        {
            Id = Guid.NewGuid();
            Name = name;
            Capacity = capacity;
            FuelConsumption = fuelConsumption;
            Iterations = iterations;
        }
    }
}
