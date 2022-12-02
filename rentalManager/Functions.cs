using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
/*
* Functions Class
* Author: Shoumik Shill, 250935418
* Class that handles the logic
*/

class Functions {

    // ------------ Attributes ------------ 

    
    List<RentalItem> itemList = new List<RentalItem>();
    List<Customer> customerList = new List<Customer>();

    /* Initialize database */
    static database db = new database();

    // ------------ Item Functions ------------ 

    // Return a list of the Item List
    public List<RentalItem> returnItemList() {

        List<string> dbItemList = db.GetItemList();
        //this line below will print out all the items in the db
        //dbItemList.ForEach(Console.WriteLine);
        return itemList;
    }

    // Add Item to the database and return true if successful
    public Boolean addItem(string name, double cost, int stock) {
        
        RentalItem newItem = new RentalItem(name, cost, stock);
        // Add to local DB
        itemList.Add(newItem);

        // Code to add to database
        db.InsertItem(name, cost, stock);
        // Placeholder
        return false;
    }

    // Delete Item from database and return true if successful
    public Boolean deleteItem(int itemArrayPosition) {
        

        // Database Code 
        string toDelete = itemList[itemArrayPosition].getItemName();
        db.DeleteItem(toDelete);
        // Remove from localDB
        itemList.RemoveAt(itemArrayPosition);

        // Placeholder
        return false;
    }

    

    // ------------ Customer Functions ------------ 

    // Return a list of the Customer List
    public List<Customer> returnCustomerList() { // Change string to Customer.cs?
        
        List<string> dbCustomerList = db.GetCustomerList();
        //this line below will print out all the items in the db
        //dbCustomerList.ForEach(Console.WriteLine);
        return customerList;
    }

    // Add Customer to the database and return true if successful
    public Boolean addCustomer(string name) {
        // Generate customer UUID
        Guid customerUUID = Guid.NewGuid();
        

        // Add customer to list
        string custID = customerUUID.ToString();
        Customer newCust = new Customer(name, custID);
        customerList.Add(newCust);

        // Database code
        db.InsertCustomer(custID, name);
        // Placeholder
        return false;
    }

    // Delete Customer from database and return true if successful
    public Boolean deleteCustomer(int customerArrayPosition) {

        //db code
        string toDelete = customerList[customerArrayPosition].getCustomerID();
        db.DeleteCustomer(toDelete);

        // Remove from localDB
        customerList.RemoveAt(customerArrayPosition);

        return false;
    }

    // ------------ Customer List Functions ------------ 

    // Adds the item to the customer's list
    public Boolean rentItem(Customer cust, RentalItem item) {

        // Convert from Rental Item to Rented Item
        RentedItem rentedItem = new RentedItem(DateTime.Now, item);

        // Add the converted Rented Item to customer's list.
        cust.addRentalItem(rentedItem);

        // Decrease Stock
        item.itemRented();

        // db code
        string name = cust.getCustomerName();
        string itemName = item.getItemName();
        double cost = item.getItemCost();
        db.RentItem(name, itemName, cost);
        return false;
    }

    // Removes item from the customer's list

    // Change param to RentedItem?
    public Boolean returnItem(Customer cust, RentedItem item) {
        
        //db code
        string name = cust.getCustomerName();
        string itemName = item.getItemName();
        db.ReturnItem(name, itemName);

        // cust list
        cust.removeRentalItem(item);

        // Increase stock
        
        foreach (var i in itemList) {
            if (i.getItemName() == item.getItemRented()) {
                i.itemReturned();
                return true;
            }
        }
   

        return false;
    }

    // ------------ Customer Payment Functions ------------ 

    // Return total amount a customer owes
    public double customerOwe(Customer cust) {

        // db code
        string name = cust.getCustomerName();
        double balance = cust.getBalance();
        db.CustomerSetBalance(name, balance);


        return cust.getBalance();
    }

    // Deducts a payment of money from the amount they owe
    public Boolean customerPay(int customerIndex, double pay) {
        
        //db code
        string name = customerList[customerIndex].getCustomerName();
        db.CustomerPayBalance(name, pay);

        //list code
        this.customerList[customerIndex].payBalance(pay);
        
        // Placeholder
        return false;
    }

}