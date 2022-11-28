#include <Model.h>
#include <algorithm>




RentalItem::RentalItem(string itemName, double itemCost, int inStock) {
    itemName = itemName;
    itemCost = itemCost;
    inStock = inStock;
}

 void RentalItem::itemRented() {
    inStock -= 1;
}

 void RentalItem::itemReturned() {
    inStock += 1;
}



void RentalItem::addCustomer(Customer newCustomer) {
    customerList.push_back(newCustomer);
}

void RentalItem::removeCustomer(Customer toRemove) {
    auto it = find(customerList.begin(), customerList.end(), toRemove);
    if(it != customerList.end())
        customerList.erase(it, customerList.end());
}

vector<Customer> RentalItem::getCustomers() {
    return customerList;
}

int RentalItem::getItemsInStock() {
    return inStock;
}

double RentalItem::getItemCost() {
    return itemCost;
}

string RentalItem::getItemName() {
    return itemName;
}

void RentalItem::setItemCost(double newCost) {
    itemCost = newCost;
}

void RentalItem::setItemsInStock(int newStock) {
    inStock = newStock;
}


 /*void RentalItem::createRentalAgreement(Customer withCustomer, RentalItem rentalItem) {
    withCustomer.addRentalItem(rentalItem);
    rentalItem.addCustomer(withCustomer);
    rentalItem.itemRented();
}*/