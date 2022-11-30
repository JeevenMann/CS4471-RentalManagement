using System;
using System.Collections.Generic;
using System.Linq;

class RentalItem {

        string itemName;
        double itemCost;
        int inStock;
        List<Customer> customerList = new List<Customer>();  

public RentalItem(string itemName, double itemCost, int inStock) {
    this.itemName = itemName;
    this.itemCost = itemCost;
    this.inStock = inStock;
}

 public void itemRented() {
    inStock -= 1;
}

 public void itemReturned() {
    this.inStock = this.inStock + 1;
}

public void addCustomer(Customer newCustomer) {
    customerList.Add(newCustomer);
}

public void removeCustomer(Customer toRemove) {
    var customerToRemove = customerList.SingleOrDefault(x => x.getCustomerID() == toRemove.getCustomerID());
    if (customerToRemove != null) 
        customerList.Remove(customerToRemove);
}

public List<Customer> getCustomers() {
    return this.customerList;
}

public int getItemsInStock() {
    return this.inStock;
}

public double getItemCost() {
    return this.itemCost;
}

public string getItemName() {
    return this.itemName;
}

public void setItemCost(double newCost) {
    this.itemCost = newCost;
}

public void setItemsInStock(int newStock) {
    this.inStock = newStock;
}

public void createRentalAgreement(Customer withCustomer, RentalItem rentalItem) {
    RentedItem rentedItem = new RentedItem(DateTime.Now, rentalItem);
    withCustomer.addRentalItem(rentedItem);
    rentalItem.addCustomer(withCustomer);
    rentalItem.itemRented();
}

}

 