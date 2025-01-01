using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Transmission
    {
        //ID
        public int ID { get; set; }

        //Model name
        [Display(Name = "Transmission")]
        [Required]
        public string TransmissionName { get; set; } //ex: Manual, Automatic

        public ICollection<Car>? Cars { get; set; } //navigation property
    }
}
