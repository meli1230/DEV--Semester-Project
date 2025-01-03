using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class VehicleType
    {
        //ID
        public int ID { get; set; }

        //Type name
        [Display(Name = "Body Type")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Requirements: at most 50 characters")]
        public string VehicleTypeName { get; set; } //ex: Sedan, Hatchback, Crossover

        public ICollection<Car>? Cars { get; set; } //navigation property
    }
}
