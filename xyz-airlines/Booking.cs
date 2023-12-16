using System;

namespace xyz_airlines
{
    public class Booking
    {
        private readonly string date;
        private static int bookingNumber = 1; // static so that each booking has a unique number
        private readonly int validNumber;
        private readonly int bookingID;
        private readonly Flight flight;
        private readonly Customer customer;

        public Booking(string date, Flight flight, Customer customer)
        {
            this.date = date;
            this.flight = flight;
            this.customer = customer;
            this.validNumber = bookingNumber++;
        }
        // Getters
        public string GetDate() { return date; }
        public int GetBookingID() { return bookingID; }
        public Flight GetFlight() { return flight; }
        public Customer GetCustomer() { return customer; }

        public override string ToString()
        {
            return (
                "Booking Number: " + validNumber +
                "\tDate: " + date +
                "\tFlight: " + flight.GetFlightNumber() +
                "\tCustomer ID: " + customer.GetCustomerID()
            );
        }
    }
}