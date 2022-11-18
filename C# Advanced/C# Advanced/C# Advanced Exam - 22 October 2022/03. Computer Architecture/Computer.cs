using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public Computer(string model,int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }
        public int Count => Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count + 1 <= Capacity) 
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            if (Multiprocessor.Any(x=>x.Brand == brand))
            {
                CPU wanted = Multiprocessor.First(x => x.Brand == brand);
                Multiprocessor.Remove(wanted);
                return true;
            }
            return false; ;
        }

        public CPU MostPowerful()
        {
            CPU cpu = new CPU("",1,1);
            foreach (var current in Multiprocessor.OrderByDescending(x=>x.Frequency))
            {
                cpu = current;
                break;
            }
            return cpu;
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
           
            for (int i = 0; i < Multiprocessor.Count; i++)
            {
                if (i+1 == Multiprocessor.Count)
                {
                    sb.Append(Multiprocessor[i].ToString());
                }
                else
                {
                    sb.AppendLine(Multiprocessor[i].ToString());
                }
               
            }
            return sb.ToString();
        }
    }
}
