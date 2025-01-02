namespace MelisaIuliaProiect.Models
{
    public class CarFuel
    {
        public int ID { get; set; }
        public string CarVIN { get; set; }
        public Car Car {  get; set; }
        public int FuelID { get; set; }
        public Fuel Fuel {  get; set; }
    }
}
