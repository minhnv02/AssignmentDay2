using System;
using System.Globalization;
using CarManagementSystem.Models;

class Program
{
    static void Main()
    {
        try
        {
            string make = GetNonEmptyString("Enter car make: ");
            string model = GetNonEmptyString("Enter car model: ");
            int year = GetValidYear();
            DateTime lastMaintenance = GetValidDateTime("Enter last maintenance date (yyyy-MM-dd): ", "yyyy-MM-dd");

            Car car = GetCarType(make, model, year, lastMaintenance);
            car.DisplayDetails();

            if (ConfirmAction("Do you want to refuel/charge? (Y/N): "))
            {
                DateTime refuelChargeTime = GetValidDateTime("Enter refuel/charge date and time (yyyy-MM-dd HH:mm): ", "yyyy-MM-dd HH:mm");
                
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

    private static string GetNonEmptyString(string str)
    {
        while (true)
        {
            Console.Write(str);
            string input = Console.ReadLine()?.Trim()??"";
            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Console.WriteLine("Input cannot be empty. Please try again.");
        }
    }

    private static int GetValidYear()
    {
        while (true)
        {
            Console.Write("Enter car year (e.g., 2020): ");
            if (int.TryParse(Console.ReadLine(), out int year) && year >= 1886 && year <= DateTime.Now.Year)
                return year;

            Console.WriteLine("Invalid year! Please enter a valid year between 1886 and the current year.");
        }   
    }

    private static DateTime GetValidDateTime(string prompt, string format)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                return date;

            Console.WriteLine($"Invalid date format! Please use the correct format: {format}.");
        }
    }

    private static bool ConfirmAction(string question)
    {
        while (true)
        {
            Console.Write(question);
            string input = Console.ReadLine()?.Trim()??"".ToUpper();
            switch (input)
            {
                case "Y": return true;
                case "N": return false;
                default:
                    Console.WriteLine("Invalid input! Please enter 'Y' or 'N'.");
                    break;
            }
        }
    }

    private static Car GetCarType(string make, string model, int year, DateTime lastMaintenance)
    {
        while (true)
        {
            Console.Write("Is this a FuelCar or ElectricCar? (F/E): ");
            string input = Console.ReadLine()?.Trim() ?? string.Empty.ToUpper();

            switch (input)
            {
                case "F": return new FuelCar(make, model, year, lastMaintenance);
                case "E": return new ElectricCar(make, model, year, lastMaintenance);
                default:
                    Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar.");
                    break;
            }
        }
    }
}
