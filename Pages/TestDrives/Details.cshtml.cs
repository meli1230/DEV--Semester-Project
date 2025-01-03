using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MelisaIuliaProiect.Data;
using MelisaIuliaProiect.Models;

namespace MelisaIuliaProiect.Pages.TestDrives
{
    public class DetailsModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public DetailsModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

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

            return Page();
        }
    }
}
