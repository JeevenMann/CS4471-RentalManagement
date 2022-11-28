#include <string>
#include <vector>
#include <algorithm>
#include <map>

using namespace std;


#ifndef Model_H
#define Model_H

class RentalItem {
    private:
        string itemName;
        double itemCost;
        int inStock;
        vector<Customer> customerList;  
    public:
        void itemRented();
        void itemReturned();
        void changeItemCost(double newCost);
        RentalItem(string itemName, double itemCost, int inStock);
        void addCustomer(Customer newCustomer);
        void removeCustomer(Customer toRemove);
        vector<Customer> getCustomers();
        int getItemsInStock();
        double getItemCost();
        string getItemName();
        void setItemCost(double newCost);
        void setItemsInStock(int newStock);
    };

class Customer {
    private:
        string customerID;
        map<string,RentalItem> rentedItems;  
        double balance;
    public:
        Customer(string customerID);
        void removeRentalItem(RentalItem toRemove);
        void addRentalItem(string todayDate, RentalItem rentedItem);
        map<string, RentalItem> getRentalItems();
};

#endif Model_H

