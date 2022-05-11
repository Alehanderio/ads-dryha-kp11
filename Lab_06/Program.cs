using System;

namespace lab_6
{
    class Program
    {
        static Steck a;
        static Steck b;
        static Steck c;
        static int sizw;
        public static void allCommands()
        {
            Console.WriteLine("/help - list of commands;");
            Console.WriteLine("/game - shows th code in process");
            Console.WriteLine("/clear - clear console;");
            Console.WriteLine("/quit - exit.");
        }

        public static void Creation()
        {
            Console.Write("Enter a size:  ");
            try
            {
                int sz = int.Parse(Console.ReadLine());
                sizw = sz;
                a = new Steck(sz);
                b = new Steck(sz);
                c = new Steck(sz);
                a.Top = sz;
                for (int i = 0; i < sz; i++)
                {
                    a.Array[i] = sz - i;
                }
                Print();
            }
            catch
            {
                Console.WriteLine("Wrong input!!!");
                allCommands();
            }
        }

        public static void Print()
        {
            Console.Write("\nStack A: ");
            for (int i = 0; i < a.Top; i++)
            {
                Console.Write($"{a.Array[i]} ");
            }
            Console.Write("     Stack B: ");
            for (int i = 0; i < b.Top; i++)
            {
                Console.Write($"{b.Array[i]} ");
            }
            Console.Write("     Stack C: ");
            for (int i = 0; i < c.Top; i++)
            {
                Console.Write($"{c.Array[i]} ");
            }
        }

        public static void hanoi(int n, Steck A, Steck B, Steck C)
        {
            
            if (n == 1)
            {
                int temp = A.Pop();
                C.Push(temp);
                Print();
            }
            else
            {
                hanoi(n - 1, A, C, B);
                int temp2 = A.Pop();
                C.Push(temp2);
                Print();
                hanoi(n - 1, B, A, C);
            }
        }

    static void Main(string[] args)
        {
            allCommands();
            while (true)
            {
                try
                {
                    string enterCommand = Console.ReadLine();
                    switch (enterCommand)
                    {
                        case "/help":
                            allCommands();
                            break;
                        case ("/game"):
                            Creation();
                            hanoi(sizw, a, b, c);
                            Print();
                            break;
                        case ("/quit"):
                            System.Environment.Exit(1);
                            break;
                        case "/clear":
                            Console.Clear();
                            allCommands();
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
