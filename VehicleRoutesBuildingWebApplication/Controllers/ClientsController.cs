using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleRoutesBuildingWebApplication.Data;
using VehicleRoutesBuildingWebApplication.Models.ClientsViewModels;
using VehicleRoutesBuildingWebApplication.Models.Domain;

namespace VehicleRoutesBuildingWebApplication.Controllers
{
    public class ClientsController : Controller
    {
        private readonly Context _context;

        public ClientsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clients = await _context.Clients.Include(x => x.Location).ToListAsync();
            return View(clients);
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
    string name,
    string phoneNumber,
    int productWeight)
         {
             if (string.IsNullOrEmpty(coordinates) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address)
                 || productWeight <= 0)
                 return RedirectToAction("Index");

            var coordinatesList = coordinates.Split(',').ToList();

            var latitude = double.Parse(coordinatesList[CoordinatesIndex.Latitude], CultureInfo.InvariantCulture);

            var longitude = double.Parse(coordinatesList[CoordinatesIndex.Longitude], CultureInfo.InvariantCulture);

            var client = new Client(latitude, longitude, address, name, phoneNumber, productWeight);

            var location = client.Location;

            await _context.Locations.AddAsync(location);
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            // получаем URL-адрес действия, на которое нужно перенаправиться
            var redirectUrl = Url.Action("Index", "Clients");

            Console.WriteLine("Перенаправление на URL-адрес: " + redirectUrl);

            // возвращаем URL-адрес в формате JSON
            return Json(new { redirectToUrl = redirectUrl });
        }   

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var client = await _context.Clients.Include(x => x.Location).FirstOrDefaultAsync(x => x.Id == Id);

            if (client != null)
            {
                _context.Locations.Remove(client.Location);
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
