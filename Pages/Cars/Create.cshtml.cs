using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MelisaIuliaProiect.Data;
using MelisaIuliaProiect.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;


namespace MelisaIuliaProiect.Pages.Cars
{
    [Authorize(Roles="Admin")]
    public class CreateModel : CarFuelsPageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public CreateModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SellerID"] = new SelectList(_context.Set<Seller>(), "ID", "SellerName");
            ViewData["EquipmentID"] = new SelectList(_context.Set<Equipment>(), "ID", "EquipmentName");
            ViewData["FuelID"] = new SelectList(_context.Set<Fuel>(), "ID", "FuelName");
            ViewData["TransmissionID"] = new SelectList(_context.Set<Transmission>(), "ID", "TransmissionName");
            ViewData["VehicleModelID"] = new SelectList(_context.Set<VehicleModel>(), "ID", "VehicleModelName");
            ViewData["VehicleTypeID"] = new SelectList(_context.Set<VehicleType>(), "ID", "VehicleTypeName");

            var car = new Car();
            car.CarFuels = new List<CarFuel>();
            PopulateAssignedFuelData(_context, car);

            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedFuels)
        {
            var newCar = new Car();

            if (selectedFuels != null)
            {
                newCar.CarFuels = new List<CarFuel>();
                foreach (var fuel in selectedFuels)
                {
                    var fuelToAdd = new CarFuel
                    {
                        FuelID = int.Parse(fuel)
                    };
                    newCar.CarFuels.Add(fuelToAdd);
                }
            }

            Car.CarFuels = newCar.CarFuels;

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
