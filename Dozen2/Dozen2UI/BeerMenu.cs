using System;
using Dozen2Models;
using Dozen2BL;
using System.Collections.Generic;

namespace Dozen2UI
{
    public class BeerMenu : IMenu
    {
        Drink drink = new Drink();
        public void Start()
        {
            bool startBeerMenu = true;
            do
            {
                Console.WriteLine("What kind of Beer would you like?");
                Console.WriteLine("[0] Lager");
                Console.WriteLine("[1] Stout");
                Console.WriteLine("[2] Ale");
                Console.WriteLine("[3] Back");

                Console.WriteLine("Enter a number: ");
                string beerInput = Console.ReadLine();

                switch (beerInput)
                {
                    case "0" :
                        CreateLager();
                        break;
                
                    case "1" : 
                        CreateStout();
                        break;

                    case "2" :
                        CreateAle();
                        break;
                    case "3" :
                       // MainMenu();
                        startBeerMenu = false;
                        break;
            

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

            } while (startBeerMenu);   
            
           
        }

        public void CreateAle()
        {
            drink.DrinkName = "Ale";
            drink.ABV = 9;
            drink.Price = 8.00;
        }

        public void CreateStout()
        {
            drink.DrinkName = "Stout";
            drink.ABV = 12;
            drink.Price = 10.00;
        }

        public void CreateLager()
        {
            drink.DrinkName = "Lager";
            drink.ABV = 6;
            drink.Price = 5.00;
        }
    }
}