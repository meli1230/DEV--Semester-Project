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
    public class IndexModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public IndexModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        public IList<TestDrive> TestDrive { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TestDrive = await _context.TestDrive
                 .Include(td => td.Car)
                     .ThenInclude(c => c.VehicleModel)
                .Include(td => td.Car)
                    .ThenInclude(c => c.Transmission)
                .Include(td => td.Car)
                    .ThenInclude(c => c.Seller)
                .Include(td => td.Customer)
                .ToListAsync();
        }
    }
}
