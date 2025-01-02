using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MelisaIuliaProiect.Data;
using MelisaIuliaProiect.Models;
using MelisaIuliaProiect.Models.ViewModels;

namespace MelisaIuliaProiect.Pages.Transmissions
{
    public class IndexModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public IndexModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        public IList<Transmission> Transmission { get;set; } = default!;

        //select functionality
        public TransmissionIndexData TransmissionData { get; set; }
        public int TransmissionID { get; set; }
        public string VIN { get; set; }

        public async Task OnGetAsync(int? id, string? carVIN)
        {
            TransmissionData = new TransmissionIndexData();
            TransmissionData.Transmissions = await _context.Transmission
                .Include(s => s.Cars) // Include Cars as per Transmission class
                    .ThenInclude(c => c.VehicleModel) // Include VehicleModel
                .OrderBy(s => s.TransmissionName) // Order by TransmissionName
                .ToListAsync();

            if (id != null)
            {
                TransmissionID = id.Value;
                Transmission transmission = TransmissionData.Transmissions
                    .Where(s => s.ID == id.Value)
                    .Single();
                TransmissionData.Cars = transmission.Cars;
            }
        }
    }
}
