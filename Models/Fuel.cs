using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Fuel
    {
        //ID
        public int ID { get; set; }

        //Model name
        [Display(Name = "Fuel")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Requirements: at most 50 characters")]
        public string FuelName { get; set; } //ex: Petrol, Electric, Hybrid

        public ICollection<CarFuel>? CarFuels { get; set; } //navigation property
    }
}
