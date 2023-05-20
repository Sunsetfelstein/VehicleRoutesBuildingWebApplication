
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace VehicleRoutesBuildingWebApplication.Models.Domain;

public class Client
{
    [Key]
    public Guid Id { get; set; }   
    public Location Location { get; set; }  
    public string Name { get; set; }  
    public string PhoneNumber { get; set; }
    public int ProductWeight { get; set; }

    public Client()
    {

    }

    public Client(double latitude, double longitude, string adress, string name, string phoneNumber, int productWeight)
    {
        Id = Guid.NewGuid();
        Location = new Location(latitude, longitude, adress);
        Name = name;
        PhoneNumber = phoneNumber;
        ProductWeight = productWeight;
    }
}