using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class TestDrive
    {
        public int ID {  get; set; }
        public int? CustomerID { get; set; } //foreign key to the Customer entity
        public Customer? Customer { get; set; } //navigation property

        public string? CarVIN { get; set; } //foreign key to the Car entity
        public Car? Car { get; set; } //navigation property


        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime TestDriveDate { get; set; } //test drive date attribute


    }
}
