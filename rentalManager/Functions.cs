using System;
using System.Collections.Generic;

/*
* Functions Class
* Author: Shoumik Shill, 250935418
* Controller Class that handles the modifying of the Model (Customer lists, Rental and Rented Item lists)
*/

class Functions {

    // ------------ Attributes ------------ 

    // List data structures that contain lists of Rental Items and Customers
    List<RentalItem> itemList = new List<RentalItem>();
    List<Customer> customerList = new List<Customer>();

    // ------------ Item List Methods ------------ 

    // Return a list of the Item List
    public List<RentalItem> returnItemList() {
        return itemList;
    }

    // Add Item to the database and return true if successful
    public void addItem(string name, double cost, int stock) {
        
        RentalItem newItem = new RentalItem(name, cost, stock);
        // Add to local DB
        itemList.Add(newItem);

    }

    // Delete Item from database and return true if successful
    public void deleteItem(int itemArrayPosition) {

        // Remove from localDB
        itemList.RemoveAt(itemArrayPosition);

    }

    // ------------ Customer List Methods ------------ 

    // Return a list of the Customer List
    public List<Customer> returnCustomerList() {
        return customerList;
    }

    // Add Customer to the database and return true if successful
    public void addCustomer(string name) {

        // Generate customer UUID
        Guid customerUUID = Guid.NewGuid();

        // Add customer to localDB
        Customer newCust = new Customer(name, customerUUID.ToString());
        customerList.Add(newCust);
    }

    // Delete Customer from database and return true if successful
    public void deleteCustomer(int customerArrayPosition) {
        // Remove from localDB
        customerList.RemoveAt(customerArrayPosition);
    }

    // ------------ Rental Management Methods ------------ 

    // Adds the item to the customer's list
    public void rentItem(Customer cust, RentalItem item) {

        // Convert from Rental Item to Rented Item
        RentedItem rentedItem = new RentedItem(DateTime.Now, item);

        // Add the converted Rented Item to customer's list.
        cust.addRentalItem(rentedItem);

        // Decrease Stock
        item.itemRented();
    }

    // Return an item from customer
    public void returnItem(Customer cust, RentedItem item) {

        // Remove item from customer
        cust.removeRentalItem(item);

        // Increase stock
        foreach (var i in itemList) {
            if (i.getItemName() == item.getItemRented()) {
                i.itemReturned();
            }
        }
    }

    // ------------ Customer Payment Methods ------------ 

    // Return total amount a customer owes
    public double customerOwe(Customer cust) {
        return cust.getBalance();
    }

    // Deducts a payment of money from the amount they owe
    public void customerPay(int customerIndex, double pay) {
        this.customerList[customerIndex].payBalance(pay);
    }

}