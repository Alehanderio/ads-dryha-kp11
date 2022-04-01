using System;
using System.Collections.Generic;

namespace _5_lab_ads
{
    internal class Program
    {
        static Random rnd = new Random();
        static int n, m;
        static int[,] table;
        static int[] tempArray;
        static bool sorted = false;
        static bool Atstart = true;

        static void Main(string[] args)
        {
            checkList();
            while (true)
            {
                try
                {
                    string enterCommand = Console.ReadLine();
                    switch (enterCommand)
                    {
                        case "/help":
                            checkList();
                            break;
                        case "/user":
                            Get_Parametres();
                            Fill_table();
                            Out_Table(table);
                            FindToSort(table);
                            ActualySort(tempArray);
                            InBack(table);
                            Out_Table(table);
                            sorted = false;
                            break;
                        case "/fixed":
                            n = 8; m = 8;
                            table = new int[n, n];
                            Fill_table();
                            Out_Table(table);
                            FindToSort(table);
                            ActualySort(tempArray);
                            InBack(table);
                            Out_Table(table);
                            sorted = false;
                            break;
                        case ("/quit"):
                            System.Environment.Exit(1);
                            break;
                        case "/clear":
                            Console.Clear();
                            checkList();
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
        static void checkList()
        {
            Console.WriteLine("/help - list of commands;");
            Console.WriteLine("/user - input params for matrix;");
            Console.WriteLine("/fixed - fixed size of matrix;");
            Console.WriteLine("/clear - clear console;");
            Console.WriteLine("/quit - exit");
        }
        static int median(int left, int right, int mid)
        {
            int[] med = { tempArray[left], tempArray[right], tempArray[mid] };
            Array.Sort(med);
            return Array.IndexOf(tempArray, med[1]);
        }
        static void OutArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }
        static void swap(int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }
        static void InsertionSort(int[] array, int start, int end)
        {
            int x;
            int j;
            for (int i = start; i <= end; i++)
            {
                x = array[i];
                j = i;
                while (j > start && array[j - 1] > x)
                {
                    swap(array, j, j - 1);
                    j -= 1;
                }
                array[j] = x;
            }
            if (Atstart)
            {
                QuickSortMedian(array, end, array.Length - 1);
            }
            else
            {
                QuickSortMedian(array, 0, start - 1);
            }
        }
        public static void QuickSortMedian(int[] array, int start, int end)
        {
            int left = start;
            int right = end;

            int pivot = array[median(0, tempArray.Length - 1, (tempArray.Length - 1) / 2)];

            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    swap(array, left, right);

                    left++;
                    right--;
                }
            }


            if (start < right)
            {
                if (Math.Abs(right - start) < n)
                {
                    InsertionSort(array, start, right);
                }
                else
                {
                    QuickSortMedian(array, start, right);
                }
                Atstart = true;
            }

            if (left < end)
            {
                if (Math.Abs(end - left) < n)
                {
                    InsertionSort(array, left, end);
                }
                else
                {
                    QuickSortMedian(array, left, end);
                }
                Atstart = false;
            }
        }
        static void Out_Table(int[,] matrix)
        {
            Console.WriteLine();
            for (int x = 0; x < m; x++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j < m / 2 && i > j && i < m - j - 1)
                    {
                        if (!sorted)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        Console.Write($"{matrix[i, j],5}");

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write($"{matrix[i, j],5}");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int x = 0; x < m; x++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        } 
        static void Get_Parametres()
        {
            Console.Write("Enter n = ");
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter int please");
            }
            Console.Write("Enter m = ");
            m = n;
            //try
            //{
            //    m = int.Parse(Console.ReadLine());
            //}
            //catch
            //{
            //    Console.WriteLine("Enter int please");
            //}
            table = new int[n, n];
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
                        next = rnd.Next(n * m + 15);
                        if (!Contains(table, next)) break;
                    }
                    table[i, j] = next;
                }
            }
        }       
        static bool Contains(int[,] matrix, int value)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == value) return true;
                }
            }
            return false;
        }       
        static void FindToSort(int[,] matrix)
        {
            List<int> temp = new List<int>();
            int i = 0;
            bool forward = true;
            while (i < m / 2)
            {
                if (forward)
                {
                    for(int j = 0; j < n; j++)
                    {
                        if (j > i && j < m - 1 - i)
                        {
                            temp.Add(matrix[j, i]);
                        }
                    }
                    i++;
                    forward = false;
                }
                else
                {
                    for (int j = n - i - 1; j > 0; j--)
                    {
                        if (j > i && j < m - 1 - i)
                        {
                            temp.Add(matrix[j, i]);
                        }
                    }
                    i++;
                    forward = true;
                }
            }
            tempArray = temp.ToArray();
            foreach(int item in tempArray)
            {
                Console.Write(item + "  ");
            }
        }       
        static void ActualySort(int[] array)
        {
            //Out(tempArray);
            QuickSortMedian(tempArray, 0, tempArray.Length - 1);
            Console.WriteLine();
            OutArray(tempArray);
            sorted = true;
        }
        static void InBack(int[,] matrix)
        {
            int i = 0;
            int counter = 0;
            bool forward = true;
            while (i < m / 2)
            {
                if (forward)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j > i && j < m - 1 - i)
                        {
                            matrix[j, i] = tempArray[counter];
                            counter++;
                        }
                    }
                    i++;
                    forward = false;
                }
                else
                {
                    for (int j = n - i - 1; j > 0; j--)
                    {
                        if (j > i && j < m - 1 - i)
                        {
                            matrix[j, i] = tempArray[counter];
                            counter++;
                        }
                    }
                    i++;
                    forward = true;
                }
            }
        }
    }
}
