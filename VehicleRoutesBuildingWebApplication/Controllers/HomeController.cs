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

        var points = new List<PointViewModel>();

        foreach(var client in clients) 
        {
            points.Add(new PointViewModel(client.Location, client.Name, client.PhoneNumber, client.ProductWeight, false));
        }
        foreach(var depot in depots)
        {
            var zeroWeight = 0;
            var emptyPhoneNumver = string.Empty;
            points.Add(new PointViewModel(depot.Location, depot.Name, emptyPhoneNumver, zeroWeight, true));
        }
        return View(points);
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromBody] LocationViewModel location)
    {
        var test = location;
        return RedirectToAction("Index");
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