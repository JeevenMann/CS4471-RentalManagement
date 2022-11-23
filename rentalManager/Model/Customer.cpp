#include <Model.h>


Customer::Customer(string customerID) {
   customerID = customerID;
}
void Customer::addRentalItem(RentalItem rentedItem) {
    rentedItems.push_back(rentedItem);
}

void Customer::removeRentalItem(RentalItem toRemove) {
    auto it = find(rentedItems.begin(), rentedItems.end(), toRemove);
    if(it != rentedItems.end())
        rentedItems.erase(it, rentedItems.end());}

vector<RentalItem> Customer::getRentalItems() {
    return rentedItems;
}



/*
Customer Data type - Navjeeven
Name (and/or ID, customer with same name, maybe make a random number generator to make an 4 digit number)
List of rentedItem datatypes
*/