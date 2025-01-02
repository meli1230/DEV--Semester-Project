using Microsoft.AspNetCore.Mvc.RazorPages;
using MelisaIuliaProiect.Data;

namespace MelisaIuliaProiect.Models
{
    public class CarFuelsPageModel:PageModel
    {
        public List<AssignedFuelData> AssignedFuelDataList;
        public void PopulateAssignedFuelData(MelisaIuliaProiectContext context, Car car)
        {
            var allFuels = context.Fuel;
            var carFuels = new HashSet<int>(
                car.CarFuels.Select(f => f.FuelID));

            AssignedFuelDataList = new List<AssignedFuelData>();
            foreach (var fuel in allFuels)
            {
                AssignedFuelDataList.Add(new AssignedFuelData
                {
                    FuelID = fuel.ID,
                    Name = fuel.FuelName,
                    Assigned = carFuels.Contains(fuel.ID)
                });
            }
        }

        public void UpdateCarFuels(MelisaIuliaProiectContext context, string[] selectedFuels, Car carToUpdate)
        {
            if (selectedFuels == null)
            {
                carToUpdate.CarFuels = new List<CarFuel>();
                return;
            }

            var selectedFuelsHS = new HashSet<string>(selectedFuels);
            var carFuels = new HashSet<int>(
                carToUpdate.CarFuels.Select(f => f.Fuel.ID));

            foreach (var fuel in context.Fuel)
            {
                if (selectedFuelsHS.Contains(fuel.ID.ToString()))
                {
                    if (!carFuels.Contains(fuel.ID))
                    {
                        carToUpdate.CarFuels.Add(
                            new CarFuel
                            {
                                CarVIN = carToUpdate.VIN,
                                FuelID = fuel.ID
                            });
                    }
                }
                else
                {
                    if (carFuels.Contains(fuel.ID))
                    {
                        CarFuel fuelToRemove = carToUpdate
                            .CarFuels
                            .SingleOrDefault(i => i.FuelID == fuel.ID);
                        context.Remove(fuelToRemove);
                    }
                }
            }
        }
    }
}