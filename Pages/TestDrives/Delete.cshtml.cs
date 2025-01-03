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
    public class DeleteModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public DeleteModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testdrive = await _context.TestDrive.FindAsync(id);
            if (testdrive != null)
            {
                TestDrive = testdrive;
                _context.TestDrive.Remove(TestDrive);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
