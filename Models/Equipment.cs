using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        
        [Display(Name = "Equipment")]
        public string EquipmentName { get; set; }

        public string Infotainment {  get; set; } //ex: 10-inch touchscreen
        public string Upholstery { get; set; } //ex: Fabric, Leather, Synthetic Leather
        public string Wheels { get; set; } //ex: 18-inch alloy wheels, 16-inch steel wheels

        [Display(Name = "Parking Assist")]
        public string ParkingAssist { get; set; } //rear parking sensors, parking camera
        public ICollection<Car>? Cars { get; set; } //navigation property
    }
}
