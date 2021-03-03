using System;
using Dozen2Models;
using Dozen2BL;
using System.Collections.Generic;
using Dozen2UI;

namespace Dozen2UI
{
    public class CustomerMenu : IMenu
    {
           private ICustomerBL _customerBL;
           private ILocationBL _locationBL;
           private IDrinkBL _drinkBL;
           private IOrderBL _orderBL;
           DrinkMenu drinkMenu = new DrinkMenu();
           public CustomerMenu(IDrinkBL drinkBL, ICustomerBL customerBL, ILocationBL locationBL, IOrderBL orderBL)
           {
               _customerBL = customerBL;
              _drinkBL = drinkBL;
              _locationBL = locationBL;
              _orderBL = orderBL;
           }
             

        public void Start()
        { 
            bool run = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to the Main Menu!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] - Search Existing Customers");
                Console.WriteLine("[1] - New Customer");
                Console.WriteLine("[2] - Place an Order (Existing Customers"); 
                Console.WriteLine("[3] - Select a Store Location");
                Console.WriteLine("[4] - Back");
                //Console.WriteLine("[5] - Main Menu");
                Console.WriteLine("----------------------------------------");
                string selection = Console.ReadLine();

                switch(selection)
                {
                    case "0" :
                        GetCustomers();
                        break;
                    case "1" :
                        CreateCustomer();
                        break;
                    case "2" :
                        drinkMenu.Start();
                        break;
                    case "3" :
                        GetStores();
                        break;
                    case "4" :
                       
                        run = false;
                        break;

                   // case "5" :
                      //  drinkMenu.MainMenu();
                     //   break;
                    default :
                        Console.WriteLine("Invalid! Try again");
                        break;
                } 

            } while (run);
        }

        public Customer SearchCustomer()
        {
            Console.WriteLine("Enter customer's FirstName LastName: ");
            string name = Console.ReadLine();
            int check = 0;
            foreach (var element in _customerBL.GetCustomers())
            {
                if (element.Name == name)
                {
                    return element;
                }

            }
            if (check == 0)
            {
                Console.WriteLine("Matching customer not found");
            }

            Customer nullCustomer = null;
            return nullCustomer;
        }

        public void GetOrders()
        {
            foreach (var element in _orderBL.GetOrders() )
            {
                Console.WriteLine(element.OrderID);
            }
        }
        public void GetPastOrders()
        {
            Customer customer = FindCustomer();
        }

        public Customer FindCustomer()
        {
            Console.WriteLine("Enter customer's full name [FirstName LastName]: ");
            string name = Console.ReadLine();
            int exists = 0;
            foreach (var element in _customerBL.GetCustomers())
            {
                if(element.Name == name)
                {
                    return element;
                }
            }
        
            if (exists == 0)
            {
                Console.WriteLine("This customer doesn't exist.");
            }
            Customer nullCustomer = null;
            return nullCustomer;
        }

        public void CreateCustomer()
        {
            Customer customer = new Customer();  
            Console.WriteLine("Enter your age");
            customer.Age =Console.ReadLine()  ; 
            
            
            if( int.Parse( customer.Age ) < 21 )
            {
                Console.WriteLine("You aren't old enough!");
                return;
            }
            else
            {
                Console.WriteLine("Cheers! Welcome to the Dozen family!");
                Console.WriteLine("_____________________________________");
                Console.WriteLine("Enter your full name [FirstName LastName]");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Enter your phone number");
                customer.PhoneNumber = Console.ReadLine();

                _customerBL.AddCustomer(customer);
            }
            
        }

        public void GetCustomers()
        {
            Console.WriteLine("Enter an existing customer's name");
            string name = Console.ReadLine();
            int counter = 0; //counter checks if customer can be found in db
                //if no matching name, returns an error message

            foreach (var element in _customerBL.GetCustomers())
            {
                if (element.Name.Equals(name) ) 
                {
                    Console.WriteLine(element.ToString());
                    counter++;
                }
            }
                
            if (counter == 0)
            {
                Console.WriteLine("No customer found with those credentials.");
            } 
        }


            public void GetStores()
            {
                foreach (var element in _locationBL.GetLocations())
                {
                    Console.WriteLine(element.ToString());
                }
                Console.WriteLine("Enter a Store Code: ");
                int storeCode = int.Parse( Console.ReadLine() );
                Location specifiedLocation = _locationBL.GetSpecifiedLocation(storeCode);
                if(specifiedLocation == null)
                {
                    Console.WriteLine("Invalid code.");
                }
                else
                {
                    Console.WriteLine($"{specifiedLocation.LocationName} Inventory: ");
                    foreach (Drink element in _drinkBL.GetDrinksByLocation(storeCode))
                    {
                        Console.WriteLine(element.DrinkName.ToString());
                        //not sure if this will work ^^^^^
                    }

                    Order newOrder = new Order();
                    bool shop = true;
                    List <Drink> drinkCart = new List<Drink>();
                    List<int> quantityInCart = new List<int>();
                    double total = 0.0;
                    do
                    {
                        Console.WriteLine("Select Drink to add to your order");
                        Console.WriteLine("Type 'Submit' when you're finished.");
                        Console.WriteLine("If you wish to cancel, type 'Cancel'");
                        Console.WriteLine("Selection: ");

                        string selection = Console.ReadLine();

                        if (selection == "cancel" || selection == "Cancel")
                        {
                            shop = false;
                        }
                        else if (selection == "submit" || selection == "Submit")
                        {
                            newOrder.Total = total;
                            newOrder.Location = specifiedLocation;
                            Customer customerOrder = FindCustomer();

                            if(customerOrder == null)
                            {
                                Console.WriteLine("cannot find customer");
                            }
                            else
                            {
                                newOrder.Customer = customerOrder;
                            }

                            _orderBL.AddOrder(newOrder);
                        }

                    }while (shop);
                }
            }
    }

}  
 
//add customer  written
//search customer  written
//place order   written
//view order history by location 
//view order history by customer
//view inventory by location
//

