using System;
using System.Collections.Generic;
using System.Linq;

class Customer {

        string customerID;
        List<RentedItem> rentedItems = new List<RentedItem>();

    double balance = 0.0;

    public double getBalance()
    {
        return this.balance;
    }

    public void generateBalance()
    {
        var balance = 0.0;
         foreach (var i in rentedItems) {
            balance += i.calculateRent();
        }

        this.balance = balance;
    }

    public Customer(string customerID) {
   this.customerID = customerID;
}
public void addRentalItem(RentedItem rentedItem) {
     rentedItems.Add(rentedItem);
}

public void removeRentalItem(RentedItem toRemove) {
    var itemToRemove = rentedItems.SingleOrDefault(x => x.getDateRented() == toRemove.getDateRented());
    if (itemToRemove != null)
        rentedItems.Remove(itemToRemove);
}

public List<RentedItem> getRentalItems() {
    return rentedItems;
}

public string getCustomerID() {
    return this.customerID;
}

}