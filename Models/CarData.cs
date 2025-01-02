namespace MelisaIuliaProiect.Models
{
    public class CarData
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Fuel> Fuels {  get; set; }
        public IEnumerable<CarFuel> CarFuels { get; set; }
    }
}
