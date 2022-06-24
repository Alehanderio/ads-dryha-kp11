using System;
using System.Collections.Generic;
using System.Numerics;

namespace heshTables
{ 
    class Program
    {
        static Random rng = new Random();
        public static HashTableBook HTBtemp;
        public static HashTableAuthor HTA;
        public static List<int> IDlist = new List<int>();

        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!(Char.IsLetter(c) || c == ' '))
                    return false;
            }
            return true;
        }

        public static void allCommands()
        {
            Console.WriteLine("control - filled");
            Console.WriteLine("/a - adding a new book;");
            Console.WriteLine("/f - finding a book;");
            Console.WriteLine("/r - removing a book;");
            Console.WriteLine("/fAll - shows all books of this author;");
            Console.WriteLine("/s - show Hash Table about books;");
            Console.WriteLine("/sA - show Hash Table about authors;");
            Console.WriteLine("/h - list of commands;");
            Console.WriteLine("/empty - clear both hash tables");
            Console.WriteLine("/clr - clear console;");
            Console.WriteLine("/q - exit.");
        }

        static int IDgenerator()
        {
            while (true)
            {
                string temp = "";
                for (int i = 0; i < 6; i++)
                {
                    temp += rng.Next(0, 10).ToString();
                }
                if (!IDlist.Contains(int.Parse(temp)))
                {
                    return int.Parse(temp);
                }
            }
        }

        static void Control(HashTableBook htb, HashTableAuthor hta)
        {
            ValueBook entry1 = new ValueBook("Lord of the rings", new LinkedList<string>(), 1956);
            entry1.authors.AddLast("Sir Tolkien");
            htb.Insert(new KeyBook(IDgenerator()), entry1);
            hta.Insert(new KeyAuth("Sir Tolkien"), new ValueAuth(new LinkedList<string>()), "Lord of the rings");

            ValueBook entry3 = new ValueBook("The Witcher 1", new LinkedList<string>(), 1978);
            entry3.authors.AddLast("Sapkovskiy");
            htb.Insert(new KeyBook(IDgenerator()), entry3);
            hta.Insert(new KeyAuth("Sapkovskiy"), new ValueAuth(new LinkedList<string>()), "The Witcher 1");

            ValueBook entry4 = new ValueBook("The Witcher 2", new LinkedList<string>(), 1979);
            entry4.authors.AddLast("Sapkovskiy");
            htb.Insert(new KeyBook(IDgenerator()), entry4);
            hta.Insert(new KeyAuth("Sapkovskiy"), new ValueAuth(new LinkedList<string>()), "The Witcher 2");

            ValueBook entry5 = new ValueBook("The Witcher 3", new LinkedList<string>(), 1980);
            entry5.authors.AddLast("Sapkovskiy");
            htb.Insert(new KeyBook(IDgenerator()), entry5);
            hta.Insert(new KeyAuth("Sapkovskiy"), new ValueAuth(new LinkedList<string>()), "The Witcher 3");

            ValueBook entry2 = new ValueBook("Silmarilion", new LinkedList<string>(), 1977);
            entry2.authors.AddLast("Sir Tolkien");
            entry2.authors.AddLast("Son Tolkien");
            htb.Insert(new KeyBook(IDgenerator()), entry2);
            hta.Insert(new KeyAuth("Sir Tolkien"), new ValueAuth(new LinkedList<string>()), "Silmarilion");
            hta.Insert(new KeyAuth("Son Tolkien"), new ValueAuth(new LinkedList<string>()), "Silmarilion");
            Console.WriteLine("Table of books");
            htb.Print();
            Console.WriteLine("Table of authors");
            hta.Print();
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
                        case "control":
                            HTBtemp = new HashTableBook(4);//initializing hashTables
                            HTA = new HashTableAuthor(4);
                            Control(HTBtemp, HTA);
                            break;

                        case "/empty":
                            HTBtemp = new HashTableBook(4);//initializing hashTables
                            HTA = new HashTableAuthor(4);
                            Console.Clear();
                            Console.WriteLine("Cleared hash tables!");
                            allCommands();
                            break;

                        case "/r":
                            Console.Write($"Enter a key to remove a book: ");
                            int tempKeyR = int.Parse(Console.ReadLine());
                            HTBtemp.Remove(new KeyBook(tempKeyR));
                            break;

                        case "/f":
                            Console.Write($"Enter a key to find a book: ");
                            int tempKey = int.Parse(Console.ReadLine());
                            HTBtemp.Find(new KeyBook(tempKey));
                            break;
                        case "/fAll":
                            Console.Write($"Enter an author to find it`s books: ");
                            string tempKeyFall = Console.ReadLine();
                            HTBtemp.findAllBooks(new KeyAuth(tempKeyFall), HTA);
                            break;

                        #region [/addBook]
                        case "/a":
                            if (HTBtemp == null)
                            {
                                HTBtemp = new HashTableBook(4);//initializing hashTables
                                HTA = new HashTableAuthor(4);
                            }
                            //this is creating entry
                            Console.Write($"Enter a new book`s name:  ");
                            string tempName = Console.ReadLine();
                            Console.Write($"Enter a new book`s year of publishing:  ");
                            int tempYear = int.Parse(Console.ReadLine());
                            if (tempYear > 2022)
                            {
                                Console.WriteLine("This year has not come, so we will set 2022 as a year of publishing.");
                                tempYear = 2022;
                            }if(tempYear < 0)
                            {
                                Console.WriteLine("Books from that age are known nowdays so we will set the year to 0.");
                                tempYear = 0;
                            }
                            ValueBook entry = new ValueBook(tempName, new LinkedList<string>(), tempYear);
                            List<string> Authors = new List<string>();
                            while (true)
                            {
                                Console.Write($"Enter Author`s name if no author is chosen it will be error" +
                                    $" (or '/x' to exit):  ");
                                string tempRead = Console.ReadLine();
                                if (tempRead == "/x")
                                {
                                    break;
                                }
                                if (!string.IsNullOrEmpty(tempRead) && !Authors.Contains(tempRead))
                                {
                                    if (tempRead.Length <= 20)
                                    {
                                        if (IsAllLetters(tempRead))
                                        {
                                            entry.authors.AddLast(tempRead);
                                            HTA.Insert(new KeyAuth(tempRead), new ValueAuth(new LinkedList<string>()), tempName);
                                            Authors.Add(tempRead);
                                        }
                                        else { Console.WriteLine("Wrong input of name(only ENGLISH letters alawed and space)"); }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Name is it long error try another");
                                    }
                                }
                            }
                            KeyBook entryKey = new KeyBook(IDgenerator());
                            IDlist.Add(entryKey.bookID);
                            HTBtemp.Insert(entryKey, entry);
                            break;
                        #endregion

                        case "/h":
                            allCommands();
                            break;

                        case "/s":
                            HTBtemp.Print();
                            break;

                        case "/sA":
                            HTA.Print();
                            break;
                        case "/clr":
                            Console.Clear();
                            allCommands();
                            break;

                        case ("/q"):
                            System.Environment.Exit(1);
                            break;

                        default:
                            Console.WriteLine("Incorect command.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Error ocqured try again!!");
                }
            }
        }
    }

    class HashTableBook
    {
        NodeBook[] table;
        int numBuckets;
        int size;
        double LoadFactorTotal = 0.75;

        public HashTableBook(int maxTableSize)
        {
            size = 0;
            table = new NodeBook[maxTableSize];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = null;
            }
            numBuckets = maxTableSize;
        }

        public void findAllBooks(KeyAuth key, HashTableAuthor hta)
        {
            hta.Find(key);
        }

        int GetHash(KeyBook key)
        {
            return key.bookID % table.Length;
        }

        public void Print()
        {
            foreach (NodeBook item in table)
            {
                var temp = item;
                if (temp != null)
                {
                    temp.Show();
                    while (temp.next != null)
                    {
                        temp.next.Show();
                        temp = temp.next;
                    }
                }
            }
        }

        void Rehash()
        {
            size = 0;
            NodeBook[] temp = table;
            table = new NodeBook[temp.Length * 2];
            foreach (NodeBook item in temp)
            {
                var tempR = item;
                if (tempR != null)
                {
                    Insert(tempR.key, tempR.value);
                    while (tempR.next != null)
                    {
                        //Console.WriteLine("wloop");
                        tempR = tempR.next;
                        Insert(tempR.key, tempR.value);
                    }
                }
            }
            Console.WriteLine("Rehasing succesfuly!") ;
        }
        
        public void Find(KeyBook key)
        {
            int hash = GetHash(key);
            NodeBook current = table[hash];
            while (current != null)
            {
                if(current.key.bookID == key.bookID)
                {
                    current.Show();
                    return;
                }
                else
                {
                    current = current.next;
                }
            }
            Console.WriteLine("No such book found(!");
            return;
        }

        public void Remove(KeyBook key)
        {
            int hash = GetHash(key);
            NodeBook head = table[hash];
            if (head != null)
            {
                if (head.key.bookID == key.bookID)
                {
                    if (head.next != null)
                    {
                        table[hash] = head.next;
                        Console.WriteLine("Removed successfuly!");
                        return;
                    }
                    else
                    {
                        table[hash] = null;
                        size--;
                        Console.WriteLine("Removed successfuly!");
                        return;
                    }
                }
                else
                {
                    NodeBook curPrev = table[hash];
                    NodeBook current = table[hash].next;
                    while (current != null)
                    {
                        if (current.key.bookID == key.bookID)
                        {
                            curPrev.next = current.next;
                            Console.WriteLine("Removed successfuly!");
                            return;
                        }
                        else
                        {
                            curPrev = current;
                            current = current.next;
                        }
                    }
                }
            }

            Console.WriteLine("No book to remove(!");
            return;
        }

        public void Insert(KeyBook key, ValueBook val)
        {
            NodeBook newEntry = new NodeBook(key, val);
            int hash = GetHash(key);
            NodeBook currentEntry = table[hash];
            if (currentEntry == null)
            {
                table[hash] = newEntry;
                size++;
                //Console.Write("Inserted:    ");
                //newEntry.Show();
                Console.WriteLine("Done");
            }
            else
            {
                //bool upd = false;
                while (currentEntry.next != null)
                {
                    if (currentEntry.key == key)
                    {
                        currentEntry.value = val;
                        //upd = true;
                        return;
                    }
                    currentEntry = currentEntry.next;
                }
                //if (!upd)
                {
                    //Console.Write("Inserted:    "); newEntry.Show();
                    Console.WriteLine("Done");
                    currentEntry = table[hash];
                    table[hash] = newEntry;
                    table[hash].next = currentEntry;
                }

            }
            double loadFactor = (1.0 * size) / (numBuckets);
            //Console.WriteLine($"Book Load factor: {loadFactor}");
            if (loadFactor >= LoadFactorTotal)
            {
                numBuckets *= 2;
                Console.WriteLine("Rehashing books started...");
                Rehash();
            }
        }
    }
    class NodeBook
    {
        public KeyBook key;
        public ValueBook value;
        public NodeBook next;
        public NodeBook(KeyBook key, ValueBook value)
        {
            this.key = key;
            this.value = value;
            this.next = null;
        }
        public void Show()
        {
            Console.WriteLine($"Key: {key.bookID}; Title: {value.title};  Year: {value.yearOfPublishing};   by {value.ShowAuthor()};");
        }
    }
    class KeyBook
    {
        public int bookID;
        public KeyBook(int ID)
        {
            bookID = ID;
        }
    }
    class ValueBook
    {
        public string title;
        public LinkedList<string> authors;
        public int yearOfPublishing;
        
        public string ShowAuthor()
        {
            string temp = "";
            foreach (var item in authors)
            {
                temp += $"{item}, ";
            }
            temp = temp.Substring(0, temp.Length - 2);
            return temp;
        }
        public ValueBook(string title, LinkedList<string> authors, int yearOfPublishing)
        {
            this.title = title;
            this.authors = authors;
            this.yearOfPublishing = yearOfPublishing;
        }
    }


    class HashTableAuthor
    {
        public NodeAuth[] tableA;
        int numBuckets;
        int size;
        double LoadFactorTotal = 0.75;
        public HashTableAuthor(int length)
        {
            size = 0;
            tableA = new NodeAuth[length];
            numBuckets = length;
            for (int i = 0; i < tableA.Length; i++)
            {
                tableA[i] = null;
            }
        }

        public int GetHash(string key)
        {
            key = key.ToLower();
            string Alph = "abcdefghijklmnopqrstuvwxyz ";
            BigInteger hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hash += (BigInteger)((Alph.IndexOf(key[i]) + 1) * Math.Pow(27, key.Length - 1 - i));
            }
            return (int)(hash % tableA.Length);
        }

        public void Insert(KeyAuth key, ValueAuth val, string bookToAdd)
        {
            NodeAuth newEntry = new NodeAuth(key, val);
            int hash = GetHash(key.AuthorName);
            NodeAuth currentEntry = tableA[hash];
            if (currentEntry == null)
            {
                newEntry.value.books.AddLast(bookToAdd);
                tableA[hash] = newEntry;
                size++;
                Console.WriteLine("Done");
                //Console.Write("Inserted:    ");
                //newEntry.Show();
            }
            else
            {
                bool upd = false;
                while (currentEntry != null)
                {
                    if (currentEntry.key.AuthorName == key.AuthorName)
                    {
                        upd = true;
                        currentEntry.value.books.AddLast(bookToAdd);
                        Console.WriteLine("Done");
                        return;
                    }
                    currentEntry = currentEntry.next;
                }
                if (!upd)
                {
                    Console.WriteLine("Done");
                    //Console.Write("Inserted:    "); newEntry.Show();
                    currentEntry = tableA[hash];
                    tableA[hash] = newEntry;
                    tableA[hash].next = currentEntry;
                }

            }
            double loadFactor = (1.0 * size) / (numBuckets);
            //Console.WriteLine($"Author Load factor: {loadFactor}");
            if (loadFactor >= LoadFactorTotal)
            {
                numBuckets *= 2;
                Console.WriteLine("Rehashing authors started...");
                Rehash();
            }
        }

        public void Print()
        {
            foreach (NodeAuth item in tableA)
            {
                var temp = item;
                if (temp != null)
                {
                    temp.Show();
                    while (temp.next != null)
                    {
                        temp.next.Show();
                        temp = temp.next;
                    }
                }

            }
        }

        void Rehash()
        {
            size = 0;
            NodeAuth[] temp = tableA;
            tableA = new NodeAuth[temp.Length * 2];
            foreach (NodeAuth item in temp)
            {
                var tempR = item;
                if (tempR != null)
                {
                    Insert(tempR.key, tempR.value, null);
                    while (tempR.next != null)
                    {
                        //Console.WriteLine("wloop");
                        tempR = tempR.next;
                        Insert(tempR.key, tempR.value, null);
                    }
                }
            }
            Console.WriteLine("Rehasing succesfuly!");
        }

        public void Find(KeyAuth key)
        {
            int hash = GetHash(key.AuthorName);
            NodeAuth current = tableA[hash];
            while (current != null)
            {
                if (current.key.AuthorName == key.AuthorName)
                {
                    current.Show();
                    return;
                }
                else
                {
                    current = current.next;
                }
            }
            Console.WriteLine("No such Author found(!");
            return;
        }

        public void Remove(KeyAuth key)
        {
            int hash = GetHash(key.AuthorName);
            NodeAuth head = tableA[hash];
            if (head != null)
            {
                if (head.key.AuthorName == key.AuthorName)
                {
                    if (head.next != null)
                    {
                        tableA[hash] = head.next;
                        Console.WriteLine("Removed successfuly!");
                        return;
                    }
                    else
                    {
                        tableA[hash] = null;
                        size--;
                        Console.WriteLine("Removed successfuly!");
                        return;
                    }
                }
                else
                {
                    NodeAuth curPrev = tableA[hash];
                    NodeAuth current = tableA[hash].next;
                    while (current != null)
                    {
                        if (current.key.AuthorName == key.AuthorName)
                        {
                            curPrev.next = current.next;
                            Console.WriteLine("Removed successfuly!");
                            return;
                        }
                        else
                        {
                            curPrev = current;
                            current = current.next;
                        }
                    }
                }
            }

            Console.WriteLine("No such author to remove(!");
            return;
        }

    }
    class NodeAuth
    {
        public KeyAuth key;
        public ValueAuth value;
        public NodeAuth next;
        public NodeAuth(KeyAuth key, ValueAuth value)
        {
            this.key = key;
            this.value = value;
            this.next = null;
        }
        public void Show()
        {
            Console.WriteLine($"Author: {key.AuthorName}; Wrote {value.ShowBooks()};");
        }
    }
    class KeyAuth
    {
        public string AuthorName;
        public KeyAuth(string name)
        {
            AuthorName = name;
        }
    }
    class ValueAuth
    {
        public LinkedList<string> books;
        public ValueAuth(LinkedList<string> book)
        {
            books = book;
        }
        public string ShowBooks()
        {
            string temp = "";
            foreach (var item in books)
            {
                temp += $"{item}, ";
            }
            temp = temp.Substring(0, temp.Length - 2);
            return temp;
        }
    }
}
