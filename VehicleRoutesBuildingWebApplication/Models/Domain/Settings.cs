using System.ComponentModel.DataAnnotations;

namespace VehicleRoutesBuildingWebApplication.Models.Domain
{
    public class Settings
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double FuelConsumption { get; set; }
        public int Iterations { get; set; }
        public int FuelCost { get; set; }
        
        public Settings()
        {

        }

        public Settings(string name, int capacity, double fuelConsumption, int iterations, int fuelCost)
        {
            Id = Guid.NewGuid();
            Name = name;
            Capacity = capacity;
            FuelConsumption = fuelConsumption;
            Iterations = iterations;
            FuelCost = fuelCost;
        }
    }
}
