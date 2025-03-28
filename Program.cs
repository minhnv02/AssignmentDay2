using System;
using CarManagementSystem.Models;

class Program
{
    static void Main()
    {
        try
        {
            string make = Helper.GetNonEmptyString("Enter car make: ");
            string model = Helper.GetNonEmptyString("Enter car model: ");
            int year = Helper.GetValidYear();
            DateTime lastMaintenance = Helper.GetValidDateTime("Enter last maintenance date (yyyy-MM-dd): ", "yyyy-MM-dd");

            Car car = Helper.GetCarType(make, model, year, lastMaintenance);
            car.DisplayDetails();

            if (Helper.ConfirmAction("Do you want to refuel/charge? (Y/N): "))
            {
                DateTime refuelChargeTime = Helper.GetValidDateTime("Enter refuel/charge date and time (yyyy-MM-dd HH:mm): ", "yyyy-MM-dd HH:mm");

                switch (car)
                {
                    case FuelCar fuelCar:
                        fuelCar.Refuel(refuelChargeTime);
                        break;
                    case ElectricCar electricCar:
                        electricCar.Charge(refuelChargeTime);
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
