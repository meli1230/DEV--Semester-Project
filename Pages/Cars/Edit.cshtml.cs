using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MelisaIuliaProiect.Data;
using MelisaIuliaProiect.Models;

namespace MelisaIuliaProiect.Pages.Cars
{
    public class EditModel : CarFuelsPageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public EditModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car
                .Include(b => b.Equipment)
                .Include (b => b.CarFuels).ThenInclude(b => b.Fuel)
                .Include(b => b.Seller)
                .Include(b => b.Transmission)
                .Include(b => b.VehicleModel)
                .Include(b => b.VehicleType)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.VIN == id);

            if (Car == null)
            {
                return NotFound();
            }

            PopulateAssignedFuelData(_context, Car);

            ViewData["SellerID"] = new SelectList(_context.Set<Seller>(), "ID", "SellerName");
            ViewData["EquipmentID"] = new SelectList(_context.Set<Equipment>(), "ID", "EquipmentName");
            ViewData["FuelID"] = new SelectList(_context.Set<Fuel>(), "ID", "FuelName");
            ViewData["TransmissionID"] = new SelectList(_context.Set<Transmission>(), "ID", "TransmissionName");
            ViewData["VehicleModelID"] = new SelectList(_context.Set<VehicleModel>(), "ID", "VehicleModelName");
            ViewData["VehicleTypeID"] = new SelectList(_context.Set<VehicleType>(), "ID", "VehicleTypeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string id, string[] selectedFuels)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carToUpdate = await _context.Car
                .Include(b => b.Equipment)
                .Include(b => b.CarFuels).ThenInclude(b => b.Fuel)
                .Include(b => b.Seller)
                .Include(b => b.Transmission)
                .Include(b => b.VehicleModel)
                .Include(b => b.VehicleType)
                .FirstOrDefaultAsync(m => m.VIN == id);

            if (carToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Car>(
                carToUpdate,
                "Car",
                c => c.HorsePower, 
                c => c.Torque, 
                c => c.Autonomy, 
                c => c.Price,
                c => c.EquipmentID, 
                c => c.SellerID, 
                c => c.TransmissionID,
                c => c.VehicleModelID, 
                c => c.VehicleTypeID
                ))
            {
                UpdateCarFuels(_context, selectedFuels, carToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateCarFuels(_context, selectedFuels, carToUpdate);
            PopulateAssignedFuelData(_context, carToUpdate);

            return Page();
        }
    }
}
