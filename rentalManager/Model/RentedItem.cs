

using System;
using System.Globalization;

class RentedItem {

    double rentCost;
    DateTime dateRented;
    string itemRented;


    public double getRentCost()
    {
        return this.rentCost;
    }

    public DateTime getDateRented()
    {
        return this.dateRented;
    }

    public string getItemRented()
    {
        return this.itemRented;
    }

    public double calculateRent() {
            var cal = new System.Globalization.GregorianCalendar();
            var weekNum = cal.GetWeekOfYear(this.dateRented, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            TimeSpan tt = this.dateRented - DateTime.Now;

            int totalWeeks = tt.Days/7;
            var biweeklyAmount = (totalWeeks % 2);

            if (biweeklyAmount > 0) {
                biweeklyAmount -= 1;
            }

            return (biweeklyAmount * rentCost) + (rentCost);

    }

    public RentedItem(DateTime dateRented, RentalItem itemRented) {
        this.dateRented = dateRented;
        this.rentCost = itemRented.getItemCost();
        this.itemRented = itemRented.getItemName();
    }



}