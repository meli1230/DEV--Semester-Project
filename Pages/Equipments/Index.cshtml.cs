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

namespace MelisaIuliaProiect.Pages.Equipments
{
    public class IndexModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public IndexModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        public IList<Equipment> Equipment { get; set; } = default!;

        //select functionality
        public EquipmentIndexData EquipmentData { get; set; }
        public int EquipmentID { get; set; }
        public string VIN { get; set; }

        public async Task OnGetAsync(int? id, string? carVIN)
        {
            EquipmentData = new EquipmentIndexData();
            EquipmentData.Equipments = await _context.Equipment
                .Include(s => s.Cars) // Include Cars as per Equipment class
                    .ThenInclude(c => c.VehicleModel) // Include VehicleModel
                .OrderBy(s => s.EquipmentName) // Order by EquipmentName
                .ToListAsync();

            if (id != null)
            {
                EquipmentID = id.Value;
                Equipment equipment = EquipmentData.Equipments
                    .Where(s => s.ID == id.Value)
                    .Single();
                EquipmentData.Cars = equipment.Cars;
            }
        }

        //public async Task OnGetAsync()
        //{
        //    Equipment = await _context.Equipment.ToListAsync();
        //}
    }
}
