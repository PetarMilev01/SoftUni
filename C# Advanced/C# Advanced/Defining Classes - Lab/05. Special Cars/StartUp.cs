using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CarManufacturer;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Tire[][] tires = new Tire[100][];
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input = Console.ReadLine();
            int counter = 0;
            while (input != "No more tires")
            {
                string[] info = input.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                Tire[] tires01 = new Tire[4];
                for (int i = 0, p = 0; p < info.Length / 2; i += 2, p++) 
                {
                    int year = int.Parse(info[i]);
                    double pressure = double.Parse(info[i + 1]);
                    Tire tire = new Tire(year, pressure);
                    tires01[p] = tire;
                }
                tires[counter] = tires01;
                counter++;
                input = Console.ReadLine();
            }
            input = Console.ReadLine();

            while (input != "Engines done")
            {
                string[] info = input.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                int horsePowers = int.Parse(info[0]);
                double cubicCapacity = double.Parse(info[1]);
                Engine engine = new Engine(horsePowers, cubicCapacity);
                engines.Add(engine);
                input = Console.ReadLine();
            }
             input = Console.ReadLine();

            while (input  != "Show special")
            {
                string[] carInfo = input.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Tire[] tires1 = tires[tiresIndex];
                Engine engine = engines[engineIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption,engine,tires1);
                cars.Add(car);
                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                if (car.Year >=2017 && car.Engine.HorsePower>330 && car.Tires.Sum(x=>x.Pressure)>9 && car.Tires.Sum(x=>x.Pressure)<=10)
                {
                    car.Drive(20);
                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
