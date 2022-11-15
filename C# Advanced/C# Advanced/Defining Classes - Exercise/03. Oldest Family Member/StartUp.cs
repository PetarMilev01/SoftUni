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
            Family people = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);
                people.AddMember(new Person(name, age));
            }
            Person oldestPerson =  people.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
