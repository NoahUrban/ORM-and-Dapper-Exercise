using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using Dapper;
using ORM_Dapper;


namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperProductRepository(conn);

            Console.WriteLine("Type a new product name?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is the price?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the category ID?");
            var prodCat = int.Parse(Console.ReadLine());

            repo.CreateProduct(prodName, prodPrice, prodCat);

            var prodList = repo.GetAllProducts();

            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name}");
            }
        }
    }
}
