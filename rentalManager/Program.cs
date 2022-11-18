using System;

namespace rentalManager
{
    class Program
    {

        //Prints the Customer List
        private static void writeCustomerList()
        {
            Console.WriteLine("1. James\n2. Dan\n3. Mike\n");
        }

        //This is the customer menu, allows you to add and delete customers
        private static bool CustomerMenu()
        {
            //Console.Clear();
            Console.WriteLine("\n||| CUSTOMER MENU |||\n"+
            "1. Customer List\n"+
            "2. Add Customer\n"+
            "3. Delete Customer\n"+
            "4. Back");

            switch(Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    writeCustomerList();
                    return true;
                case "2":
                    Console.WriteLine("Enter Customer Name:");
                    Console.ReadLine();
                    //Add customer to database function/command
                    Console.WriteLine("Customer Added:");
                    return true;
                case "3":
                    Console.WriteLine("Choose Customer From List:");
                    writeCustomerList();
                    Console.ReadLine();
                    //delete customer function/command
                    Console.WriteLine("Customer Deleted:");
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }

        }

        //Prints the Main Menu
        public static void writeMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n||| RENTAL MANAGER MAIN MENU |||\n"+
            "Choose Item From List:\n"+
            "1. Customer Menu\n"+
            "2. Item Menu\n"+
            "3. Rental Menu\n"+
            "4. Payment Menu\n"+
            "5. Exit");
        }

        private static bool MainMenu()
        {
            bool inSideMenu=true;
            writeMainMenu();
            switch(Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    while(inSideMenu){inSideMenu=CustomerMenu();}
                    return true;
                case "2":
                    Console.Clear();
                    return true;
                case "3":
                    Console.Clear();
                    return true;
                case "4":
                    Console.Clear();
                    return true;
                case "5":
                    Console.Clear();
                    return false;
                default:
                    Console.WriteLine("Invalid Input");
                    return true;
            }
        }

        static void Main(string[] args)
        {
            bool inMenu =true;
            while(inMenu)
            {
                inMenu=MainMenu();
            }
        }
    }


}
