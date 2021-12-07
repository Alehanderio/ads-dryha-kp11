using System;

namespace asd_lab_3
{
    class Program
    {
        static Random rnd = new Random();
        static int n, m;
        static int min = 0;
        static int[,] table;
        static int[] mainD, sideD;

        static void Get_Parametres()
        {
            Console.Write("Enter n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Enter m = ");
            m = int.Parse(Console.ReadLine());
            table = new int[n, m];
            min = Math.Min(n, m);
            mainD = new int[min];
            sideD = new int[min];
        }
        static void Fill_table()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int next = 0;
                    while (true)
                    {
                        next = rnd.Next(n * m + 1);
                        if (!Contains(table, next)) break;
                    }

                    table[i,j] = next;
                }
            }
        }
        static bool Contains(int[,] matrix, int value)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j] == value) return true;
                }
            }
                return false;
        }
        static void ToArrays()
        {
            for (int i = 0; i < min; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == j)
                    {
                        mainD[i] = table[i, j];
                        //Console.WriteLine($"{mainD[i]}    {i}");
                    }
                    if (i == m - j - 1)
                    {
                        sideD[i] = table[i, j];
                        //Console.WriteLine($"******{sideD[i]}   {i}");
                    }
                }
            }
        }
        static void ToMatrix()
        {
            for (int i = 0; i < min; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == j)
                    {
                        table[i, j] = mainD[i];
                    }
                    else if (i == m - j - 1)
                    {
                        table[i, j] = sideD[i];
                    }
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
        static void Out_Table_Sorted(int[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (table[i, j] == table[i, m - j - 1])
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write($"{matrix[i, j],5}");
                    }
                    else if (i == m - j - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"{matrix[i, j],5}");
                    }
                    else if (i == j)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write($"{matrix[i, j],5}");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write($"{matrix[i, j],5}");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
        static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
        static void CoctailThroughArrays()
        {
            for (int i = 0; i < min - 1; i++)
            {
                for (int j = 1; j < min - i; j++)
                {
                    //Buble part
                    if (mainD[j] == sideD[j])
                    {
                        if (mainD[j - 1] > mainD[j + 1])
                        {
                            Swap(mainD, j - 1, j + 1);
                        }
                        if (sideD[j - 1] < sideD[j + 1])
                        {
                            Swap(sideD, j - 1, j + 1);
                        }
                    }
                    else if (mainD[j - 1] == sideD[j - 1])
                    {
                        if (mainD[j - 2] > mainD[j])
                        {
                            Swap(mainD, j - 2, j);
                        }
                        if (sideD[j - 2] < sideD[j])
                        {
                            Swap(sideD, j - 2, j);
                        }
                    }
                    else
                    {
                        if (mainD[j - 1] > mainD[j])
                        {
                            Swap(mainD, j - 1, j);
                        }
                        if (sideD[j - 1] < sideD[j])
                        {
                            Swap(sideD, j - 1, j);
                        }
                    }
                }
                
                //reverse buble part
                for (int j = min - i - 1; j > 0; j--)
                {
                    if (mainD[j] == sideD[j])
                    {
                        if (mainD[j - 1] > mainD[j + 1])
                        {
                            Swap(mainD, j - 1, j + 1);
                        }
                        if (sideD[j - 1] < sideD[j + 1])
                        {
                            Swap(sideD, j - 1, j + 1);
                        }
                    }
                    else if (mainD[j - 1] == sideD[j - 1])
                    {
                        if (mainD[j - 2] > mainD[j])
                        {
                            Swap(mainD, j - 2, j);
                        }
                        if (sideD[j - 2] < sideD[j])
                        {
                            Swap(sideD, j - 2, j);
                        }
                    }
                    else {
                        if (mainD[j] < mainD[j - 1])
                        {
                            Swap(mainD, j - 1, j);
                        }
                        if (sideD[j] > sideD[j - 1])
                        {
                            Swap(sideD, j - 1, j);
                        }
                    }
                }
            }
        }
 
        static void Main(string[] args)
        {
            Get_Parametres();
            Fill_table();
            Out_Table(table);
            Console.WriteLine();
            ToArrays();
            CoctailThroughArrays();
            ToMatrix();
            Out_Table_Sorted(table);
        }
    }
}
