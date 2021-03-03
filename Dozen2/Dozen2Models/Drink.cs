using System;

namespace Dozen2Models
{
    public class Drink
    {
        private string drinkName; //private backing field for DrinkName
        private int abv; //private backing field for ABV
        private double price; //private backing field for Price

        public string DrinkName
        {
            get{return drinkName;}
            set{drinkName = value;}
        }

        public int ABV
        {
            get{return abv;}
            set{abv = value;}
        }

        public double Price
        {
            get{return price;}
            set{price = value;}
        }



    }
}
