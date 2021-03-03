namespace Dozen2Models
{
    public class Customer
    {
         private string name;
        private string phoneNumber;
        private int customerID;
        private string age;


        public static int roster = 0;

        public string Name
        {
            get{return name;}
            set{name = value;}
        }

        public string PhoneNumber
        {
            get
            {return phoneNumber;}
            set
            {phoneNumber = value;}
        }

        public string Age 
        {
               
            get{return age;}
            set{age = value;}
        }



        
    }
}


// public int ABV
//         {
//             get{return abv;}
//             set{abv = value;}
//         }