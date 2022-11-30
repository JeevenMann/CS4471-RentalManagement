using System;
using System.Collections.Generic;
using System.Linq;

/*
* Functions Class
* Author: Shoumik Shill, 250935418
* Class that handles the logic
*/

class Functions {

    // ------------ Attributes ------------ 

    int copyCustomerMoney;

    // ------------ Item Functions ------------ 

    // Return a list of the Item List
    List<string> returnItemList() { // Change string to RentalItem.cs??

        // Placeholder
        return null;
    }

    // Add Item to the database and return true if successful
    Boolean addItem(string name, double cost, int stock) {
        
        RentalItem newItem = new RentalItem(name, cost, stock);

        // Code to add to database

        // Placeholder
        return false;
    }

    // Delete Item from database and return true if successful
    Boolean deleteItem(int itemArrayPosition) {

        // Code to delete item from database

        // Placeholder
        return false;
    }

    

    // ------------ Customer Functions ------------ 

    // Return a list of the Customer List
    List<string> returnCustomerList() { // Change string to Customer.cs?

        // Placeholder
        return null;
    }

    // Add Customer to the database and return true if successful
    Boolean addCustomer(string name) {
        
        // Customer needs a constructor I think
        // Customer newCust = new Customer();

        // Placeholder
        return false;
    }

    // Delete Customer from database and return true if successful
    Boolean deleteCustomer(int customerArrayPosition) {

        // Code to delete Customer from database

        // Placeholder
        return false;
    }

    // ------------ Customer List Functions ------------ 

    // Adds the item to the customer's list
    Boolean rentItem(Customer cust, RentalItem item) {

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
    Boolean returnItem(Customer cust, RentalItem item) {
    // Boolean returnItem(Customer cust, RentedItem item) {

        // cust.removeRentalItem(item);

        // Increase stock
        item.itemReturned();

        // Placeholder
        return false;
    }

    // ------------ Customer Payment Functions ------------ 

    // Return total amount a customer owes
    double customerOwe(Customer cust) {

        // Placeholder
        return cust.getBalance();
    }

    // Deducts a payment of money from the amount they owe
    Boolean customerPay(Customer cust, float pay) {

        // need some deduct balance attribute in Customer probably

        // Placeholder
        return false;
    }

}