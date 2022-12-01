//Saif Jouda

using System;
using System.Collections.Generic;
using System.Linq;



namespace rentalManager
{
    class Program
    {

        static Functions function = new Functions();

        ///////////////////////////////////////////////////////////////////
        ////////////////////////// ITEM MENU //////////////////////////////

        //Displays the list of items
        private static void writeItemList()
        {
            List<RentalItem> rentItems = function.returnItemList();
            if(rentItems.Count==0) Console.WriteLine("List is Empty");
            for(int i=0; i< rentItems.Count; i++){
                Console.WriteLine((i+1)+". "+rentItems[i].getItemName());
            } 
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
                    String iname = Console.ReadLine();
                    double cost;
                    int stock;
                    Console.WriteLine("Enter cost of renting the item bi-weekly");
                    while(true)
                    {
                        try
                        {
                            cost = Convert.ToDouble(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please Enter a Valid Input");
                        }
                    }
                    Console.WriteLine("Enter stock amount:");
                    while(true)
                    {
                        try
                        {
                            stock = Int32.Parse(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please Enter a Valid Input");
                        }
                    }
                    //Add Item to database function/command
                    function.addItem(iname, cost, stock);
                    Console.Clear();
                    Console.WriteLine("Item Added");
                    return true;
                case "3":
                    Console.WriteLine("Choose Item to Delete:");
                    writeItemList();
                    int arrLoc;
                    while(true)
                    {
                        try
                        {
                            arrLoc = Int32.Parse(Console.ReadLine());
                            function.deleteItem(arrLoc-1);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please Enter a Valid Input");
                        }
                    }
                    //delete item function/command
                    //function.deleteItem(arrLoc-1);
                    Console.Clear();
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
            List<Customer> custList = function.returnCustomerList();
            if(custList.Count==0) Console.WriteLine("List is Empty");
            for(int i=0; i< custList.Count; i++){
                Console.WriteLine((i+1)+". "+custList[i].getCustomerName());
            } 
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
                    String cname = Console.ReadLine();
                    //Add customer to database function/command
                    function.addCustomer(cname);
                    Console.Clear();
                    Console.WriteLine("Customer Added");
                    return true;
                case "3":
                    Console.WriteLine("Choose Customer From List:");
                    writeCustomerList();
                    int arrLoc;
                    while(true)
                    {
                        try
                        {
                            arrLoc = Int32.Parse(Console.ReadLine());
                            function.deleteCustomer(arrLoc-1);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please Enter a Valid Input");
                        }
                    }
                    //delete customer function/command
                    Console.Clear();
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

        private static bool writeCustomersItems(Customer customer)
        {
            List<RentedItem> itemList = customer.getRentalItems();
            if(itemList.Count==0) 
            { 
                Console.WriteLine("List is Empty");
                return false;
            }
            else
            {
                for(int i=0; i< itemList.Count; i++){
                    Console.WriteLine((i+1)+". "+itemList[i].getItemRented());
                }
                return true; 
            }
        }

        private static bool RentalMenu()
        {
            Console.WriteLine("\n||| RENTAL MENU |||\n"+
            "1. Rent Item\n"+
            "2. Return Item\n"+
            "3. Back");

            switch(Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Choose Customer:");
                    writeCustomerList();
                    Customer cusToRent;
                    while(true)
                    {
                        try
                        {
                            int cusLoc = Int32.Parse(Console.ReadLine());
                            cusToRent=function.returnCustomerList()[cusLoc-1];
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please Enter a Valid Input");
                        }
                    }
                    Console.WriteLine("Choose Item To Rent:");
                    writeItemList();
                    RentalItem itemToRent;
                    while(true)
                    {
                        try
                        {
                            int iLoc = Int32.Parse(Console.ReadLine());
                            itemToRent=function.returnItemList()[iLoc-1];
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please Enter a Valid Input");
                        }
                    }
                    function.rentItem(cusToRent,itemToRent);
                    //ADD item to customer's item list
                    Console.WriteLine("Item Added to Customer's Item List");
                    return true;
                case "2":
                    Console.WriteLine("Choose Customer:");
                    writeCustomerList();
                    Customer cusToRentR;
                    while(true)
                    {
                        try
                        {
                            int cusLoc = Int32.Parse(Console.ReadLine());
                            cusToRentR=function.returnCustomerList()[cusLoc-1];
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please Enter a Valid Input");
                        }
                    }
                    Console.WriteLine("Choose Item To Remove:");
                    //LIST OF CUSTOMER"S ITEMS
                    if(writeCustomersItems(cusToRentR))
                    {
                        RentedItem itemToRentR;
                        while(true)
                        {
                            try
                            {
                                int iLoc = Int32.Parse(Console.ReadLine());
                                itemToRentR=cusToRentR.getRentalItems()[iLoc-1];
                                function.returnItem(cusToRentR,itemToRentR);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Please Enter a Valid Input");
                            }
                        }

                        Console.WriteLine("Item Removed to Customer's Item List");
                    }
                    else
                    {
                        Console.WriteLine("Returning to Rental Menu");
                    }
                    //ADD item to customer's item list
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
            "1. View Customer's Item List and Amount Owed\n"+
            "2. Make Customer Payment\n"+
            "3. Back");

            switch(Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Choose Customer:");
                    writeCustomerList();
                    Customer cusToShow;
                    while(true)
                    {
                        try
                        {
                            int cusLoc = Int32.Parse(Console.ReadLine());
                            cusToShow=function.returnCustomerList()[cusLoc-1];
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Please Enter a Valid Input");
                        }
                    }
                    //Print Customer's List with Amount Owing
                    Console.WriteLine("Amount Owed: "+ cusToShow.getBalance());
                    writeCustomersItems(cusToShow);
                    return true;
                case "2":
                    Console.WriteLine("Choose Customer:");
                    writeCustomerList();
                    Console.ReadLine();
                    Console.WriteLine("Enter Amount Paid:");
                    Console.ReadLine();
                    Console.WriteLine("Amount Deducted from Amount Owed");
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
