using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }
        
        public Cargo Cargo { get; set; }

        public Tire[] Tires = new Tire[4];

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

    }
}
