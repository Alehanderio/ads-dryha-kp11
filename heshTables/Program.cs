using System;

namespace heshTables
{
    class Program
    {
        public static void allCommands()
        {
            Console.WriteLine("/help - list of commands;");
            Console.WriteLine("/clr - clear console;");
            Console.WriteLine("/q - exit.");
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
                        case ("/q"):
                            System.Environment.Exit(1);
                            break;
                        case "/clr":
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
                    Console.WriteLine("Unknown error!!");
                }
            }
        }
    }

    class HashTable
    {

    }
}
