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

        public PointViewModel(Location location, string name, string phoneNumber, int productWeight, bool isDepot)
        {
            Location = location;
            Name = name;
            PhoneNumber = phoneNumber;
            ProductWeight = productWeight;
            IsDepot = isDepot;
        }
    }
}
