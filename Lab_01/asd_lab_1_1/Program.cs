using System;
using static System.Math;

namespace asd_lab_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, x, y, z;
            Console.Write("Enter x = "); x = Double.Parse(Console.ReadLine());
            Console.Write("Enter y = "); y = Double.Parse(Console.ReadLine());
            Console.Write("Enter z = "); z = Double.Parse(Console.ReadLine());
            double a1 = Pow(x, z) * y - Cbrt(Pow(x, 2) - y * Pow(z, 3));
            if (a1 == 0 || (x < 0 && 1 / z % 2 == 0))
            {
                Console.WriteLine("a and b are not possible to count.");
            }
            else
            {
                a = (x + y - z) / a1;
                Console.WriteLine($"a equals {a}");
                if (a == 0)
                {
                    Console.WriteLine("b is not possibl to count");
                }
                else
                {
                    b = Cos(x * y + Pow(y, 2) / Pow(a, 2));
                    Console.WriteLine($"b equals {b}");
                }
            }
        }
    }
}
