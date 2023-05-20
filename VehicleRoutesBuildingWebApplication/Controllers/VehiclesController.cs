using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleRoutesBuildingWebApplication.Data;
using VehicleRoutesBuildingWebApplication.Models.ClientsViewModels;
using VehicleRoutesBuildingWebApplication.Models.Domain;
using VehicleRoutesBuildingWebApplication.Models.VehicleViewModels;

namespace VehicleRoutesBuildingWebApplication.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Context _context;

        public VehiclesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return View(vehicles);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddVehicleViewModel addVehicleViewModel)
        {
            var name = addVehicleViewModel.Name;
            var capacity = addVehicleViewModel.Capacity;
            var fuelConsumption = addVehicleViewModel.FuelConsumption;

            var vehicle = new Vehicle(name, capacity, fuelConsumption);

            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == Id);

            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
