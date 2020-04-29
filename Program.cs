using System;
using System.Collections.Generic;
using System.Threading;

namespace Client
{
    class Program
    {
        static public List<Client> clients = new List<Client>();
        static int id = 0;
        static void Main(string[] args)
        {
            Thread func = new Thread(Functions);
            func.Start();
        }
        static void Functions()
        {
            bool start = true;
            while (start)
            {
                Thread selectAll = new Thread(new ThreadStart(SelectAll));
                selectAll.Start();
                Console.WriteLine("1-for select one.\n2-for insert one");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter client Id from upper:");
                            id = int.Parse(Console.ReadLine());
                            Console.WriteLine("1-for delete\n2- for update\n3-to go to the main menu");
                            int chs = int.Parse(Console.ReadLine());
                            switch (chs)
                            {
                                case 1:
                                    {
                                        Thread delete = new Thread(new ThreadStart(Delete));
                                        delete.Start();
                                    }
                                    break;
                                case 2:
                                    {
                                        Thread update = new Thread(new ThreadStart(Update));
                                        update.Start();
                                    }
                                    break;
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter FirstName:");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter LastName:");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Enter Age:");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Balance:");
                            decimal balance = decimal.Parse(Console.ReadLine());
                            Thread insert = new Thread(() => Insert(new Client() { Age = age, Balance = balance, FirstName = firstName, LastName = lastName }));
                            insert.Start();
                        }
                        break;
                }
            }
        }

        static void Delete()
        {
            List<Client> li = new List<Client>();
            foreach (var client in clients)
            {
                if (client.Id != id)
                {
                    li.Add(client);
                }
            }
            clients = li;
        }

        static void SelectAll()
        {
            Console.WriteLine("Id FirstName LastName Age Balance");
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Id} {client.FirstName} {client.LastName} {client.Age} {client.Balance}");
            }
        }
        static void Update()
        {
            Console.WriteLine("Reenter FirstName:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Reenter LastName:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Reenter Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Reenter Balance:");
            decimal balance = decimal.Parse(Console.ReadLine());
            int i = 0;
            foreach (var client in clients)
            {
                if (client.Id == id)
                {
                    break;
                }
                i++;
            }
            clients[i].FirstName = firstName;
            clients[i].LastName = lastName;
            clients[i].LastBalance = clients[i].Balance;
            clients[i].Age = age;
            clients[i].Balance = balance;
        }
        static void Insert(Client client)
        {

            int id = CheckId();
            clients.Add(new Client()
            {
                Id = id,
                Age = client.Age,
                Balance = client.Balance,
                FirstName = client.FirstName,
                LastName = client.LastName,
                LastBalance = client.Balance,
            });
        }
        static int CheckId()
        {
            int id = 1;
            try
            {
                id = clients[clients.Count - 1].Id + 1;
            }
            catch (Exception ex)
            {

            }
            return id;
        }
    }
}
