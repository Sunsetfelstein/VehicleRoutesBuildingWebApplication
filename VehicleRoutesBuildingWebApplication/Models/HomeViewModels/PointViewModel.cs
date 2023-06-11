using VehicleRoutesBuildingWebApplication.Models.Domain;

namespace VehicleRoutesBuildingWebApplication.Models.HomeViewModels
{
    public class PointViewModel
    {
        public Location Location { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int ProductWeight { get; set; }
        public bool IsDepot { get; set; }
        public int Capacity { get; set; }
        public double FuelConsumption { get; set; }
        
        public int FuelCost { get; set; }
        public int Iterations { get; set; }

        public PointViewModel(Location location, string name, string phoneNumber, int productWeight, bool isDepot, int capacity, double fuelConsumption, int iterations, int fuelCost)
        {
            Location = location;
            Name = name;
            PhoneNumber = phoneNumber;
            ProductWeight = productWeight;
            IsDepot = isDepot;
            Capacity = capacity;
            FuelConsumption = fuelConsumption;
            Iterations = iterations;
            FuelCost = fuelCost;
        }
    }
}
