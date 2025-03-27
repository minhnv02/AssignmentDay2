namespace CarManagementSystem.Models
{
    public abstract class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public DateTime LastMaintenance { get; set; }

        protected Car(string make, string model, int year, DateTime lastMaintenance)
        {
            Make = make;
            Model = model;
            Year = year;
            LastMaintenance = lastMaintenance;
        }

        public DateTime ScheduleMaintenance()
        {
            return LastMaintenance.AddMonths(6);
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Car: {Make} {Model} ({Year})");
            Console.WriteLine($"Last Maintenance: {LastMaintenance:yyyy-MM-dd}");
            Console.WriteLine($"Next Maintenance: {ScheduleMaintenance():yyyy-MM-dd}");
        }
    }
}
