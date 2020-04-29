using System;
using System.Collections.Generic;
using System.Threading;

namespace Client
{
    class Program
    {
        static public List<Client> clients = new List<Client>();
        static void Main(string[] args)
        {
            Thread insert = new Thread(Insert);
            insert.Start();
            Console.ReadKey();
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
        }
        static void Insert()
        {
            Console.WriteLine("Enter FirstName:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter LastName:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Balance:");
            decimal balance = decimal.Parse(Console.ReadLine());
            int id = CheckId();
            clients.Add(new Client()
            {
                Id = id,
                Age = age,
                Balance = balance,
                FirstName = firstName,
                LastName = lastName,
                LastBalance = balance,
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
