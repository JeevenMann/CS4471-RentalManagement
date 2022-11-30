using System;
using System.Collections.Generic;
using System.Linq;

class Customer {

        string customerID;
        string customerName;
        List<RentedItem> rentedItems = new List<RentedItem>();
        double balance = 0.0;
        double amountPaid = 0.0;

    public Customer(string customerName, string customerID) {
        this.customerName = customerName;
        this.customerID = customerID;
    }


    public double getBalance()
    {
        this.generateBalance();
        return this.balance;
    }

    public void generateBalance()
    {
        var balance = 0.0;
         foreach (var i in rentedItems) {
            balance += i.calculateRent();
        }

        this.balance = balance - amountPaid;
    }

public void addRentalItem(RentedItem rentedItem) {
     rentedItems.Add(rentedItem);
}

public void removeRentalItem(RentedItem toRemove) {
    var itemToRemove = rentedItems.SingleOrDefault(x => x.getDateRented() == toRemove.getDateRented());
    if (itemToRemove != null)
        rentedItems.Remove(itemToRemove);
}

List<RentedItem> getRentalItems() {
    return rentedItems;
}

public string getCustomerID() {
    return this.customerID;
}

public string getCustomerName() {
    return this.customerName;
}

public void payBalance(double amountPaid) {
    this.amountPaid += amountPaid;
}

}