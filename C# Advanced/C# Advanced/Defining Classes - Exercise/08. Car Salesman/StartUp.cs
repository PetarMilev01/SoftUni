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
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = input[0];
                int power = int.Parse(input[1]);
                int displacement = 0;
                string efficiency = "n/a";

                if (input.Length == 3)
                {
                    bool trial = int.TryParse(input[2], out displacement);

                    if (!trial)
                    {
                        efficiency = input[2];
                    }
                }
                if (input.Length == 4)
                {
                    displacement = int.Parse(input[2]);
                    efficiency = input[3];
                }
                engines.Add(new Engine(model, power, displacement, efficiency));
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = input[0];
                Engine engine = engines.Where(x => x.Model == input[1]).First();
                int weight = 0;
                string color = "n/a";
                if (input.Length == 3)
                {
                    bool trial = int.TryParse(input[2], out weight);
                    if (!trial)
                    {                    
                        color = input[2];
                    }
                }
                if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                }
                cars.Add(new Car(model, engine, weight, color));
            }

            foreach (var car in cars)
            {
                string engineDisplacement = car.Engine.Displacement == 0 ? "n/a" : car.Engine.Displacement.ToString();
                string carWeight = car.Weight == 0 ? "n/a" : car.Weight.ToString();
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                //Console.WriteLine(String.IsNullOrEmpty(A) ? "Yes" : "No");
                Console.WriteLine($"    Displacement: {engineDisplacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {carWeight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
