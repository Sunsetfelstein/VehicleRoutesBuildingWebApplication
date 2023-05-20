using VehicleRoutesBuildingWebApplication.Models.Domain;

namespace VehicleRoutesBuildingWebApplication.Models.ClientsViewModels
{
    public class AddClientViewModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Coordinates { get; set; }
        public int ProductWeight { get; set; }
    }
}
