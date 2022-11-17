using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count => this.cars.Count;
        public string AddCar(Car car)
        {
            if (this.cars.Any(x=>x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.capacity == this.cars.Count)
            {
                return "Parking is full!";
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return $"Car with that registration number, doesn't exist!";
            }
            this.cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

       public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
       {
            foreach (var registration in registrationNumbers)
            {
                Car car = this.cars.FirstOrDefault(x => x.RegistrationNumber == registration);
                this.cars.Remove(car);
            }
       }

    }
}
