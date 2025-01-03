using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MelisaIuliaProiect.Data;
using MelisaIuliaProiect.Models;
using Microsoft.EntityFrameworkCore;

namespace MelisaIuliaProiect.Pages.TestDrives
{
    public class CreateModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public CreateModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var carList = _context.Car
                .Include(b => b.VehicleModel)
                .Include(b => b.Transmission)
                .Include(b => b.Seller)
                .Select(c => new
                {
                    c.VIN,
                    CarSpecs = c.VehicleModel.VehicleModelName + " " + 
                        c.Transmission.TransmissionName + " " +
                        c.HorsePower + " PS sold by" +
                        c.Seller.SellerName
                });

            ViewData["CarVIN"] = new SelectList(carList, "VIN", "CarSpecs");
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "FullName");

            return Page();
        }

        [BindProperty]
        public TestDrive TestDrive { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TestDrive.Add(TestDrive);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
