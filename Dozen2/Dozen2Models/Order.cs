namespace Dozen2Models
{
    public class Order
    {
        private int orderID;
        private double total;
        private Customer customer;
        private Location location;

        //list of order items aka collection

        public Customer Customer 
        {
            get 
            {
                return customer;
            }
            set
            {
                customer = value;
            
            }
        }
        public Location Location 
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
        public double Total 
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        public int OrderID 
        {
            get{return orderID;}
            set{orderID = value;}
        }

        public override string ToString()
        {
            return $"Order ID: {this.OrderID} \n\tTotal: ${this.Total}";
        }

    }
}