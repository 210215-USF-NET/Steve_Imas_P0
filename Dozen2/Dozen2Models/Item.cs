namespace Dozen2Models
{
    /// <summary>
    /// this data structure models a drink and its quantity.
    /// the quantity was separated from the drink as it could vary from orders and locations
    /// this is a wrapper class
    /// </summary>
    public class Item
    {
        public Drink Drink {get;set;}
        public int Quantity {get;set;}
    }
}