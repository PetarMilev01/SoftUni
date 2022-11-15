using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1Km = double.Parse(carInfo[2]);

                if (!cars.Any(x=>x.Model == model))
                {
                    cars.Add(new Car(model, fuelAmount, fuelConsumptionFor1Km));
                }
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                //Drive BMW-M2 56
                string[] carInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = carInfo[1];
                int distance = int.Parse(carInfo[2]);
                Car currentCar = cars.Where(x => x.Model == model).First();
                if (!currentCar.Drive(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:0.00} {car.TravelledDistance}");
            }
        }
    }
}
