using System;

namespace xyz_airlines
{
    public class Customer
    {
        private readonly string firstName;
        private readonly string lastName;
        private static int customerID = 1; // static so that each customer has a unique ID
        private readonly int validID;
        private readonly string phone;
        private int numberOfBookings;

        public Customer(string firstName, string lastName, string phone, int numberOfBookings)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.validID = customerID++;
            this.phone = phone;
            this.numberOfBookings = numberOfBookings;
        }
        // Getters  
        public string GetFirstName() { return firstName; }
        public string GetLastName() { return lastName; }
        public int GetCustomerID() { return validID; }
        public string GetPhone() { return phone; }
        public int GetNumberOfBookings() { return numberOfBookings; }

        public void AddBooking() { numberOfBookings++; }

        public override string ToString()
        {
            return (
                "Customer ID: " + validID +
                "\tName: " + firstName + " " + lastName +
                "\tPhone: " + phone +
                "\tNumber of Bookings: " + numberOfBookings
            );
        }
    }
}