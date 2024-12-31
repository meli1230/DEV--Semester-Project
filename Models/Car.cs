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
        [Display(Name = "Car Model")] //friendly name for display purposes
        [Required]
        public string Model { get; set; } //ex: C-HR, Camry, RAV4

        //Type
        [Required]
        public string CarType { get; set; } //ex: Sedan, Hatchback, Crossover

        //Production Date
        [DataType(DataType.Date)] //field should be treated as date
        [Required]
        public DateTime ProductionDate { get; set; }

        //Equipment type
        [Required]
        public string Equipment { get; set; } //ex: Exclusive, Dynamic, Active

        //Color
        [Required]
        public string Color { get; set; }

        //Transmission
        [Required]
        public string Transmission { get; set; } //ex: Manual, Automatic

        //Horsepower
        [Required]
        public int HorsePower { get; set; }

        //Torque
        [Required]
        public int Torque { get; set; }

        //Autonomy
        [Required]
        public int Autonomy { get; set; }

        //Fuel Type
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
