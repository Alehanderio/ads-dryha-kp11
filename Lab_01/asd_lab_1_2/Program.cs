using System;
using static System.Math;

namespace asd_lab_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            long temp = 0;
            Console.WriteLine("2 digits");
            for(int n = 10; n <= 99; n++)
            {
                temp = Convert.ToInt32(Pow(n / 10, 2) + Pow(n % 10, 2));
                if(temp == n)
                {
                    Console.WriteLine(n);
                }
            }
            Console.WriteLine("3 digits");
            for (int n = 100; n <= 999; n++)
            {
                int x1 = n / 100; int x2 = n - 100 * x1;
                temp = Convert.ToInt32(Pow(x1, 3) + Pow(x2 / 10, 3)
                    + Pow(x2 % 10, 3));
                if (temp == n)
                {
                    Console.WriteLine(n);
                }
            }
            Console.WriteLine("4 digits");
            for (int n = 1000; n <= 9999; n++)
            {
                int x1 = n / 1000;
                int x2 = (n - 1000 * x1) / 100;
                int x3 = n - 1000 * x1 - 100 * x2;
                temp = Convert.ToInt32(Pow(x1, 4) + Pow(x2, 4)
                    + Pow(x3 / 10, 4) + Pow(x3 % 10, 4));
                if (temp == n)
                {
                    Console.WriteLine(n);
                }
            }
        }
    }
}
