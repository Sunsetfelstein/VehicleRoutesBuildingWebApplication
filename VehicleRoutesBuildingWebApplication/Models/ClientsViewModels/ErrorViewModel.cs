namespace VehicleRoutesBuildingWebApplication.Models.ClientsViewModels;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}