using CarManagementSystem.Interfaces;

namespace CarManagementSystem.Models
{
    public class ElectricCar : Car, IChargeable
    {
        public ElectricCar(string make, string model, int year, DateTime lastMaintenance)
            : base(make, model, year, lastMaintenance) { }

        public void Charge(DateTime timeOfCharge)
        {
            Console.WriteLine($"ElectricCar {Make} {Model} charged on {timeOfCharge:yyyy-MM-dd HH:mm}");
        }
    }
}
