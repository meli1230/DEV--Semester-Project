using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Seller
    {
        public int ID {  get; set; }

        [Display(Name = "Seller")]
        public string SellerName { get; set; }
        public ICollection<Car>? Cars { get; set; } //navigation property
    }
}
