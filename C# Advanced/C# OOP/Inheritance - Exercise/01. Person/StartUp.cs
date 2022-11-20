using System;
using System.Numerics;

namespace Person
{
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child kid = new Child(name,age);
            Console.WriteLine(kid);
        }
    }
}
