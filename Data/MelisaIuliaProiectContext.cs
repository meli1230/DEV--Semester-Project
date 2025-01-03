using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MelisaIuliaProiect.Models;

namespace MelisaIuliaProiect.Data
{
    public class MelisaIuliaProiectContext : DbContext
    {
        public MelisaIuliaProiectContext (DbContextOptions<MelisaIuliaProiectContext> options)
            : base(options)
        {
        }

        public DbSet<MelisaIuliaProiect.Models.Car> Car { get; set; } = default!;
        public DbSet<MelisaIuliaProiect.Models.Seller> Seller { get; set; } = default!;
        public DbSet<MelisaIuliaProiect.Models.Equipment> Equipment { get; set; } = default!;
        public DbSet<MelisaIuliaProiect.Models.Fuel> Fuel { get; set; } = default!;
        public DbSet<MelisaIuliaProiect.Models.Transmission> Transmission { get; set; } = default!;
        public DbSet<MelisaIuliaProiect.Models.VehicleModel> VehicleModel { get; set; } = default!;
        public DbSet<MelisaIuliaProiect.Models.VehicleType> VehicleType { get; set; } = default!;
        public DbSet<MelisaIuliaProiect.Models.Customer> Customer { get; set; } = default!;
        public DbSet<MelisaIuliaProiect.Models.TestDrive> TestDrive { get; set; } = default!;
    }
}
