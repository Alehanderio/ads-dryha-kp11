using System;
using System.Collections.Generic;

namespace _4_lab_ads
{
    class Program
    {
        public static void allCommands()
        {
            Console.WriteLine("/help - list of commands;");
            Console.WriteLine("/addLast - add an element to the tail;");
            Console.WriteLine("/addFirst - add an element to the head;");
            Console.WriteLine("/delLast - remove an element at the tail;");
            Console.WriteLine("/delFirst - remove an element at the head;");
            Console.WriteLine("/addPos - add an element at the position;");
            Console.WriteLine("/delPos - remove an element at the position;");
            Console.WriteLine("/addCenter - add an element at the central position;");
            Console.WriteLine("/print - outputs whole list");
            Console.WriteLine("/clear - clear console;");
            Console.WriteLine("/quit - exit.");
        }
        public class DLList
        {
            public DLList()
            {
                head = null;
                tail = null;
            }
            public Node head;
            public Node tail;
            public void AdLast(int data)
            {
                if (head == null)
                {
                    head = new Node(data, null, null);
                    tail = head;
                }
                else if (head.next == null)
                {
                    head = tail;
                    tail = new Node(data, head, null);
                    head.next = tail;
                }
                else
                {
                    Node temp = tail;
                    Node last = new Node(data, temp, null);
                    tail = last;
                    temp.next = last;
                }
            }
            public void AdFirst(int data)
            {
                
                if (head == null)
                {
                    head = new Node(data, null, null);
                    tail = head;
                }
                else if (head.next == null)
                {
                    tail = head;
                    head = new Node(data, null, tail);
                    tail.prev = head;
                }
                else
                {
                    Node temp = head;
                    Node first = new Node(data, null, temp);
                    head = first;
                    temp.prev = first;
                }
            }
            public void DelFirst()
            {
                if (head == null)
                {
                    Console.Write("No such element!  ");
                }
                else if (head.next == null)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.next;
                    head.prev = null;
                }
            }
            public void DelLast()
            {
                if (head == null)
                {
                    Console.Write("No such element!  ");
                }
                else if (tail.prev == null || tail == null)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    tail = tail.prev;
                    tail.next = null;
                }
            }
            public void AddToPosition(int data, int pos)
            {
                if(head == null || tail == null)
                {
                    AdFirst(data);
                }
                else
                {
                    Node current = head;
                    if (pos == 0)
                    {
                        AdFirst(data);
                    }
                    else
                    {
                        for (int i = 0; i < pos; i++)
                        {
                            if (current.next == null)
                            {
                                AdFirst(data);
                                return;
                            }
                            else
                            {
                                current = current.next;
                            }
                        }
                        Node temp = current.prev;
                        Node inp = new Node(data, temp, current);
                        temp.next = inp;
                        current.prev = inp;
                        if (inp.prev == null)
                        {
                            head = inp;
                        }
                        else if (inp.next == null)
                        {
                            tail = inp;
                        }
                    }
                }
            }
            public void DelAtPosition(int pos)
            {
                if (head == null || tail == null)
                {
                    Console.Write("No such element!!!  ");
                }
                else
                {
                    Node current = head;
                    if (pos == 0)
                    {
                        DelFirst();
                    }
                    else
                    {
                        for (int i = 0; i < pos; i++)
                        {
                            if (current.next == null)
                            {
                                DelFirst();
                                return;
                            }
                            else
                            {
                                current = current.next;
                            }
                        }
                        if (current.next == null)
                        {
                            tail = current.prev;
                            current.prev = null;
                        }
                        else
                        {
                            Node tempPrev = current.prev;
                            Node tempNext = current.next;
                            tempPrev.next = tempNext;
                            tempNext.prev = tempPrev;
                        }
                    }
                }
            }
            public void AddAtCenter(int data)
            {
                if (head == null)
                {
                    AdFirst(data);
                }
                else if (head.next == null)
                {
                    tail = new Node(data, head, null);
                    head.next = tail;
                }
                else
                {
                    Node current = head;
                    int counter = 0;
                    while (current.next != null)
                    {
                        counter++;
                        current = current.next;
                    }
                    current = head;
                    for (int i = 0; i < counter / 2 + 1; i++)
                    {
                        current = current.next;
                    }
                    Node temp = current.prev;
                    Node inp = new Node(data, temp, current);
                    temp.next = inp;
                    current.prev = inp;
                    if (inp.prev == null)
                    {
                        head = inp;
                    }
                    else if (inp.next == null)
                    {
                        tail = inp;
                    }
                }
            }
            public void Print()
            {
                if (head == null)
                {
                    Console.WriteLine("List is empty!!!");
                }
                else
                {
                    Node current = head;
                    while (current != null)
                    {
                        Console.Write(current.data + "  ");
                        current = current.next;
                    }
                    Console.WriteLine();
                }
            }

            public class Node
            {
                public Node prev;
                public Node next;
                public int data;
                public Node(int data, Node prev, Node next)
                {
                    this.data = data;
                    this.prev = prev;
                    this.next = next;
                }
            }
        }
        static void Main(string[] args)
        {
            DLList test = new DLList();
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
                        case "/addLast":
                            Console.Write("Enter value: ");
                            test.AdLast(int.Parse(Console.ReadLine()));
                            test.Print();
                            break;
                        case "/addFirst":
                            Console.Write("Enter value: ");
                            test.AdFirst(int.Parse(Console.ReadLine()));
                            test.Print();
                            break;
                        case "/delLast":
                            test.DelLast();
                            test.Print();
                            break;
                        case "/delFirst":
                            test.DelFirst();
                            test.Print();
                            break;
                        case "/addPos":
                            Console.Write("Enter value: "); int tempVal = int.Parse(Console.ReadLine());
                            Console.WriteLine("Attention! Numeration starts with 0!");
                            Console.Write("Enter position: "); int tempPos = int.Parse(Console.ReadLine());
                            test.AddToPosition(tempVal, tempPos);
                            test.Print();
                            break;
                        case "/delPos":
                            Console.Write("Enter position: "); tempPos = int.Parse(Console.ReadLine());
                            test.DelAtPosition(tempPos);
                            test.Print();
                            break;
                        case "/addCenter":
                            Console.Write("Enter value: "); tempVal = int.Parse(Console.ReadLine());
                            test.AddAtCenter(tempVal);
                            test.Print();
                            break;
                        case "/print":
                            test.Print();
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
