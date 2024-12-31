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
    }
}
