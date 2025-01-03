using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Car
    {

        //VIN
        [Key] //specify that this is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //don't generate automatically, as it will be given by the user
        [Display(Name = "VIN")]
        public string VIN { get; set; } //vehicle identification number (aka chassis number)

        //Vehicle model
        [Display(Name = "Model")]
        public int? VehicleModelID { get; set; } //vehicle model entity
        public VehicleModel? VehicleModel { get; set; } //navigation property

        //Body type
        [Display(Name = "Body Type")]
        public int? VehicleTypeID { get; set; } //vehicle type entity
        public VehicleType? VehicleType { get; set; }  //navigation property

        //Equipment type
        [Display(Name = "Equipment")]
        public int? EquipmentID { get; set; } //equipment entity
        public Equipment? Equipment { get; set; } //navigation property

        //Fuel Type
        [Display(Name = "Fuel")]
        public ICollection<CarFuel>? CarFuels { get; set; }

        //Transmission
        [Display(Name = "Transmission")]
        public int? TransmissionID { get; set; } //transmission entity
        public Transmission? Transmission { get; set; }  //navigation property

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

        //Seller
        [Display(Name = "Seller")]
        public int? SellerID { get; set; } //seller entity
        public Seller? Seller { get; set; } //navigation property

        //Price
        [Column(TypeName = "decimal(9,2)")]
        [Required]
        public decimal Price { get; set; }

        //Test Drives
        [Display(Name = "Test Drive")]
        public ICollection<TestDrive>? TestDrives{ get; set; }
    }
}
