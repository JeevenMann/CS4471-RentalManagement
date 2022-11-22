#include <string>
#include <vector>

using namespace std;


#ifndef Model_H
#define Model_H

class RentalItem {
    string itemName;
    double itemCost;
    int inStock;
    vector<Customer> customerList;  
    void itemRented();
    void itemReturned();
};

class Customer {
    string customerID;
    vector<RentalItem> rentedItems;  

    Customer(string customerID);

};

#endif Model_H

