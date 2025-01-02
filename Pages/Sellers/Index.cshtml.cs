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

namespace MelisaIuliaProiect.Pages.Sellers
{
    public class IndexModel : PageModel
    {
        private readonly MelisaIuliaProiect.Data.MelisaIuliaProiectContext _context;

        public IndexModel(MelisaIuliaProiect.Data.MelisaIuliaProiectContext context)
        {
            _context = context;
        }

        public IList<Seller> Seller { get;set; } = default!;

        //select functionality
        public SellerIndexData SellerData { get;set; }
        public int SellerID { get;set; }
        public string VIN {  get;set; }


        public async Task OnGetAsync(int? id, string? carVIN)
        {
            SellerData = new SellerIndexData();
            SellerData.Sellers = await _context.Seller
                .Include(s => s.Cars) // Include Cars as per Seller class
                    .ThenInclude(c => c.VehicleModel) // Include VehicleModel
                .OrderBy(s => s.SellerName) // Order by SellerName
                .ToListAsync();

            if (id != null)
            {
                SellerID = id.Value;
                Seller seller = SellerData.Sellers
                    .Where(s => s.ID == id.Value)
                    .Single();
                SellerData.Cars = seller.Cars;
            }
        }
    }
}
