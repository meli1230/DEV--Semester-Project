using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Seller
    {
        public int ID {  get; set; }

        [Display(Name = "Seller")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(100, ErrorMessage = "Requirements: at most 100 characters")]
        public string SellerName { get; set; }
        public ICollection<Car>? Cars { get; set; } //navigation property
    }
}
