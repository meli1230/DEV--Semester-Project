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

namespace MelisaIuliaProiect.Pages.TestDrives
{
    public class EditModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public EditModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TestDrive TestDrive { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TestDrive = await _context.TestDrive
                .Include(td => td.Customer) 
                .Include(td => td.Car)
                    .ThenInclude(c => c.VehicleModel)
                .Include(td => td.Car)
                    .ThenInclude(c => c.Transmission)
                .Include(td => td.Car)
                    .ThenInclude(c => c.Seller)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (TestDrive == null)
            {
                return NotFound();
            }

            var carList = _context.Car
                .Include(c => c.VehicleModel)
                .Include(c => c.Transmission)
                .Include(c => c.Seller)
                .Select(x => new
                {
                    x.VIN,
                    CarSpecs =
                        x.VehicleModel.VehicleModelName + " - " +
                        x.Transmission.TransmissionName + " - " +
                        x.HorsePower + " PS - " +
                        x.Seller.SellerName
                })
                .ToList();

            //TestDrive = testdrive;
            ViewData["CarVIN"] = new SelectList(carList, "VIN", "CarSpecs");
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TestDrive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestDriveExists(TestDrive.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TestDriveExists(int id)
        {
            return _context.TestDrive.Any(e => e.ID == id);
        }
    }
}
