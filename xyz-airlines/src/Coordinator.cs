using System;

namespace xyz_airlines
{
    public class Coordinator
    {
        private readonly FlightList flights;
        private readonly BookingList bookings;
        private readonly CustomerList customers;

        public Coordinator(FlightList flightList, BookingList bookingList, CustomerList customerList)
        {
            this.flights = flightList;
            this.bookings = bookingList;
            this.customers = customerList;
        }

        public bool AddFlight(int flightNumber, string origin, string destination, int capacity, int numberOfPassengers)
        {
            // Check if a flight with the same flight number already exists
            if (this.flights.Exists(flightNumber))
            {
                return false; // Flight already exists
            }

            Flight flight = new Flight(flightNumber, origin, destination, capacity, numberOfPassengers);
            return this.flights.Add(flight);
        }

        public string ViewFlights()
        {
            string result = this.flights.PrintAll();
            // Check if there are any flights
            if (result.Length > 0)
            {
                return result;
            }
            return " No Flights Yet...";
        }

        public string ViewSpecificFlight(int flightNumber)
        {
            Flight flight = this.flights.Search(flightNumber);
            // Check if the flight exists
            if (flight != null)
            {
                return flight.ToString() + "\t" + flight.GetPassengers();
            }
            return " Flight Not Found...";
        }

        public bool DeleteFlight(int flightNumber)
        {
            Flight flight = this.flights.Search(flightNumber);
            if (flight != null && flight.GetNumberOfPassengers() == 0)
            {
                return this.flights.Remove(flight);
            }
            return false;
        }

        public bool AddCustomer(string firstName, string lastName, string phone)
        {
            // Check if a customer with the same first name, last name, and phone already exists
            if (this.customers.Exists(firstName, lastName, phone))
            {
                return false; // Customer already exists
            }

            Customer customer = new Customer(firstName, lastName, phone, 0);
            return this.customers.Add(customer);
        }

        public string ViewCustomers()
        {
            string result = this.customers.PrintAll();
            // Check if there are any customers
            if (result.Length > 0)
            {
                return result;
            }
            return " No Customers Yet...";
        }

        public bool DeleteCustomer(int customerID)
        {
            Customer customer = this.customers.Search(customerID);
            // Check if the customer exists and has no bookings
            if (customer != null && customer.GetNumberOfBookings() == 0)
            {
                return this.customers.Remove(customer);
            }
            return false;
        }

        public bool MakeBooking(string date, int flightNumber, int GetCustomerID)
        {
            Flight flight = this.flights.Search(flightNumber);
            Customer customer = this.customers.Search(GetCustomerID);
            Booking booking = new Booking(date, flight, customer);
            // Check if the flight and customer exist and the flight has room for another passenger
            if (flight != null && customer != null && (flight.GetNumberOfPassengers() < flight.GetCapacity()))
            {
                customer.AddBooking();
                flight.AddPassenger(customer);
                return this.bookings.Add(booking);
            }
            return false;
        }

        public string ViewBookings()
        {
            string result = this.bookings.PrintAll();
            // Check if there are any bookings
            if (result.Length > 0)
            {
                return result;
            }
            return " No Bookings Yet...";
        }
    }
}