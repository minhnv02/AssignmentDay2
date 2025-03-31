using System;
using System.Globalization;
using CarManagementSystem.Models;

public static class Helper
{
    public static string GetNonEmptyString(string str)
    {
        while (true)
        {
            Console.Write(str);
            string input = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Console.WriteLine("Input cannot be empty. Please try again.");
        }
    }

    public static int GetValidYear()
    {
        while (true)
        {
            Console.Write("Enter car year (e.g., 2020): ");
            if (int.TryParse(Console.ReadLine(), out int year) && year >= 1886 && year <= DateTime.Now.Year)
            {
                return year;
            }
            Console.WriteLine("Invalid year! Please enter a valid year between 1886 and the current year.");
        }
    }

    public static DateTime GetValidMaintenanceDate(int carYear)
    {
        while (true)
        {
            Console.Write("Enter last maintenance date (yyyy-MM-dd): ");
            string input = Console.ReadLine()?.Trim() ?? "";
            if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                if (date.Year >= carYear && date.Year <= DateTime.Now.Year)
                {
                    return date;
                }
                Console.WriteLine($"Maintenance date must be between the car year ({carYear}) and the current year.");
            }
            else
            {
                Console.WriteLine("Invalid date format! Please use the correct format: yyyy-MM-dd.");
            }
        }
    }

    public static DateTime GetValidDateTime(string prompt, string format)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";
            if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            Console.WriteLine($"Invalid date format! Please use the correct format: {format}.");
        }
    }

    public static bool ConfirmAction(string question)
    {
        while (true)
        {
            Console.Write(question);
            string input = Console.ReadLine()?.Trim()?.ToUpper() ?? "";
            if (input == "Y")
            {
                return true;
            }
            else if (input == "N")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter 'Y' or 'N'.");
            }
        }
    }

    public static Car CreateCar(string make, string model, int year, DateTime lastMaintenance)
    {
        string carType = GetCarType();
        return carType switch
        {
            "F" => new FuelCar(make, model, year, lastMaintenance),
            "E" => new ElectricCar(make, model, year, lastMaintenance),
            _ => throw new ArgumentException("Invalid car type.")
        };
    }

    private static string GetCarType()
    {
        while (true)
        {
            Console.Write("Is this a FuelCar or ElectricCar? (F/E): ");
            string input = Console.ReadLine()?.Trim()?.ToUpper() ?? "";
            if (input == "F" || input == "E")
            {
                return input;
            }
            Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar.");
        }
    }
}
