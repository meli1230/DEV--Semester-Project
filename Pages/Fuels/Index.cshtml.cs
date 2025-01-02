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

namespace MelisaIuliaProiect.Pages.Fuels
{
    public class IndexModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public IndexModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        public IList<Fuel> Fuel { get;set; } = default!;

        //select functionality
        public FuelIndexData FuelData { get; set; }
        public int FuelID { get; set; }
        public string VIN { get; set; }

        public async Task OnGetAsync(int? id, string? carVIN)
        {
            FuelData = new FuelIndexData();
            FuelData.Fuels = await _context.Fuel
                .Include(s => s.CarFuels)
                    .ThenInclude(cf => cf.Car)
                        .ThenInclude(c => c.VehicleModel) // Include VehicleModel
                .OrderBy(s => s.FuelName) // Order by FuelName
                .ToListAsync();

            if (id != null)
            {
                FuelID = id.Value;
                Fuel fuel = FuelData.Fuels
                    .Where(s => s.ID == id.Value)
                    .Single();
                FuelData.Cars = fuel.CarFuels
                    .Select(cf => cf.Car)
                    .ToList();
            }
        }


        //public async Task OnGetAsync()
        //{
        //    Fuel = await _context.Fuel.ToListAsync();
        //}
    }
}
