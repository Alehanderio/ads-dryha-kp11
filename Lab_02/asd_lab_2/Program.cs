using System;
//using System.Collections.Generic;

namespace asd_lab_2
{
    class Program
    {
        static Random rnd = new Random();
        static int n, m, k = 0;
        static string sum = "";
        static int[,] test;
        static int[,] table;
        static void Fill_Test()
        {
            int index = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    index++;
                    test[i, j] = index;
                }
            }
        }
        static void Get_Parametres()
        {
            Console.Write("Enter k = ");
            k = int.Parse(Console.ReadLine());
            Console.Write("Enter n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Enter m = ");
            m = int.Parse(Console.ReadLine());
            if (m % 2 != 0)
            {
                Console.WriteLine("Fatal Error");
                Environment.Exit(0);
            }
            table = new int[n, m];
            test = new int[n, m];
        }
        static void Fill_Table()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    table[i, j] = rnd.Next(1, 51);
                }
            }
        }
        static void Out_Table(int[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Go_ZigZag(int[,] matrix)
        {
            Console.WriteLine("* * * * *ZigZag Part* * * * *");
            int i = n - 2, j = 0, ind = 1;
            Check_Keys(n - 1, 0, matrix);
            while (ind < n + m / 2 - 1)
            {
                while (i < n - 1 && j < (m / 2 - 1))
                {
                    Check_Keys(i, j, matrix);
                    i++;
                    j++;
                }
                if (i == n - 1 && j < (m / 2 - 1))
                {
                    Check_Keys(i, j, matrix);
                    j++;
                    ind++;
                }
                else if (i > 0 && j == (m / 2 - 1))
                {
                    Check_Keys(i, j, matrix);
                    i--;
                    ind++;
                }
                while (i > 0 && j > 0)
                {
                    Check_Keys(i, j, matrix);
                    i--;
                    j--;
                }
                if (j == 0 && i > 0)
                {
                    Check_Keys(i, j, matrix);
                    i--;
                    ind++;
                }
                else if (j >= 0 && i == 0)
                {
                    Check_Keys(i, j, matrix);
                    j++;
                    ind++;
                }
            }
            Console.WriteLine();
        }
        static void Go_Snake(int[,] matrix)
        {
            Console.WriteLine("* * * * *Snake Part* * * * *");
            for (int i = 0; i < n; i++)
            {
                if ((double)i % 2 == 0)
                {
                    for (int j = m / 2; j < m; j++)
                    {
                        Check_Keys(i, j, matrix);
                    }
                }
                else
                {
                    for (int j = m - 1; j > m / 2 - 1; j--)
                    {
                        Check_Keys(i, j, matrix);
                    }
                }
            }
            Console.WriteLine();
        }
        static void Check_Keys(int i, int j, int[,] matrix)
        {
            Console.Write($"f({i + 1},{j + 1})={matrix[i, j],2}  ");
            if (matrix[i, j] > k)
            {
                sum += $"f({i},{j})={matrix[i, j],2}\n";
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("/help - list of commands;");
            Console.WriteLine("/control - control matrix;");
            Console.WriteLine("/random - psevdo rabdom matrix;");
            Console.WriteLine("/clear - clear console;");
            Console.WriteLine("/quit - exit");
            while (true)
            {
                try
                {
                    string enterCommand = Console.ReadLine();
                    switch (enterCommand)
                    {
                        case "/help":
                            Console.WriteLine("/help - list of commands;");
                            Console.WriteLine("/control - control matrix;");
                            Console.WriteLine("/random - psevdo rabdom matrix;");
                            Console.WriteLine("/clear - clear console;");
                            Console.WriteLine("/quit - exit.");
                            break;
                        case "/control":
                            Get_Parametres();
                            Fill_Test();
                            Out_Table(test);
                            Go_ZigZag(test);
                            Go_Snake(test);
                            if (sum != "")
                            {
                                Console.WriteLine($"{sum}");
                            }
                            else
                            {
                                Console.WriteLine("No such numbers");
                            }
                            sum = "";
                            break;
                        case "/random":
                            Get_Parametres();
                            Fill_Table();
                            Out_Table(table);
                            Go_ZigZag(table);
                            Go_Snake(table);
                            if (sum != "")
                            {
                                Console.WriteLine($"{sum}");
                            }
                            else
                            {
                                Console.WriteLine("No such numbers");
                            }
                            sum = "";
                            break;
                        case ("/quit"):
                            System.Environment.Exit(1);
                            break;
                        case "/clear":
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Incorect command.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Fatal error!!");
                }
            }
        }
    }
}
