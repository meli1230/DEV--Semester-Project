using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Car
    {

        //VIN
        [Key] //specify that this is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //don't generate automatically, as it will be given by the user
        public string VIN { get; set; } //vehicle identification number (aka chassis number)

        //Model
        [Display(Name = "Model")] //friendly name for display purposes
        [Required]
        public string Model { get; set; } //ex: C-HR, Camry, RAV4

        //Type
        [Display(Name = "Type")]
        [Required]
        public string CarType { get; set; } //ex: Sedan, Hatchback, Crossover

        //Equipment type
        [Required]
        public string Equipment { get; set; } //ex: Exclusive, Dynamic, Active

        //Transmission
        [Required]
        public string Transmission { get; set; } //ex: Manual, Automatic

        //Horsepower
        [Display(Name = "HP")]
        [Required]
        public int HorsePower { get; set; }

        //Torque
        [Required]
        public int Torque { get; set; }

        //Autonomy
        [Required]
        public int Autonomy { get; set; }

        //Fuel Type
        [Display(Name = "Fuel")]
        [Required]
        public string FuelType { get; set; } //ex: Petrol, Electric, Hybrid

        //Seller
        [Required]
        public string Seller { get; set; } //ex: Toyota Cluj Vest, Toyota Calea Turzii

        //Price
        [Column(TypeName = "decimal(9,2)")]
        [Required]
        public decimal Price { get; set; }
    }
}
