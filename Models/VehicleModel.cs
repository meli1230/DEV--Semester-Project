using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class VehicleModel
    {
        //ID
        public int ID { get; set; }

        //Model name
        [Display(Name = "Model")]
        [Required]
        public string VehicleModelName { get; set; } //ex: C-HR, Camry, RAV4

        public ICollection<Car>? Cars { get; set; } //navigation property
    }
}
