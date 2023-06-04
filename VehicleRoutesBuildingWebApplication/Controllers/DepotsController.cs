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
using VehicleRoutesBuildingWebApplication.Models.DepotViewModels;
using VehicleRoutesBuildingWebApplication.Models.Domain;

namespace VehicleRoutesBuildingWebApplication.Controllers
{
    public class DepotsController : Controller
    {
        private readonly Context _context;

        public DepotsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var depots = await _context.Depots.Include(x => x.Location).ToListAsync();
            return View(depots);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        private static class CoordinatesIndex
        {
            public const int Latitude = 0;
            public const int Longitude = 1;
        }

        [HttpPost]
        public async Task<IActionResult> Add(string coordinates,
    string address,
    string name)
        {
            if (string.IsNullOrEmpty(coordinates) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address))
                return RedirectToAction("Index");

            var coordinatesList = coordinates.Split(',').ToList();

            var latitude = double.Parse(coordinatesList[CoordinatesIndex.Latitude], CultureInfo.InvariantCulture);

            var longitude = double.Parse(coordinatesList[CoordinatesIndex.Longitude], CultureInfo.InvariantCulture);

            var depot = new Depot(latitude, longitude, address, name);

            var location = depot.Location;

            await _context.Locations.AddAsync(location);
            await _context.Depots.AddAsync(depot);
            await _context.SaveChangesAsync();

            // получаем URL-адрес действия, на которое нужно перенаправиться
            var redirectUrl = Url.Action("Index", "Depots");

            Console.WriteLine("Перенаправление на URL-адрес: " + redirectUrl);

            // возвращаем URL-адрес в формате JSON
            return Json(new { redirectToUrl = redirectUrl });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var depot = await _context.Depots.Include(x => x.Location).FirstOrDefaultAsync(x => x.Id == Id);

            if (depot != null)
            {
                _context.Locations.Remove(depot.Location);
                _context.Depots.Remove(depot);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
