#include <Model.h>


class RentalItem {

RentalItem::RentalItem(string itemName, double itemCost, int inStock) {
    itemName = itemName;
    itemCost = itemCost;
    inStock = inStock;
}

 void itemRented() {
    inStock -= 1;
}

 void itemReturned() {
    inStock += 1;
}

};

/*
Rentalitem Data type - Navjeeven
Item Name
Rent Cost
Renting Rules?
Left in stock (number not rented)
List of Customers who are renting that item
*/