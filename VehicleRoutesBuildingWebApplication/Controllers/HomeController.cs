using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleRoutesBuildingWebApplication.Data;
using VehicleRoutesBuildingWebApplication.Models;
using VehicleRoutesBuildingWebApplication.Models.ClientsViewModels;
using VehicleRoutesBuildingWebApplication.Models.Domain;
using VehicleRoutesBuildingWebApplication.Models.HomeViewModels;

namespace VehicleRoutesBuildingWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Context _context;

    public HomeController(ILogger<HomeController> logger, Context context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var clients = await _context.Clients.Include(x => x.Location).ToListAsync();
        var depots = await _context.Depots.Include(x => x.Location).ToListAsync();
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync();
        
        var capacity = vehicle?.Capacity ?? 0;
        var fuelConsumption = vehicle?.FuelConsumption ?? 0.0;
        var iterations = vehicle?.Iterations ?? 0;

        var points = clients.Select(client => new PointViewModel(client.Location, client.Name, client.PhoneNumber, client.ProductWeight, false, capacity, fuelConsumption, iterations)).ToList();

        foreach(var depot in depots)
        {
            const int zeroWeight = 0;
            var emptyPhoneNumber = string.Empty;
            points.Add(new PointViewModel(depot.Location, depot.Name, emptyPhoneNumber, zeroWeight, true, capacity, fuelConsumption, iterations));
        }

        return View(points);
    }

    [HttpPost]
    public Task<IActionResult> Index([FromBody] LocationViewModel location)
    {
        var test = location;
        return Task.FromResult<IActionResult>(RedirectToAction("Index"));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}