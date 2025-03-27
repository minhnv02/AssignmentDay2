using CarManagementSystem.Interfaces;

namespace CarManagementSystem.Models
{
    public class FuelCar : Car, IFuelable
    {
        public FuelCar(string make, string model, int year, DateTime lastMaintenance)
            : base(make, model, year, lastMaintenance) { }

        public void Refuel(DateTime timeOfRefuel)
        {
            Console.WriteLine($"FuelCar {Make} {Model} refueled on {timeOfRefuel:yyyy-MM-dd HH:mm}");
        }
    }
}
