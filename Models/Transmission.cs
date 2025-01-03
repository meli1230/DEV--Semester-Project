using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Transmission
    {
        //ID
        public int ID { get; set; }

        //Model name
        [Display(Name = "Transmission")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Requirements: at most 50 characters")]
        public string TransmissionName { get; set; } //ex: Manual, Automatic

        public ICollection<Car>? Cars { get; set; } //navigation property
    }
}
