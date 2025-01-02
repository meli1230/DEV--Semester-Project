using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MelisaIuliaProiect.Data;
using MelisaIuliaProiect.Models;

namespace MelisaIuliaProiect.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public DeleteModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
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
                //.Include(b => b.Fuel)
                .Include(b => b.Seller)
                .Include(b => b.Transmission)
                .Include(b => b.VehicleModel)
                .Include(b => b.VehicleType)
                .Include(b => b.CarFuels).ThenInclude(cf => cf.Fuel)
                .FirstOrDefaultAsync(m => m.VIN == id);
            

            if (Car == null)
            {
                return NotFound();
            }
            //else
            //{
            //    Car = car;
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(b => b.Equipment)
                //.Include(b => b.Fuel)
                .Include(b => b.Seller)
                .Include(b => b.Transmission)
                .Include(b => b.VehicleModel)
                .Include(b => b.VehicleType)
                .FirstOrDefaultAsync(m => m.VIN == id);

            //var car = await _context.Car.FindAsync(id);

            if (car != null)
            {
                Car = car;
                _context.Car.Remove(Car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
