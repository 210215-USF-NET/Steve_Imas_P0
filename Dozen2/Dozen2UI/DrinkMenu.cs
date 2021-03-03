using System;
using Dozen2Models;
using Dozen2BL;
using System.Collections.Generic;

namespace Dozen2UI
{
    public class DrinkMenu : IMenu
    {
        BeerMenu beerMenu = new BeerMenu();
        Drink drink = new Drink();

        ManagerMenu managerMenu = new ManagerMenu();
      
        public void Start()
        {
            bool startMenu = true;
            do
            {
                Console.WriteLine("Welcome to Dozen! Are you a manager or a customer?");
                Console.WriteLine("[0] Place an Order (Existing Customer)"); 
                Console.WriteLine("[1] Manager");
                Console.WriteLine("[2] Exit");

            //get user input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0" : 
                    beerMenu.Start();
                    break;

                    case "1" :
                    managerMenu.Start();
                    break;
                
                    case "2" :
                    startMenu = false;
                    break;

                    default: 
                    Console.WriteLine("Invalid input! Try again");
                    break;
                }
            } while (startMenu);
        }

       

        

        // public void MainMenu()
        // {
        //     DrinkMenu dMenu = new DrinkMenu(_customerBL, _locationBL, _drinkBL, _inventoryBL, _orderBL, _drinkOrderBL);
        //     dMenu.Start();
        // }
    }
}