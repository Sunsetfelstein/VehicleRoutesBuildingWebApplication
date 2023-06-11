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
using VehicleRoutesBuildingWebApplication.Models.SettingsViewModels;

namespace VehicleRoutesBuildingWebApplication.Controllers
{
    public class SettingsController : Controller
    {
        private readonly Context _context;

        public SettingsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var settings = await _context.Settings.ToListAsync();
            return View(settings);
        }

        [HttpGet]
        public IActionResult Change()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Change(ChangeSettingsViewModel changeSettingsViewModel)
        {
            var name = "Настройки";
            var capacity = changeSettingsViewModel.Capacity;
            var fuelConsumption = changeSettingsViewModel.FuelConsumption;
            var iterations = changeSettingsViewModel.Iterations;
            var fuelCost = changeSettingsViewModel.FuelCost;
            
            /*if (capacity <= 0 || fuelConsumption <= 0 || iterations <= 0)
                return RedirectToAction("Index");*/
            
            var oldVehicle = await _context.Settings.FirstOrDefaultAsync();
            
            if (oldVehicle != null)
            {
                _context.Settings.Remove(oldVehicle);
                await _context.SaveChangesAsync();
            }

            var settings = new Settings(name, capacity, fuelConsumption, iterations, fuelCost);

            await _context.Settings.AddAsync(settings);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var settings = await _context.Settings.FirstOrDefaultAsync(x => x.Id == Id);

            if (settings == null) 
                return RedirectToAction("Index");
            
            _context.Settings.Remove(settings);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
