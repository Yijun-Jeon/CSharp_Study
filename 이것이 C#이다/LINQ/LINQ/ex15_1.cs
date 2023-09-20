using System;
using System.Linq;

namespace ex15_1
{
    class Car
    {
        public int Cost { get; set; }
        public int MaxSpeed { get; set; }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Car[] cars =
            {
                new Car(){Cost = 56, MaxSpeed = 120 },
                new Car(){Cost = 70, MaxSpeed = 150 },
                new Car(){Cost = 45, MaxSpeed = 180 },
                new Car(){Cost = 32, MaxSpeed = 200 },
                new Car(){Cost = 82, MaxSpeed = 200 },
            };

            var selected = from car in cars
                           where car.Cost >= 50
                           where car.MaxSpeed >= 150
                           select car;

            foreach (var car in selected)
                Console.WriteLine($"Cost: {car.Cost}, Max Speed: {car.MaxSpeed}");
        }
    }
}