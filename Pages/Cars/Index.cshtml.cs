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

        //sort functionality
        public string VINSort {  get; set; }
        public string ModelSort {  get; set; }
        public string TypeSort { get; set; }

        //search functionality
        public string Search { get; set; }

        public async Task OnGetAsync(string vin, int? fuelID, string sortOrder, string searchInput)
        {
            CarD = new CarData();

            VINSort = sortOrder == "vin" ? "vin_desc" : "vin";
            ModelSort = sortOrder == "model" ? "model_desc" : "model";
            TypeSort = sortOrder == "type" ? "type_desc" : "type";

            Search = searchInput;


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

            //sort
            switch (sortOrder)
            {
                case "vin_desc":
                    CarD.Cars = CarD.Cars.OrderByDescending(c => c.VIN).ToList();
                    break;

                case "vin":
                    CarD.Cars = CarD.Cars.OrderBy(c => c.VIN).ToList();
                    break;

                case "type_desc":
                    CarD.Cars = CarD.Cars.OrderByDescending(c => c.VehicleType.VehicleTypeName).ToList();
                    break;

                case "type":
                    CarD.Cars = CarD.Cars.OrderBy(c => c.VehicleType.VehicleTypeName).ToList();
                    break;

                case "model_desc":
                    CarD.Cars = CarD.Cars.OrderByDescending(c => c.VehicleModel.VehicleModelName).ToList();
                    break;

                default:
                    CarD.Cars = CarD.Cars.OrderBy(c => c.VehicleModel.VehicleModelName).ToList(); // Default: Model ascending
                    break;
            }

            //search
            if(!String.IsNullOrEmpty(searchInput))
            {
                string lowerSearchString = searchInput.ToLower();
                CarD.Cars = CarD.Cars.Where(s => 
                        s.VIN.ToLower().Contains(lowerSearchString) ||
                        s.VehicleModel.VehicleModelName.ToLower().Contains(lowerSearchString) ||
                        s.VehicleType.VehicleTypeName.ToLower().Contains(lowerSearchString)
                    );
                                            
            }
        }
    }
}
