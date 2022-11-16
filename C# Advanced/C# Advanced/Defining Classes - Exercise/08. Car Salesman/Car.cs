using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; } // optional
        public string Color { get; set; } //optional

        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
    }
}
