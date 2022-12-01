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

    // ------------ Item Functions ------------ 

    // Return a list of the Item List
    public List<RentalItem> returnItemList() {
        return itemList;
    }

    // Add Item to the database and return true if successful
    public Boolean addItem(string name, double cost, int stock) {
        
        RentalItem newItem = new RentalItem(name, cost, stock);
        // Add to local DB
        itemList.Add(newItem);

        // Code to add to database

        // Placeholder
        return false;
    }

    // Delete Item from database and return true if successful
    public Boolean deleteItem(int itemArrayPosition) {
        // Remove from localDB
        itemList.RemoveAt(itemArrayPosition);

        // Code to delete item from database

        // Placeholder
        return false;
    }

    

    // ------------ Customer Functions ------------ 

    // Return a list of the Customer List
    public List<Customer> returnCustomerList() { // Change string to Customer.cs?
        return customerList;
    }

    // Add Customer to the database and return true if successful
    public Boolean addCustomer(string name) {
        // Generate customer UUID
        Guid customerUUID = Guid.NewGuid();
        

        // Add customer to localDB
        Customer newCust = new Customer(name, customerUUID.ToString());
        customerList.Add(newCust);

        // Code to add customer to Database

        // Placeholder
        return false;
    }

    // Delete Customer from database and return true if successful
    public Boolean deleteCustomer(int customerArrayPosition) {

        // Remove from localDB
        customerList.RemoveAt(customerArrayPosition);

        // Code to delete Customer from database

        // Placeholder
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

        // Placeholder
        return false;
    }

    // Removes item from the customer's list

    // Change param to RentedItem?
    public Boolean returnItem(Customer cust, RentedItem item) {

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

        // Placeholder
        return cust.getBalance();
    }

    // Deducts a payment of money from the amount they owe
    public Boolean customerPay(int customerIndex, double pay) {

        
        this.customerList[customerIndex].payBalance(pay);
        
        // Placeholder
        return false;
    }

}