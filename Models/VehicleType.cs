using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class VehicleType
    {
        //ID
        public int ID { get; set; }

        //Type name
        [Display(Name = "Body Type")]
        [Required]
        public string VehicleTypeName { get; set; } //ex: Sedan, Hatchback, Crossover

        public ICollection<Car>? Cars { get; set; } //navigation property
    }
}
