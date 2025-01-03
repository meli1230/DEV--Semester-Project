using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        
        [Display(Name = "Equipment")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Requirements: at most 50 characters")]
        public string EquipmentName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(150, ErrorMessage = "Requirements: at most 150 characters")]
        public string Infotainment {  get; set; } //ex: 10-inch touchscreen

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(250, ErrorMessage = "Requirements: at most 250 characters")]
        public string Upholstery { get; set; } //ex: Fabric, Leather, Synthetic Leather

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(150, ErrorMessage = "Requirements: at most 150 characters")]
        public string Wheels { get; set; } //ex: 18-inch alloy wheels, 16-inch steel wheels

        [Display(Name = "Parking Assist")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(250, ErrorMessage = "Requirements: at most 250 characters")]
        public string ParkingAssist { get; set; } //rear parking sensors, parking camera
        public ICollection<Car>? Cars { get; set; } //navigation property
    }
}
