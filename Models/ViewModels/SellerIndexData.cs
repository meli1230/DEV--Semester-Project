using System.Collections.Generic;

namespace MelisaIuliaProiect.Models.ViewModels
{
    public class SellerIndexData
    {
        public IEnumerable<Seller> Sellers { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
