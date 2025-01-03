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
                .Include (t => t.Car)
                    .ThenInclude(t => t.VehicleModel)
                .Include (t=> t.Car)
                    .ThenInclude(t => t.Transmission)
                .Include(t => t.Car)
                    .ThenInclude(t => t.Seller)
                .Include(t => t.Customer)
                .ToListAsync();
        }
    }
}
