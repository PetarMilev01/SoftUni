using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        
        public bool Drive(int distance)
        {
            if (distance * FuelConsumptionPerKilometer <= FuelAmount)
            {
                FuelAmount -= distance * FuelConsumptionPerKilometer;
                TravelledDistance += distance;
                return true;
            }

            return false;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionFor1Km)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionFor1Km;
            TravelledDistance = 0.0;
        }

    }
}
