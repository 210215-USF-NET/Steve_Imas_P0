using System;
using Dozen2Models;
using Dozen2DL;
using Dozen2DL.Entities;
using Dozen2BL;

using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Dozen2UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configDB = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            string connection = configDB.GetConnectionString("Dozen2DB");
            DbContextOptions<DBSteveIP0Context> dbOptions = new DbContextOptionsBuilder<DBSteveIP0Context>().UseSqlServer(connection).Options;

            using var context = new DBSteveIP0Context(dbOptions); 

            DrinkMenu dMenu = new DrinkMenu();
            dMenu.Start();
        }
    }
}
/*
//add customer
//search customer
//place order
//view order history by location 
//view order history by customer
//view inventory by location
//

*/