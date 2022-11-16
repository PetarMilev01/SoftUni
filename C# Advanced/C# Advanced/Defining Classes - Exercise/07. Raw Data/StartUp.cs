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
                List<string> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string model = input[0];

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];

                input.RemoveRange(0, 5);
                for (int c = 0, index = 0; c < input.Count; c+=2,index++)
                {
                    double tirePressure = double.Parse(input[c]);
                    int tireAge = int.Parse(input[c + 1]);
                    tires[index] = new Tire(tirePressure, tireAge);
                }
                cars.Add(new Car(model,engine,cargo,tires));
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                foreach (var car in cars.Where(x=>x.Tires.Any(y=>y.Pressure<1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (type == "flammable")
            {
                foreach (var car in cars.Where(x=>x.Cargo.CargoType=="flammable").Where(x=>x.Engine.Power>250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
