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
    public class IndexModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public IndexModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }
        public CarData CarD {  get;set; }
        public string CarVIN {  get; set; }
        public int FuelID { get; set; }

        public async Task OnGetAsync(string vin, int? fuelID)
        {
            CarD = new CarData();

            CarD.Cars = await _context.Car
                .Include(b => b.Seller)
                .Include(b => b.Equipment)
                .Include(c => c.CarFuels).ThenInclude(cf => cf.Fuel)
                .Include(b => b.Transmission)
                .Include(b => b.VehicleModel)
                .Include(b => b.VehicleType)
                .AsNoTracking()
                .OrderBy(c => c.VIN)
                .ToListAsync();

            if (vin != null)
            {
                CarVIN = vin;
                Car car = CarD.Cars
                    .Where(c => c.VIN == vin)
                    .Single();
                CarD.Fuels = car.CarFuels.Select(cf => cf.Fuel);
            }
        }
    }
}
