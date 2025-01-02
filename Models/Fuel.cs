using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Fuel
    {
        //ID
        public int ID { get; set; }

        //Model name
        [Display(Name = "Fuel")]
        [Required]
        public string FuelName { get; set; } //ex: Petrol, Electric, Hybrid

        public ICollection<CarFuel>? CarFuels { get; set; } //navigation property
    }
}
