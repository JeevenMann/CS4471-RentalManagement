using System;

namespace rentalManager
{
    class Program
    {

        ///////////////////////////////////////////////////////////////////
        ////////////////////////// ITEM MENU //////////////////////////////

        //Item List writer
        private static void writeItemList()
        {
            Console.WriteLine("1. Dumbell\n2. Car\n3. Guitar\n");
        }

        //Item Menu
        private static bool ItemMenu()
        {
            Console.WriteLine("\n||| ITEM MENU |||\n"+
            "1. Item List\n"+
            "2. Add Item\n"+
            "3. Delete Item\n"+
            "4. Back");

            switch(Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    writeItemList();
                    return true;
                case "2":
                    Console.WriteLine("Enter Item Name:");
                    Console.ReadLine();
                    Console.WriteLine("Enter cost of renting the item bi-weekly");
                    Console.ReadLine();
                    Console.WriteLine("Enter stock amount:");
                    Console.ReadLine();
                    //Add Item to database function/command
                    Console.WriteLine("Item Added");
                    return true;
                case "3":
                    Console.WriteLine("Choose Item From List:");
                    writeItemList();
                    Console.ReadLine();
                    //delete customer function/command
                    Console.WriteLine("Item Deleted");
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        ///////////////////////////////////////////////////////////////////
        ////////////////////////// CUSTOMER MENU //////////////////////////

        //Prints the Customer List//
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
                    Console.WriteLine("Customer Added");
                    return true;
                case "3":
                    Console.WriteLine("Choose Customer From List:");
                    writeCustomerList();
                    Console.ReadLine();
                    //delete customer function/command
                    Console.WriteLine("Customer Deleted");
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }

        }


        ///////////////////////////////////////////////////////////////////
        ////////////////////////// RENTAL MENU //////////////////////////////

        private static bool RentalMenu()
        {
            Console.WriteLine("\n||| RENTAL MENU |||\n"+
            "1. Rent Item\n"+
            "2. Remove Item Being Rented\n"+
            "3. Back");

            switch(Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Choose Customer:");
                    writeCustomerList();
                    Console.ReadLine();
                    Console.WriteLine("Choose Item To Rent:");
                    writeItemList();
                    Console.ReadLine();
                    //ADD item to customer's item list
                    Console.WriteLine("Item Added to Customer's Item List");
                    return true;
                case "2":
                    Console.WriteLine("Choose Customer:");
                    writeCustomerList();
                    Console.ReadLine();
                    Console.WriteLine("Choose Item To Remove:");
                    //LIST OF CUSTOMER"S ITEMS
                    Console.ReadLine();
                    //ADD item to customer's item list
                    Console.WriteLine("Item Added to Customer's Item List");
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }

        }

        /////////////////////////////////////////////////////////////////////
        ////////////////////////// PAYMENT MENU //////////////////////////////

        private static bool PaymentMenu()
        {
            Console.WriteLine("\n||| PAYMENT MENU |||\n"+
            "1. View Customer's Item List\n"+
            "2. Make Customer Payment\n"+
            "3. Back");

            switch(Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Choose Customer:");
                    writeCustomerList();
                    Console.ReadLine();
                    //Print Customer's List with Amount Owing
                    return true;
                case "2":
                    Console.WriteLine("Choose Customer:");
                    writeCustomerList();
                    Console.ReadLine();
                    Console.WriteLine("Enter Amount Paid:");
                    Console.ReadLine();
                    //Payment Function
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }

        }

        ///////////////////////////////////////////////////////////////////
        ////////////////////////// MAIN MENU /////////////////////////////

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
                    while(inSideMenu){inSideMenu=ItemMenu();}
                    return true;
                case "3":
                    Console.Clear();
                    while(inSideMenu){inSideMenu=RentalMenu();}
                    return true;
                case "4":
                    Console.Clear();
                    while(inSideMenu){inSideMenu=PaymentMenu();}
                    return true;
                case "5":
                    Console.Clear();
                    return false;
                default:
                    Console.WriteLine("Invalid Input");
                    return true;
            }
        }


        ///////////////////////////////////////////////////////////////////////
        ////////////////////////// MAIN FUNCTION //////////////////////////////
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
