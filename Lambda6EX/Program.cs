using Lambda6Ex.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Lambda6Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the full file path: ");
            string path = Console.ReadLine();

            List<Product> products = new List<Product>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);

                    products.Add(new Product(name, price));
                }
            }

            var avg = products.Select(p => p.Price).Average();
            Console.WriteLine("Average price: " + avg.ToString("F2", CultureInfo.InvariantCulture));

            var productsName = products.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach(Product p in products){
                Console.WriteLine(p.Name);
            }
        
        }
    }
}
